using System;

namespace FbxSharp
{
    public struct FbxTimeSpan
    {
        public FbxTime Start;
        public FbxTime Stop;

        #region Public Member Functions
        
        // Deviation from SDK: no zero-parameter constructor

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
            return new FbxTime(GetStop().Get() - GetStart().Get());
        }

        public FbxTime GetSignedDuration()
        {
            return new FbxTime(GetStop().Get() - GetStart().Get());
        }

        public int GetDirection()
        {
            if (GetStop().Get() >= GetStart().Get()) return 1;
            return -1;
        }

        public bool IsInside(FbxTime pTime)
        {
            throw new NotImplementedException();
        }

        //public FbxTimeSpan Intersect(FbxTimeSpan &pTime)
        //public bool operator!=(FbxTimeSpan &pTime)
        //public bool operator==(FbxTimeSpan &pTime)
        //public void UnionAssignment(FbxTimeSpan &pSpan, int pDirection=FBXSDK_TIME_FORWARD)
        
        #endregion
    }
}
