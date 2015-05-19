#!/bin/bash

for f in ../test-cases/*.tc
do
  g=`basename -s.tc $f`
  fbxtest cpp $f $g.cpp
done

