#!/bin/bash

for f in ../test-cases/*.tc
do
  g=`basename $f .tc`
  fbxtest cs $f $g.cs
done

