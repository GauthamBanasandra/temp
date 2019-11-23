#include <algorithm>
#include <iostream>
#include <ostream>
#include <vector>

void Print(const std::vector<int> &numbers) {
  auto separator = "";
  for (const auto number : numbers) {
    std::cout << separator << number;
    separator = " ";
  }
  std::cout << std::endl;
}

int main(int argc, char *argv[]) {
  std::vector<int> numbers{1, 2, 3, 4, 4, 5, 4};
  std::cout << "Numbers:" << std::endl;
  Print(numbers);
  std::cout << std::endl;

  std::cout << "Delete the third element:" << std::endl;
  numbers.erase(numbers.begin() + 2);
  Print(numbers);
  std::cout << std::endl;

  std::cout << "Remove all occurrences of 4:" << std::endl;
  numbers.erase(std::remove(numbers.begin(), numbers.end(), 4), numbers.end());
  Print(numbers);
  std::cout << std::endl;

  std::cout << "Inserting 4 at position 2 (0-based):" << std::endl;
  numbers.insert(numbers.begin() + 2, 4);
  Print(numbers);
  std::cout << std::endl;

  std::cout << "Inserting 6, 5 times at position 2 (0-based):" << std::endl;
  numbers.insert(numbers.begin() + 2, 5, 6);
  Print(numbers);

  return 0;
}
