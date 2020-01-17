#include <iostream>
#include <thread>

#include "worker.h"

void Worker::Start() {
  std::thread runner([this]() {
    while (!stop_) {
      Process();
    }
  });
  runner.detach();
}

void Worker::Process() {
  const auto value = messages_.Pop();
  std::cout << "Worker got value : " << value << std::endl;
}
