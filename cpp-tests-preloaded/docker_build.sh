#!/bin/bash

__DIR__="$(dirname "$(realpath "${BASH_SOURCE[0]}")")"
__ROOT_DIR__="$(dirname "$(realpath "$__DIR__")")"

docker build \
  -t fbxsharp-cpp-tests-preloaded \
  -f "$__DIR__/Dockerfile-cpp-test-preloaded" \
  "$__ROOT_DIR__"
