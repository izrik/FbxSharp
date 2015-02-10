using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class ParseObject
    {
        public string Name;
        public List<object> Values = new List<object>();
        public List<ParseObject> Properties = new List<ParseObject>();
        public bool HasEmptyBlock = true;
    }
}

