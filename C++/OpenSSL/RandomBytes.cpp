#include <iostream>
#include <optional>
#include <ostream>
#include <vector>

#include <openssl/err.h>
#include <openssl/rand.h>

std::optional<std::string> FillRandBytes(unsigned char *buf, const int size) {
  if (RAND_bytes(buf, size) == 1) {
    return std::nullopt;
  }
  return ERR_reason_error_string(ERR_get_error());
}

int main(int argc, char *argv[]) {
  std::vector<unsigned char> buffer(10);
  auto error = FillRandBytes(&buffer[0], static_cast<int>(buffer.size()));
  if (error.has_value()) {
    std::cout << "Unable to get random bytes, err : " << *error << std::endl;
    return 0;
  }

  for (auto c : buffer) {
    std::cout << static_cast<int>(c) << ' ';
  }
  std::cout << std::endl;
  return 0;
}
