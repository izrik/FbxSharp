using System;

namespace FbxSharp
{
    public abstract class FbxGeometryBase : FbxLayerContainer
    {
        protected FbxGeometryBase(string name = "")
            : base(name)
        {
            PrimaryVisibility = FbxPropertyT<bool>.StaticInit(this,
                "Primary Visibility", false, false);
            CastShadow = FbxPropertyT<bool>.StaticInit(this, "Casts Shadows",
                false, false);
            ReceiveShadow = FbxPropertyT<bool>.StaticInit(this,
                "Receive Shadows", false, false);
            BBoxMin = FbxPropertyT<FbxVector3>.StaticInit(this, "BBoxMin",
                FbxVector3.Zero, false);
            BBoxMax = FbxPropertyT<FbxVector3>.StaticInit(this, "BBoxMax",
                FbxVector3.Zero, false);
        }

        #region Control Points, Normals, Binormals and Tangent Management

        FbxVector4 [] controlPoints = new FbxVector4[0];
        FbxVector4[] controlPointNormals = new FbxVector4[0];

        public void InitControlPoints(int pCount)
        {
            controlPoints = new FbxVector4[pCount];
        }

        public void InitNormals(int pCount=0)
        {
            controlPointNormals =
                new FbxVector4[
                    pCount > 0 ?
                        pCount :
                        controlPoints.Length];
        }

        public int GetControlPointsCount()
        {
            return controlPoints.Length;
        }

        public void SetControlPointsCount(int pCount)
        {
            if (pCount == GetControlPointsCount()) return;

            var pts = new FbxVector4[pCount];
            Array.Copy(controlPoints, pts, Math.Min(controlPoints.Length, pts.Length));
            controlPoints = pts;
        }

        public virtual void SetControlPointAt(FbxVector4 pCtrlPoint, FbxVector4 pNormal, int pIndex, bool pI2DSearch=false)
        {
            SetControlPointAt(pCtrlPoint, pIndex);
            SetControlPointNormalAt(pNormal, pIndex);
        }

        public virtual void SetControlPointAt(FbxVector4 pCtrlPoint, int pIndex)
        {
            controlPoints[pIndex] = pCtrlPoint;
        }

        public virtual FbxVector4 GetControlPointAt(int pIndex)
        {
            return controlPoints[pIndex];
        }

        public virtual void SetControlPointNormalAt(FbxVector4 pNormal, int pIndex /*, bool pI2DSearch=false*/)
        {
            controlPointNormals[pIndex] = pNormal;
        }

        public virtual FbxVector4[] GetControlPoints(/*FbxStatus pStatus=null*/)
        {
            return controlPoints;
        }

        #endregion

        #region Public and Fast Access Properties

        public readonly FbxPropertyT<bool> PrimaryVisibility;
        public readonly FbxPropertyT<bool> CastShadow;
        public readonly FbxPropertyT<bool> ReceiveShadow;
        public readonly FbxPropertyT<FbxVector3> BBoxMin;
        public readonly FbxPropertyT<FbxVector3> BBoxMax;

        public void ComputeBBox()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

