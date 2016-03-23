#!/bin/bash

TAG="$1"

if [ "$TAG" = "" ]
then
    TAG=$TRAVIS_TAG
fi

if [ "$TAG" = "" ]
then
    echo 'No tag given. Package will not be created.'
    exit 1
fi

VERSION=`echo "$TAG" | perl -ne 'print /^v(\d+\.\d+(?:\.\d+(?:\.\d+)?)?)$/'`
if [ "$VERSION" = "" ];
then
    echo 'Wrong version format. Package will not be created.'
    exit 1
fi

AVERSION=`grep AssemblyVersion AssemblyInfo.cs | perl -npe 's/^.*?\"//;s/\".*$//'`

if [ "$VERSION" != "$AVERSION" ]
then
    echo "Tag doesn't match assembly version. Package will not be created."
    exit 1
fi

echo 'Creating the nuget package...'
if ! nuget pack FbxSharp.nuspec -Properties version=$VERSION ; then
    echo 'Error creating the package. The package will not be uploaded.'
    exit 1
fi

echo 'Uploading the package to nuget...'
if ! nuget push -ApiKey $NUGET_APIKEY FbxSharp.$VERSION.nupkg ; then
    echo 'Error uploading the package. Quitting.'
    exit 1
fi

echo 'Done.'
