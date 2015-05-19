using System;

namespace FbxSharp
{
    public class AnimCurveKey : AnimCurveKeyBase
    {
        #region Public Member Functions

        public AnimCurveKey(FbxTime? pTime=null, float pVal=0)
        {
            if (pTime.HasValue)
            {
                Time = pTime.Value;
            }
            else
            {
                Time = new FbxTime(0);
            }

            Value = pVal;
        }

        public FbxTime Time;
        public float Value;
        public bool Break;
        public AnimCurveDef.ETangentMode TangentMode = AnimCurveDef.ETangentMode.eTangentAuto;
        public AnimCurveDef.EInterpolationType Interpolation = AnimCurveDef.EInterpolationType.eInterpolationCubic;
        public AnimCurveDef.EWeightedMode TangentWeightMode = AnimCurveDef.EWeightedMode.eWeightedNone;
        public AnimCurveDef.EConstantMode ConstantMode = AnimCurveDef.EConstantMode.eConstantNext;
        public AnimCurveDef.EVelocityMode TangentVelocityMode = AnimCurveDef.EVelocityMode.eVelocityNone;
        public AnimCurveDef.ETangentVisibility TangentVisibility = AnimCurveDef.ETangentVisibility.eTangentShowNone;

        float[] DataFloat = {
            0,                              // eRightSlope, eTCBTension
            0,                              // eNextLeftSlope, eTCBContinuity
            AnimCurveDef.sDEFAULT_WEIGHT,   // eRightWeight, eTCBBias
            AnimCurveDef.sDEFAULT_WEIGHT,   // eNextLeftWeight
            AnimCurveDef.sDEFAULT_VELOCITY, // eRightVelocity
            AnimCurveDef.sDEFAULT_VELOCITY, // eNextLeftVelocity
        };

        public override FbxTime GetTime()
        {
            return Time;
        }

        public override void SetTime(FbxTime pTime)
        {
            Time = pTime;
        }

        public void Set(FbxTime pTime, float pValue)
        {
            Time = pTime;
            Value = pValue;
        }

        public void SetTCB(FbxTime pTime, float pValue, float pData0=0.0f, float pData1=0.0f, float pData2=0.0f)
        {
            throw new NotImplementedException();
        }

        public float GetValue()
        {
            return Value;
        }

        public void SetValue(float pValue)
        {
            Value = pValue;
        }

        public AnimCurveDef.EInterpolationType GetInterpolation()
        {
            return Interpolation;
        }

        public void SetInterpolation(AnimCurveDef.EInterpolationType pInterpolation)
        {
            Interpolation = pInterpolation;
        }

        public AnimCurveDef.ETangentMode GetTangentMode(bool pIncludeOverrides=false)
        {
            return TangentMode;
        }

        public void SetTangentMode(AnimCurveDef.ETangentMode pTangentMode)
        {
            TangentMode = pTangentMode;
        }

        public AnimCurveDef.EWeightedMode GetTangentWeightMode()
        {
            return TangentWeightMode;
        }

        public void SetTangentWeightMode(AnimCurveDef.EWeightedMode pTangentWeightMode, AnimCurveDef.EWeightedMode pMask=AnimCurveDef.EWeightedMode.eWeightedAll)
        {
            TangentWeightMode = (TangentWeightMode & ~(pMask & AnimCurveDef.EWeightedMode.eWeightedAll)) | pTangentWeightMode;
        }

        public void SetTangentWeightAndAdjustTangent(AnimCurveDef.EDataIndex pIndex, double pWeight)
        {
            SetDataFloat(pIndex, (float)pWeight);
        }

        public AnimCurveDef.EVelocityMode GetTangentVelocityMode()
        {
            return TangentVelocityMode;
        }

        public void SetTangentVelocityMode(AnimCurveDef.EVelocityMode pTangentVelocityMode, AnimCurveDef.EVelocityMode pMask=AnimCurveDef.EVelocityMode.eVelocityAll)
        {
            TangentVelocityMode = pTangentVelocityMode;
        }

        public AnimCurveDef.EConstantMode GetConstantMode()
        {
            return ConstantMode;
        }

        public void SetConstantMode(AnimCurveDef.EConstantMode pMode)
        {
            ConstantMode = pMode;
        }

        public float GetDataFloat(AnimCurveDef.EDataIndex pIndex)
        {
            return DataFloat[(int)pIndex];
        }

        public void SetDataFloat(AnimCurveDef.EDataIndex pIndex, float pValue)
        {
            DataFloat[(int)pIndex] = pValue;
        }

        public void SetTangentVisibility(AnimCurveDef.ETangentVisibility pVisibility)
        {
            TangentVisibility = pVisibility;
        }

        public AnimCurveDef.ETangentVisibility GetTangentVisibility()
        {
            return TangentVisibility;
        }

        public void SetBreak(bool pVal)
        {
            Break = pVal;
        }

        public bool GetBreak()
        {
            return Break;
        }

        #endregion
    }
}

