using System;
using FbxSharp;
using System.Collections.Generic;

namespace FbxSharp
{
    public class Collector : Visitor
    {
        public ISet<FbxObject> Collect(FbxObject obj)
        {
            Objects.Clear();
            Accept(obj);
            return Objects;
        }

        readonly ISet<FbxObject> Objects = new HashSet<FbxObject>();

        public override void Visit(FbxObject obj)
        {
            Objects.Add(obj);
        }
    }
}

