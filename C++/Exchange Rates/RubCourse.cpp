#include <iostream>
#include <iomanip>
#include "rub_course.h"
using namespace std;
Rub_course::Rub_course() :  sum(), number(), median() {}

void Rub_course::course(json& j, ofstream& out) {
    json r = j["rates"];
    out << fixed << setprecision(6);
    out << "Current rate on " << j["date"] << endl;
    for (json::iterator it = r.begin(); it != r.end(); ++it) {
        if (sum.find(it.key()) == sum.end()) {
            sum[it.key()] = 0;
            number[it.key()] = 0;
            median[it.key()] = {};
        }
        sum[it.key()] += (double)it.value();
        number[it.key()]++;
        median[it.key()].push_back(it.value());
        out << it.key() << " : ";
        out << setw(11) << (double)it.value() << endl;
    }
    out << endl;
}

void Rub_course::average(ofstream& out) {
    out << fixed << setprecision(6);
    out << "      Average       Median     " << endl;
    for (auto i: sum) {
        out << i.first << " : " << setw(11) << i.second / number[i.first] << " : ";
        out << setw(11) << median[i.first][median[i.first].size()/2] << endl;
    }
    out << endl;
}
