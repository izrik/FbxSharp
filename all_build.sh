#!/bin/bash -xe
set -e
#(cd fbxcppcommon && make ) && \
dotnet build FbxSharp.sln
ls -laR TestCaseGenerator/bin/* || true
#(cd FbxCppTests && make all && make check ) && \
#    (cd fbxcppcli && make ) && \
#    dotnet test FbxSharpTests/
