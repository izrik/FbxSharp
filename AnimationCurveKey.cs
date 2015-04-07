using System;

namespace FbxSharp
{
    public class AnimationCurveKey : AnimationCurveKeyBase
    {
        #region Public Member Functions

        public AnimationCurveKey()
        {
            throw new NotImplementedException();
        }

        public AnimationCurveKey(FbxTime pTime)
        {
            throw new NotImplementedException();
        }

        public AnimationCurveKey(FbxTime pTime, float pVal)
        {
            throw new NotImplementedException();
        }

        public override FbxTime GetTime()
        {
            throw new NotImplementedException();
        }

        public override void SetTime(FbxTime pTime)
        {
            throw new NotImplementedException();
        }

        public void Set(FbxTime pTime, float pValue)
        {
            throw new NotImplementedException();
        }

        public void SetTCB(FbxTime pTime, float pValue, float pData0=0.0f, float pData1=0.0f, float pData2=0.0f)
        {
            throw new NotImplementedException();
        }

        public float GetValue()
        {
            throw new NotImplementedException();
        }

        public void SetValue(float pValue)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool GetBreak()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

