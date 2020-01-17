package main

/*
#cgo LDFLAGS: -L C:/Users/Gautham/projects/github/temp/go/cgo/math/lib/build/Debug -ladd
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
