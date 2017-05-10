using System;

namespace FbxSharp
{
    public class FbxAnimCurveKey : FbxAnimCurveKeyBase
    {
        #region Public Member Functions

        public FbxAnimCurveKey(FbxTime? pTime=null, float pVal=0)
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
        public FbxAnimCurveDef.ETangentMode TangentMode = FbxAnimCurveDef.ETangentMode.eTangentAuto;
        public FbxAnimCurveDef.EInterpolationType Interpolation = FbxAnimCurveDef.EInterpolationType.eInterpolationCubic;
        public FbxAnimCurveDef.EWeightedMode TangentWeightMode = FbxAnimCurveDef.EWeightedMode.eWeightedNone;
        public FbxAnimCurveDef.EConstantMode ConstantMode = FbxAnimCurveDef.EConstantMode.eConstantNext;
        public FbxAnimCurveDef.EVelocityMode TangentVelocityMode = FbxAnimCurveDef.EVelocityMode.eVelocityNone;
        public FbxAnimCurveDef.ETangentVisibility TangentVisibility = FbxAnimCurveDef.ETangentVisibility.eTangentShowNone;

        float[] DataFloat = {
            0,                              // eRightSlope, eTCBTension
            0,                              // eNextLeftSlope, eTCBContinuity
            FbxAnimCurveDef.sDEFAULT_WEIGHT,   // eRightWeight, eTCBBias
            FbxAnimCurveDef.sDEFAULT_WEIGHT,   // eNextLeftWeight
            FbxAnimCurveDef.sDEFAULT_VELOCITY, // eRightVelocity
            FbxAnimCurveDef.sDEFAULT_VELOCITY, // eNextLeftVelocity
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

        public FbxAnimCurveDef.EInterpolationType GetInterpolation()
        {
            return Interpolation;
        }

        public void SetInterpolation(FbxAnimCurveDef.EInterpolationType pInterpolation)
        {
            Interpolation = pInterpolation;
        }

        public FbxAnimCurveDef.ETangentMode GetTangentMode(bool pIncludeOverrides=false)
        {
            return TangentMode;
        }

        public void SetTangentMode(FbxAnimCurveDef.ETangentMode pTangentMode)
        {
            TangentMode = pTangentMode;
        }

        public FbxAnimCurveDef.EWeightedMode GetTangentWeightMode()
        {
            return TangentWeightMode;
        }

        public void SetTangentWeightMode(FbxAnimCurveDef.EWeightedMode pTangentWeightMode, FbxAnimCurveDef.EWeightedMode pMask=FbxAnimCurveDef.EWeightedMode.eWeightedAll)
        {
            TangentWeightMode = (TangentWeightMode & ~(pMask & FbxAnimCurveDef.EWeightedMode.eWeightedAll)) | pTangentWeightMode;
        }

        public void SetTangentWeightAndAdjustTangent(FbxAnimCurveDef.EDataIndex pIndex, double pWeight)
        {
            SetDataFloat(pIndex, (float)pWeight);
        }

        public FbxAnimCurveDef.EVelocityMode GetTangentVelocityMode()
        {
            return TangentVelocityMode;
        }

        public void SetTangentVelocityMode(FbxAnimCurveDef.EVelocityMode pTangentVelocityMode, FbxAnimCurveDef.EVelocityMode pMask=FbxAnimCurveDef.EVelocityMode.eVelocityAll)
        {
            TangentVelocityMode = pTangentVelocityMode;
        }

        public FbxAnimCurveDef.EConstantMode GetConstantMode()
        {
            return ConstantMode;
        }

        public void SetConstantMode(FbxAnimCurveDef.EConstantMode pMode)
        {
            ConstantMode = pMode;
        }

        public float GetDataFloat(FbxAnimCurveDef.EDataIndex pIndex)
        {
            return DataFloat[(int)pIndex];
        }

        public void SetDataFloat(FbxAnimCurveDef.EDataIndex pIndex, float pValue)
        {
            DataFloat[(int)pIndex] = pValue;
        }

        public void SetTangentVisibility(FbxAnimCurveDef.ETangentVisibility pVisibility)
        {
            TangentVisibility = pVisibility;
        }

        public FbxAnimCurveDef.ETangentVisibility GetTangentVisibility()
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

