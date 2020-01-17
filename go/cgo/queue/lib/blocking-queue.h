#ifndef BLOCKING_QUEUE_H
#define BLOCKING_QUEUE_H

#include <condition_variable>
#include <mutex>
#include <queue>

class BlockingQueue {
public:
  BlockingQueue(const size_t capacity) : capacity_{capacity} {}

  void Push(int value);
  int Pop();

private:
  size_t capacity_{0};
  std::queue<int> data_;
  std::condition_variable data_signal_;
  std::mutex data_mutex_;
};

#endif
