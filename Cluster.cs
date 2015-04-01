using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class Cluster : SubDeformer
    {
        public Cluster(string name="")
            : base(name)
        {
            Link = this.SrcObjects.CreateObjectView<Node>();
        }

        public List<long> Indexes;
        public List<double> Weights;

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

        public ELinkMode LinkMode;

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

        public void AddControlPointIndex(int pIndex, double pWeight)
        {
            throw new NotImplementedException();
        }

        public int GetControlPointIndicesCount()
        {
            throw new NotImplementedException();
        }

        public int GetControlPointIndices()
        {
            throw new NotImplementedException();
        }

        public double GetControlPointWeights()
        {
            throw new NotImplementedException();
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

