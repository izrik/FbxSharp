using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class Mesh : FbxGeometry
    {
        public Mesh(string name="")
            : base(name)
        {
        }

        public override EAttributeType AttributeType { get { return EAttributeType.Mesh; } }

        public List<List<long>> PolygonIndexes = new List<List<long>>();
    }
}

