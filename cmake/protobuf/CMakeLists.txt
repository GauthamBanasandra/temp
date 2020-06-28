cmake_minimum_required(VERSION 3.15)

project(JustFindProtobuf)

find_package(Protobuf REQUIRED)

message(STATUS "protobuf include dirs ${PROTOBUF_INCLUDE_DIRS}")
message(STATUS "protobuf library ${PROTOBUF_LIBRARY}")
message(STATUS "protobuf protoc library ${PROTOBUF_PROTOC_LIBRARY}")
