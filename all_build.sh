#!/bin/bash
set -e
(cd FbxOpenCpp && make all && ./bin/FbxOpenCpp ) && \
    nuget restore FbxSharpBuild.sln && \
    msbuild /p:Configuration=Debug FbxSharpBuild.sln && \
    nunit-console ./FbxSharpTests/bin/Debug/FbxSharpTests.dll
