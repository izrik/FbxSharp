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

        public enum EMode
        {
            eDefaultMode,
            eFrames120,
            eFrames100,
            eFrames60,
            eFrames50,
            eFrames48,
            eFrames30,
            eFrames30Drop,
            eNTSCDropFrame,
            eNTSCFullFrame,
            ePAL,
            eFrames24,
            eFrames1000,
            eFilmFullFrame,
            eCustom,
            eFrames96,
            eFrames72,
            eFrames59dot94,
            eFrames119dot88,
            eModesCount
        }

        public FbxTime(long time)
        {
            Value = time;
        }

        public long Value;

        public long Get()
        {
            return Value;
        }

        public long GetMilliSeconds()
        {
            return Value / FBXSDK_TC_MILLISECOND;
        }

        public double GetSecondDouble()
        {
            return Value / (double)UnitsPerSecond;
        }

        public int GetSecondCount()
        {
            return (int)(Value / UnitsPerSecond);
        }

        public long GetFrameCount(EMode pTimeMode = EMode.eDefaultMode)
        {
            // TODO: take time mode into account
            return Value / (FBXSDK_TC_SECOND / 30);
        }

        public double GetFrameCountPrecise(EMode pTimeMode = EMode.eDefaultMode)
        {
            // TODO: take time mode into account
            return (double) (Value / (FBXSDK_TC_SECOND / 30));
        }
    }
    
}
