package main

/*
#cgo LDFLAGS: -L C:/Users/Gautham/projects/github/temp/go/cgo/queue/lib/out/build/x64-Debug/Debug -lserver
void Start();
void Process(int value);
*/
import "C"
import "time"

func main() {
	C.Start()
	C.Process(2)
	time.Sleep(20 * time.Second)
}
