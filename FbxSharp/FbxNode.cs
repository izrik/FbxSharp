using System;
using System.Collections.Generic;
using System.Linq;

namespace FbxSharp
{
    public class FbxNode : FbxObject
    {
        public FbxNode(string name = "")
        {
            LclTranslation = FbxPropertyT<FbxVector3>.StaticInit(this,
                "Lcl Translation", FbxVector3.Zero, false);
            LclRotation = FbxPropertyT<FbxVector3>.StaticInit(this,
                "Lcl Rotation", FbxVector3.Zero, false);
            LclScaling = FbxPropertyT<FbxVector3>.StaticInit(this,
                "Lcl Scaling", FbxVector3.One, false);
            Visibility = FbxPropertyT<double>.StaticInit(this, "Visibility",
                0.0, false);
            VisibilityInheritance = FbxPropertyT<bool>.StaticInit(this,
                "Visibility Inheritance", false, false);
            QuaternionInterpolate =
                FbxPropertyT<EFbxQuatInterpMode>.StaticInit(this,
                    "QuaternionInterpolate", default, false);
            RotationOffset = FbxPropertyT<FbxVector3>.StaticInit(this,
                "RotationOffset", FbxVector3.Zero, false);
            RotationPivot = FbxPropertyT<FbxVector3>.StaticInit(this,
                "RotationPivot", FbxVector3.Zero, false);
            ScalingOffset = FbxPropertyT<FbxVector3>.StaticInit(this,
                "ScalingOffset", FbxVector3.Zero, false);
            ScalingPivot = FbxPropertyT<FbxVector3>.StaticInit(this,
                "ScalingPivot", FbxVector3.Zero, false);
            TranslationActive = FbxPropertyT<bool>.StaticInit(this,
                "TranslationActive", false, false);
            TranslationMin = FbxPropertyT<FbxVector3>.StaticInit(this,
                "TranslationMin", FbxVector3.Zero, false);
            TranslationMax = FbxPropertyT<FbxVector3>.StaticInit(this,
                "TranslationMax", FbxVector3.Zero, false);
            TranslationMinX = FbxPropertyT<bool>.StaticInit(this,
                "TranslationMinX", false, false);
            TranslationMinY = FbxPropertyT<bool>.StaticInit(this,
                "TranslationMinY", false, false);
            TranslationMinZ = FbxPropertyT<bool>.StaticInit(this,
                "TranslationMinZ", false, false);
            TranslationMaxX = FbxPropertyT<bool>.StaticInit(this,
                "TranslationMaxX", false, false);
            TranslationMaxY = FbxPropertyT<bool>.StaticInit(this,
                "TranslationMaxY", false, false);
            TranslationMaxZ = FbxPropertyT<bool>.StaticInit(this,
                "TranslationMaxZ", false, false);
            RotationOrder = FbxPropertyT<ERotationOrder>.StaticInit(this,
                "RotationOrder", default, false);
            RotationSpaceForLimitOnly = FbxPropertyT<bool>.StaticInit(this,
                "RotationSpaceForLimitOnly", false, false);
            RotationStiffnessX = FbxPropertyT<double>.StaticInit(this,
                "RotationStiffnessX", 0.0, false);
            RotationStiffnessY = FbxPropertyT<double>.StaticInit(this,
                "RotationStiffnessY", 0.0, false);
            RotationStiffnessZ = FbxPropertyT<double>.StaticInit(this,
                "RotationStiffnessZ", 0.0, false);
            AxisLen = FbxPropertyT<double>.StaticInit(this, "AxisLen", 0.0,
                false);
            PreRotation = FbxPropertyT<FbxVector3>.StaticInit(this,
                "PreRotation", FbxVector3.Zero, false);
            PostRotation = FbxPropertyT<FbxVector3>.StaticInit(this,
                "PostRotation", FbxVector3.Zero, false);
            RotationActive = FbxPropertyT<bool>.StaticInit(this,
                "RotationActive", false, false);
            RotationMin = FbxPropertyT<FbxVector3>.StaticInit(this,
                "RotationMin", FbxVector3.Zero, false);
            RotationMax = FbxPropertyT<FbxVector3>.StaticInit(this,
                "RotationMax", FbxVector3.Zero, false);
            RotationMinX = FbxPropertyT<bool>.StaticInit(this, "RotationMinX",
                false, false);
            RotationMinY = FbxPropertyT<bool>.StaticInit(this, "RotationMinY",
                false, false);
            RotationMinZ = FbxPropertyT<bool>.StaticInit(this, "RotationMinZ",
                false, false);
            RotationMaxX = FbxPropertyT<bool>.StaticInit(this, "RotationMaxX",
                false, false);
            RotationMaxY = FbxPropertyT<bool>.StaticInit(this, "RotationMaxY",
                false, false);
            RotationMaxZ = FbxPropertyT<bool>.StaticInit(this, "RotationMaxZ",
                false, false);
            InheritType = FbxPropertyT<FbxTransform.EInheritType>.StaticInit(
                this, "InheritType", default, false);
            ScalingActive = FbxPropertyT<bool>.StaticInit(this,
                "ScalingActive", false, false);
            ScalingMin = FbxPropertyT<FbxVector3>.StaticInit(this,
                "ScalingMin", FbxVector3.Zero, false);
            ScalingMax = FbxPropertyT<FbxVector3>.StaticInit(this,
                "ScalingMax", FbxVector3.Zero, false);
            ScalingMinX = FbxPropertyT<bool>.StaticInit(this, "ScalingMinX",
                false, false);
            ScalingMinY = FbxPropertyT<bool>.StaticInit(this, "ScalingMinY",
                false, false);
            ScalingMinZ = FbxPropertyT<bool>.StaticInit(this, "ScalingMinZ",
                false, false);
            ScalingMaxX = FbxPropertyT<bool>.StaticInit(this, "ScalingMaxX",
                false, false);
            ScalingMaxY = FbxPropertyT<bool>.StaticInit(this, "ScalingMaxY",
                false, false);
            ScalingMaxZ = FbxPropertyT<bool>.StaticInit(this, "ScalingMaxZ",
                false, false);
            GeometricTranslation = FbxPropertyT<FbxVector3>.StaticInit(this,
                "GeometricTranslation", FbxVector3.Zero, false);
            GeometricRotation = FbxPropertyT<FbxVector3>.StaticInit(this,
                "GeometricRotation", FbxVector3.Zero, false);
            GeometricScaling = FbxPropertyT<FbxVector3>.StaticInit(this,
                "GeometricScaling", FbxVector3.Zero, false);
            MinDampRangeX = FbxPropertyT<double>.StaticInit(this,
                "MinDampRangeX", 0.0, false);
            MinDampRangeY = FbxPropertyT<double>.StaticInit(this,
                "MinDampRangeY", 0.0, false);
            MinDampRangeZ = FbxPropertyT<double>.StaticInit(this,
                "MinDampRangeZ", 0.0, false);
            MaxDampRangeX = FbxPropertyT<double>.StaticInit(this,
                "MaxDampRangeX", 0.0, false);
            MaxDampRangeY = FbxPropertyT<double>.StaticInit(this,
                "MaxDampRangeY", 0.0, false);
            MaxDampRangeZ = FbxPropertyT<double>.StaticInit(this,
                "MaxDampRangeZ", 0.0, false);
            MinDampStrengthX = FbxPropertyT<double>.StaticInit(this,
                "MinDampStrengthX", 0.0, false);
            MinDampStrengthY = FbxPropertyT<double>.StaticInit(this,
                "MinDampStrengthY", 0.0, false);
            MinDampStrengthZ = FbxPropertyT<double>.StaticInit(this,
                "MinDampStrengthZ", 0.0, false);
            MaxDampStrengthX = FbxPropertyT<double>.StaticInit(this,
                "MaxDampStrengthX", 0.0, false);
            MaxDampStrengthY = FbxPropertyT<double>.StaticInit(this,
                "MaxDampStrengthY", 0.0, false);
            MaxDampStrengthZ = FbxPropertyT<double>.StaticInit(this,
                "MaxDampStrengthZ", 0.0, false);
            PreferedAngleX = FbxPropertyT<double>.StaticInit(this,
                "PreferedAngleX", 0.0, false);
            PreferedAngleY = FbxPropertyT<double>.StaticInit(this,
                "PreferedAngleY", 0.0, false);
            PreferedAngleZ = FbxPropertyT<double>.StaticInit(this,
                "PreferedAngleZ", 0.0, false);
            LookAtProperty = FbxPropertyT<FbxObject>.StaticInit(this,
                "LookAtProperty", null, false);
            UpVectorProperty = FbxPropertyT<FbxObject>.StaticInit(this,
                "UpVectorProperty", null, false);
            Show = FbxPropertyT<bool>.StaticInit(this, "Show", false, false);
            NegativePercentShapeSupport = FbxPropertyT<bool>.StaticInit(this,
                "NegativePercentShapeSupport", false, false);
            DefaultAttributeIndex = FbxPropertyT<int>.StaticInit(this,
                "DefaultAttributeIndex", 0, false);
            Freeze = FbxPropertyT<bool>.StaticInit(this, "Freeze", false,
                false);
            LODBox = FbxPropertyT<bool>.StaticInit(this, "LODBox", false,
                false);

            DefaultAttributeIndex.Set(-1);
            nodeAttributes =
                SrcObjects.CreateCollectionView<FbxNodeAttribute>();
            Materials = SrcObjects.CreateCollectionView<FbxSurfaceMaterial>();
        }

