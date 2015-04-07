using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class AnimationCurve : FbxObject
    {
        //public double DefaultValue;
        //
        //public List<AnimationCurveKey> Keys = new List<AnimationCurveKey>();

        #region Animation curve creation.

        public static AnimationCurve Create(Scene pContainer, string pName)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Key Management

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

        public virtual void KeyClear()
        {
            throw new NotImplementedException();
        }

        public virtual int KeyGetCount()
        {
            throw new NotImplementedException();
        }

        public virtual int KeyAdd(FbxTime pTime, AnimationCurveKeyBase pKey/*, int *pLast=NULL*/)
        {
            throw new NotImplementedException();
        }

        public virtual int KeyAdd(FbxTime pTime/*, int *pLast=NULL*/)
        {
            throw new NotImplementedException();
        }

        public virtual bool KeySet(int pIndex, AnimationCurveKeyBase pKey)
        {
            throw new NotImplementedException();
        }

        public virtual bool KeyRemove(int pIndex)
        {
            throw new NotImplementedException();
        }

        public virtual bool KeyRemove(int pStartIndex, int pEndIndex)
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

    }
}

