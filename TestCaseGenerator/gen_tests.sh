#!/bin/bash

mono bin/Debug/TestCaseGenerator.exe cpp f NodeTest.tc && mv NodeTest.tc.cpp ../../../FbxOpenCpp/NodeTest.cpp
mono bin/Debug/TestCaseGenerator.exe cs f NodeTest.tc && mv NodeTest.tc.cs ../FbxSharpTests/NodeTest.cs 

