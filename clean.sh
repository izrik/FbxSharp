#!/bin/bash
set -e
( cd fbxcppcommon && make clean ) && \
    ( cd FbxCppTests && make clean ) && \
    ( cd fbxcppcli && make clean ) && \
    dotnet clean FbxSharp.sln
