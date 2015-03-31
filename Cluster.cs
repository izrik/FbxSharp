using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class Cluster : SubDeformer
    {
        public Cluster(string name="")
            : base(name)
        {
        }

        public List<long> Indexes;
        public List<double> Weights;

        public Matrix Transform;
        public Matrix TransformLink;
    }
}

