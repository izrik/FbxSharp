using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class FbxAnimCurve : FbxAnimCurveBase
    {
        public FbxAnimCurve(string name="")
            : base(name)
        {
        }

        #region Animation curve creation.

        public static FbxAnimCurve Create(FbxScene pContainer, string pName)
        {
            throw new NotImplementedException();
        }

        #endregion

        //public double DefaultValue;

        #region Key Management

        SortedList<long, FbxAnimCurveKeyBase> keys = new SortedList<long, FbxAnimCurveKeyBase>();

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
            return keys.Count;
        }

        public override int KeyAdd(FbxTime pTime, FbxAnimCurveKeyBase pKey/*, int *pLast=NULL*/)
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
            return KeyAdd(pTime, new FbxAnimCurveKey(pTime));
        }

        public override bool KeySet(int pIndex, FbxAnimCurveKeyBase pKey)
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
            FbxAnimCurveDef.EInterpolationType pInterpolation=FbxAnimCurveDef.EInterpolationType.eInterpolationCubic,
            FbxAnimCurveDef.ETangentMode pTangentMode=FbxAnimCurveDef.ETangentMode.eTangentAuto,
            float pData0=0.0f, float pData1=0.0f,
            FbxAnimCurveDef.EWeightedMode pTangentWeightMode=FbxAnimCurveDef.EWeightedMode.eWeightedNone,
            float pWeight0=FbxAnimCurveDef.sDEFAULT_WEIGHT,
            float pWeight1=FbxAnimCurveDef.sDEFAULT_WEIGHT,
            float pVelocity0=FbxAnimCurveDef.sDEFAULT_VELOCITY,
            float pVelocity1=FbxAnimCurveDef.sDEFAULT_VELOCITY)
        {
            throw new NotImplementedException();
        }

        public virtual void KeySetTCB(int pKeyIndex, FbxTime pTime, float pValue,
                float pData0=0.0f, float pData1=0.0f, float pData2=0.0f)
        {
            throw new NotImplementedException();
        }

        public virtual FbxAnimCurveDef.EInterpolationType KeyGetInterpolation(int pKeyIndex)
        {
            throw new NotImplementedException();
        }

        public virtual void KeySetInterpolation(int pKeyIndex, FbxAnimCurveDef.EInterpolationType pInterpolation)
        {
            throw new NotImplementedException();
        }

        public virtual FbxAnimCurveDef.EConstantMode KeyGetConstantMode(int pKeyIndex)
        {
            throw new NotImplementedException();
        }

        public virtual FbxAnimCurveDef.ETangentMode KeyGetTangentMode(int pKeyIndex, bool pIncludeOverrides=false)
        {
            throw new NotImplementedException();
        }

        public virtual void KeySetConstantMode(int pKeyIndex, FbxAnimCurveDef.EConstantMode pMode)
        {
            throw new NotImplementedException();
        }

        public virtual void KeySetTangentMode(int pKeyIndex, FbxAnimCurveDef.ETangentMode pTangent)
        {
            throw new NotImplementedException();
        }

        public virtual FbxAnimCurveKey KeyGet(int pIndex)
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
            var key = keys[keys.Keys[pIndex]] as FbxAnimCurveKey;
            return key.GetDataFloat(FbxAnimCurveDef.EDataIndex.eNextLeftWeight);
        }

        public virtual float KeyGetRightTangentWeight(int pIndex)
        {
            var key = keys[keys.Keys[pIndex]] as FbxAnimCurveKey;
            return key.GetDataFloat(FbxAnimCurveDef.EDataIndex.eRightWeight);
        }

        public virtual void KeySetLeftTangentWeight(int pIndex, float pWeight, bool pAdjustTan=false)
        {
            var key = keys[keys.Keys[pIndex]] as FbxAnimCurveKey;
            key.SetTangentWeightAndAdjustTangent(FbxAnimCurveDef.EDataIndex.eNextLeftWeight, pWeight);
        }

        public virtual void KeySetRightTangentWeight(int pIndex, float pWeight, bool pAdjustTan=false)
        {
            var key = keys[keys.Keys[pIndex]] as FbxAnimCurveKey;
            key.SetTangentWeightAndAdjustTangent(FbxAnimCurveDef.EDataIndex.eRightWeight, pWeight);
        }

        public virtual float KeyGetLeftTangentVelocity(int pIndex)
        {
            var key = keys[keys.Keys[pIndex]] as FbxAnimCurveKey;
            return key.GetDataFloat(FbxAnimCurveDef.EDataIndex.eNextLeftVelocity);
        }

        public virtual float KeyGetRightTangentVelocity(int pIndex)
        {
            var key = keys[keys.Keys[pIndex]] as FbxAnimCurveKey;
            return key.GetDataFloat(FbxAnimCurveDef.EDataIndex.eRightVelocity);
        }
        #endregion

        #region Evaluation and Analysis

        public override float Evaluate(FbxTime pTime/*, int *pLast=NULL*/)
        {
            if (keys.Count == 0) return 0;

            var index = keys.IndexOfOrBeforeKey(pTime.Value);

            if (index < 0)
            {
                return (keys[keys.Keys[0]] as FbxAnimCurveKey).GetValue();
            }

            var pre = (keys[keys.Keys[index]] as FbxAnimCurveKey);

            if (index >= keys.Count - 1)
            {
                return pre.GetValue();
            }

            if (pre.GetTime().Get() == pTime.Get())
            {
                return pre.GetValue();
            }

            var post = (keys[keys.Keys[index+1]] as FbxAnimCurveKey);

            double p0, p1, p2, p3;
            double s0, s1, s2, s3;
            double t0, t1, t2, t3;

            p1 = pre.GetValue();
            t1 = pre.GetTime().Get();
            p2 = post.GetValue();
            t2 = post.GetTime().Get();
            if (index > 0)
            {
                var prepre = (keys[keys.Keys[index-1]] as FbxAnimCurveKey);
                p0 = prepre.GetValue();
                t0 = prepre.GetTime().Get();
            }
            else
            {
                p0 = p1 - (p2 - p1);
                t0 = t1 - (t2 - t1);
            }
            if (index < keys.Count - 2)
            {
                var postpost = (keys[keys.Keys[index + 2]] as FbxAnimCurveKey);
                p3 = postpost.GetValue();
                t3 = postpost.GetTime().Get();
            }
            else
            {
                p3 = p2 + (p2 - p1);
                t3 = t2 + (t2 - t1);
            }

            s0 = (t0 - t1) / (t2 - t1);
            s1 = (t1 - t1) / (t2 - t1);
            s2 = (t2 - t1) / (t2 - t1);
            s3 = (t3 - t1) / (t2 - t1);

            double t = pTime.Get();
            double s = (t - t1) / (t2 - t1);

            double ss = s*s;
            double sss = ss*s;
            double m1 = (p2 - p0) / (s2 - s0);
            double m2 = (p3 - p1) / (s3 - s1);
            double x =
                (2 * sss - 3 * ss + 1) * p1 +
                (sss - 2 * ss + s) * m1 +
                (-2 * sss + 3 * ss) * p2 +
                (sss - ss) * m2;

            return (float)x;
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

        public virtual void CopyFrom(FbxAnimCurve /*&*/pSource, bool pWithKeys=true)
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

        public override string GetNameSpacePrefix()
        {
            return "AnimCurve::";
        }
    }
}

