using System;

namespace FbxSharp
{
    public class AnimEvaluator : FbxObject
    {
        public Matrix GetNodeGlobalTransform(Node pNode)
        {
            return GetNodeGlobalTransform(pNode, FbxTime.Infinite);
        }
        public Matrix GetNodeGlobalTransform(Node pNode, FbxTime pTime, Node.EPivotSet pPivotSet=Node.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            throw new NotImplementedException();
        }

        public Matrix GetNodeLocalTransform(Node pNode)
        {
            return GetNodeLocalTransform(pNode, FbxTime.Infinite);
        }
        public Matrix GetNodeLocalTransform(Node pNode, FbxTime pTime, Node.EPivotSet pPivotSet=Node.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            throw new NotImplementedException();
        }

        public Vector4 GetNodeLocalTranslation(Node pNode)
        {
            return GetNodeLocalTranslation(pNode, FbxTime.Infinite);
        }
        public Vector4 GetNodeLocalTranslation(Node pNode, FbxTime pTime, Node.EPivotSet pPivotSet=Node.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            throw new NotImplementedException();
        }

        public Vector4 GetNodeLocalRotation(Node pNode)
        {
            return GetNodeLocalRotation(pNode, FbxTime.Infinite);
        }
        public Vector4 GetNodeLocalRotation(Node pNode, FbxTime pTime, Node.EPivotSet pPivotSet=Node.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            throw new NotImplementedException();
        }

        public Vector4 GetNodeLocalScaling(Node pNode)
        {
            return GetNodeLocalScaling(pNode, FbxTime.Infinite);
        }
        public Vector4 GetNodeLocalScaling(Node pNode, FbxTime pTime, Node.EPivotSet pPivotSet=Node.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            throw new NotImplementedException();
        }

        public T GetPropertyValue<T>(Property pProperty, FbxTime pTime, bool pForceEval=false)
        {
            throw new NotImplementedException();
        }

        //public FbxPropertyValue GetPropertyValue(Property pProperty, FbxTime pTime, bool pForceEval=false)
        //{
        //    throw new NotImplementedException();
        //}

        public AnimCurveNode GetPropertyCurveNode(Property pProperty, AnimLayer pAnimLayer)
        {
            throw new NotImplementedException();
        }

        public FbxTime ValidateTime(FbxTime pTime)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Flush(Node pNode)
        {
            throw new NotImplementedException();
        }

        public void Flush(Property pProperty)
        {
            throw new NotImplementedException();
        }

        public void ComputeLocalTRSFromGlobal(out Vector4 pRetLT, out Vector4 pRetLR, out Vector4 pRetLS, Node pNode, Matrix pGX)
        {
            ComputeLocalTRSFromGlobal(out pRetLT, out pRetLR, out pRetLS, pNode, pGX, FbxTime.Infinite);
        }
        public void ComputeLocalTRSFromGlobal(out Vector4 pRetLT, out Vector4 pRetLR, out Vector4 pRetLS, Node pNode, Matrix pGX, FbxTime pTime, Node.EPivotSet pPivotSet=Node.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            throw new NotImplementedException();
        }
    }
}

