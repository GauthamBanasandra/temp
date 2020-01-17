cmake_minimum_required(VERSION 3.15)

project(queue)

set(CMAKE_CXX_VISIBILITY_PRESET hidden)
set(CMAKE_VISIBILITY_INLINES_HIDDEN YES)
include(GenerateExportHeader)

add_library(server SHARED
    server.cpp
    blocking-queue.cpp
    worker.cpp)
target_include_directories(server PUBLIC ${PROJECT_BINARY_DIR}/exports ${PROJECT_SOURCE_DIR})
generate_export_header(server EXPORT_FILE_NAME ${PROJECT_BINARY_DIR}/exports/server_export.h)

add_executable(client main.cpp)
target_link_libraries(client server)
