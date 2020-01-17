cmake_minimum_required(VERSION 3.15)

project(math)

set(CMAKE_CXX_VISIBILITY_PRESET hidden)
set(CMAKE_VISIBILITY_INLINES_HIDDEN YES)
include(GenerateExportHeader)

add_library(add SHARED add.cpp)
target_include_directories(add PUBLIC ${PROJECT_BINARY_DIR}/exports)
generate_export_header(add EXPORT_FILE_NAME ${PROJECT_BINARY_DIR}/exports/add_export.h)
