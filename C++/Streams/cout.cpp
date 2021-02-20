#include <iostream>
#include <ostream>
#include <string>

int main(int argc, char *argv[]) {
  const std::string data("Hello there, this is some data");
  std::cout.write(data.c_str(), data.size()).write("\n", sizeof '\n');
  return 0;
}
