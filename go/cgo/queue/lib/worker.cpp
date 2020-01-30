#include <iostream>
#include <libplatform/libplatform.h>
#include <ostream>
#include <thread>
#include <v8.h>

#include "worker.h"

Worker::Worker() : messages_{5} {}

Worker::~Worker() {
  script_.Reset();
  context_.Reset();
  isolate_->Dispose();
  v8::V8::Dispose();
  v8::V8::ShutdownPlatform();
}

void Worker::Start() {
  std::thread runner([this]() {
    while (!stop_) {
      Process();
    }
  });
  runner.detach();
}

void Worker::Process() {
  const auto value = messages_.Pop();
  std::cout << "Worker got value : " << value << std::endl;

  v8::V8::InitializeICUDefaultLocation("");
  v8::V8::InitializeExternalStartupData("");
  std::unique_ptr<v8::Platform> platform = v8::platform::NewDefaultPlatform();
  v8::V8::InitializePlatform(platform.get());
  v8::V8::Initialize();

  v8::Isolate::CreateParams create_params;
  create_params.array_buffer_allocator =
      v8::ArrayBuffer::Allocator::NewDefaultAllocator();
  v8::Isolate *isolate = v8::Isolate::New(create_params);
  {
    v8::Isolate::Scope isolate_scope(isolate);
    v8::HandleScope handle_scope(isolate);
    v8::Local<v8::Context> context = v8::Context::New(isolate);
    v8::Context::Scope context_scope(context);
    {
      auto source_str = R"(
function add(a, b) {
  return a + b;
}
add(4, 5);
      )";
      v8::Local<v8::String> source =
          v8::String::NewFromUtf8(isolate, source_str,
                                  v8::NewStringType::kNormal)
              .ToLocalChecked();
      v8::Local<v8::Script> script =
          v8::Script::Compile(context, source).ToLocalChecked();
      v8::Local<v8::Value> result = script->Run(context).ToLocalChecked();
      v8::String::Utf8Value result_utf8(isolate, result);
      std::cout << *result_utf8 << std::endl;
    }
  }
  isolate->Dispose();
  v8::V8::Dispose();
  v8::V8::ShutdownPlatform();
  delete create_params.array_buffer_allocator;
}
