#include <iostream>
#include <bits/stdc++.h>
#include "figures.h"
using namespace std;

Point::Point(double x_, double y_) {
    x = x_;
    y = y_;
}
Point::Point(const Point &p) {
    x = p.x;
    y = p.y;
}
double Point::get_x() {
    return x;
}
double Point::get_y() {
    return y;
}
double distance(const Point &p1, const Point &p2) {
    return sqrt((p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y));
}
Point &Point::operator=(const Point &p) {
    x = p.x;
    y = p.y;
    return *this;
}
bool Point::operator==(const Point &p) const {
    if (abs(p.x - x) <= 0.0001 && abs(p.y - y) <= 0.0001) {
        return true;
    } else {
        return false;
    }
}

Polyline::Polyline() {}
Polyline::Polyline(const vector<Point> &p) : points(p) {}
Polyline::Polyline(const Polyline &p) : points(p.points) {}
Polyline &Polyline::operator=(const Polyline &p) {
    points = p.points;
    return *this;
}
ostream &operator<<(ostream &out, Polyline &pol) {
    for (Point &p: pol.points) {
        out << p.get_x() << " " << p.get_y() << " ";
    }
    return out;
}

Closed_polyline::Closed_polyline() : Polyline() {}
Closed_polyline::Closed_polyline(const vector<Point> &p) : Polyline(p) {}
Closed_polyline::Closed_polyline(const Closed_polyline &p) : Polyline(p) {}
Closed_polyline &Closed_polyline::operator=(const Closed_polyline &p) {
    points = p.points;
    return *this;
}
double Closed_polyline::length() {
    double len = 0;
    for (int i = 0; i < points.size() - 1; i++){
        len += distance(points[i], points[i + 1]);
    }
    return len;
}

Polygon::Polygon() : Closed_polyline() {}
Polygon::Polygon(const vector<Point> &p) {
    points = p;
    check_polygon();
}
Polygon::Polygon(const Polygon &p) :
    Closed_polyline(p.points) {}
Polygon &Polygon::operator=(const Polygon &p) {
    points = p.points;
    return *this;
}
void Polygon::check_polygon() {
    if (points.size() < 3) {
        cout << "It is not a polygon because there are few vertexes";
        return;
    }
    for (int i = 0; i < points.size(); i++) {
        for (int j = i + 1; j < points.size(); j++) {
            if (points[i] == points[j]) {
                cout << "It is not a polygon because some vertexes are equal";
                return;
            }
        }
    }
    for (int i = 1; i < points.size() - 1; i++) {
        double k1 = (points[i].get_y() - points[i - 1].get_y()) / (points[i].get_x() - points[i - 1].get_x()),
                b1 = points[i - 1].get_y() - k1 * points[i - 1].get_x(),
                k2 = (points[i + 1].get_y() - points[i].get_y()) / (points[i + 1].get_x() - points[i].get_x()),
                b2 = points[i].get_y() - k1 * points[i].get_x();
        if (k1 == k2 && b1 == b2) {
            cout << "It is not a polygon because vertexes lie on the same line";
            return;
        }
    }
}
double Polygon::perimeter(){
    return length();
}
double Polygon::square(){
    if (points.size() < 3) {
        return -1;
    }
    double s = 0;
    for(int i = 0; i < points.size() - 1; ++i)
        s += points[i].get_x() * points[i + 1].get_y() - points[i].get_y() * points[i + 1].get_x();
    return 0.5 * abs(s);
}

void Regular_polygon:: check_regular_polygon() {
    for(int i = 1; i < points.size(); i++) {
        if (abs(distance(points[i], points[i - 1]) - a) > 0.0001) {
            throw logic_error("It's not a regular polygon because sides are not equal");
        }
    }
    check_polygon();
}
Regular_polygon:: Regular_polygon(): Polygon(), a(0) {}
Regular_polygon:: Regular_polygon(vector<Point> &p): Polygon(p), a(distance(p[0], p[1])) {
    check_regular_polygon();
}
Regular_polygon:: Regular_polygon(const Regular_polygon& p): Polygon(p.points), a(p.a) {}
Regular_polygon& Regular_polygon:: operator= (const Regular_polygon &p) {
    a = p.a;
    points = p.points;
    return (*this);
}
double Regular_polygon:: perimeter(){
    return a * points.size();
}
double Regular_polygon:: square(){
    return perimeter() * a / 2;
}

