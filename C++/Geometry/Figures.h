#ifndef CLASS_FIGURES_H
#define CLASS_FIGURES_H
using namespace std;
class Point {
    double x;
    double y;
public:
    Point(double x_, double y_);
    Point(const Point &p);
    double get_x();
    double get_y();
    friend double distance(const Point &p1, const Point &p2);
    Point &operator=(const Point &p);
    bool operator==(const Point &p) const;
};

class Polyline {
protected:
    vector<Point> points;
public:
    Polyline();
    explicit Polyline(const vector<Point> &p);
    Polyline(const Polyline &p);
    Polyline &operator=(const Polyline &p);
    friend ostream &operator<<(ostream &, Polyline &pol);
};

class Closed_polyline : public Polyline {
public:
    Closed_polyline();
    explicit Closed_polyline(const vector<Point> &p);
    Closed_polyline(const Closed_polyline &p);
    Closed_polyline &operator=(const Closed_polyline &p);
    double length();
};

class Polygon : public Closed_polyline {
protected:
    void check_polygon();
public:
    Polygon();
    explicit Polygon(const vector<Point> &p);
    Polygon(const Polygon &p);
    virtual Polygon &operator=(const Polygon &p);
    virtual double perimeter();
    virtual double square();
};

class Regular_polygon: public Polygon {
protected:
    double a;
    void check_regular_polygon();
public:
    Regular_polygon();
    explicit Regular_polygon(vector<Point>&);
    Regular_polygon(const Regular_polygon&);
    Regular_polygon& operator= (const Regular_polygon&);
    double perimeter() override;
    double square() override;
};

class Triangle: public Polygon {
protected:
    double a, b, c;
    void check_triangle();
public:
    Triangle();
    Triangle(const Point&, const Point&, const Point&);
    explicit Triangle(const vector <Point>&);
    Triangle(const Triangle&);
    Triangle& operator= (const Triangle&);
    double perimeter() override;
    double square() override;
};

class Trapezoid: public Polygon {
protected:
    double a, b, c, d;
    void check_trapezoid();
public:
    Trapezoid();
    Trapezoid(Point, Point, Point, Point);
    explicit Trapezoid(const vector<Point>&);
    Trapezoid& operator= (const Trapezoid&);
    double perimeter() override;
    double square() override;
};
#endif //CLASS_FIGURES_H
