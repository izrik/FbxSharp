using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class Mesh : Geometry
    {
        public override EAttributeType AttributeType { get { return EAttributeType.Mesh; } }

        public List<Vector3> VertexPositions = new List<Vector3>();
        public List<List<long>> PolygonIndexes = new List<List<long>>();

        public List<Layer> Layers = new List<Layer>();
    }
}

