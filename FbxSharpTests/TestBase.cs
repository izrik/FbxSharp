using System;
using FbxSharp;

namespace FbxSharpTests
{
    public class TestBase
    {
        public static int CountProperties(FbxObject obj)
        {
            return obj.Properties.Count;
        }
    }
}

