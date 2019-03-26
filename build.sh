#!/bin/bash
set -e
nuget restore FbxSharpBuild.sln
msbuild /p:Configuration=Debug FbxSharpBuild.sln
nunit-console-2.6 ./FbxSharpTests/bin/Debug/FbxSharpTests.dll