        public bool MultiLayer;
        public bool MultiTake;
        public bool Shading;
        public string Culling;

        #region Node Tree Management

        //Get the parent node.
        public FbxNode GetParent()
        {
            return ParentNode;
        }

        //Add a child node and its underlying node tree.
        public bool AddChild(FbxNode pNode)
        {
            if (pNode == null)
                return false;
            this.ConnectSrcObject(pNode);
            return true;
        }

        void ConnectScene(FbxObject obj)
        {
            if (obj.Scene != this.Scene)
            {
                if (obj.Scene != null)
                {
                    obj.DisconnectDstObject(obj.Scene);
                }
                if (this.Scene != null)
                {
                    obj.ConnectDstObject(this.Scene);
                }
            }

            var node = obj as FbxNode;
            if (node != null)
            {
                foreach (var src in node.SrcObjects)
                {
                    if (src is FbxNode)
                        ConnectScene(src as FbxNode);
                }
            }
        }

        //Remove the child node.
        public FbxNode RemoveChild(FbxNode pNode)
        {
            if (this.DisconnectSrcObject(pNode))
            {
                return pNode;
            }
            return null;
        }

        public override bool DisconnectSrcObject(FbxObject pObject)
        {
            var ret = base.DisconnectSrcObject(pObject);

            if (pObject is FbxNode)
            {
                DisconnectScene((FbxNode)pObject);
            }

            return ret;
        }

