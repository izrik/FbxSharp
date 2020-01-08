#!/bin/bash

for f in ../test-cases/*.tc
do
  g=`basename $f .tc`
  fbxtest cpp $f $g.cpp
done

