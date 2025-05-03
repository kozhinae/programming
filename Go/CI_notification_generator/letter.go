//go:build !solution

package ci

import (
	"bytes"
	_ "embed"
	"strings"
	"text/template"
)

//go:embed letter.tmpl

var letterTemplate string

func splitLines(log string) []string {
	return strings.Split(log, "\n")
}

func sub(a, b int) int {
	return a - b
}

func MakeLetter(n *Notification) (string, error) {
	tmpl, err := template.New("letter").Funcs(template.FuncMap{
		"splitLines": splitLines,
		"sub":        sub,
	}).Parse(strings.ReplaceAll(letterTemplate, "\r", ""))
	if err != nil {
		return "", err
	}

	var result bytes.Buffer
	err = tmpl.Execute(&result, n)
	if err != nil {
		return "", err
	}
	output := strings.TrimRight(result.String(), "\n")

	if n.Pipeline.Status == "failed" {
		return output + "\n", nil
	}

	return output, nil
}
