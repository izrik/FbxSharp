#!/bin/bash
set -e
dotnet build FbxSharp.sln
dotnet test FbxSharpTests/
