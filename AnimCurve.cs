using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class AnimCurve : FbxObject
    {
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

        public virtual void KeyClear()
        {
            throw new NotImplementedException();
        }

        public virtual int KeyGetCount()
        {
            throw new NotImplementedException();
        }

        public virtual int KeyAdd(FbxTime pTime, AnimCurveKeyBase pKey/*, int *pLast=NULL*/)
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

        public virtual bool KeySet(int pIndex, AnimCurveKeyBase pKey)
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

