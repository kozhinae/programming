#define CURL_STATICLIB
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <curl/curl.h>
#include "json.h"
#include "windows.h"
#include "rub_course.h"

using namespace std;
using json = nlohmann::json;

int main(void) {
    Rub_course r;
    ofstream fout("answer.txt");
    for (int i = 0; i < 1000; ++i) {
        CURL* curl;
        FILE* f;
        f = fopen("file.json", "wb");
        curl = curl_easy_init();
        curl_easy_setopt(curl, CURLOPT_URL, "https://www.cbr-xml-daily.ru/latest.js");
        curl_easy_setopt(curl, CURLOPT_WRITEDATA, f);
        int result = curl_easy_perform(curl);
        curl_easy_cleanup(curl);
        fclose(f);
        ifstream rate("file.json");
        json j = json::parse(rate);
        r.course(j, fout);
        r.average(fout);
        rate.close();
        Sleep(4000);
    }
    fout.close();
    FreeConsole();
    return 0;
}
