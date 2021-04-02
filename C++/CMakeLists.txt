cmake_minimum_required(VERSION 3.14)

project(Cpp)

set(CMAKE_CXX_STANDARD 17)

if(${CMAKE_SYSTEM_NAME} STREQUAL "Windows")
	add_executable(vector "STL/vector.cpp")
	
	add_executable(basename "Files/Basename.cpp")
	
	add_executable(cout "Streams/cout.cpp")
	
	add_executable(console_write "Windows/ConsoleWrite.cpp")
	
	add_executable(read_certificate "Windows/ReadCertificate.cpp")
	target_link_libraries(read_certificate crypt32.lib)
else()
	add_subdirectory(OpenSSL)

	add_executable(snprintf "stdio/snprintf.c")
endif()
