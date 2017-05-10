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

        public FbxVector4 GetNodeLocalTranslation(FbxNode pNode)
        {
            return GetNodeLocalTranslation(pNode, FbxTime.Infinite);
        }
        public FbxVector4 GetNodeLocalTranslation(FbxNode pNode, FbxTime pTime, FbxNode.EPivotSet pPivotSet=FbxNode.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            return GetPropertyValue<FbxVector4>(pNode.LclTranslation, pTime, pForceEval);
        }

        public FbxVector4 GetNodeLocalRotation(FbxNode pNode)
        {
            return GetNodeLocalRotation(pNode, FbxTime.Infinite);
        }
        public FbxVector4 GetNodeLocalRotation(FbxNode pNode, FbxTime pTime, FbxNode.EPivotSet pPivotSet=FbxNode.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            return GetPropertyValue<FbxVector4>(pNode.LclRotation, pTime, pForceEval);
        }

        public FbxVector4 GetNodeLocalScaling(FbxNode pNode)
        {
            return GetNodeLocalScaling(pNode, FbxTime.Infinite);
        }
        public FbxVector4 GetNodeLocalScaling(FbxNode pNode, FbxTime pTime, FbxNode.EPivotSet pPivotSet=FbxNode.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            return GetPropertyValue<FbxVector4>(pNode.LclScaling, pTime, pForceEval);
        }

        public T GetPropertyValue<T>(FbxProperty pProperty, FbxTime pTime, bool pForceEval=false)
        {
            return pProperty.EvaluateValue<T>(pTime, pForceEval);
        }

        //public FbxPropertyValue GetPropertyValue(Property pProperty, FbxTime pTime, bool pForceEval=false)
        //{
        //    throw new NotImplementedException();
        //}

        public FbxAnimCurveNode GetPropertyCurveNode(FbxProperty pProperty, FbxAnimLayer pAnimLayer)
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

        public void Flush(FbxProperty pProperty)
        {
            throw new NotImplementedException();
        }

        public void ComputeLocalTRSFromGlobal(out FbxVector4 pRetLT, out FbxVector4 pRetLR, out FbxVector4 pRetLS, FbxNode pNode, FbxMatrix pGX)
        {
            ComputeLocalTRSFromGlobal(out pRetLT, out pRetLR, out pRetLS, pNode, pGX, FbxTime.Infinite);
        }
        public void ComputeLocalTRSFromGlobal(out FbxVector4 pRetLT, out FbxVector4 pRetLR, out FbxVector4 pRetLS, FbxNode pNode, FbxMatrix pGX, FbxTime pTime, FbxNode.EPivotSet pPivotSet=FbxNode.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            throw new NotImplementedException();
        }
    }
}

