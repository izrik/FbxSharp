#!/bin/bash

DEBUG=
if [[ "$1" == "--debug" ]]; then
    DEBUG=1
fi

for f in ../test-cases/*.tc
do
  g=`basename $f .tc`
  if [[ -n "$DEBUG" ]]; then
    echo "Generating $g in C#"
  fi
  mono ../TestCaseGenerator/bin/Debug/TestCaseGenerator.exe cs $f $g.cs
done

