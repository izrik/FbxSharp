#!/bin/bash
set -e
dotnet build FbxSharp.sln && \
    dotnet test FbxSharpTests/ && \
    (cd fbxcppcommon && make ) && \
    (cd FbxCppTests && make all && make check ) && \
    (cd fbxcppcli && make )