        void DisconnectScene(FbxNode child)
        {
            if (child.Scene != null)
            {
                child.DisconnectDstObject(child.Scene);
            }
            foreach (var src in child.SrcObjects)
            {
                if (src is FbxNode)
                    DisconnectScene(src as FbxNode);
            }
        }

        //Get the number of children nodes.
        public int GetChildCount()//bool pRecursive = false)
        {
            return GetSrcObjectCount<FbxNode>();
        }

        //Get child by index.
        public FbxNode GetChild(int pIndex)
        {
            return GetSrcObject<FbxNode>(pIndex);
        }

        public FbxNode ParentNode
        {
            get { return GetDstObject<FbxNode>(); }
        }

        //Finds a child node by name.
        //FbxNode *   FindChild (const char *pName, bool pRecursive=true, bool pInitial=false)

        #endregion

        #region Node Attribute Management

        readonly CollectionView<FbxNodeAttribute> nodeAttributes;

        public FbxNodeAttribute SetNodeAttribute(FbxNodeAttribute pNodeAttribute)
        {
            ConnectSrcObject(pNodeAttribute);
            if (DefaultAttributeIndex.Get() < 0)
            {
                DefaultAttributeIndex.Set(nodeAttributes.IndexOf(pNodeAttribute));
            }

            return pNodeAttribute;
        }

        public FbxNodeAttribute GetNodeAttribute()
        {
            if (DefaultAttributeIndex.Get() < 0) return null;
            if (DefaultAttributeIndex.Get() >= nodeAttributes.Count) return null;
            return nodeAttributes[DefaultAttributeIndex.Get()];
        }

        public int GetNodeAttributeCount()
        {
            return nodeAttributes.Count;
        }

        public int GetDefaultNodeAttributeIndex()
        {
            return DefaultAttributeIndex.Get();
        }

        public bool SetDefaultNodeAttributeIndex(int pIndex /*, FbxStatus=null*/)
        {
            throw new NotImplementedException();
        }

