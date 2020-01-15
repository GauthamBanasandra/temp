package main

/*
#include <stdio.h>

void AddAndPrint(int a, int b) {
	int c = a + b;
	printf("%d\n", c);
}
*/
import "C"

func main() {
	a := C.int(2)
	b := C.int(3)
	C.AddAndPrint(a, b)
}
