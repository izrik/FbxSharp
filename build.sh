#!/bin/bash
set -e
nuget restore FbxSharpBuild.sln
xbuild /p:Configuration=Debug FbxSharpBuild.sln
nunit-console ./FbxSharpTests/bin/Debug/FbxSharpTests.dll
