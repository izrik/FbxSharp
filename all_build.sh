#!/bin/bash
set -e
(cd FbxCppTests && make all && ./bin/FbxCppTests ) && \
    nuget restore FbxSharpBuild.sln && \
    msbuild /p:Configuration=Debug FbxSharpBuild.sln && \
    nunit-console ./FbxSharpTests/bin/Debug/FbxSharpTests.dll
