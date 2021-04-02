#include <limits.h>
#include <stdio.h>
#include <string.h>

int main(int argc, char *argv[]) {
  char filename[PATH_MAX];
  char list_dir_test[PATH_MAX];

  for (int i = 0; i < PATH_MAX; ++i) {
    list_dir_test[i] = 'a';
  }

  const int write_size =
      snprintf(NULL, 0, "%s/many_files_%d", list_dir_test, 2);
  printf("Size to write = %d\n", write_size);

  const int actual_write_size =
      snprintf(filename, PATH_MAX, "%s/many_files_%d", list_dir_test, 2);
  printf("Size written = %d\n", actual_write_size);
  return 0;
}
