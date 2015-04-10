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

        public AnimCurveDef.EInterpolationType GetInterpolation()
        {
            throw new NotImplementedException();
        }

        public void SetInterpolation(AnimCurveDef.EInterpolationType pInterpolation)
        {
            throw new NotImplementedException();
        }

        public AnimCurveDef.ETangentMode GetTangentMode(bool pIncludeOverrides=false)
        {
            throw new NotImplementedException();
        }

        public void SetTangentMode(AnimCurveDef.ETangentMode pTangentMode)
        {
            throw new NotImplementedException();
        }

        public AnimCurveDef.EWeightedMode GetTangentWeightMode()
        {
            throw new NotImplementedException();
        }

        public void SetTangentWeightMode(AnimCurveDef.EWeightedMode pTangentWeightMode, AnimCurveDef.EWeightedMode pMask=AnimCurveDef.EWeightedMode.eWeightedAll)
        {
            throw new NotImplementedException();
        }

        public void SetTangentWeightAndAdjustTangent(AnimCurveDef.EDataIndex pIndex, double pWeight)
        {
            throw new NotImplementedException();
        }

        public AnimCurveDef.EVelocityMode GetTangentVelocityMode()
        {
            throw new NotImplementedException();
        }

        public void SetTangentVelocityMode(AnimCurveDef.EVelocityMode pTangentVelocityMode, AnimCurveDef.EVelocityMode pMask=AnimCurveDef.EVelocityMode.eVelocityAll)
        {
            throw new NotImplementedException();
        }

        public AnimCurveDef.EConstantMode GetConstantMode()
        {
            throw new NotImplementedException();
        }

        public void SetConstantMode(AnimCurveDef.EConstantMode pMode)
        {
            throw new NotImplementedException();
        }

        public float GetDataFloat(AnimCurveDef.EDataIndex pIndex)
        {
            throw new NotImplementedException();
        }

        public void SetDataFloat(AnimCurveDef.EDataIndex pIndex, float pValue)
        {
            throw new NotImplementedException();
        }

        public void SetTangentVisibility(AnimCurveDef.ETangentVisibility pVisibility)
        {
            throw new NotImplementedException();
        }

        public AnimCurveDef.ETangentVisibility GetTangentVisibility()
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

