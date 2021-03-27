#include <iostream>
#include <memory>
#include <ostream>
#include <string>
#include <vector>

#include <openssl/rand.h>

std::unique_ptr<std::string> GetRandomClientId() {
  /**
   *  The server is requesting a 16-byte UUID:
   *  https://github.com/c9n/hadoop/blob/master/hadoop-common-project/hadoop-common/src/main/java/org/apache/hadoop/ipc/ClientId.java
   *
   *  This function generates a 16-byte UUID (version 4):
   *  https://en.wikipedia.org/wiki/Universally_unique_identifier#Version_4_.28random.29
   **/
  std::vector<unsigned char> buf(16);
  RAND_pseudo_bytes(&buf[0], buf.size());

  // clear the first four bits of byte 6 then set the second bit
  buf[6] = (buf[6] & 0x0f) | 0x40;

  // clear the second bit of byte 8 and set the first bit
  buf[8] = (buf[8] & 0xbf) | 0x80;
  return std::make_unique<std::string>(reinterpret_cast<const char *>(&buf[0]),
                                       buf.size());
}

int main(int argc, char *argv[]) {
  const auto client_id = GetRandomClientId();
  for (auto c : *client_id) {
    std::cout << static_cast<int>(c) << ' ';
  }
  std::cout << std::endl;
  return 0;
}
