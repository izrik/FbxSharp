#!/bin/bash

__DIR__="$(dirname "$(realpath "${BASH_SOURCE[0]}")")"
__ROOT_DIR__="$(dirname "$(realpath "$__DIR__")")"

DEBUG=
if [[ "$1" == "--debug" ]]; then
    DEBUG=1
fi

for f in "$__ROOT_DIR__"/test-cases/*.tc
do
  g=`basename $f .tc`
  if [[ -n "$DEBUG" ]]; then
    echo "Generating $g in C#"
  fi
  dotnet "$__ROOT_DIR__/TestCaseGenerator/bin/Debug/net8.0/TestCaseGenerator.dll" cs $f "$__DIR__/$g.cs"
done