        public FbxNodeAttribute GetNodeAttributeByIndex(int pIndex)
        {
            return nodeAttributes[pIndex];
        }

        public int GetNodeAttributeIndex(FbxNodeAttribute nodeattr /*, FbxStatus=null*/)
        {
            return nodeAttributes.IndexOf(nodeattr);
        }

        #endregion

        #region Node Evaluation Functions

        public FbxAnimEvaluator GetAnimationEvaluator()
        {
            if (Scene != null)
                return Scene.GetAnimationEvaluator();

            return FbxAnimEvaluator.Default;
        }

        public FbxMatrix EvaluateGlobalTransform()
        {
            return EvaluateGlobalTransform(FbxTime.Infinite);
        }
        public FbxMatrix EvaluateGlobalTransform(FbxTime pTime, FbxNode.EPivotSet pPivotSet=FbxNode.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            return GetAnimationEvaluator().GetNodeGlobalTransform(this, pTime, pPivotSet, pApplyTarget, pForceEval);
        }

        public FbxMatrix EvaluateLocalTransform()
        {
            return EvaluateLocalTransform(FbxTime.Infinite);
        }
        public FbxMatrix EvaluateLocalTransform(FbxTime pTime, FbxNode.EPivotSet pPivotSet=FbxNode.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            return GetAnimationEvaluator().GetNodeLocalTransform(this, pTime, pPivotSet, pApplyTarget, pForceEval);
        }

        public FbxVector4 EvaluateLocalTranslation()
        {
            return EvaluateLocalTranslation(FbxTime.Infinite);
        }
        public FbxVector4 EvaluateLocalTranslation(FbxTime pTime, FbxNode.EPivotSet pPivotSet=FbxNode.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            throw new NotImplementedException();
        }

        public FbxVector4 EvaluateLocalRotation()
        {
            return EvaluateLocalRotation(FbxTime.Infinite);
        }
        public FbxVector4 EvaluateLocalRotation(FbxTime pTime, FbxNode.EPivotSet pPivotSet=FbxNode.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            throw new NotImplementedException();
        }

        public FbxVector4 EvaluateLocalScaling()
        {
            return EvaluateLocalScaling(FbxTime.Infinite);
        }
        public FbxVector4 EvaluateLocalScaling(FbxTime pTime, FbxNode.EPivotSet pPivotSet=FbxNode.EPivotSet.eSourcePivot, bool pApplyTarget=false, bool pForceEval=false)
        {
            throw new NotImplementedException();
        }

        //public bool EvaluateGlobalBoundingBoxMinMaxCenter(out Vector4 pBBoxMin, out Vector4 pBBoxMax, out Vector4 pBBoxCenter,  FbxTime pTime=FBXSDK_TIME_INFINITE)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool EvaluateRayIntersectionPoint(out Vector4 pOut,  Vector4 pRayOrigin,  Vector4 pRayDir, bool pCulling=false,  FbxTime pTime=FBXSDK_TIME_INFINITE)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        #region Material Management

        public readonly CollectionView<FbxSurfaceMaterial> Materials;

        public int AddMaterial(FbxSurfaceMaterial pMaterial)
        {
            ConnectSrcObject(pMaterial);
            return Materials.IndexOf(pMaterial);
        }

        public bool RemoveMaterial(FbxSurfaceMaterial pMaterial)
        {
            return DisconnectSrcObject(pMaterial);
        }

        public int GetMaterialCount()
        {
            return Materials.Count;
        }

        public FbxSurfaceMaterial GetMaterial(int pIndex)
        {
            return Materials[pIndex];
        }

        public void RemoveAllMaterials()
        {
            foreach (var m in Materials.ToArray())
            {
                RemoveMaterial(m);
            }
        }

        public int GetMaterialIndex(string pName)
        {
            return Materials.ToList().FindIndex(m => m.Name == pName);
        }

        #endregion

        #region Public and Fast Access Properties

