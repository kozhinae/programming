#pragma once
#include <map>
#include "json.h"
#include <fstream>

using namespace std;
using json = nlohmann::json;

class Rub_course {
public:
    map<string, double> sum;
    map<string, double> number;
    map<string, vector<double>> median;
public:
    Rub_course();
    void course(json&, ofstream&);
    void average(ofstream&);
};
