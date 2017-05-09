using System;

namespace FbxSharp
{
    public class FbxAnimEvaluator : FbxObject
    {
        public static readonly FbxAnimEvaluator Default = new FbxAnimEvalClassic();

        public FbxMatrix GetNodeGlobalTransform(FbxNode pNode)
        {
            return GetNodeGlobalTransform(pNode, FbxTime.Infinite);
        }
        public FbxMatrix GetNodeGlobalTransform(FbxNode pNode, FbxTime pTime, FbxNode.EPivotSet pPivotSet=FbxNode.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            var m = GetNodeLocalTransform(pNode, pTime, pPivotSet, pApplyTarget, pForceEval);
            if (pNode.GetParent() != null)
            {
                var p = GetNodeGlobalTransform(pNode.GetParent(), pTime, pPivotSet, pApplyTarget, pForceEval);
                m = p * m;
            }
            return m;
        }

        public FbxMatrix GetNodeLocalTransform(FbxNode pNode)
        {
            return GetNodeLocalTransform(pNode, FbxTime.Infinite);
        }
        public FbxMatrix GetNodeLocalTransform(FbxNode pNode, FbxTime pTime, FbxNode.EPivotSet pPivotSet=FbxNode.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            var translation = GetNodeLocalTranslation(pNode, pTime, pPivotSet, pApplyTarget, pForceEval);
            var rotation = GetNodeLocalRotation(pNode, pTime, pPivotSet, pApplyTarget, pForceEval);
            var scaling = GetNodeLocalScaling(pNode, pTime, pPivotSet, pApplyTarget, pForceEval);
            var m = new FbxMatrix(translation, rotation, scaling);

            return m;
        }

        public Vector4 GetNodeLocalTranslation(FbxNode pNode)
        {
            return GetNodeLocalTranslation(pNode, FbxTime.Infinite);
        }
        public Vector4 GetNodeLocalTranslation(FbxNode pNode, FbxTime pTime, FbxNode.EPivotSet pPivotSet=FbxNode.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            return GetPropertyValue<Vector4>(pNode.LclTranslation, pTime, pForceEval);
        }

        public Vector4 GetNodeLocalRotation(FbxNode pNode)
        {
            return GetNodeLocalRotation(pNode, FbxTime.Infinite);
        }
        public Vector4 GetNodeLocalRotation(FbxNode pNode, FbxTime pTime, FbxNode.EPivotSet pPivotSet=FbxNode.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            return GetPropertyValue<Vector4>(pNode.LclRotation, pTime, pForceEval);
        }

        public Vector4 GetNodeLocalScaling(FbxNode pNode)
        {
            return GetNodeLocalScaling(pNode, FbxTime.Infinite);
        }
        public Vector4 GetNodeLocalScaling(FbxNode pNode, FbxTime pTime, FbxNode.EPivotSet pPivotSet=FbxNode.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            return GetPropertyValue<Vector4>(pNode.LclScaling, pTime, pForceEval);
        }

        public T GetPropertyValue<T>(Property pProperty, FbxTime pTime, bool pForceEval=false)
        {
            return pProperty.EvaluateValue<T>(pTime, pForceEval);
        }

        //public FbxPropertyValue GetPropertyValue(Property pProperty, FbxTime pTime, bool pForceEval=false)
        //{
        //    throw new NotImplementedException();
        //}

        public FbxAnimCurveNode GetPropertyCurveNode(Property pProperty, FbxAnimLayer pAnimLayer)
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

        public void Flush(FbxNode pNode)
        {
            throw new NotImplementedException();
        }

        public void Flush(Property pProperty)
        {
            throw new NotImplementedException();
        }

        public void ComputeLocalTRSFromGlobal(out Vector4 pRetLT, out Vector4 pRetLR, out Vector4 pRetLS, FbxNode pNode, FbxMatrix pGX)
        {
            ComputeLocalTRSFromGlobal(out pRetLT, out pRetLR, out pRetLS, pNode, pGX, FbxTime.Infinite);
        }
        public void ComputeLocalTRSFromGlobal(out Vector4 pRetLT, out Vector4 pRetLR, out Vector4 pRetLS, FbxNode pNode, FbxMatrix pGX, FbxTime pTime, FbxNode.EPivotSet pPivotSet=FbxNode.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            throw new NotImplementedException();
        }
    }
}

