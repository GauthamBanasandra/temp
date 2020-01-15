#include <stdio.h>

void AddAndPrint(int a, int b) {
  int c = a + b;
  printf("%d\n", c);
}

int main(int argc, char const *argv[]) {
  AddAndPrint(2, 3);
  return 0;
}
