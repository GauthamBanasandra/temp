#include <algorithm>
#include <iostream>
#include <iterator>
#include <ostream>
#include <vector>

void Print(const std::vector<int> &numbers) {
  auto separator = "";
  for (const auto &number : numbers) {
    std::cout << separator << number;
    separator = " ";
  }
  std::cout << std::endl;

  separator = "";
  for (size_t i = 0, len = numbers.size(); i < len; ++i) {
    std::cout << separator << i;
    separator = " ";
  }
  std::cout << std::endl;
}

int main(int argc, char *argv[]) {
  std::vector<int> numbers{1, 2, 3, 3, 4, 4, 4, 5, 6};

  std::cout << "Numbers and indices:" << std::endl;
  Print(numbers);
  std::cout << std::endl;

  std::cout << "Index of first occurrence of 4:" << std::endl;
  auto find_it = std::lower_bound(numbers.begin(), numbers.end(), 4);
  auto i = std::distance(numbers.begin(), find_it);
  std::cout << i << std::endl << std::endl;

  std::cout << "Index of a number greater than 4:" << std::endl;
  find_it = std::upper_bound(numbers.begin(), numbers.end(), 4);
  i = std::distance(numbers.begin(), find_it);
  std::cout << i << std::endl << std::endl;

  std::cout << "Index of a number less than 4:" << std::endl;
  auto rfind_it =
      std::lower_bound(numbers.rbegin(), numbers.rend(), 4);
  i = numbers.size() - std::distance(numbers.rbegin(), rfind_it);
  std::cout << i << std::endl << std::endl;

  std::cout << "Index of last occurrence of 4:" << std::endl;
  rfind_it =
      std::upper_bound(numbers.rbegin(), numbers.rend(), 4, std::greater<>());
  i = std::distance(numbers.rbegin(), rfind_it);
  std::cout << i << std::endl << std::endl;
  return 0;
}
