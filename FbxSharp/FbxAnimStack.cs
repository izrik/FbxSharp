using System;

namespace FbxSharp
{
    public class FbxAnimStack : FbxCollection
    {
        public FbxAnimStack(String name = "")
            : base(name)
        {
            Description = FbxPropertyT<string>.StaticInit(this, "Description",
                null, default, false);
            LocalStart = FbxPropertyT<FbxTime>.StaticInit(this, "LocalStart",
                null, default, false);
            LocalStop = FbxPropertyT<FbxTime>.StaticInit(this, "LocalStop",
                null, default, false);
            ReferenceStart = FbxPropertyT<FbxTime>.StaticInit(this,
                "ReferenceStart", null, default, false);
            ReferenceStop = FbxPropertyT<FbxTime>.StaticInit(this,
                "ReferenceStop", null, default, false);
        }

        #region Public Attributes

        public readonly FbxPropertyT<string> Description;
        public readonly FbxPropertyT<FbxTime> LocalStart;
        public readonly FbxPropertyT<FbxTime> LocalStop;
        public readonly FbxPropertyT<FbxTime> ReferenceStart;
        public readonly FbxPropertyT<FbxTime> ReferenceStop;

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
            return new FbxTimeSpan(ReferenceStart.Get(), ReferenceStop.Get());
        }

        public void SetReferenceTimeSpan(FbxTimeSpan pTimeSpan)
        {
            ReferenceStart.Set(pTimeSpan.GetStart());
            ReferenceStop.Set(pTimeSpan.GetStop());
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

