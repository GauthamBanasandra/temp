cmake_minimum_required(VERSION 2.8)

project(JustFindOpenSSL)

find_package(OpenSSL REQUIRED)

message(STATUS "OpenSSL include dir ${OPENSSL_INCLUDE_DIR}")
message(STATUS "OpenSSL libraries ${OPENSSL_LIBRARIES}")
