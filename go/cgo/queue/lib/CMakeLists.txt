cmake_minimum_required(VERSION 3.15)

project(queue)

set(CB_CHECKOUT_DIR "C:/Users/Gautham/projects/github/couchbase/mad-hatter")

# icu
set(ICU_HEADERS "${CB_CHECKOUT_DIR}/build/tlm/deps/v8.exploded/include/unicode")
set(ICU_LIBRARIES
        "${CB_CHECKOUT_DIR}/build/tlm/deps/v8.exploded/lib/Release/icuuc.dll.lib"
        "${CB_CHECKOUT_DIR}/build/tlm/deps/v8.exploded/lib/Release/icui18n.dll.lib")

# v8
set(V8_HEADERS "${CB_CHECKOUT_DIR}/build/tlm/deps/v8.exploded/include")
set(V8_LIBRARIES
        "${CB_CHECKOUT_DIR}/build/tlm/deps/v8.exploded/lib/Release/v8.dll.lib"
        "${CB_CHECKOUT_DIR}/build/tlm/deps/v8.exploded/lib/Release/v8_libplatform.dll.lib"
        "${CB_CHECKOUT_DIR}/build/tlm/deps/v8.exploded/lib/Release/v8_libbase.dll.lib")

set(CMAKE_CXX_VISIBILITY_PRESET hidden)
set(CMAKE_VISIBILITY_INLINES_HIDDEN YES)
include(GenerateExportHeader)

add_library(server SHARED
    server.cpp
    blocking-queue.cpp
    worker.cpp)
target_include_directories(server
	PUBLIC ${PROJECT_BINARY_DIR}/exports ${PROJECT_SOURCE_DIR}
	PRIVATE ${ICU_HEADERS} ${V8_HEADERS})
target_link_libraries(server
	PRIVATE ${ICU_LIBRARIES} ${V8_LIBRARIES})
generate_export_header(server EXPORT_FILE_NAME ${PROJECT_BINARY_DIR}/exports/server_export.h)

add_executable(client main.cpp)
target_link_libraries(client server)
