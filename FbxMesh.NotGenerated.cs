using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public partial class FbxMesh : FbxGeometry
    {
        public FbxMesh(string name="")
            : base(name)
        {
        }

        public override EAttributeType AttributeType { get { return EAttributeType.Mesh; } }

        public List<List<long>> PolygonIndexes = new List<List<long>>();
    }
}

