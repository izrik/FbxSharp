using System;

namespace FbxSharp
{
    public abstract class GeometryBase : LayerContainer
    {
        #region Control Points, Normals, Binormals and Tangent Management

        Vector4 [] controlPoints = new Vector4[0];

        public void InitControlPoints(int pCount)
        {
            controlPoints = new Vector4[pCount];
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
            throw new NotImplementedException();
        }

        public virtual void SetControlPointAt(Vector4 pCtrlPoint, int pIndex)
        {
            controlPoints[pIndex] = pCtrlPoint;
        }

        public virtual Vector4 GetControlPointAt(int pIndex)
        {
            return controlPoints[pIndex];
        }

        public virtual void SetControlPointNormalAt(Vector4 pNormal, int pIndex, bool pI2DSearch = false)
        {
            throw new NotImplementedException();
        }

        public virtual Vector4[] GetControlPoints(/*FbxStatus pStatus=null*/)
        {
            return controlPoints;
        }

        #endregion
    }
}

