#include "server.h"

#include <chrono>
#include <thread>

int main(int argc, char *argv[]) {
  Start();
  Process(2);

  std::this_thread::sleep_for(std::chrono::seconds(10));
  return 0;
}
