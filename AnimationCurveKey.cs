using System;

namespace FbxSharp
{
    public class AnimationCurveKey : AnimationCurveKeyBase
    {
        #region Public Member Functions

        public AnimationCurveKey(FbxTime? pTime=null, float pVal=0)
        {
            if (pTime.HasValue)
            {
                Time = pTime.Value;
            }
            else
            {
                throw new NotImplementedException();
            }

            Value = pVal;
        }

        public FbxTime Time;
        public float Value;
        public bool Break;

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

        public AnimationCurveDef.EInterpolationType GetInterpolation()
        {
            throw new NotImplementedException();
        }

        public void SetInterpolation(AnimationCurveDef.EInterpolationType pInterpolation)
        {
            throw new NotImplementedException();
        }

        public AnimationCurveDef.ETangentMode GetTangentMode(bool pIncludeOverrides=false)
        {
            throw new NotImplementedException();
        }

        public void SetTangentMode(AnimationCurveDef.ETangentMode pTangentMode)
        {
            throw new NotImplementedException();
        }

        public AnimationCurveDef.EWeightedMode GetTangentWeightMode()
        {
            throw new NotImplementedException();
        }

        public void SetTangentWeightMode(AnimationCurveDef.EWeightedMode pTangentWeightMode, AnimationCurveDef.EWeightedMode pMask=AnimationCurveDef.EWeightedMode.eWeightedAll)
        {
            throw new NotImplementedException();
        }

        public void SetTangentWeightAndAdjustTangent(AnimationCurveDef.EDataIndex pIndex, double pWeight)
        {
            throw new NotImplementedException();
        }

        public AnimationCurveDef.EVelocityMode GetTangentVelocityMode()
        {
            throw new NotImplementedException();
        }

        public void SetTangentVelocityMode(AnimationCurveDef.EVelocityMode pTangentVelocityMode, AnimationCurveDef.EVelocityMode pMask=AnimationCurveDef.EVelocityMode.eVelocityAll)
        {
            throw new NotImplementedException();
        }

        public AnimationCurveDef.EConstantMode GetConstantMode()
        {
            throw new NotImplementedException();
        }

        public void SetConstantMode(AnimationCurveDef.EConstantMode pMode)
        {
            throw new NotImplementedException();
        }

        public float GetDataFloat(AnimationCurveDef.EDataIndex pIndex)
        {
            throw new NotImplementedException();
        }

        public void SetDataFloat(AnimationCurveDef.EDataIndex pIndex, float pValue)
        {
            throw new NotImplementedException();
        }

        public void SetTangentVisibility(AnimationCurveDef.ETangentVisibility pVisibility)
        {
            throw new NotImplementedException();
        }

        public AnimationCurveDef.ETangentVisibility GetTangentVisibility()
        {
            throw new NotImplementedException();
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

