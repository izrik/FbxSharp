using System;
using System.Linq;
using System.Collections.Generic;

namespace FbxSharp
{
    public class Converter
    {
        public FbxScene ConvertScene(List<ParseObject> parsedObjects)
        {
            return new Converter7300().ConvertScene(parsedObjects);
        }
    }
}

