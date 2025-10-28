#!/bin/bash

__DIR__="$(dirname "$(realpath "${BASH_SOURCE[0]}")")"

make --file "$__DIR__/Makefile" && \
  "$__DIR__/bin/FbxCppTests" "$@"
