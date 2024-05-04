using System;
using System.Collections.Generic;
using System.Linq;

namespace FbxSharp
{
    public class FbxNode : FbxObject
    {
        public FbxNode(string name="")
        {
            this.Properties.AddRange(
                new FbxProperty[] {
                    LclTranslation,
                    LclRotation,
                    LclScaling,
                    Visibility,
                    VisibilityInheritance,
                    QuaternionInterpolate,
                    RotationOffset,
                    RotationPivot,
                    ScalingOffset,
                    ScalingPivot,
                    TranslationActive,
                    TranslationMin,
                    TranslationMax,
                    TranslationMinX,
                    TranslationMinY,
                    TranslationMinZ,
                    TranslationMaxX,
                    TranslationMaxY,
                    TranslationMaxZ,
                    RotationOrder,
                    RotationSpaceForLimitOnly,
                    RotationStiffnessX,
                    RotationStiffnessY,
                    RotationStiffnessZ,
                    AxisLen,
                    PreRotation,
                    PostRotation,
                    RotationActive,
                    RotationMin,
                    RotationMax,
                    RotationMinX,
                    RotationMinY,
                    RotationMinZ,
                    RotationMaxX,
                    RotationMaxY,
                    RotationMaxZ,
                    InheritType,
                    ScalingActive,
                    ScalingMin,
                    ScalingMax,
                    ScalingMinX,
                    ScalingMinY,
                    ScalingMinZ,
                    ScalingMaxX,
                    ScalingMaxY,
                    ScalingMaxZ,
                    GeometricTranslation,
                    GeometricRotation,
                    GeometricScaling,
                    MinDampRangeX,
                    MinDampRangeY,
                    MinDampRangeZ,
                    MaxDampRangeX,
                    MaxDampRangeY,
                    MaxDampRangeZ,
                    MinDampStrengthX,
                    MinDampStrengthY,
                    MinDampStrengthZ,
                    MaxDampStrengthX,
                    MaxDampStrengthY,
                    MaxDampStrengthZ,
                    PreferedAngleX,
                    PreferedAngleY,
                    PreferedAngleZ,
                    LookAtProperty,
                    UpVectorProperty,
                    Show,
                    NegativePercentShapeSupport,
                    DefaultAttributeIndex,
                    Freeze,
                    LODBox});

            this.ChildNodes = SrcObjects.CreateCollectionView<FbxNode>();
            _parentNode = DstObjects.CreateObjectView<FbxNode>();

            DefaultAttributeIndex.Set(-1);
            nodeAttributes = SrcObjects.CreateCollectionView<FbxNodeAttribute>();
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
                foreach (var child in node.ChildNodes)
                {
                    ConnectScene(child);
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
            foreach (var subchild in child.ChildNodes)
            {
                DisconnectScene(subchild);
            }
        }

        //Get the number of children nodes.
        public int GetChildCount()//bool pRecursive = false)
        {
            return ChildNodes.Count;
        }

        //Get child by index.
        public FbxNode GetChild(int pIndex)
        {
            return ChildNodes[pIndex];
        }

        private ObjectView<FbxNode> _parentNode;
        public FbxNode ParentNode
        {
            get { return _parentNode.Get(); }
        }
        public readonly CollectionView<FbxNode> ChildNodes;

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

        public FbxPropertyT<FbxVector3>                       LclTranslation              = new FbxPropertyT<FbxVector3>("Lcl Translation");
        public FbxPropertyT<FbxVector3>                       LclRotation                 = new FbxPropertyT<FbxVector3>("Lcl Rotation");
        public FbxPropertyT<FbxVector3>                       LclScaling                  = new FbxPropertyT<FbxVector3>("Lcl Scaling", FbxVector3.One);
        public FbxPropertyT<double>                        Visibility                  = new FbxPropertyT<double>("Visibility");
        public FbxPropertyT<bool>                          VisibilityInheritance       = new FbxPropertyT<bool>("Visibility Inheritance");
        public FbxPropertyT<EFbxQuatInterpMode>               QuaternionInterpolate       = new FbxPropertyT<EFbxQuatInterpMode>("QuaternionInterpolate");
        public FbxPropertyT<FbxVector3>                       RotationOffset              = new FbxPropertyT<FbxVector3>("RotationOffset");
        public FbxPropertyT<FbxVector3>                       RotationPivot               = new FbxPropertyT<FbxVector3>("RotationPivot");
        public FbxPropertyT<FbxVector3>                       ScalingOffset               = new FbxPropertyT<FbxVector3>("ScalingOffset");
        public FbxPropertyT<FbxVector3>                       ScalingPivot                = new FbxPropertyT<FbxVector3>("ScalingPivot");
        public FbxPropertyT<bool>                          TranslationActive           = new FbxPropertyT<bool>("TranslationActive");
        public FbxPropertyT<FbxVector3>                       TranslationMin              = new FbxPropertyT<FbxVector3>("TranslationMin");
        public FbxPropertyT<FbxVector3>                       TranslationMax              = new FbxPropertyT<FbxVector3>("TranslationMax");
        public FbxPropertyT<bool>                          TranslationMinX             = new FbxPropertyT<bool>("TranslationMinX");
        public FbxPropertyT<bool>                          TranslationMinY             = new FbxPropertyT<bool>("TranslationMinY");
        public FbxPropertyT<bool>                          TranslationMinZ             = new FbxPropertyT<bool>("TranslationMinZ");
        public FbxPropertyT<bool>                          TranslationMaxX             = new FbxPropertyT<bool>("TranslationMaxX");
        public FbxPropertyT<bool>                          TranslationMaxY             = new FbxPropertyT<bool>("TranslationMaxY");
        public FbxPropertyT<bool>                          TranslationMaxZ             = new FbxPropertyT<bool>("TranslationMaxZ");
        public FbxPropertyT<ERotationOrder>                RotationOrder               = new FbxPropertyT<ERotationOrder>("RotationOrder");
        public FbxPropertyT<bool>                          RotationSpaceForLimitOnly   = new FbxPropertyT<bool>("RotationSpaceForLimitOnly");
        public FbxPropertyT<double>                        RotationStiffnessX          = new FbxPropertyT<double>("RotationStiffnessX");
        public FbxPropertyT<double>                        RotationStiffnessY          = new FbxPropertyT<double>("RotationStiffnessY");
        public FbxPropertyT<double>                        RotationStiffnessZ          = new FbxPropertyT<double>("RotationStiffnessZ");
        public FbxPropertyT<double>                        AxisLen                     = new FbxPropertyT<double>("AxisLen");
        public FbxPropertyT<FbxVector3>                       PreRotation                 = new FbxPropertyT<FbxVector3>("PreRotation");
        public FbxPropertyT<FbxVector3>                       PostRotation                = new FbxPropertyT<FbxVector3>("PostRotation");
        public FbxPropertyT<bool>                          RotationActive              = new FbxPropertyT<bool>("RotationActive");
        public FbxPropertyT<FbxVector3>                       RotationMin                 = new FbxPropertyT<FbxVector3>("RotationMin");
        public FbxPropertyT<FbxVector3>                       RotationMax                 = new FbxPropertyT<FbxVector3>("RotationMax");
        public FbxPropertyT<bool>                          RotationMinX                = new FbxPropertyT<bool>("RotationMinX");
        public FbxPropertyT<bool>                          RotationMinY                = new FbxPropertyT<bool>("RotationMinY");
        public FbxPropertyT<bool>                          RotationMinZ                = new FbxPropertyT<bool>("RotationMinZ");
        public FbxPropertyT<bool>                          RotationMaxX                = new FbxPropertyT<bool>("RotationMaxX");
        public FbxPropertyT<bool>                          RotationMaxY                = new FbxPropertyT<bool>("RotationMaxY");
        public FbxPropertyT<bool>                          RotationMaxZ                = new FbxPropertyT<bool>("RotationMaxZ");
        public FbxPropertyT<FbxTransform.EInheritType>        InheritType                 = new FbxPropertyT<FbxTransform.EInheritType>("InheritType");
        public FbxPropertyT<bool>                          ScalingActive               = new FbxPropertyT<bool>("ScalingActive");
        public FbxPropertyT<FbxVector3>                       ScalingMin                  = new FbxPropertyT<FbxVector3>("ScalingMin");
        public FbxPropertyT<FbxVector3>                       ScalingMax                  = new FbxPropertyT<FbxVector3>("ScalingMax");
        public FbxPropertyT<bool>                          ScalingMinX                 = new FbxPropertyT<bool>("ScalingMinX");
        public FbxPropertyT<bool>                          ScalingMinY                 = new FbxPropertyT<bool>("ScalingMinY");
        public FbxPropertyT<bool>                          ScalingMinZ                 = new FbxPropertyT<bool>("ScalingMinZ");
        public FbxPropertyT<bool>                          ScalingMaxX                 = new FbxPropertyT<bool>("ScalingMaxX");
        public FbxPropertyT<bool>                          ScalingMaxY                 = new FbxPropertyT<bool>("ScalingMaxY");
        public FbxPropertyT<bool>                          ScalingMaxZ                 = new FbxPropertyT<bool>("ScalingMaxZ");
        public FbxPropertyT<FbxVector3>                       GeometricTranslation        = new FbxPropertyT<FbxVector3>("GeometricTranslation");
        public FbxPropertyT<FbxVector3>                       GeometricRotation           = new FbxPropertyT<FbxVector3>("GeometricRotation");
        public FbxPropertyT<FbxVector3>                       GeometricScaling            = new FbxPropertyT<FbxVector3>("GeometricScaling");
        public FbxPropertyT<double>                        MinDampRangeX               = new FbxPropertyT<double>("MinDampRangeX");
        public FbxPropertyT<double>                        MinDampRangeY               = new FbxPropertyT<double>("MinDampRangeY");
        public FbxPropertyT<double>                        MinDampRangeZ               = new FbxPropertyT<double>("MinDampRangeZ");
        public FbxPropertyT<double>                        MaxDampRangeX               = new FbxPropertyT<double>("MaxDampRangeX");
        public FbxPropertyT<double>                        MaxDampRangeY               = new FbxPropertyT<double>("MaxDampRangeY");
        public FbxPropertyT<double>                        MaxDampRangeZ               = new FbxPropertyT<double>("MaxDampRangeZ");
        public FbxPropertyT<double>                        MinDampStrengthX            = new FbxPropertyT<double>("MinDampStrengthX");
        public FbxPropertyT<double>                        MinDampStrengthY            = new FbxPropertyT<double>("MinDampStrengthY");
        public FbxPropertyT<double>                        MinDampStrengthZ            = new FbxPropertyT<double>("MinDampStrengthZ");
        public FbxPropertyT<double>                        MaxDampStrengthX            = new FbxPropertyT<double>("MaxDampStrengthX");
        public FbxPropertyT<double>                        MaxDampStrengthY            = new FbxPropertyT<double>("MaxDampStrengthY");
        public FbxPropertyT<double>                        MaxDampStrengthZ            = new FbxPropertyT<double>("MaxDampStrengthZ");
        public FbxPropertyT<double>                        PreferedAngleX              = new FbxPropertyT<double>("PreferedAngleX");
        public FbxPropertyT<double>                        PreferedAngleY              = new FbxPropertyT<double>("PreferedAngleY");
        public FbxPropertyT<double>                        PreferedAngleZ              = new FbxPropertyT<double>("PreferedAngleZ");
        public FbxPropertyT<FbxObject>                     LookAtProperty              = new FbxPropertyT<FbxObject>("LookAtProperty");
        public FbxPropertyT<FbxObject>                     UpVectorProperty            = new FbxPropertyT<FbxObject>("UpVectorProperty");
        public FbxPropertyT<bool>                          Show                        = new FbxPropertyT<bool>("Show");
        public FbxPropertyT<bool>                          NegativePercentShapeSupport = new FbxPropertyT<bool>("NegativePercentShapeSupport");
        public FbxPropertyT<int>                           DefaultAttributeIndex       = new FbxPropertyT<int>("DefaultAttributeIndex");
        public FbxPropertyT<bool>                          Freeze                      = new FbxPropertyT<bool>("Freeze");
        public FbxPropertyT<bool>                          LODBox                      = new FbxPropertyT<bool>("LODBox");

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

