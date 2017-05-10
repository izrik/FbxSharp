using System;

namespace FbxSharp
{
    public class FbxAnimStack : FbxCollection
    {
        public FbxAnimStack(String name="")
            : base(name)
        {
            Properties.Add(Description);
            Properties.Add(LocalStart);
            Properties.Add(LocalStop);
            Properties.Add(ReferenceStart);
            Properties.Add(ReferenceStop);
        }

        #region Public Attributes

        public readonly FbxPropertyT<string>   Description     = new FbxPropertyT<string>( "Description");
        public readonly FbxPropertyT<FbxTime>  LocalStart      = new FbxPropertyT<FbxTime>("LocalStart");
        public readonly FbxPropertyT<FbxTime>  LocalStop       = new FbxPropertyT<FbxTime>("LocalStop");
        public readonly FbxPropertyT<FbxTime>  ReferenceStart  = new FbxPropertyT<FbxTime>("ReferenceStart");
        public readonly FbxPropertyT<FbxTime>  ReferenceStop   = new FbxPropertyT<FbxTime>("ReferenceStop");

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

        public bool BakeLayers(FbxAnimEvaluator pEvaluator, FbxTime pStart, FbxTime pStop, FbxTime pPeriod)
        {
            throw new NotImplementedException();
        }

        #endregion

        public override string GetNameSpacePrefix()
        {
            return "AnimStack::";
        }
    }
}

