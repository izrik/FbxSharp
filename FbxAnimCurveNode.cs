using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class FbxAnimCurveNode : FbxObject
    {
        public FbxAnimCurveNode(String name="")
            : base(name)
        {
            Properties.Add(channelRootProperty);
        }

        #region Utility Functions

        protected readonly FbxPropertyT<float> channelRootProperty = new FbxPropertyT<float>("d");

        protected class Channel
        {
            public Channel(FbxProperty prop)
            {
                Property = prop;
                Curves = prop.SrcObjects.CreateCollectionView<FbxAnimCurve>();
            }

            public string Name { get { return Property.Name; } }
            public readonly FbxProperty Property;
            public readonly CollectionView<FbxAnimCurve> Curves;
        }
        protected readonly List<Channel> channels = new List<Channel>();

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

        public FbxAnimCurveNode Find(string pName)
        {
            throw new NotImplementedException();
        }

        public uint GetChannelsCount()
        {
            return (uint)channels.Count;
        }

        public int GetChannelIndex(string pChannelName)
        {
            return channels.FindIndex(c => c.Name == pChannelName);
        }

        public string GetChannelName(int pChannelId)
        {
            return channels[pChannelId].Name;
        }

        public void ResetChannels()
        {
            throw new NotImplementedException();
        }

        public bool AddChannel<T>(string pChnlName, T pValue)
        {
            var prop = new FbxPropertyT<T>(pChnlName, pValue);
            var ch = new Channel(prop);
            Properties.Add(prop);
            channels.Add(ch);
            return true;
        }

        public void SetChannelValue<T>(string pChnlName, T pValue)
        {
            channels[GetChannelIndex(pChnlName)].Property.Set(pValue);
        }

        public void SetChannelValue<T>(uint pChnlId, T pValue)
        {
            channels[(int)pChnlId].Property.Set(pValue);
        }

        public T GetChannelValue<T>(string pChnlName, T pInitVal)
        {
            throw new NotImplementedException();
        }

        public T GetChannelValue<T>(uint pChnlId, T pInitVal)
        {
            throw new NotImplementedException();
        }

        public static FbxAnimCurveNode CreateTypedCurveNode(FbxProperty pProperty, FbxScene pScene)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Animation Curve Management

        public bool DisconnectFromChannel(FbxAnimCurve pCurve, uint pChnlId)
        {
            throw new NotImplementedException();
        }

        public bool ConnectToChannel(FbxAnimCurve pCurve, string pChnl, bool pInFront=false)
        {
            channels[GetChannelIndex(pChnl)].Property.ConnectSrcObject(pCurve);
            return true;
        }

        public bool ConnectToChannel(FbxAnimCurve pCurve, uint pChnlId, bool pInFront=false)
        {
            channels[(int)pChnlId].Property.ConnectSrcObject(pCurve);
            return true;
        }

        public FbxAnimCurve CreateCurve(string pCurveNodeName, string pChannel)
        {
            throw new NotImplementedException();
        }

        public FbxAnimCurve CreateCurve(string pCurveNodeName, uint pChannelId=0)
        {
            throw new NotImplementedException();
        }

        public int GetCurveCount(uint pChannelId, string pCurveNodeName=null)
        {
            return channels[(int)pChannelId].Curves.Count;
        }

        public FbxAnimCurve GetCurve(uint pChannelId, uint pId=0, string pCurveNodeName=null)
        {
            return channels[(int)pChannelId].Curves[(int)pId];
        }


        #endregion

        public override string GetNameSpacePrefix()
        {
            return "AnimCurveNode::";
        }
    }
}

