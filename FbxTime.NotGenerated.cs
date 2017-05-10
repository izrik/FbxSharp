using System;

namespace FbxSharp
{
    public struct FbxTime
    {
        public static readonly FbxTime Infinite = new FbxTime(0x7fffffffffffffffL);
        public static readonly FbxTime Zero = new FbxTime(0);

        public const long UnitsPerSecond = 46186158000L;

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

        public long GetFrameCount()
        {
            return Value / 1539538600L;
        }
    }
    
}
