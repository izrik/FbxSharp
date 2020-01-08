#!/bin/bash

pushd FbxSharpTests
./gen_tests.sh
popd

pushd FbxCppTests
./gen_tests.sh
popd

