using System;

namespace FbxSharp
{
    public struct FbxTime
    {
        public static readonly FbxTime Infinite = new FbxTime(0x7fffffffffffffffL);
        public static readonly FbxTime Zero = new FbxTime(0);

        public const long UnitsPerSecond = 141120000L;

        public const long FBXSDK_TC_MILLISECOND = 141120L;
        public const long FBXSDK_TC_SECOND = 141120000L;
        public const long FBXSDK_TC_LEGACY_MILLISECOND = 46186158L;

        public const int FBXSDK_TC_STANDARD_DEFINITION = 0;
        public const int FBXSDK_TC_LEGACY_DEFINITION = 127;

        public FbxTime(long time)
        {
            Value = time;
        }

        public long Value;

        public long Get()
        {
            return Value;
        }

        public double GetSecondDouble()
        {
            return Value / (double)UnitsPerSecond;
        }

        public int GetSecondCount()
        {
            return (int)(Value / UnitsPerSecond);
        }

        public long GetFrameCount()
        {
            return Value / 4704000;
        }
    }
    
}
