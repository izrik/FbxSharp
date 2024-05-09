#!/bin/bash

__DIR__="$(dirname $(realpath $BASH_SOURCE))"

IMAGE=ubuntu:24.04
SETUP=1
while [[ -n "$1" ]] ; do
  case "$1" in
    "--image")
      IMAGE="$2"
      shift
      ;;
    "--setup")
      SETUP=1
      ;;
    "--no-setup")
      SETUP=""
  esac
  shift
done

if [[ -n "$SETUP" ]] ; then
  COMMAND="/host/.github/workflows/build_setup.sh && /host/cpp_tests.sh"
else
  COMMAND="/host/cpp_tests.sh"
fi

docker run \
  --rm -it \
  -v "$PWD:/host" \
  -e "SUDO=pseudo" \
  "$IMAGE" \
  bash -c "$COMMAND"
