#include <Windows.h>

int main(int argc, char *argv[]) {
  char message[] = "Hello\n";
  auto *const stdout = GetStdHandle(STD_OUTPUT_HANDLE);
  unsigned long c_chars;
  WriteConsole(stdout, message, lstrlen(message), &c_chars, nullptr);
  return 0;
}
