using System;

namespace FbxSharp
{
    public abstract class Geometry : GeometryBase
    {
        protected Geometry(string name="")
            : base(name)
        {
            Deformers = SrcObjects.CreateCollectionView<Deformer>();
        }

        #region Deformer Management

        public readonly CollectionView<Deformer> Deformers;

        public int AddDeformer(Deformer pDeformer)
        {
            ConnectSrcObject(pDeformer);
            return Deformers.IndexOf(pDeformer);
        }

        public Deformer RemoveDeformer(int pIndex/*, FbxStatus pStatus=null*/)
        {
            var deformer = Deformers[pIndex];
            return DisconnectSrcObject(deformer) ? deformer : null;
        }

        public int GetDeformerCount()
        {
            return Deformers.Count;
        }

        public Deformer GetDeformer(int pIndex/*, FbxStatus pStatus=null*/)
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

