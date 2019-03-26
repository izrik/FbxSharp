#!/bin/bash
set -e
nuget restore FbxSharpBuild.sln
msbuild /p:Configuration=Debug FbxSharpBuild.sln
nunit-console ./FbxSharpTests/bin/Debug/FbxSharpTests.dll
