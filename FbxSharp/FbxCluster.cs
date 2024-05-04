using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class FbxCluster : FbxSubDeformer
    {
        public FbxCluster(string name="")
            : base(name)
        {
            Link = this.SrcObjects.CreateObjectView<FbxNode>();
        }

        #region Public Member Functions

        public void SetControlPointIWCount(int pCount)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region General Functions

        public override EType GetSubDeformerType()
        {
            return EType.eCluster;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Link Mode, Link Node, Associate Model

        public enum ELinkMode
        {
            eNormalize,
            eAdditive,
            eTotalOne,
        }

        public ELinkMode LinkMode = ELinkMode.eNormalize;

        public void SetLinkMode(ELinkMode pMode)
        {
            LinkMode = pMode;
        }

        public ELinkMode GetLinkMode()
        {
            return LinkMode;
        }

        public readonly ObjectView<FbxNode> Link;

        public void SetLink(FbxNode pNode)
        {
            if (GetLink() == pNode)
                return;

            if (GetLink() != null)
            {
                DisconnectSrcObject(GetLink());
            }

            ConnectSrcObject(pNode);
        }

        public FbxNode GetLink()
        {
            return Link.Get();
        }

        public void SetAssociateModel(FbxNode pNode)
        {
            throw new NotImplementedException();
        }

        public FbxNode GetAssociateModel()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Control Points

        public readonly List<int> ControlPointIndices = new List<int>();
        public readonly List<double> ControlPointWeights = new List<double>();

        public void AddControlPointIndex(int pIndex, double pWeight)
        {
            ControlPointIndices.Add(pIndex);
            ControlPointWeights.Add(pWeight);
        }

        public int GetControlPointIndicesCount()
        {
            return ControlPointIndices.Count;
        }

        public IList<int> GetControlPointIndices()
        {
            return ControlPointIndices;
        }

        public IList<double> GetControlPointWeights()
        {
            return ControlPointWeights;
        }

        #endregion

        #region Transformation matrices

        public FbxMatrix Transform = FbxMatrix.Identity;

        public void SetTransformMatrix(FbxMatrix pMatrix)
        {
            Transform = pMatrix;
        }

        public FbxMatrix GetTransformMatrix(FbxMatrix pMatrix)
        {
            return Transform;
        }

        public FbxMatrix TransformLink = FbxMatrix.Identity;

        public void SetTransformLinkMatrix(FbxMatrix pMatrix)
        {
            TransformLink = pMatrix;
        }

        public FbxMatrix GetTransformLinkMatrix(FbxMatrix pMatrix)
        {
            return TransformLink;
        }

        public void SetTransformAssociateModelMatrix(FbxMatrix pMatrix)
        {
            throw new NotImplementedException();
        }

        public FbxMatrix GetTransformAssociateModelMatrix(FbxMatrix pMatrix)
        {
            throw new NotImplementedException();
        }

        public void SetTransformParentMatrix(FbxMatrix pMatrix)
        {
            throw new NotImplementedException();
        }

        public FbxMatrix GetTransformParentMatrix(FbxMatrix pMatrix)
        {
            throw new NotImplementedException();
        }

        public bool IsTransformParentSet()
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}

