using System;

namespace TestCaseGenerator
{
    public class FbxType
    {
        public string Name;
        public FbxType BaseType;

        public FbxMethod[] Methods = new FbxMethod[0];
    }
}