void Triangle::check_triangle() {
    if (points[0] == points[1] || points[0] == points[2] || points[1] == points[2]) {
        cout << "It is not a triangle because some points are equal" << endl;
    }
    for (int i = 0; i < 2; i++){
        double k1 = (points[i].get_y() - points[i - 1].get_y()) / (points[i].get_x() - points[i - 1].get_x()),
                b1 = points[i - 1].get_y() - k1 * points[i - 1].get_x(),
                k2 = (points[i + 1].get_y() - points[i].get_y()) / (points[i + 1].get_x() - points[i].get_x()),
                b2 = points[i].get_y() - k1 * points[i].get_x();
        if (k1 == k2 && b1 == b2) {
            cout << "It is not a triangle because vertexes lie on the same line" << endl;
            return;
        }
    }
}
Triangle:: Triangle(): Polygon(), a(0), b(0), c(0) {}
Triangle:: Triangle(const Point &p1, const Point &p2, const Point &p3): Polygon({p1, p2, p3}) {
    check_triangle();
    a = distance(p1, p2);
    b = distance(p1, p3);
    c = distance(p2, p3);
}
Triangle:: Triangle(const vector<Point> &p) {
    if (p.size() != 3) {
        cout << "There are not 3 points in a vector" << endl;
    }
    points = p;
    check_triangle();
}
Triangle:: Triangle(const Triangle &tr): Polygon(tr.points), a(tr.a), b(tr.b), c(tr.c) {}
Triangle& Triangle:: operator= (const Triangle &tr) {
    points = tr.points;
    a = tr. a;
    b = tr.b;
    c = tr.c;
    return (*this);
}
double Triangle:: perimeter(){
    return a + b + c;
}
double Triangle:: square(){
    double p = perimeter() / 2;
    return sqrt(p * (p - a) * (p - b) * (p - c));
}

void Trapezoid:: check_trapezoid() {
    check_polygon();
    double k1 = (points[1].get_y() - points[0].get_y()) / (points[1].get_x() - points[0].get_x()),
            k2 = (points[2].get_y() - points[1].get_y()) / (points[2].get_x() - points[1].get_x()),
            k3 = (points[3].get_y() - points[2].get_y()) / (points[3].get_x() - points[2].get_x()),
            k4 = (points[0].get_y() - points[3].get_y()) / (points[0].get_x() - points[3].get_x());
    if (!(k1 == k3 || k2 == k4)) {
        cout << "It is not a trapezoid because there are not parallel sides" << endl;
    }
    if (k1 == k3 && k2 == k4) {
        cout << "It is not a trapezoid because all opposite sides are parallel" << endl;
    }
}
Trapezoid:: Trapezoid() {}
Trapezoid:: Trapezoid(Point p1, Point p2, Point p3, Point p4): Polygon({p1, p2, p3, p4}) {
    a = distance(points[0], points[1]);
    b = distance(points[1], points[2]);
    c = distance(points[2], points[3]);
    d = distance(points[3], points[0]);
    check_trapezoid();
}
Trapezoid:: Trapezoid(const vector<Point> &p){
    points = p;
    check_trapezoid();
    a = distance(points[0], points[1]);
    b = distance(points[1], points[2]);
    c = distance(points[2], points[3]);
    d = distance(points[3], points[0]);
}
Trapezoid& Trapezoid:: operator= (const Trapezoid &tr) {
    points = tr.points;
    a = tr.a;
    b = tr.b;
    c = tr.c;
    d = tr.d;
    return (*this);
}
double Trapezoid:: perimeter(){
    return a + b + c + d;
}
double Trapezoid ::square() {
    return (a + b)/2 * sqrt(c*c - pow(((b - a) * (b - a) + c * c - d * d)/(2 * (b - a)), 2));
}

int main() {
    Point p(10, 5);
    Point q(11, 7.5);
    q = p;
    cout << q.get_x() << " " << q.get_y();
    Polyline pl;
    vector<Point> points = {{1, 2},
                            {3, 4}};

    Closed_polyline cp;
    vector<Point> point = {{1, 1},
                           {2, 2},
                           {3, 3},
                           {1, 5}};
    cout << cp << endl;
    Polygon pol;
    vector<Point> pointes = {{1, 1},
                             {2, 2}};
    Polygon *a[1];
    a[0] = new Triangle({0, 0}, {1,1}, {1, 0});
    a[1] = new Trapezoid(point);
    for (auto i: a) {
        cout << i->square() << endl;
    }
    return 0;
}
