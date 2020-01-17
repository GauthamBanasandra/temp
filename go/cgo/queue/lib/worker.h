#ifndef WORKER_H
#define WORKER_H

#include "blocking-queue.h"

class Worker {
public:
  Worker() : messages_{5} {}

  void Process(const int value)
  {
    messages_.Push(value);
  }
  void Start();

private:
  void Process();

  bool stop_{false};
  BlockingQueue messages_;
};

#endif
