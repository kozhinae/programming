#include <iostream>
#include <vector>
#include <deque>
#include <queue>
#include <map>
#include <unordered_map>
#include <list>
#include "CAllocator.h"
#include <time.h>

[[maybe_unused]] void vector_test() {
    std::vector<int, CAllocator<int>> arr(8);

    for (int i = 0; i < 8; ++i) {
        arr[i] = i;
    }

    std::vector<int, CAllocator<int>> arr1 = arr;

    for (int i = 0; i < 8; ++i) {
        arr1.push_back(i);
    }

    for (auto i: arr) {
        std::cout << i << " ";
    }
    std::cout << std::endl;

    for (auto i: arr1) {
        std::cout << i << " ";
    }
    std::cout << std::endl;
}


[[maybe_unused]] void map_test() {
    std::map<int, int, std::less<>, CAllocator<std::pair<int, int>>> my_map;
    for (int i = 0; i < 3; ++i) {
        my_map.insert({i, i});
    }
//    std::map<int, int, std::less<>, CAllocator<std::pair<int, int>>> my_map_2(my_map);
//    for (int i = 3; i < 6; ++i) {
//        my_map_2.insert({i, i});
//    }

    for (auto i : my_map) {
        std::cout << i.second << " ";
    }

    std::cout << std::endl;

//    for (auto i : my_map_2) {
//        std::cout << i.second << " ";
//    }

    std::cout << std::endl;

    for (int i = 0; i < 2; ++i) {
        my_map.erase(my_map.begin());
    }

    for (auto i : my_map) {
        std::cout << i.second << " ";
    }

    std::cout << std::endl;
}

int main()
{
//    map_test();
    vector_test();

    return 0;
}
