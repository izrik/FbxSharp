#!/bin/bash

DEBUG=
if [[ "$1" == "--debug" ]]; then
    DEBUG=1
fi

for f in ../test-cases/*.tc
do
  g=`basename $f .tc`
  if [[ -n "$DEBUG" ]]; then
    echo "Generating $g in C++"
  fi
  dotnet ../TestCaseGenerator/bin/Debug/net8.0/TestCaseGenerator.dll cpp $f $g.cpp
done

