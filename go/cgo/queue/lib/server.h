#ifndef SERVER_H
#define SERVER_H

#include "server_export.h"

extern "C" SERVER_EXPORT void Configure();

extern "C" SERVER_EXPORT void Start();

extern "C" SERVER_EXPORT void Process(int value);

#endif
