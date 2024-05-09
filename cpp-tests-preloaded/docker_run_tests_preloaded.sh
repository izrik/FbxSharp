#!/bin/bash

__DIR__="$(dirname "$(realpath "${BASH_SOURCE[0]}")")"
__ROOT_DIR__="$(dirname "$(realpath "$__DIR__")")"

"$__ROOT_DIR__/docker_build_test.sh" \
  --image fbxsharp-cpp-tests-preloaded \
  --no-setup