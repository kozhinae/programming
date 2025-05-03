//go:build !solution

package bank

import (
	"context"
	"fmt"
	"github.com/jackc/pgx/v5"
	"github.com/jackc/pgx/v5/pgxpool"
)

type ledgerImpl struct {
	db *pgxpool.Pool
}

func New(ctx context.Context, dsn string) (Ledger, error) {
	db, err := pgxpool.New(ctx, dsn)
	if err != nil {
		return nil, fmt.Errorf("failed to connect to the database: %w", err)
	}

	createTableQuery := `
	CREATE TABLE IF NOT EXISTS accounts (
		id TEXT PRIMARY KEY,
		balance BIGINT NOT NULL
	)`
	_, err = db.Exec(ctx, createTableQuery)
	if err != nil {
		db.Close()
		return nil, fmt.Errorf("failed to create table: %w", err)
	}

	return &ledgerImpl{db: db}, nil
}

func (l *ledgerImpl) CreateAccount(ctx context.Context, id ID) error {
	query := `INSERT INTO accounts (id, balance) VALUES ($1, 0)`
	_, err := l.db.Exec(ctx, query, id)
	if err != nil {
		return fmt.Errorf("failed to create account: %w", err)
	}
	return nil
}

func (l *ledgerImpl) GetBalance(ctx context.Context, id ID) (Money, error) {
	query := `SELECT balance FROM accounts WHERE id = $1`
	var balance Money
	err := l.db.QueryRow(ctx, query, id).Scan(&balance)
	if err != nil {
		if err == pgx.ErrNoRows {
			return 0, fmt.Errorf("account not found: %w", err)
		}
		return 0, fmt.Errorf("failed to get balance: %w", err)
	}
	return balance, nil
}

func (l *ledgerImpl) Deposit(ctx context.Context, id ID, amount Money) error {
	if amount < 0 {
		return ErrNegativeAmount
	}

	query := `UPDATE accounts SET balance = balance + $1 WHERE id = $2`
	cmdTag, err := l.db.Exec(ctx, query, amount, id)
	if err != nil {
		return fmt.Errorf("failed to deposit: %w", err)
	}
	if cmdTag.RowsAffected() == 0 {
		return fmt.Errorf("account not found")
	}
	return nil
}

func (l *ledgerImpl) Withdraw(ctx context.Context, id ID, amount Money) error {
	if amount < 0 {
		return ErrNegativeAmount
	}

	tx, err := l.db.Begin(ctx)
	if err != nil {
		return fmt.Errorf("failed to start transaction: %w", err)
	}
	defer func() {
		if rollbackErr := tx.Rollback(ctx); rollbackErr != nil && err == nil {
			err = fmt.Errorf("failed to rollback transaction: %w", rollbackErr)
		}
	}()

	query := `SELECT balance FROM accounts WHERE id = $1 FOR UPDATE`
	var balance Money
	err = tx.QueryRow(ctx, query, id).Scan(&balance)
	if err != nil {
		if err == pgx.ErrNoRows {
			return fmt.Errorf("account not found: %w", err)
		}
		return fmt.Errorf("failed to get balance: %w", err)
	}

	if balance < amount {
		return ErrNoMoney
	}

	updateQuery := `UPDATE accounts SET balance = balance - $1 WHERE id = $2`
	_, err = tx.Exec(ctx, updateQuery, amount, id)
	if err != nil {
		return fmt.Errorf("failed to withdraw: %w", err)
	}

	if err := tx.Commit(ctx); err != nil {
		return fmt.Errorf("failed to commit transaction: %w", err)
	}

	return nil
}

func (l *ledgerImpl) Transfer(ctx context.Context, from, to ID, amount Money) error {
	if amount < 0 {
		return ErrNegativeAmount
	}

	var first, second ID
	if from < to {
		first, second = from, to
	} else {
		first, second = to, from
	}

	tx, err := l.db.Begin(ctx)
	if err != nil {
		return fmt.Errorf("failed to start transaction: %w", err)
	}
	defer func() {
		if rollbackErr := tx.Rollback(ctx); rollbackErr != nil && err == nil {
			err = fmt.Errorf("failed to rollback transaction: %w", rollbackErr)
		}
	}()

	query := `SELECT balance FROM accounts WHERE id = $1 FOR UPDATE`
	var firstBalance, secondBalance Money

	err = tx.QueryRow(ctx, query, first).Scan(&firstBalance)
	if err != nil {
		if err == pgx.ErrNoRows {
			return fmt.Errorf("account %s not found: %w", first, err)
		}
		return fmt.Errorf("failed to get balance for %s: %w", first, err)
	}

	err = tx.QueryRow(ctx, query, second).Scan(&secondBalance)
	if err != nil {
		if err == pgx.ErrNoRows {
			return fmt.Errorf("account %s not found: %w", second, err)
		}
		return fmt.Errorf("failed to get balance for %s: %w", second, err)
	}

	if from < to {
		if firstBalance < amount {
			return ErrNoMoney
		}

		withdrawQuery := `UPDATE accounts SET balance = balance - $1 WHERE id = $2`
		_, err = tx.Exec(ctx, withdrawQuery, amount, from)
		if err != nil {
			return fmt.Errorf("failed to withdraw from source account: %w", err)
		}

		depositQuery := `UPDATE accounts SET balance = balance + $1 WHERE id = $2`
		_, err = tx.Exec(ctx, depositQuery, amount, to)
		if err != nil {
			return fmt.Errorf("failed to deposit to destination account: %w", err)
		}
	} else {
		if secondBalance < amount {
			return ErrNoMoney
		}

		withdrawQuery := `UPDATE accounts SET balance = balance - $1 WHERE id = $2`
		_, err = tx.Exec(ctx, withdrawQuery, amount, from)
		if err != nil {
			return fmt.Errorf("failed to withdraw from source account: %w", err)
		}

		depositQuery := `UPDATE accounts SET balance = balance + $1 WHERE id = $2`
		_, err = tx.Exec(ctx, depositQuery, amount, to)
		if err != nil {
			return fmt.Errorf("failed to deposit to destination account: %w", err)
		}
	}

	if err := tx.Commit(ctx); err != nil {
		return fmt.Errorf("failed to commit transaction: %w", err)
	}

	return nil
}

func (l *ledgerImpl) Close() error {
	l.db.Close()
	return nil
}
