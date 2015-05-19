using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public static class SortedListHelper
    {
        public static int IndexOfOrBeforeKey<TKey, TValue>(this SortedList<TKey, TValue> list, TKey value, IComparer<TKey> comparer=null)
        {
            return list.Keys.BinarySearchEqualOrLessThan(value, comparer);
        }
    }
}

