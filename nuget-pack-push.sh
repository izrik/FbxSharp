#!/bin/bash

VERSION=`echo "$1" | perl -ne 'print /^v(\d+\.\d+(?:\.\d+(?:\.\d+)?)?)$/'`
if [ "$VERSION" = "" ];
then
    echo 'Wrong version format. Package will not be created.'
    exit 1
fi

AVERSION=`grep AssemblyVersion AssemblyInfo.cs | perl -npe 's/^.*?\"//;s/\".*$//'`

if [ "$VERSION" != "$AVERSION ]
then
    echo "Tag doesn't match assembly version. Package will not be created."
    exit 1
fi

nuget pack FbxSharp.nuspec -Properties version=$VERSION && \
    nuget push -ApiKey $NUGET_APIKEY FbxSharp.$VERSION.nupkg