        public FbxPropertyT<FbxVector3> LclTranslation;
        public FbxPropertyT<FbxVector3> LclRotation;
        public FbxPropertyT<FbxVector3> LclScaling;
        public FbxPropertyT<double> Visibility;
        public FbxPropertyT<bool> VisibilityInheritance;
        public FbxPropertyT<EFbxQuatInterpMode> QuaternionInterpolate;
        public FbxPropertyT<FbxVector3> RotationOffset;
        public FbxPropertyT<FbxVector3> RotationPivot;
        public FbxPropertyT<FbxVector3> ScalingOffset;
        public FbxPropertyT<FbxVector3> ScalingPivot;
        public FbxPropertyT<bool> TranslationActive;
        public FbxPropertyT<FbxVector3> TranslationMin;
        public FbxPropertyT<FbxVector3> TranslationMax;
        public FbxPropertyT<bool> TranslationMinX;
        public FbxPropertyT<bool> TranslationMinY;
        public FbxPropertyT<bool> TranslationMinZ;
        public FbxPropertyT<bool> TranslationMaxX;
        public FbxPropertyT<bool> TranslationMaxY;
        public FbxPropertyT<bool> TranslationMaxZ;
        public FbxPropertyT<ERotationOrder> RotationOrder;
        public FbxPropertyT<bool> RotationSpaceForLimitOnly;
        public FbxPropertyT<double> RotationStiffnessX;
        public FbxPropertyT<double> RotationStiffnessY;
        public FbxPropertyT<double> RotationStiffnessZ;
        public FbxPropertyT<double> AxisLen;
        public FbxPropertyT<FbxVector3> PreRotation;
        public FbxPropertyT<FbxVector3> PostRotation;
        public FbxPropertyT<bool> RotationActive;
        public FbxPropertyT<FbxVector3> RotationMin;
        public FbxPropertyT<FbxVector3> RotationMax;
        public FbxPropertyT<bool> RotationMinX;
        public FbxPropertyT<bool> RotationMinY;
        public FbxPropertyT<bool> RotationMinZ;
        public FbxPropertyT<bool> RotationMaxX;
        public FbxPropertyT<bool> RotationMaxY;
        public FbxPropertyT<bool> RotationMaxZ;
        public FbxPropertyT<FbxTransform.EInheritType> InheritType;
        public FbxPropertyT<bool> ScalingActive;
        public FbxPropertyT<FbxVector3> ScalingMin;
        public FbxPropertyT<FbxVector3> ScalingMax;
        public FbxPropertyT<bool> ScalingMinX;
        public FbxPropertyT<bool> ScalingMinY;
        public FbxPropertyT<bool> ScalingMinZ;
        public FbxPropertyT<bool> ScalingMaxX;
        public FbxPropertyT<bool> ScalingMaxY;
        public FbxPropertyT<bool> ScalingMaxZ;
        public FbxPropertyT<FbxVector3> GeometricTranslation;
        public FbxPropertyT<FbxVector3> GeometricRotation;
        public FbxPropertyT<FbxVector3> GeometricScaling;
        public FbxPropertyT<double> MinDampRangeX;
        public FbxPropertyT<double> MinDampRangeY;
        public FbxPropertyT<double> MinDampRangeZ;
        public FbxPropertyT<double> MaxDampRangeX;
        public FbxPropertyT<double> MaxDampRangeY;
        public FbxPropertyT<double> MaxDampRangeZ;
        public FbxPropertyT<double> MinDampStrengthX;
        public FbxPropertyT<double> MinDampStrengthY;
        public FbxPropertyT<double> MinDampStrengthZ;
        public FbxPropertyT<double> MaxDampStrengthX;
        public FbxPropertyT<double> MaxDampStrengthY;
        public FbxPropertyT<double> MaxDampStrengthZ;
        public FbxPropertyT<double> PreferedAngleX;
        public FbxPropertyT<double> PreferedAngleY;
        public FbxPropertyT<double> PreferedAngleZ;
        public FbxPropertyT<FbxObject> LookAtProperty;
        public FbxPropertyT<FbxObject> UpVectorProperty;
        public FbxPropertyT<bool> Show;
        public FbxPropertyT<bool> NegativePercentShapeSupport;
        public FbxPropertyT<int> DefaultAttributeIndex;
        public FbxPropertyT<bool> Freeze;
        public FbxPropertyT<bool> LODBox;

        #endregion

        public enum ERotationOrder
        {
            OrderXYZ,
            OrderXZY,
            OrderYZX,
            OrderYXZ,
            OrderZXY,
            OrderZYX,
            OrderSphericXYZ,
        }

        public enum EPivotSet
        {
            eSourcePivot,
            eDestinationPivot,
        }

        public override string GetNameSpacePrefix()
        {
            return "Model::";
        }

    }
}

