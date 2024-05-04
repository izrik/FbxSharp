#!/bin/bash
set -e
(cd fbxcppcommon && make ) && \
    (cd FbxCppTests && make all && make check ) && \
    (cd fbxcppcli && make ) && \
    dotnet build FbxSharp.sln && \
    dotnet test FbxSharpTests/
