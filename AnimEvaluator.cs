using System;

namespace FbxSharp
{
    public class AnimEvaluator : FbxObject
    {
        Matrix GetNodeGlobalTransform(Node pNode)
        {
            return GetNodeGlobalTransform(pNode, FbxTime.Infinite);
        }
        Matrix GetNodeGlobalTransform(Node pNode, FbxTime pTime, Node.EPivotSet pPivotSet=Node.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            throw new NotImplementedException();
        }

        Matrix GetNodeLocalTransform(Node pNode)
        {
            return GetNodeLocalTransform(pNode, FbxTime.Infinite);
        }
        Matrix GetNodeLocalTransform(Node pNode, FbxTime pTime, Node.EPivotSet pPivotSet=Node.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            throw new NotImplementedException();
        }

        Vector4 GetNodeLocalTranslation(Node pNode)
        {
            return GetNodeLocalTranslation(pNode, FbxTime.Infinite);
        }
        Vector4 GetNodeLocalTranslation(Node pNode, FbxTime pTime, Node.EPivotSet pPivotSet=Node.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            throw new NotImplementedException();
        }

        Vector4 GetNodeLocalRotation(Node pNode)
        {
            return GetNodeLocalRotation(pNode, FbxTime.Infinite);
        }
        Vector4 GetNodeLocalRotation(Node pNode, FbxTime pTime, Node.EPivotSet pPivotSet=Node.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            throw new NotImplementedException();
        }

        Vector4 GetNodeLocalScaling(Node pNode)
        {
            return GetNodeLocalScaling(pNode, FbxTime.Infinite);
        }
        Vector4 GetNodeLocalScaling(Node pNode, FbxTime pTime, Node.EPivotSet pPivotSet=Node.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            throw new NotImplementedException();
        }

        T GetPropertyValue<T>(Property pProperty, FbxTime pTime, bool pForceEval=false)
        {
            throw new NotImplementedException();
        }

        //FbxPropertyValue GetPropertyValue(Property pProperty, FbxTime pTime, bool pForceEval=false)
        //{
        //    throw new NotImplementedException();
        //}

        AnimationCurveNode GetPropertyCurveNode(Property pProperty, AnimationLayer pAnimLayer)
        {
            throw new NotImplementedException();
        }

        FbxTime ValidateTime(FbxTime pTime)
        {
            throw new NotImplementedException();
        }

        void Reset()
        {
            throw new NotImplementedException();
        }

        void Flush(Node pNode)
        {
            throw new NotImplementedException();
        }

        void Flush(Property pProperty)
        {
            throw new NotImplementedException();
        }

        void ComputeLocalTRSFromGlobal(out Vector4 pRetLT, out Vector4 pRetLR, out Vector4 pRetLS, Node pNode, Matrix pGX)
        {
            ComputeLocalTRSFromGlobal(out pRetLT, out pRetLR, out pRetLS, pNode, pGX, FbxTime.Infinite);
        }
        void ComputeLocalTRSFromGlobal(out Vector4 pRetLT, out Vector4 pRetLR, out Vector4 pRetLS, Node pNode, Matrix pGX, FbxTime pTime, Node.EPivotSet pPivotSet=Node.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            throw new NotImplementedException();
        }
    }
}

