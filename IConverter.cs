using System;
using System.Linq;
using System.Collections.Generic;

namespace FbxSharp
{
    public interface IConverter
    {
        FbxScene ConvertScene(List<ParseObject> parsedObjects);
    }
}

