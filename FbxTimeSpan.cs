using System;

namespace FbxSharp
{
    public struct FbxTimeSpan
    {
        public FbxTime Start;
        public FbxTime Stop;

        public FbxTimeSpan(FbxTime pStart, FbxTime pStop)
        {
            Start = pStart;
            Stop = pStop;
        }

        public void Set(FbxTime pStart, FbxTime pStop)
        {
            Start = pStart;
            Stop = pStop;
        }

        public void SetStart(FbxTime pStart)
        {
            Start = pStart;
        }

        public void SetStop(FbxTime pStop)
        {
            Stop = pStop;
        }

        public FbxTime GetStart()
        {
            return Start;
        }

        public FbxTime GetStop()
        {
            return Stop;
        }

        public FbxTime GetDuration()
        {
            throw new NotImplementedException();
        }

        public FbxTime GetSignedDuration()
        {
            throw new NotImplementedException();
        }

        public int GetDirection()
        {
            throw new NotImplementedException();
        }

        public bool IsInside(FbxTime pTime)
        {
            throw new NotImplementedException();
        }

        //public FbxTimeSpan Intersect(FbxTimeSpan &pTime)
        //public bool operator!=(FbxTimeSpan &pTime)
        //public bool operator==(FbxTimeSpan &pTime)
        //public void UnionAssignment(FbxTimeSpan &pSpan, int pDirection=FBXSDK_TIME_FORWARD)
    }
}
