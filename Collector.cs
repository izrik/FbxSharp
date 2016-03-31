using System;
using FbxSharp;
using System.Collections.Generic;

namespace FbxSharp
{
    public class Collector : FbxVisitor
    {
        public readonly ISet<FbxObject> Objects = new HashSet<FbxObject>();

        public override void Visit(FbxObject obj)
        {
            Objects.Add(obj);
        }
    }
}

