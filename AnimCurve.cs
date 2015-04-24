using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class AnimCurve : AnimCurveBase
    {
        public AnimCurve(string name="")
            : base(name)
        {
        }

        #region Animation curve creation.

        public static AnimCurve Create(Scene pContainer, string pName)
        {
            throw new NotImplementedException();
        }

        #endregion

        //public double DefaultValue;

        #region Key Management

        SortedList<long, AnimCurveKeyBase> keys = new SortedList<long, AnimCurveKeyBase>();

        public virtual void ResizeKeyBuffer(int pKeyCount)
        {
            throw new NotImplementedException();
        }

        public virtual void KeyModifyBegin()
        {
            throw new NotImplementedException();
        }

        public virtual void KeyModifyEnd()
        {
            throw new NotImplementedException();
        }

        public override void KeyClear()
        {
            throw new NotImplementedException();
        }

        public override int KeyGetCount()
        {
            throw new NotImplementedException();
        }

        public override int KeyAdd(FbxTime pTime, AnimCurveKeyBase pKey/*, int *pLast=NULL*/)
        {
            if (keys.ContainsKey(pTime.Value))
            {
                keys[pTime.Value] = pKey;
            }
            else
            {
                keys.Add(pTime.Value, pKey);
            }

            return keys.IndexOfKey(pTime.Value);
        }

        public virtual int KeyAdd(FbxTime pTime/*, int *pLast=NULL*/)
        {
            return KeyAdd(pTime, new AnimCurveKey(pTime));
        }

        public override bool KeySet(int pIndex, AnimCurveKeyBase pKey)
        {
            throw new NotImplementedException();
        }

        public override bool KeyRemove(int pIndex)
        {
            throw new NotImplementedException();
        }

        public override bool KeyRemove(int pStartIndex, int pEndIndex)
        {
            throw new NotImplementedException();
        }

        public virtual int KeyInsert(FbxTime pTime/*, int *pLast=NULL*/)
        {
            throw new NotImplementedException();
        }

        public virtual double KeyFind(FbxTime pTime/*, int *pLast=NULL*/)
        {
            throw new NotImplementedException();
        }

        public virtual bool KeyScaleValue(float pMultValue)
        {
            throw new NotImplementedException();
        }

        public virtual bool KeyScaleValueAndTangent(float pMultValue)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Key Manipulation

        public virtual void KeySet(int pKeyIndex, FbxTime pTime, float pValue,
            AnimCurveDef.EInterpolationType pInterpolation=AnimCurveDef.EInterpolationType.eInterpolationCubic,
            AnimCurveDef.ETangentMode pTangentMode=AnimCurveDef.ETangentMode.eTangentAuto,
            float pData0=0.0f, float pData1=0.0f,
            AnimCurveDef.EWeightedMode pTangentWeightMode=AnimCurveDef.EWeightedMode.eWeightedNone,
            float pWeight0=AnimCurveDef.sDEFAULT_WEIGHT,
            float pWeight1=AnimCurveDef.sDEFAULT_WEIGHT,
            float pVelocity0=AnimCurveDef.sDEFAULT_VELOCITY,
            float pVelocity1=AnimCurveDef.sDEFAULT_VELOCITY)
        {
            throw new NotImplementedException();
        }

        public virtual void KeySetTCB(int pKeyIndex, FbxTime pTime, float pValue,
                float pData0=0.0f, float pData1=0.0f, float pData2=0.0f)
        {
            throw new NotImplementedException();
        }

        public virtual AnimCurveDef.EInterpolationType KeyGetInterpolation(int pKeyIndex)
        {
            throw new NotImplementedException();
        }

        public virtual void KeySetInterpolation(int pKeyIndex, AnimCurveDef.EInterpolationType pInterpolation)
        {
            throw new NotImplementedException();
        }

        public virtual AnimCurveDef.EConstantMode KeyGetConstantMode(int pKeyIndex)
        {
            throw new NotImplementedException();
        }

        public virtual AnimCurveDef.ETangentMode KeyGetTangentMode(int pKeyIndex, bool pIncludeOverrides=false)
        {
            throw new NotImplementedException();
        }

        public virtual void KeySetConstantMode(int pKeyIndex, AnimCurveDef.EConstantMode pMode)
        {
            throw new NotImplementedException();
        }

        public virtual void KeySetTangentMode(int pKeyIndex, AnimCurveDef.ETangentMode pTangent)
        {
            throw new NotImplementedException();
        }

        public virtual AnimCurveKey KeyGet(int pIndex)
        {
            throw new NotImplementedException();
        }

        public virtual float KeyGetValue(int pKeyIndex)
        {
            throw new NotImplementedException();
        }

        public virtual void KeySetValue(int pKeyIndex, float pValue)
        {
            throw new NotImplementedException();
        }

        public virtual void KeyIncValue(int pKeyIndex, float pValue)
        {
            throw new NotImplementedException();
        }

        public virtual void KeyMultValue(int pKeyIndex, float pValue)
        {
            throw new NotImplementedException();
        }

        public virtual void KeyMultTangent(int pKeyIndex, float pValue)
        {
            throw new NotImplementedException();
        }

        public override FbxTime KeyGetTime(int pKeyIndex)
        {
            throw new NotImplementedException();
        }

        public override void KeySetTime(int pKeyIndex, FbxTime pTime)
        {
            throw new NotImplementedException();
        }

        public virtual void KeySetBreak(int pKeyIndex, bool pVal)
        {
            throw new NotImplementedException();
        }

        public virtual bool KeyGetBreak(int pKeyIndex)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Key Tangent Management

        public virtual float KeyGetLeftDerivative(int pIndex)
        {
            throw new NotImplementedException();
        }

        public virtual void KeySetLeftDerivative(int pIndex, float pValue)
        {
            throw new NotImplementedException();
        }

        public virtual float KeyGetLeftAuto(int pIndex, bool pApplyOvershootProtection=false)
        {
            throw new NotImplementedException();
        }

        //public virtual FbxAnimCurveTangentInfo KeyGetLeftDerivativeInfo(int pIndex)
        //{
        //    throw new NotImplementedException();
        //}

        //public virtual void KeySetLeftDerivativeInfo(int pIndex, /*const*/ FbxAnimCurveTangentInfo /*&*/pValue, bool pForceDerivative=false)
        //{
        //    throw new NotImplementedException();
        //}

        public virtual float KeyGetRightDerivative(int pIndex)
        {
            throw new NotImplementedException();
        }

        public virtual void KeySetRightDerivative(int pIndex, float pValue)
        {
            throw new NotImplementedException();
        }

        public virtual float KeyGetRightAuto(int pIndex, bool pApplyOvershootProtection=false)
        {
            throw new NotImplementedException();
        }

        //public virtual FbxAnimCurveTangentInfo KeyGetRightDerivativeInfo(int pIndex)
        //{
        //    throw new NotImplementedException();
        //}

        //public virtual void KeySetRightDerivativeInfo(int pIndex, /*const*/ FbxAnimCurveTangentInfo /*&*/pValue, bool pForceDerivative=false)
        //{
        //    throw new NotImplementedException();
        //}

        public virtual bool KeyIsLeftTangentWeighted(int pIndex)
        {
            throw new NotImplementedException();
        }

        public virtual bool KeyIsRightTangentWeighted(int pIndex)
        {
            throw new NotImplementedException();
        }

        public virtual float KeyGetLeftTangentWeight(int pIndex)
        {
            throw new NotImplementedException();
        }

        public virtual float KeyGetRightTangentWeight(int pIndex)
        {
            throw new NotImplementedException();
        }

        public virtual void KeySetLeftTangentWeight(int pIndex, float pWeight, bool pAdjustTan=false)
        {
            throw new NotImplementedException();
        }

        public virtual void KeySetRightTangentWeight(int pIndex, float pWeight, bool pAdjustTan=false)
        {
            throw new NotImplementedException();
        }

        public virtual float KeyGetLeftTangentVelocity(int pIndex)
        {
            throw new NotImplementedException();
        }

        public virtual float KeyGetRightTangentVelocity(int pIndex)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Evaluation and Analysis

        public override float Evaluate(FbxTime pTime/*, int *pLast=NULL*/)
        {
            if (keys.Count == 0) return 0;

            var index = keys.IndexOfOrBeforeKey(pTime.Value);

            if (index < 0)
            {
                return (keys[keys.Keys[0]] as AnimCurveKey).GetValue();
            }

            return (keys[keys.Keys[index]] as AnimCurveKey).GetValue();
        }

        public override float EvaluateIndex(double pIndex)
        {
            throw new NotImplementedException();
        }

        public virtual float EvaluateLeftDerivative(FbxTime pTime/*, int *pLast=NULL*/)
        {
            throw new NotImplementedException();
        }

        public virtual float EvaluateRightDerivative(FbxTime pTime/*, int *pLast=NULL*/)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Utility functions.

        public virtual bool GetTimeInterval(FbxTimeSpan /*&*/pTimeInterval)
        {
            throw new NotImplementedException();
        }

        public virtual void CopyFrom(AnimCurve /*&*/pSource, bool pWithKeys=true)
        {
            throw new NotImplementedException();
        }

        public virtual float GetValue(int pCurveNodeIndex=0)
        {
            throw new NotImplementedException();
        }

        public virtual void SetValue(float pValue, int pCurveNodeIndex=0)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

