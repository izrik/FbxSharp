using System;

namespace FbxSharp
{
    public struct AnimationCurveKey
    {
        public AnimationCurveKey(long time, double value)
        {
            Time = time;
            Value = value;
        }

        public readonly long Time;
        public readonly double Value;
    }
}

