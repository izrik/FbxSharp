#!/bin/bash

__DIR__="$(dirname "$(realpath "${BASH_SOURCE[0]}")")"
__ROOT_DIR__="$(dirname "$(realpath "$__DIR__")")"

dotnet \
  "$__ROOT_DIR__/TestCaseGenerator/bin/Debug/net8.0/TestCaseGenerator.dll" \
  cs \
  --input "$__ROOT_DIR__/test-cases" \
  --output "$__DIR__" \
  "$@"
