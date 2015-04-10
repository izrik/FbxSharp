using System;

namespace FbxSharp
{
    public class AnimCurveNode : FbxObject
    {
        public AnimCurveNode(String name="")
            : base(name)
        {
        }

        #region Utility Functions

        public bool IsAnimated(bool pRecurse=false)
        {
            throw new NotImplementedException();
        }

        public bool GetAnimationInterval(TimeSpan pTimeInterval)
        {
            throw new NotImplementedException();
        }

        public bool IsComposite()
        {
            throw new NotImplementedException();
        }

        public AnimCurveNode Find(string pName)
        {
            throw new NotImplementedException();
        }

        public uint GetChannelsCount()
        {
            throw new NotImplementedException();
        }

        public int GetChannelIndex(string pChannelName)
        {
            throw new NotImplementedException();
        }

        public string GetChannelName(int pChannelId)
        {
            throw new NotImplementedException();
        }

        public void ResetChannels()
        {
            throw new NotImplementedException();
        }

        public bool AddChannel<T>(string pChnlName, T pValue)
        {
            throw new NotImplementedException();
        }

        public void SetChannelValue<T>(string pChnlName, T pValue)
        {
            throw new NotImplementedException();
        }

        public void SetChannelValue<T>(uint pChnlId, T pValue)
        {
            throw new NotImplementedException();
        }

        public T GetChannelValue<T>(string pChnlName, T pInitVal)
        {
            throw new NotImplementedException();
        }

        public T GetChannelValue<T>(uint pChnlId, T pInitVal)
        {
            throw new NotImplementedException();
        }

        public static AnimCurveNode CreateTypedCurveNode(Property pProperty, Scene pScene)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Animation Curve Management

        public bool DisconnectFromChannel(AnimCurve pCurve, uint pChnlId)
        {
            throw new NotImplementedException();
        }

        public bool ConnectToChannel(AnimCurve pCurve, string pChnl, bool pInFront=false)
        {
            throw new NotImplementedException();
        }

        public bool ConnectToChannel(AnimCurve pCurve, uint pChnlId, bool pInFront=false)
        {
            throw new NotImplementedException();
        }

        public AnimCurve CreateCurve(string pCurveNodeName, string pChannel)
        {
            throw new NotImplementedException();
        }

        public AnimCurve CreateCurve(string pCurveNodeName, uint pChannelId=0)
        {
            throw new NotImplementedException();
        }

        public int GetCurveCount(uint pChannelId, string pCurveNodeName=null)
        {
            throw new NotImplementedException();
        }

        public AnimCurve GetCurve(uint pChannelId, uint pId=0, string pCurveNodeName=null)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}

