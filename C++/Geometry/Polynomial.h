#ifndef CLASS_POLYNOMIAL_H
#define CLASS_POLYNOMIAL_H
#include <iostream>
#include <vector>
#include <map>

using namespace std;

class Polynomial {
public:
    map<int, double> monomials;
    int degree;
public:
    Polynomial();
    void optimizePol();
    explicit Polynomial(const map<int, double>&);
    explicit Polynomial(const vector<double>&);
    Polynomial(const Polynomial&);
    Polynomial& operator=(const Polynomial&);
    bool operator==(const Polynomial&);
    bool operator!=(const Polynomial&);
    Polynomial operator+() const;
    Polynomial operator-() const;
    Polynomial operator+(const Polynomial&) const;
    Polynomial operator-(const Polynomial&) const;
    Polynomial& operator+=(const Polynomial&);
    Polynomial& operator-=(const Polynomial&);
    Polynomial operator*(double) const;
    Polynomial operator*(const Polynomial&) const;
    Polynomial& operator*=(const Polynomial&);
    Polynomial operator/(double) const;
    Polynomial& operator*=(double);
    Polynomial& operator/=(double);
    double& operator[](int i);
    double operator[](int i) const;
    friend Polynomial operator*(double, const Polynomial&);
    friend ostream& operator<<(ostream&, Polynomial);
    friend istream& operator>>(istream&, Polynomial&);
    ~Polynomial(){}
};
#endif //CLASS_POLYNOMIAL_H
