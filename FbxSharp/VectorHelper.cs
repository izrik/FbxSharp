using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public static class VectorHelper
    {
        public static IEnumerable<FbxVector2> ToVector2List(this IEnumerable<double> values)
        {
            int k = 0;
            double x = 0;
            foreach (var f in values)
            {
                if (k % 2 == 0)
                    x = f;
                else
                    yield return new FbxVector2(x, f);
                k++;
            }

            yield break;
        }

        public static IEnumerable<FbxVector3> ToVector3List(this IEnumerable<double> values)
        {
            int k = 0;
            double x = 0;
            double y = 0;
            foreach (var f in values)
            {
                switch (k % 3)
                {
                case 0: x = f; break;
                case 1: y = f; break;
                case 2:
                    yield return new FbxVector3(x, y, f);
                    break;
                }
                k++;
            }

            yield break;
        }

        public static IEnumerable<FbxVector4> ToVector4List(this IEnumerable<double> values)
        {
            int k = 0;
            double x = 0;
            double y = 0;
            double z = 0;
            foreach (var f in values)
            {
                switch (k % 4)
                {
                case 0: x = f; break;
                case 1: y = f; break;
                case 2: z = f; break;
                case 3:
                    yield return new FbxVector4(x, y, z, f);
                    break;
                }
                k++;
            }

            yield break;
        }
    }
}

