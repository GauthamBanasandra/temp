#include <filesystem>
#include <iostream>
#include <ostream>
#include <string>
#include <vector>

// Referring from https://www.man7.org/linux/man-pages/man3/basename.3.html
std::string GetBasename(const std::string &file_path) {
  if (file_path.empty()) {
    return ".";
  }

  const std::filesystem::path path(file_path);
  std::vector<std::string> parts;
  for (const auto &part : std::filesystem::path(file_path)) {
    parts.emplace_back(part.string());
  }

  /*Handle the case of trailing slash*/
  if (parts.back().empty()) {
    parts.pop_back();
  }
  return parts.back();
}

int main(int argc, char *argv[]) {
  const std::string file_path_str(R"(abc\\\)");
  std::cout << GetBasename(file_path_str) << std::endl;
  return 0;
}
