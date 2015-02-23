using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class AnimationCurve : FbxObject
    {
        public double DefaultValue;

        public List<AnimationCurveKey> Keys = new List<AnimationCurveKey>();

        [Flags]
        public enum ETangentMode
        {
            TangentAuto =                       0x00000100,
            TangentTCB =                        0x00000200,
            TangentUser =                       0x00000400,
            TangentGenericBreak =               0x00000800,
            TangentBreak =                      TangentGenericBreak | TangentUser,
            TangentAutoBreak =                  TangentGenericBreak | TangentAuto,
            TangentGenericClamp =               0x00001000,
            TangentGenericTimeIndependent =     0x00002000,
            TangentGenericClampProgressive =    0x00004000 | TangentGenericTimeIndependent
        }

        [Flags]
        public enum EInterpolationType
        {
            InterpolationConstant =             0x00000002,
            InterpolationLinear =               0x00000004,
            InterpolationCubic =                0x00000008
        }

        [Flags]
        public enum EWeightedMode
        {
            WeightedNone =                      0x00000000,
            WeightedRight =                     0x01000000,
            WeightedNextLeft =                  0x02000000,
            WeightedAll =                       WeightedRight | WeightedNextLeft
        }

        [Flags]
        public enum EConstantMode
        {
            ConstantStandard =                  0x00000000,
            ConstantNext =                      0x00000100
        }

        [Flags]
        public enum EVelocityMode
        {
            VelocityNone =                      0x00000000,
            VelocityRight =                     0x10000000,
            VelocityNextLeft =                  0x20000000,
            VelocityAll =                       VelocityRight | VelocityNextLeft
        }

        [Flags]
        public enum ETangentVisibility
        {
            TangentShowNone =                   0x00000000,
            TangentShowLeft =                   0x00100000,
            TangentShowRight =                  0x00200000,
            TangentShowBoth =                   TangentShowLeft | TangentShowRight
        }

        public enum EDataIndex
        {
            RightSlope =        0,
            NextLeftSlope =     1,
            Weights =           2,
            RightWeight =       2,
            NextLeftWeight =    3,
            Velocity =          4,
            RightVelocity =     4,
            NextLeftVelocity =  5,
            TCBTension =        0,
            TCBContinuity =     1,
            TCBBias =           2
        }
    }
}

