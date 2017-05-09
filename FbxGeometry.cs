using System;

namespace FbxSharp
{
    public abstract class FbxGeometry : FbxGeometryBase
    {
        protected FbxGeometry(string name="")
            : base(name)
        {
            Deformers = SrcObjects.CreateCollectionView<FbxDeformer>();
        }

        #region Deformer Management

        public readonly CollectionView<FbxDeformer> Deformers;

        public int AddDeformer(FbxDeformer pDeformer)
        {
            ConnectSrcObject(pDeformer);
            return Deformers.IndexOf(pDeformer);
        }

        public FbxDeformer RemoveDeformer(int pIndex/*, FbxStatus pStatus=null*/)
        {
            var deformer = Deformers[pIndex];
            return DisconnectSrcObject(deformer) ? deformer : null;
        }

        public int GetDeformerCount()
        {
            return Deformers.Count;
        }

        public FbxDeformer GetDeformer(int pIndex/*, FbxStatus pStatus=null*/)
        {
            return Deformers[pIndex];
        }

       //public int GetDeformerCount(Deformer::EDeformerType pType)
       //{
       //    throw new NotImplementedException();
       //}

        //public Deformer GetDeformer(int pIndex, Deformer::EDeformerType pType, FbxStatus pStatus=null)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        public override string GetNameSpacePrefix()
        {
            return "Geometry::";
        }
    }
}

