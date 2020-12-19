#include <filesystem>
#include <iostream>
#include <ostream>
#include <string>

int main(int argc, char *argv[]) {
  const std::string file_path_str(
      R"(C:\Users\Gautham\projects\github\temp\C++\CMakeLists.txt)");
  std::filesystem::path file_path(file_path_str);

  std::cout << "Filename is " << file_path.filename().string() << std::endl;
  return 0;
}
