package main

import (
	"log"
	"syscall"
)

func main() {
	mathLib, err := syscall.LoadLibrary("C:/Users/Gautham/projects/github/temp/go/loadlib/math/x64/Debug/math.dll")
	if err != nil {
		log.Fatalf("Unable to load library, err : %v", err)
	}
	defer func() {
		err := syscall.FreeLibrary(mathLib)
		if err != nil {
			log.Fatalf("Unable to free library, err : %v", err)
		}
	}()

	addFunc, err := syscall.GetProcAddress(mathLib, "Add")
	if err != nil {
		log.Fatalf("Unable to get Add function, err : %v", err)
	}

	var nargs uintptr = 2
	var a uintptr = 1
	var b uintptr = 2
	result, _, err := syscall.Syscall(uintptr(addFunc), nargs, a, b, 0)
	if err != nil && err != syscall.Errno(0) {
		log.Fatalf("Unable to call Add function, err : %d", err)
	}
	log.Printf("Result : %v", result)
}
