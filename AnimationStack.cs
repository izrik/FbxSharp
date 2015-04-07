using System;

namespace FbxSharp
{
    public class AnimationStack : Collection
    {
        #region Public Attributes

        public readonly PropertyT<string>   Description     = new PropertyT<string>( "Description");
        public readonly PropertyT<FbxTime>  LocalStart      = new PropertyT<FbxTime>("LocalStart");
        public readonly PropertyT<FbxTime>  LocalStop       = new PropertyT<FbxTime>("LocalStop");
        public readonly PropertyT<FbxTime>  ReferenceStart  = new PropertyT<FbxTime>("ReferenceStart");
        public readonly PropertyT<FbxTime>  ReferenceStop   = new PropertyT<FbxTime>("ReferenceStop");

        #endregion

        #region Utility functions.

        public FbxTimeSpan GetLocalTimeSpan()
        {
            throw new NotImplementedException();
        }

        public void SetLocalTimeSpan(FbxTimeSpan pTimeSpan)
        {
            throw new NotImplementedException();
        }

        public FbxTimeSpan GetReferenceTimeSpan()
        {
            throw new NotImplementedException();
        }

        public void SetReferenceTimeSpan(FbxTimeSpan pTimeSpan)
        {
            throw new NotImplementedException();
        }

        public bool BakeLayers(AnimEvaluator pEvaluator, FbxTime pStart, FbxTime pStop, FbxTime pPeriod)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

