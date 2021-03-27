cmake_minimum_required(VERSION 3.14)

project(OpenSSL)

find_package(OpenSSL REQUIRED)

if(NOT OPENSSL_FOUND)
	message(FATAL_ERROR "Can't build without OpenSSL")
endif()

add_executable(check_evp CheckEvp.cpp)
target_include_directories(check_evp PRIVATE ${OPENSSL_INCLUDE_DIR})
target_link_libraries(check_evp PRIVATE ${OPENSSL_LIBRARIES})

add_executable(random_bytes RandomBytes.cpp)
target_include_directories(random_bytes PRIVATE ${OPENSSL_INCLUDE_DIR})
target_link_libraries(random_bytes PRIVATE ${OPENSSL_LIBRARIES})
