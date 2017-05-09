using System;

namespace FbxSharp
{
    public abstract class FbxGeometryBase : LayerContainer
    {
        protected FbxGeometryBase(string name="")
            : base(name)
        {
            this.Properties.Add(PrimaryVisibility);
            this.Properties.Add(CastShadow);
            this.Properties.Add(ReceiveShadow);
            this.Properties.Add(BBoxMin);
            this.Properties.Add(BBoxMax);
        }

        #region Control Points, Normals, Binormals and Tangent Management

        Vector4 [] controlPoints = new Vector4[0];
        Vector4[] controlPointNormals = new Vector4[0];

        public void InitControlPoints(int pCount)
        {
            controlPoints = new Vector4[pCount];
        }

        public void InitNormals(int pCount=0)
        {
            controlPointNormals =
                new Vector4[
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

            var pts = new Vector4[pCount];
            Array.Copy(controlPoints, pts, Math.Min(controlPoints.Length, pts.Length));
            controlPoints = pts;
        }

        public virtual void SetControlPointAt(Vector4 pCtrlPoint, Vector4 pNormal, int pIndex, bool pI2DSearch=false)
        {
            SetControlPointAt(pCtrlPoint, pIndex);
            SetControlPointNormalAt(pNormal, pIndex);
        }

        public virtual void SetControlPointAt(Vector4 pCtrlPoint, int pIndex)
        {
            controlPoints[pIndex] = pCtrlPoint;
        }

        public virtual Vector4 GetControlPointAt(int pIndex)
        {
            return controlPoints[pIndex];
        }

        public virtual void SetControlPointNormalAt(Vector4 pNormal, int pIndex /*, bool pI2DSearch=false*/)
        {
            controlPointNormals[pIndex] = pNormal;
        }

        public virtual Vector4[] GetControlPoints(/*FbxStatus pStatus=null*/)
        {
            return controlPoints;
        }

        #endregion

        #region Public and Fast Access Properties

        public readonly PropertyT<bool>     PrimaryVisibility   = new PropertyT<bool>(   "Primary Visibility");
        public readonly PropertyT<bool>     CastShadow          = new PropertyT<bool>(   "Casts Shadows");
        public readonly PropertyT<bool>     ReceiveShadow       = new PropertyT<bool>(   "Receive Shadows");
        public readonly PropertyT<Vector3>  BBoxMin             = new PropertyT<Vector3>("BBoxMin");
        public readonly PropertyT<Vector3>  BBoxMax             = new PropertyT<Vector3>("BBoxMax");

        public void ComputeBBox()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

