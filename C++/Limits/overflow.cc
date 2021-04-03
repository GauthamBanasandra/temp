#include <iostream>
#include <limits>
#include <ostream>

int main(int argc, char *argv[]) {
  std::cout << "Max int64_t = " << std::numeric_limits<int64_t>::max()
            << std::endl;
  std::cout << "Max int64_t + 1 = " << std::numeric_limits<int64_t>::max() + 1
            << std::endl;
  std::cout << "Min int64_t = " << std::numeric_limits<int64_t>::min()
            << std::endl;
  return 0;
}
