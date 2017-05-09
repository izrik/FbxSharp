using System;

namespace FbxSharp
{
    public abstract class FbxAnimCurveBase : FbxObject
    {
        protected FbxAnimCurveBase(string name="")
            : base(name)
        {
        }

        #region Key Management

        public abstract void KeyClear();

        public abstract int KeyGetCount();

        public abstract int KeyAdd(FbxTime pTime, FbxAnimCurveKeyBase pKey/*, int *pLast=NULL*/);

        public abstract bool KeySet(int pIndex, FbxAnimCurveKeyBase pKey);

        public abstract bool KeyRemove(int pIndex);

        public abstract bool KeyRemove(int pStartIndex, int pEndIndex);

        #endregion

        #region Key Time Manipulation

        public virtual FbxTime KeyGetTime(int pKeyIndex)
        {
            throw new NotImplementedException();
        }

        public abstract void KeySetTime(int pKeyIndex, FbxTime pTime);

        #endregion

        #region Extrapolation

        public enum EExtrapolationType
        {
            eant = 1,
            eRepetition = 2,
            eMirrorRepetition = 3,
            eKeepSlope = 4
        }

        public void SetPreExtrapolation(EExtrapolationType pExtrapolation)
        {
            throw new NotImplementedException();
        }

        public EExtrapolationType GetPreExtrapolation()
        {
            throw new NotImplementedException();
        }

        public void SetPreExtrapolationCount(ulong pCount)
        {
            throw new NotImplementedException();
        }

        public ulong GetPreExtrapolationCount()
        {
            throw new NotImplementedException();
        }

        public void SetPostExtrapolation(EExtrapolationType pExtrapolation)
        {
            throw new NotImplementedException();
        }

        public EExtrapolationType GetPostExtrapolation()
        {
            throw new NotImplementedException();
        }

        public void SetPostExtrapolationCount(ulong pCount)
        {
            throw new NotImplementedException();
        }

        public ulong GetPostExtrapolationCount()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Evaluation and Analysis

        public abstract float Evaluate(FbxTime pTime/*, int *pLast=NULL*/);

        public abstract float EvaluateIndex(double pIndex);

        #endregion

        #region Utility functions.

        public virtual bool GetTimeInterval(out FbxTimeSpan pTimeInterval)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

