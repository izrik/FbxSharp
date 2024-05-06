#!/bin/bash

__DIR__="$(dirname $(realpath $BASH_SOURCE))"

docker run \
  --rm -it \
  -v "$PWD:/host" \
  -e "SUDO=pseudo" \
  ubuntu:24.04 \
  bash -c "/host/.github/workflows/build_setup.sh && /host/cpp_tests.sh"