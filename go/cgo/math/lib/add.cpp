#include "add_export.h"

#include <iostream>

extern "C" ADD_EXPORT int Add(int a, int b) { 
    std::cout << "Printing some message here" << std::endl;
    return a + b; }
