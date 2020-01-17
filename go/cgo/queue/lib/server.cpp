#include "server.h"
#include "worker.h"

Worker worker;

void Start() { worker.Start(); }

void Process(const int value) { worker.Process(value); }
