#!/bin/bash
set -e
nuget restore FbxSharpBuild.sln
msbuild /p:Configuration=Debug FbxSharpBuild.sln
mono ./packages/NUnit.ConsoleRunner.3.10.0/tools/nunit3-console.exe ./FbxSharpTests/bin/Debug/FbxSharpTests.dll
