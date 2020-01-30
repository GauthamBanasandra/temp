#ifndef WORKER_H
#define WORKER_H

#include <string>
#include <v8.h>

#include "blocking-queue.h"

class Worker {
public:
  Worker();
  ~Worker();

  void Process(const int value) { messages_.Push(value); }
  void Start();

private:
  void Process();

  bool stop_{false};
  BlockingQueue messages_;
  v8::Isolate *isolate_{nullptr};
  v8::Persistent<v8::Context> context_;
  v8::Persistent<v8::Script> script_;
  v8::Isolate::CreateParams isolate_params_;
};

#endif
