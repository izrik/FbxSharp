using System;
using ChamberLib;
using System.Collections.Generic;

namespace FbxSharp
{
    public class Node : FbxObject
    {
        public Node()
        {
            this.Properties.AddRange(
                new Property[] {
                    LclTranslation,
                    LclRotation,
                    LclScaling,
                    Visibility,
                    VisibilityInheritance,
                    //QuaternionInterpolate,
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
                    //RotationOrder,
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
                    //InheritType,
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

            this.ChildNodes = new NodeNodeOrderedParentChildrenCollection(this);
        }

        public bool MultiLayer;
        public bool MultiTake;
        public bool Shading;
        public string Culling;

        #region Node Tree Management

        // TODO: also create object-object connections

        //Get the parent node.
        public Node GetParent()
        {
            return ParentNode;
        }

        //Add a child node and its underlying node tree.
        public bool AddChild(Node pNode)
        {
            if (pNode == null)
                return false;
            ChildNodes.Add(pNode);
            return true;
        }

        //Remove the child node.
        public Node RemoveChild(Node pNode)
        {
            if (ChildNodes.Remove(pNode))
                return pNode;
            return null;
        }

        //Get the number of children nodes.
        public int GetChildCount()//bool pRecursive = false)
        {
            return ChildNodes.Count;
        }

        //Get child by index.
        public Node GetChild(int pIndex)
        {
            return ChildNodes[pIndex];
        }

        private Node _parentNode = null;
        public Node ParentNode
        {
            get { return _parentNode; }
            set
            {
                if (_parentNode != value)
                {
                    if (_parentNode != null)
                    {
                        _parentNode.ChildNodes.Remove(this);
                    }

                    _parentNode = value;

                    if (_parentNode != null)
                    {
                        _parentNode.ChildNodes.Add(this);
                    }
                }
            }
        }
        readonly NodeNodeOrderedParentChildrenCollection ChildNodes;

        //Finds a child node by name.
        //FbxNode *   FindChild (const char *pName, bool pRecursive=true, bool pInitial=false)

        #endregion

        #region Node Attribute Management

        NodeAttribute nodeAttribute;

        //Set the node attribute.
        public NodeAttribute SetNodeAttribute(NodeAttribute pNodeAttribute)
        {
            nodeAttribute = pNodeAttribute;
            return pNodeAttribute;
        }

        //Get the default node attribute.
        public NodeAttribute GetNodeAttribute()
        {
            return nodeAttribute;
        }

        #endregion

        #region Public and Fast Access Properties

        public PropertyT<Vector3>                       LclTranslation              = new PropertyT<Vector3>("Lcl Translation");
        public PropertyT<Vector3>                       LclRotation                 = new PropertyT<Vector3>("Lcl Rotation");
        public PropertyT<Vector3>                       LclScaling                  = new PropertyT<Vector3>("Lcl Scaling");
        public PropertyT<double>                        Visibility                  = new PropertyT<double>("Visibility");
        public PropertyT<bool>                          VisibilityInheritance       = new PropertyT<bool>("VisibilityInheritance");
        //public PropertyT<EFbxQuatInterpMode>           QuaternionInterpolate       = new PropertyT<EFbxQuatInterpMode>("QuaternionInterpolate");
        public PropertyT<Vector3>                       RotationOffset              = new PropertyT<Vector3>("RotationOffset");
        public PropertyT<Vector3>                       RotationPivot               = new PropertyT<Vector3>("RotationPivot");
        public PropertyT<Vector3>                       ScalingOffset               = new PropertyT<Vector3>("ScalingOffset");
        public PropertyT<Vector3>                       ScalingPivot                = new PropertyT<Vector3>("ScalingPivot");
        public PropertyT<bool>                          TranslationActive           = new PropertyT<bool>("TranslationActive");
        public PropertyT<Vector3>                       TranslationMin              = new PropertyT<Vector3>("TranslationMin");
        public PropertyT<Vector3>                       TranslationMax              = new PropertyT<Vector3>("TranslationMax");
        public PropertyT<bool>                          TranslationMinX             = new PropertyT<bool>("TranslationMinX");
        public PropertyT<bool>                          TranslationMinY             = new PropertyT<bool>("TranslationMinY");
        public PropertyT<bool>                          TranslationMinZ             = new PropertyT<bool>("TranslationMinZ");
        public PropertyT<bool>                          TranslationMaxX             = new PropertyT<bool>("TranslationMaxX");
        public PropertyT<bool>                          TranslationMaxY             = new PropertyT<bool>("TranslationMaxY");
        public PropertyT<bool>                          TranslationMaxZ             = new PropertyT<bool>("TranslationMaxZ");
        //public PropertyT<EFbxRotationOrder>             RotationOrder               = new PropertyT<EFbxRotationOrder>("RotationOrder");
        public PropertyT<bool>                          RotationSpaceForLimitOnly   = new PropertyT<bool>("RotationSpaceForLimitOnly");
        public PropertyT<double>                        RotationStiffnessX          = new PropertyT<double>("RotationStiffnessX");
        public PropertyT<double>                        RotationStiffnessY          = new PropertyT<double>("RotationStiffnessY");
        public PropertyT<double>                        RotationStiffnessZ          = new PropertyT<double>("RotationStiffnessZ");
        public PropertyT<double>                        AxisLen                     = new PropertyT<double>("AxisLen");
        public PropertyT<Vector3>                       PreRotation                 = new PropertyT<Vector3>("PreRotation");
        public PropertyT<Vector3>                       PostRotation                = new PropertyT<Vector3>("PostRotation");
        public PropertyT<bool>                          RotationActive              = new PropertyT<bool>("RotationActive");
        public PropertyT<Vector3>                       RotationMin                 = new PropertyT<Vector3>("RotationMin");
        public PropertyT<Vector3>                       RotationMax                 = new PropertyT<Vector3>("RotationMax");
        public PropertyT<bool>                          RotationMinX                = new PropertyT<bool>("RotationMinX");
        public PropertyT<bool>                          RotationMinY                = new PropertyT<bool>("RotationMinY");
        public PropertyT<bool>                          RotationMinZ                = new PropertyT<bool>("RotationMinZ");
        public PropertyT<bool>                          RotationMaxX                = new PropertyT<bool>("RotationMaxX");
        public PropertyT<bool>                          RotationMaxY                = new PropertyT<bool>("RotationMaxY");
        public PropertyT<bool>                          RotationMaxZ                = new PropertyT<bool>("RotationMaxZ");
        //public PropertyT<FbxTransform::EInheritType>    InheritType                 = new PropertyT<FbxTransform::EInheritType>("InheritType");
        public PropertyT<bool>                          ScalingActive               = new PropertyT<bool>("ScalingActive");
        public PropertyT<Vector3>                       ScalingMin                  = new PropertyT<Vector3>("ScalingMin");
        public PropertyT<Vector3>                       ScalingMax                  = new PropertyT<Vector3>("ScalingMax");
        public PropertyT<bool>                          ScalingMinX                 = new PropertyT<bool>("ScalingMinX");
        public PropertyT<bool>                          ScalingMinY                 = new PropertyT<bool>("ScalingMinY");
        public PropertyT<bool>                          ScalingMinZ                 = new PropertyT<bool>("ScalingMinZ");
        public PropertyT<bool>                          ScalingMaxX                 = new PropertyT<bool>("ScalingMaxX");
        public PropertyT<bool>                          ScalingMaxY                 = new PropertyT<bool>("ScalingMaxY");
        public PropertyT<bool>                          ScalingMaxZ                 = new PropertyT<bool>("ScalingMaxZ");
        public PropertyT<Vector3>                       GeometricTranslation        = new PropertyT<Vector3>("GeometricTranslation");
        public PropertyT<Vector3>                       GeometricRotation           = new PropertyT<Vector3>("GeometricRotation");
        public PropertyT<Vector3>                       GeometricScaling            = new PropertyT<Vector3>("GeometricScaling");
        public PropertyT<double>                        MinDampRangeX               = new PropertyT<double>("MinDampRangeX");
        public PropertyT<double>                        MinDampRangeY               = new PropertyT<double>("MinDampRangeY");
        public PropertyT<double>                        MinDampRangeZ               = new PropertyT<double>("MinDampRangeZ");
        public PropertyT<double>                        MaxDampRangeX               = new PropertyT<double>("MaxDampRangeX");
        public PropertyT<double>                        MaxDampRangeY               = new PropertyT<double>("MaxDampRangeY");
        public PropertyT<double>                        MaxDampRangeZ               = new PropertyT<double>("MaxDampRangeZ");
        public PropertyT<double>                        MinDampStrengthX            = new PropertyT<double>("MinDampStrengthX");
        public PropertyT<double>                        MinDampStrengthY            = new PropertyT<double>("MinDampStrengthY");
        public PropertyT<double>                        MinDampStrengthZ            = new PropertyT<double>("MinDampStrengthZ");
        public PropertyT<double>                        MaxDampStrengthX            = new PropertyT<double>("MaxDampStrengthX");
        public PropertyT<double>                        MaxDampStrengthY            = new PropertyT<double>("MaxDampStrengthY");
        public PropertyT<double>                        MaxDampStrengthZ            = new PropertyT<double>("MaxDampStrengthZ");
        public PropertyT<double>                        PreferedAngleX              = new PropertyT<double>("PreferedAngleX");
        public PropertyT<double>                        PreferedAngleY              = new PropertyT<double>("PreferedAngleY");
        public PropertyT<double>                        PreferedAngleZ              = new PropertyT<double>("PreferedAngleZ");
        public PropertyT<FbxObject>                     LookAtProperty              = new PropertyT<FbxObject>("LookAtProperty");
        public PropertyT<FbxObject>                     UpVectorProperty            = new PropertyT<FbxObject>("UpVectorProperty");
        public PropertyT<bool>                          Show                        = new PropertyT<bool>("Show");
        public PropertyT<bool>                          NegativePercentShapeSupport = new PropertyT<bool>("NegativePercentShapeSupport");
        public PropertyT<int>                           DefaultAttributeIndex       = new PropertyT<int>("DefaultAttributeIndex");
        public PropertyT<bool>                          Freeze                      = new PropertyT<bool>("Freeze");
        public PropertyT<bool>                          LODBox                      = new PropertyT<bool>("LODBox");

        #endregion
    }
}

