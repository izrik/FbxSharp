using System;
using System.Collections.Generic;
using ChamberLib;

namespace FbxSharp
{
    public class Cluster : SubDeformer
    {
        public List<long> Indexes;
        public List<double> Weights;

        public Matrix Transform;
        public Matrix TransformLink;
    }
}

