#include "server.h"
#include "worker.h"

Worker worker;

void Configure() { worker.Configure(); }

void Start() { worker.Start(); }

void Process(const int value) { worker.Process(value); }
