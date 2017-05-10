using System;

namespace FbxSharp
{
    public class FbxSkin : FbxDeformer
    {
        public FbxSkin(string name="")
            : base(name)
        {
            Geometry = this.DstObjects.CreateObjectView<FbxGeometry>();
            Clusters = this.SrcObjects.CreateCollectionView<FbxCluster>();
        }

        public double DeformAccuracy;

        #region Public Member Functions

        public void SetDeformAccuracy(double pDeformAccuracy)
        {
            DeformAccuracy = pDeformAccuracy;
        }

        public double GetDeformAccuracy()
        {
            return DeformAccuracy;
        }

        public readonly ObjectView<FbxGeometry> Geometry;

        public bool SetGeometry(FbxGeometry pGeometry)
        {
            if (GetGeometry() != null)
            {
                DisconnectDstObject(GetGeometry());
            }

            return ConnectDstObject(pGeometry);
        }

        public FbxGeometry GetGeometry()
        {
            return Geometry.Get();
        }

        public readonly CollectionView<FbxCluster> Clusters;

        public bool AddCluster(FbxCluster pCluster)
        {
            ConnectSrcObject(pCluster);
            return true;
        }

        public FbxCluster RemoveCluster(FbxCluster pCluster)
        {
            if (DisconnectSrcObject(pCluster))
                return pCluster;

            return null;
        }

        public int GetClusterCount()
        {
            return Clusters.Count;
        }

        public FbxCluster GetCluster(int pIndex)
        {
            return Clusters[pIndex];
        }

        public override EDeformerType GetDeformerType()
        {
            return EDeformerType.eSkin;
        }

        public void SetSkinningType(EType pType)
        {
            throw new NotImplementedException();
        }

        public enum EType
        {
            eRigid,
            eLinear,
            eDualQuaternion,
            eBlend,
        }

        public EType GetSkinningType()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Control Points

        public void AddControlPointIndex(int pIndex, double pBlendWeight=0)
        {
            throw new NotImplementedException();
        }

        public int GetControlPointIndicesCount()
        {
            throw new NotImplementedException();
        }

        public int[] GetControlPointIndices()
        {
            throw new NotImplementedException();
        }

        public double[] GetControlPointBlendWeights()
        {
            throw new NotImplementedException();
        }

        public void SetControlPointIWCount(int pCount)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

