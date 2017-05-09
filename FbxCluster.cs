using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class FbxCluster : SubDeformer
    {
        public FbxCluster(string name="")
            : base(name)
        {
            Link = this.SrcObjects.CreateObjectView<Node>();
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

        public readonly ObjectView<Node> Link;

        public void SetLink(Node pNode)
        {
            if (GetLink() == pNode)
                return;

            if (GetLink() != null)
            {
                DisconnectSrcObject(GetLink());
            }

            ConnectSrcObject(pNode);
        }

        public Node GetLink()
        {
            return Link.Get();
        }

        public void SetAssociateModel(Node pNode)
        {
            throw new NotImplementedException();
        }

        public Node GetAssociateModel()
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

        public Matrix Transform = Matrix.Identity;

        public void SetTransformMatrix(Matrix pMatrix)
        {
            Transform = pMatrix;
        }

        public Matrix GetTransformMatrix(Matrix pMatrix)
        {
            return Transform;
        }

        public Matrix TransformLink = Matrix.Identity;

        public void SetTransformLinkMatrix(Matrix pMatrix)
        {
            TransformLink = pMatrix;
        }

        public Matrix GetTransformLinkMatrix(Matrix pMatrix)
        {
            return TransformLink;
        }

        public void SetTransformAssociateModelMatrix(Matrix pMatrix)
        {
            throw new NotImplementedException();
        }

        public Matrix GetTransformAssociateModelMatrix(Matrix pMatrix)
        {
            throw new NotImplementedException();
        }

        public void SetTransformParentMatrix(Matrix pMatrix)
        {
            throw new NotImplementedException();
        }

        public Matrix GetTransformParentMatrix(Matrix pMatrix)
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

