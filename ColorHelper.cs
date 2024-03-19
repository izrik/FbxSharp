using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public static class ColorHelper
    {
        public static IEnumerable<FbxColor> ToColorList(this IEnumerable<double> values)
        {
            int k = 0;
            double r = 0;
            double g = 0;
            double b = 0;
            foreach (var v in values)
            {
                switch (k % 4)
                {
                    case 0: r = v; break;
                    case 1: g = v; break;
                    case 2: b = v; break;
                    case 3:
                        yield return new FbxColor(r, g, b, v);
                        break;
                }
                k++;
            }

            yield break;
        }
    }
}
