using System;

namespace FbxSharp
{
    public static class FbxAnimCurveDef
    {
        public const float  sDEFAULT_WEIGHT = 1/3.0f;
        public const float  sMIN_WEIGHT = 0.000099999997f;
        public const float  sMAX_WEIGHT = 0.99f;
        public const float  sDEFAULT_VELOCITY = 0;

        [Flags]
        public enum ETangentMode
        {
            eTangentAuto =                       0x00000100,
            eTangentTCB =                        0x00000200,
            eTangentUser =                       0x00000400,
            eTangentGenericBreak =               0x00000800,
            eTangentBreak =                      eTangentGenericBreak | eTangentUser,
            eTangentAutoBreak =                  eTangentGenericBreak | eTangentAuto,
            eTangentGenericClamp =               0x00001000,
            eTangentGenericTimeIndependent =     0x00002000,
            eTangentGenericClampProgressive =    0x00004000 | eTangentGenericTimeIndependent
        }

        [Flags]
        public enum EInterpolationType
        {
            eInterpolationConstant =             0x00000002,
            eInterpolationLinear =               0x00000004,
            eInterpolationCubic =                0x00000008
        }

        [Flags]
        public enum EWeightedMode
        {
            eWeightedNone =                      0x00000000,
            eWeightedRight =                     0x01000000,
            eWeightedNextLeft =                  0x02000000,
            eWeightedAll =                       eWeightedRight | eWeightedNextLeft
        }

        [Flags]
        public enum EConstantMode
        {
            eConstantStandard =                  0x00000000,
            eConstantNext =                      0x00000100
        }

        [Flags]
        public enum EVelocityMode
        {
            eVelocityNone =                      0x00000000,
            eVelocityRight =                     0x10000000,
            eVelocityNextLeft =                  0x20000000,
            eVelocityAll =                       eVelocityRight | eVelocityNextLeft
        }

        [Flags]
        public enum ETangentVisibility
        {
            eTangentShowNone =                   0x00000000,
            eTangentShowLeft =                   0x00100000,
            eTangentShowRight =                  0x00200000,
            eTangentShowBoth =                   eTangentShowLeft | eTangentShowRight
        }

        public enum EDataIndex
        {
            eRightSlope =        0,
            eNextLeftSlope =     1,
            eWeights =           2,
            eRightWeight =       2,
            eNextLeftWeight =    3,
            eVelocity =          4,
            eRightVelocity =     4,
            eNextLeftVelocity =  5,
            eTCBTension =        0,
            eTCBContinuity =     1,
            eTCBBias =           2
        }
    }
}

