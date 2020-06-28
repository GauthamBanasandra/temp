cmake_minimum_required(VERSION 3.14)

project(OpenSSL)

find_package(OpenSSL REQUIRED)


add_executable(check_evp CheckEvp.cpp)
target_include_directories(check_evp PRIVATE ${OPENSSL_INCLUDE_DIR})
# target_link_libraries(check_evp PRIVATE ${OPENSSL_LIBRARIES})
