#include <iostream>
#include <fstream>
#include <gtest/gtest.h>

using namespace std;

template<int X, unsigned int degree>
struct mon {
    static const long long value = X * mon<X, degree - 1>::value;
};

template<int X>
struct mon<X, 0> {
    static const long long value = 1;
};

template<int...>
struct pol;

template<>
struct pol<> {
    static const int value = 0;
};

template<int m, int ... members>
struct pol<m, members...> {
    static const int value = m + pol<members...>::value;
};

ostream &operator<<(ostream &out, pol<> p) {
    return out << pol<>::value;
}

template<int X>
ostream &operator<<(ostream &out, pol<X> p) {
    return out << p.value;
}

template<int X, int ... members>
ostream &operator<<(ostream &out, pol<X, members...> p) {
    return out << p.value;
}

TEST(Polinomial, Null) {
    int res = pol<>::value;
    EXPECT_EQ(res, 0);
}

TEST(Polinomial, Easy) {
    int res = pol<mon<3, 2>::value, mon<3, 1>::value, mon<1, 0>::value>::value;
    EXPECT_EQ(res, 13);
}

TEST(Polinomial, Hard) {
    int res = pol<mon<2, 5>::value, mon<5, 3>::value, mon<-2, 1>::value, 3>::value;
    EXPECT_EQ(res, 276);
}

int main(int argc, char **argv) {
    return 0;
}
