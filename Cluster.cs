using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class Cluster : SubDeformer
    {
        public Cluster(string name="")
            : base(name)
        {
        }

        public List<long> Indexes;
        public List<double> Weights;

        public Matrix Transform;
        public Matrix TransformLink;

        #region Public Member Functions

        public void SetControlPointIWCount(int pCount)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region General Functions

        public override EType GetSubDeformerType()
        {
            throw new NotImplementedException();
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

        public void SetLinkMode(ELinkMode pMode)
        {
            throw new NotImplementedException();
        }

        public ELinkMode GetLinkMode()
        {
            throw new NotImplementedException();
        }

        public void SetLink(Node pNode)
        {
            throw new NotImplementedException();
        }

        public Node GetLink()
        {
            throw new NotImplementedException();
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

        public void SetTransformMatrix(Matrix pMatrix)
        {
            throw new NotImplementedException();
        }

        public Matrix GetTransformMatrix(Matrix pMatrix)
        {
            throw new NotImplementedException();
        }

        public void SetTransformLinkMatrix(Matrix pMatrix)
        {
            throw new NotImplementedException();
        }

        public Matrix GetTransformLinkMatrix(Matrix pMatrix)
        {
            throw new NotImplementedException();
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

