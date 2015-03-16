using System;

namespace FbxSharp
{
    public abstract class LayerContainer : NodeAttribute
    {
        protected LayerContainer(string name="")
            : base(name)
        {
        }
    }
}

