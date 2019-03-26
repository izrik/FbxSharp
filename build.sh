#!/bin/bash
set -e
csc HelloWorld.cs
mono HelloWorld.exe
#nuget restore FbxSharpBuild.sln
#msbuild /p:Configuration=Debug FbxSharpBuild.sln
#nunit-console ./FbxSharpTests/bin/Debug/FbxSharpTests.dll
