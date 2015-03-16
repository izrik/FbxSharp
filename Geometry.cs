using System;

namespace FbxSharp
{
    public abstract class Geometry : GeometryBase
    {
        protected Geometry(string name="")
            : base(name)
        {
        }
    }
}

