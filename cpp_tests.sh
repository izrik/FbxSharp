#!/bin/bash

__DIR__="$(dirname $(realpath $BASH_SOURCE))"

( cd "$__DIR__/fbxcppcommon" && make ) && \
    ( cd "$__DIR__/FbxCppTests" && make all && make check ) && \
    ( cd "$__DIR__/fbxcppcli" && make ) && \
    echo passed
