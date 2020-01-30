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

void Worker::Configure() {
  // Initialize v8
  v8::V8::InitializeICUDefaultLocation("");
  v8::V8::InitializeExternalStartupData("");
  platform_ = v8::platform::NewDefaultPlatform();
  v8::V8::InitializePlatform(platform_.get());
  v8::V8::Initialize();

  // Initialize isolate
  isolate_params_.array_buffer_allocator =
      v8::ArrayBuffer::Allocator::NewDefaultAllocator();
  isolate_ = v8::Isolate::New(isolate_params_);
  {
    v8::Isolate::Scope isolate_scope(isolate_);
    v8::HandleScope handle_scope(isolate_);
    const auto context = v8::Context::New(isolate_);
    v8::Context::Scope context_scope(context);
    context_.Reset(isolate_, context);

    auto source_str = R"(
function add(a, b) {
  return a + b;
}
add(4, 5);
      )";
    v8::Local<v8::String> source_v8_str;
    if (!v8::String::NewFromUtf8(isolate_, source_str,
                                 v8::NewStringType::kNormal)
             .ToLocal(&source_v8_str)) {
      std::cout << "Unable to create source JavaScript string" << std::endl;
      return;
    }

    v8::Local<v8::Script> script;
    if (!v8::Script::Compile(context, source_v8_str).ToLocal(&script)) {
      std::cout << "Unable to compile script" << std::endl;
      return;
    }
    script_.Reset(isolate_, script);
  }
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

  v8::Locker locker(isolate_);
  v8::Isolate::Scope isolate_scope(isolate_);
  v8::HandleScope handle_scope(isolate_);
  auto context = context_.Get(isolate_);
  v8::Context::Scope context_scope(context);

  auto script = script_.Get(isolate_);
  v8::Local<v8::Value> result;
  if (!script->Run(context).ToLocal(&result)) {
    std::cout << "Unable to run the script" << std::endl;
    return;
  }
  v8::String::Utf8Value result_utf8(isolate_, result);
  std::cout << "From v8 : " << *result_utf8 << std::endl;
}
