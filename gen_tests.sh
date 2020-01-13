#!/bin/bash

(cd FbxSharpTests ; ./gen_tests.sh "$@" )

(cd FbxCppTests ; ./gen_tests.sh "$@" )

