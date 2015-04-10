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
            return new FbxTimeSpan(LocalStart.Get(), LocalStop.Get());
        }

        public void SetLocalTimeSpan(FbxTimeSpan pTimeSpan)
        {
            LocalStart.Set(pTimeSpan.GetStart());
            LocalStop.Set(pTimeSpan.GetStop());
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

