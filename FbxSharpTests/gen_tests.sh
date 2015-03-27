#!/bin/bash

for f in *.tc
do
  g=`basename -s.tc $f`
  fbxtest cs $f $g.cs
done

