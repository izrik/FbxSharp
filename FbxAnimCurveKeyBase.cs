using System;

namespace FbxSharp
{
    public class FbxAnimCurveKeyBase
    {
        #region Public Member Functions

        public virtual FbxTime GetTime()
        {
            return mTime;
        }

        public virtual void SetTime(FbxTime pTime)
        {
            mTime = pTime;
        }

        #endregion

        #region Public Attributes

        public FbxTime mTime;

        #endregion
    }
}

