package main

/*
#cgo LDFLAGS: -L C:/Users/Gautham/projects/github/temp/go/loadlib/math/x64/Debug -lmath
int Add(int a, int b);
*/
import "C"
import "log"

func main() {
	a := C.int(2)
	b := C.int(3)
	result := C.Add(a, b)
	log.Printf("%d", int(result))
}
