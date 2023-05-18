#include "polynomial.h"
#include <sstream>

const double EPS = 0.001;

Polynomial :: Polynomial(): monomials(), degree(0) {
    monomials[0] = 0;
}

Polynomial:: Polynomial(const map<int, double>& _m): monomials(_m), degree (_m.size() - 1) {
    optimizePol();
}

void Polynomial :: optimizePol() {
    map<int, double> new_monom;
    int newDegree = 0;
    for(auto it: monomials) {
        if (it.second) {
            new_monom[it.first] = it.second;
            newDegree = max(newDegree, it.first);
        }
    }
    degree = newDegree;
    monomials = new_monom;
}

Polynomial:: Polynomial(const vector<double>& p): monomials(), degree(p.size() - 1) {
    for(int i = 0; i < p.size(); ++i) {
        if (p[i]) {
            monomials[i] = p[i];
        }
    }
    optimizePol();
}

Polynomial:: Polynomial(const Polynomial &p): monomials(p.monomials), degree(p.degree) {}

Polynomial& Polynomial:: operator=(const Polynomial &p) {
    monomials = p.monomials;
    degree = p.degree;
    return *this;
}

bool Polynomial:: operator==(const Polynomial &p) {
    if (p.degree != degree) {
        cout << degree << ' ' << p.degree << endl;
        return false;
    }
    for (auto it: monomials) {
        if (p.monomials.count(it.first) == 0) {
            return false;
        }
        if (abs(p.monomials.at(it.first) - it.second) > EPS) {
            return false;
        }
    }
    return true;
}

bool Polynomial:: operator!=(const Polynomial &p) {
    return !((*this) == p);
}

Polynomial Polynomial:: operator+() const{
    return *this;
}

Polynomial Polynomial:: operator-() const{
    map<int, double> res_monom(monomials);
    for(auto &it: res_monom) {
        it.second = -it.second;
    }
    return Polynomial(res_monom);
}

Polynomial Polynomial:: operator+(const Polynomial &p) const{
    map<int, double> res_monom(monomials);
    for(auto it: p.monomials) {
        if (res_monom.count(it.first)) {
            res_monom[it.first] += it.second;
        }
        else {
            res_monom[it.first] = it.second;
        }
    }
    Polynomial res(res_monom);
    res.optimizePol();
    return res;
}

Polynomial Polynomial:: operator-(const Polynomial &p) const{
    Polynomial tmp = -p;
    return (*this) + tmp;
}

Polynomial& Polynomial:: operator+=(const Polynomial &p) {
    (*this) = p + (*this);
    return (*this);
}

Polynomial& Polynomial:: operator-=(const Polynomial &p) {
    (*this) = (*this) - p;
    return (*this);
}

Polynomial Polynomial:: operator*(double n) const {
    if (!n) {
        return Polynomial();
    }
    Polynomial res = *this;
    res.degree = degree;
    for(auto &it: res.monomials) {
        it.second *= n;
    }
    return res;
}

Polynomial Polynomial:: operator*(const Polynomial &p) const {
    Polynomial res;
    for(auto it1: monomials) {
        for(auto it2: p.monomials) {
            if (res.monomials.count(it1.first + it2.first)) {
                res.monomials[it1.first + it2.first] += it1.second * it2.second;
            }
            else {
                res.monomials[it1.first + it2.first] = it1.second * it2.second;
            }
        }
    }
    res.degree = p.degree * degree;
    res.optimizePol();
    return res;
}

Polynomial& Polynomial:: operator*=(const Polynomial &p) {
    (*this) = (*this) * p;
    return (*this);
}

Polynomial Polynomial:: operator/(double n) const {
    Polynomial res = *this;
    res.degree = degree;
    for(auto &it: res.monomials) {
        it.second /= n;
    }
    return res;
}

Polynomial& Polynomial:: operator*=(double n) {
    (*this) = (*this) * n;
    return (*this);
}

Polynomial& Polynomial:: operator/=(double n) {
    (*this) = (*this) / n;
    return (*this);
}

double& Polynomial:: operator[](int i) {
    if (!monomials.count(i)) {
        cout << "There is not such coefficient";
    }
    return monomials[i];
}

double Polynomial:: operator[](int i) const {
    if (!monomials.count(i)) {
        return 0;
    }
    return monomials.at(i);
}

Polynomial operator*(double n, const Polynomial &p) {
    if (!n) {
        return Polynomial();
    }
    Polynomial res = p;
    res.degree = p.degree;
    for(auto &it: res.monomials) {
        it.second *= n;
    }
    return res;
}

ostream & operator<<(ostream &out, Polynomial p) {
    if (p.monomials.empty()) {
        out << "0";
    }
    out << p.monomials[0];
    if (!p.degree) {
        return out;
    }
    if (p.monomials.count(1)) {
        if (p.monomials[1] == 1) {
            out << " + x";
        }
        else if (p.monomials[1] == -1) {
            out << " - x";
        }
        else if (p.monomials[1] > 0) {
            out << " + " << p.monomials[1] << "x";
        }
        else {
            out << " - " << -p.monomials[1] << "x";
        }
    }
    if(p.degree == 1) {
        return out;
    }
    for(int i = 1; i <= p.degree; ++i) {
        if (p.monomials.count(i)) {
            if (p.monomials[i] == 1) {
                out << " + x^" << i;
            }
            else if (p.monomials[i] == -1) {
                out << " - x^" << i;
            }
            else if (p.monomials[i] > 0) {
                out << " + " << p.monomials[i] << "x^" << i;
            }
            else {
                out << " - " << -p.monomials[i] << "x^" << i;
            }
        }
    }
    return out;
}

istream& operator>>(istream &in, Polynomial &p) {
    stringstream ss;
    p.monomials.clear();
    string s;
    getline(in, s);
    ss << s;
    double d;
    int i;
    ss >> i;
    while (ss >> d) {
        p.monomials[i] = d;
        ss >> i;
    }
    p.optimizePol();
    return in;
}

int main() {
    vector<double> a = {1,2,3,4,5};
    vector<double> b = {3, 4, 5};
    Polynomial p1(a);
    Polynomial p2(b);
    Polynomial p3 = -p1;
    Polynomial p4(a);
    p4=p4*p2;
    cout << p4 << endl;
    cout << Polynomial() << endl;
}
