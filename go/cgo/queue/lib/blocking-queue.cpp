#include <mutex>

#include "blocking-queue.h"

void BlockingQueue::Push(const int value) {
  std::unique_lock<std::mutex> guard(data_mutex_);
  data_signal_.wait(guard,
                    [this]() -> bool { return data_.size() < capacity_; });
  data_.push(value);
}

int BlockingQueue::Pop() {
  std::unique_lock<std::mutex> guard(data_mutex_);
  data_signal_.wait(guard, [this]() -> bool { return !data_.empty(); });
  const auto value = data_.front();
  data_.pop();
  return value;
}
