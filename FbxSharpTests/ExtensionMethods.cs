using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FbxSharpTests
{
    static class ExtensionMethods
    {
        public static string GetAt(this string[] array, int index)
        {
            return array[index];
        }

        public static int GetCount(this string[] array)
        {
            return array.Length;
        }
    }
}
