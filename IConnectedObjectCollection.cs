using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public interface IConnectedObjectCollection : IList<FbxObject>
    {
        event EventHandler CollectionChanged;
    }
}

