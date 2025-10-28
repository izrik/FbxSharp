using System;

namespace FbxSharp
{
    public struct FbxTimeCode
    {
        public const long FBXSDK_TC_ZERO = 0;
        public const long FBXSDK_TC_EPSILON = 1;
        public const long FBXSDK_TC_MINFINITY = -0x7fffffffffffffff;
        public const long FBXSDK_TC_INFINITY = 0x7fffffffffffffff;
        public const long FBXSDK_TC_FIX_DEN = 100000000;
        public const long FBXSDK_TC_LEGACY_MILLISECOND = 46186158;
        public const long FBXSDK_TC_LEGACY_SECOND = FBXSDK_TC_LEGACY_MILLISECOND * 1000;
        public const long FBXSDK_TC_MILLISECOND = 141120;
        public const long FBXSDK_TC_SECOND = FBXSDK_TC_MILLISECOND * 1000;
        public const long FBXSDK_TC_MINUTE = FBXSDK_TC_SECOND * 60;
        public const long FBXSDK_TC_HOUR = FBXSDK_TC_MINUTE * 60;
        public const long FBXSDK_TC_DAY = FBXSDK_TC_HOUR * 24;
        public const long FBXSDK_TC_NTSC_FIELD = FBXSDK_TC_SECOND / 30 / 2;
        public const long FBXSDK_TC_NTSC_FRAME = FBXSDK_TC_SECOND / 30;
        public const long FBXSDK_TC_MNTSC_FIELD = FBXSDK_TC_MNTSC_FRAME / 2;
        public const long FBXSDK_TC_MNTSC_FRAME = FBXSDK_TC_SECOND / 30 * 1001 / 1000;
        public const long FBXSDK_TC_MNTSC_2_FRAMES = FBXSDK_TC_MNTSC_FRAME * 2;
        public const long FBXSDK_TC_MNTSC_30_FRAMES = FBXSDK_TC_MNTSC_FRAME * 30;
        public const long FBXSDK_TC_MNTSC_1798_FRAMES = FBXSDK_TC_MNTSC_FRAME * 1798;
        public const long FBXSDK_TC_MNTSC_1800_FRAMES = FBXSDK_TC_MNTSC_FRAME * 1800;
        public const long FBXSDK_TC_MNTSC_17982_FRAMES = FBXSDK_TC_MNTSC_FRAME * 17982;
        public const long FBXSDK_TC_MNTSC_107892_FRAMES = FBXSDK_TC_MNTSC_FRAME * 107892;
        public const long FBXSDK_TC_MNTSC_108000_FRAMES = FBXSDK_TC_MNTSC_FRAME * 108000;
        public const long FBXSDK_TC_MNTSC_1_SECOND = FBXSDK_TC_MNTSC_FRAME * 30;
        public const long FBXSDK_TC_MNTSC_1_MINUTE = FBXSDK_TC_MNTSC_1_SECOND * 60;
        public const long FBXSDK_TC_MNTSC_1_HOUR = FBXSDK_TC_MNTSC_1_SECOND * 3600;
        public const ulong FBXSDK_TC_MNTSC_NUM = FBXSDK_TC_FIX_DEN * 1000 * 30 / 1001;
        public const long FBXSDK_TC_MNTSC_DEN = FBXSDK_TC_FIX_DEN;
        public const long FBXSDK_TC_PAL_FIELD = FBXSDK_TC_SECOND / 25 / 2;
        public const long FBXSDK_TC_PAL_FRAME = FBXSDK_TC_SECOND / 25;
        public const long FBXSDK_TC_FILM_FRAME = FBXSDK_TC_SECOND / 24;
        public const long FBXSDK_TC_MFILM_FIELD = FBXSDK_TC_MFILM_FRAME / 2;
        public const long FBXSDK_TC_MFILM_FRAME = FBXSDK_TC_SECOND / 24 * 1001 / 1000;
        public const long FBXSDK_TC_MFILM_1_SECOND = FBXSDK_TC_MFILM_FRAME * 24;
        public const long FBXSDK_TC_MFILM_1_MINUTE = FBXSDK_TC_MFILM_1_SECOND * 60;
        public const long FBXSDK_TC_MFILM_1_HOUR = FBXSDK_TC_MFILM_1_SECOND * 3600;
        public const ulong FBXSDK_TC_MFILM_NUM = FBXSDK_TC_FIX_DEN * 1000 * 24 / 1001;
        public const long FBXSDK_TC_MFILM_DEN = FBXSDK_TC_FIX_DEN;

        // #define 	FBXSDK_TC_REM(quot, num, den)   ((quot) = (num) / (den), (quot) * (den))
        // #define 	FBXSDK_TC_HOUR_REM(quot, num, den)   ((quot) = ((num - (-FbxLongLong(num < 0) & (den - 1))) / (den)), (quot) * (den))

        public const int FBXSDK_TC_LEGACY_DEFINITION = 127;
        public const int FBXSDK_TC_STANDARD_DEFINITION = 0;
    }
}
