#!/bin/bash

__DIR__="$(dirname "$(realpath "${BASH_SOURCE[0]}")")"

(cd "$__DIR__/FbxSharpTests" ; ./gen_tests.sh "$@" )

(cd "$__DIR__/FbxCppTests" ; ./gen_tests.sh "$@" )

