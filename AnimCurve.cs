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
            return keys.Count;
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
            var key = keys[keys.Keys[pIndex]] as AnimCurveKey;
            return key.GetDataFloat(AnimCurveDef.EDataIndex.eNextLeftWeight);
        }

        public virtual float KeyGetRightTangentWeight(int pIndex)
        {
            var key = keys[keys.Keys[pIndex]] as AnimCurveKey;
            return key.GetDataFloat(AnimCurveDef.EDataIndex.eRightWeight);
        }

        public virtual void KeySetLeftTangentWeight(int pIndex, float pWeight, bool pAdjustTan=false)
        {
            var key = keys[keys.Keys[pIndex]] as AnimCurveKey;
            key.SetTangentWeightAndAdjustTangent(AnimCurveDef.EDataIndex.eNextLeftWeight, pWeight);
        }

        public virtual void KeySetRightTangentWeight(int pIndex, float pWeight, bool pAdjustTan=false)
        {
            var key = keys[keys.Keys[pIndex]] as AnimCurveKey;
            key.SetTangentWeightAndAdjustTangent(AnimCurveDef.EDataIndex.eRightWeight, pWeight);
        }

        public virtual float KeyGetLeftTangentVelocity(int pIndex)
        {
            var key = keys[keys.Keys[pIndex]] as AnimCurveKey;
            return key.GetDataFloat(AnimCurveDef.EDataIndex.eNextLeftVelocity);
        }

        public virtual float KeyGetRightTangentVelocity(int pIndex)
        {
            var key = keys[keys.Keys[pIndex]] as AnimCurveKey;
            return key.GetDataFloat(AnimCurveDef.EDataIndex.eRightVelocity);
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

            var pre = (keys[keys.Keys[index]] as AnimCurveKey);

            if (index >= keys.Count - 1)
            {
                return pre.GetValue();
            }

            if (pre.GetTime().Get() == pTime.Get())
            {
                return pre.GetValue();
            }

            var post = (keys[keys.Keys[index+1]] as AnimCurveKey);

            double p0, p1, p2, p3;
            double s0, s1, s2, s3;
            double t0, t1, t2, t3;

            p1 = pre.GetValue();
            t1 = pre.GetTime().Get();
            p2 = post.GetValue();
            t2 = post.GetTime().Get();
            if (index > 0)
            {
                var prepre = (keys[keys.Keys[index-1]] as AnimCurveKey);
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
                var postpost = (keys[keys.Keys[index + 2]] as AnimCurveKey);
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

        public override string GetNameSpacePrefix()
        {
            return "AnimCurve::";
        }
    }
}

