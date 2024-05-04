using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public static class IListHelper
    {
        public static int BinarySearchEqualOrLessThan<T>(this IList<T> list, T value, IComparer<T> comparer=null)
        {
            if (list == null) throw new ArgumentNullException("list");

            if (list.Count == 0) return -1;

            comparer = comparer ?? Comparer<T>.Default;

            int lower = 0;
            int upper = list.Count - 1;

            int c = comparer.Compare(value, list[lower]);
            if (c == -1) return -1;
            if (c == 0) return lower;

            if (comparer.Compare(value, list[upper]) >= 0) return upper;

            while (upper - lower > 1)
            {
                int i = lower + (upper - lower) / 2;

                c = comparer.Compare(value, list[i]);

                if (c == 0) return i;
                if (c > 0)
                    lower = i;
                else
                    upper = i;
            }

            return lower;
        }
    }
}

