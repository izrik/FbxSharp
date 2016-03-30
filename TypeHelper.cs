using System;
using FbxSharp;

namespace FbxSharp
{
    public static class TypeHelper
    {
        public static string GetName(this Type type)
        {
            return type.Name;
        }

        public static string Print(this FbxTime time)
        {
            return string.Format(
                "[{0:G5}s; {1}s; {2}f; eFrames30tm]",
                //"[{0}s;{1}s;{2}f]",//;{3}tm]",
                time.GetSecondDouble(),
                (int)(time.GetSecondDouble()), //time.GetSecondCount(),
                time.GetFrameCount());//,
                //FbxTime::GetGlobalTimeMode());
        }
    }
}

