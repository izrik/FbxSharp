#!/bin/bash

pushd FbxSharpTests
./gen_tests.sh
popd

pushd FbxOpenCpp
./gen_tests.sh
popd

