using System;
using ChamberLib;

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
        }

        public bool MultiLayer;
        public bool MultiTake;
        public bool Shading;
        public string Culling;

        #region Public and Fast Access Properties

        PropertyT<Vector3>                      LclTranslation                  = new PropertyT<Vector3>("Lcl Translation");
        PropertyT<Vector3>                      LclRotation                     = new PropertyT<Vector3>("Lcl Rotation");
        PropertyT<Vector3>                      LclScaling                      = new PropertyT<Vector3>("Lcl Scaling");
        PropertyT<double>                       Visibility                      = new PropertyT<double>("Visibility");
        PropertyT<bool>                         VisibilityInheritance           = new PropertyT<bool>("VisibilityInheritance");
        //PropertyT<EFbxQuatInterpMode>           QuaternionInterpolate           = new PropertyT<EFbxQuatInterpMode>("QuaternionInterpolate");
        PropertyT<Vector3>                      RotationOffset                  = new PropertyT<Vector3>("RotationOffset");
        PropertyT<Vector3>                      RotationPivot                   = new PropertyT<Vector3>("RotationPivot");
        PropertyT<Vector3>                      ScalingOffset                   = new PropertyT<Vector3>("ScalingOffset");
        PropertyT<Vector3>                      ScalingPivot                    = new PropertyT<Vector3>("ScalingPivot");
        PropertyT<bool>                         TranslationActive               = new PropertyT<bool>("TranslationActive");
        PropertyT<Vector3>                      TranslationMin                  = new PropertyT<Vector3>("TranslationMin");
        PropertyT<Vector3>                      TranslationMax                  = new PropertyT<Vector3>("TranslationMax");
        PropertyT<bool>                         TranslationMinX                 = new PropertyT<bool>("TranslationMinX");
        PropertyT<bool>                         TranslationMinY                 = new PropertyT<bool>("TranslationMinY");
        PropertyT<bool>                         TranslationMinZ                 = new PropertyT<bool>("TranslationMinZ");
        PropertyT<bool>                         TranslationMaxX                 = new PropertyT<bool>("TranslationMaxX");
        PropertyT<bool>                         TranslationMaxY                 = new PropertyT<bool>("TranslationMaxY");
        PropertyT<bool>                         TranslationMaxZ                 = new PropertyT<bool>("TranslationMaxZ");
        //PropertyT<EFbxRotationOrder>            RotationOrder                   = new PropertyT<EFbxRotationOrder>("RotationOrder");
        PropertyT<bool>                         RotationSpaceForLimitOnly       = new PropertyT<bool>("RotationSpaceForLimitOnly");
        PropertyT<double>                       RotationStiffnessX              = new PropertyT<double>("RotationStiffnessX");
        PropertyT<double>                       RotationStiffnessY              = new PropertyT<double>("RotationStiffnessY");
        PropertyT<double>                       RotationStiffnessZ              = new PropertyT<double>("RotationStiffnessZ");
        PropertyT<double>                       AxisLen                         = new PropertyT<double>("AxisLen");
        PropertyT<Vector3>                      PreRotation                     = new PropertyT<Vector3>("PreRotation");
        PropertyT<Vector3>                      PostRotation                    = new PropertyT<Vector3>("PostRotation");
        PropertyT<bool>                         RotationActive                  = new PropertyT<bool>("RotationActive");
        PropertyT<Vector3>                      RotationMin                     = new PropertyT<Vector3>("RotationMin");
        PropertyT<Vector3>                      RotationMax                     = new PropertyT<Vector3>("RotationMax");
        PropertyT<bool>                         RotationMinX                    = new PropertyT<bool>("RotationMinX");
        PropertyT<bool>                         RotationMinY                    = new PropertyT<bool>("RotationMinY");
        PropertyT<bool>                         RotationMinZ                    = new PropertyT<bool>("RotationMinZ");
        PropertyT<bool>                         RotationMaxX                    = new PropertyT<bool>("RotationMaxX");
        PropertyT<bool>                         RotationMaxY                    = new PropertyT<bool>("RotationMaxY");
        PropertyT<bool>                         RotationMaxZ                    = new PropertyT<bool>("RotationMaxZ");
        //PropertyT<FbxTransform::EInheritType>   InheritType                     = new PropertyT<FbxTransform::EInheritType>("InheritType");
        PropertyT<bool>                         ScalingActive                   = new PropertyT<bool>("ScalingActive");
        PropertyT<Vector3>                      ScalingMin                      = new PropertyT<Vector3>("ScalingMin");
        PropertyT<Vector3>                      ScalingMax                      = new PropertyT<Vector3>("ScalingMax");
        PropertyT<bool>                         ScalingMinX                     = new PropertyT<bool>("ScalingMinX");
        PropertyT<bool>                         ScalingMinY                     = new PropertyT<bool>("ScalingMinY");
        PropertyT<bool>                         ScalingMinZ                     = new PropertyT<bool>("ScalingMinZ");
        PropertyT<bool>                         ScalingMaxX                     = new PropertyT<bool>("ScalingMaxX");
        PropertyT<bool>                         ScalingMaxY                     = new PropertyT<bool>("ScalingMaxY");
        PropertyT<bool>                         ScalingMaxZ                     = new PropertyT<bool>("ScalingMaxZ");
        PropertyT<Vector3>                      GeometricTranslation            = new PropertyT<Vector3>("GeometricTranslation");
        PropertyT<Vector3>                      GeometricRotation               = new PropertyT<Vector3>("GeometricRotation");
        PropertyT<Vector3>                      GeometricScaling                = new PropertyT<Vector3>("GeometricScaling");
        PropertyT<double>                       MinDampRangeX                   = new PropertyT<double>("MinDampRangeX");
        PropertyT<double>                       MinDampRangeY                   = new PropertyT<double>("MinDampRangeY");
        PropertyT<double>                       MinDampRangeZ                   = new PropertyT<double>("MinDampRangeZ");
        PropertyT<double>                       MaxDampRangeX                   = new PropertyT<double>("MaxDampRangeX");
        PropertyT<double>                       MaxDampRangeY                   = new PropertyT<double>("MaxDampRangeY");
        PropertyT<double>                       MaxDampRangeZ                   = new PropertyT<double>("MaxDampRangeZ");
        PropertyT<double>                       MinDampStrengthX                = new PropertyT<double>("MinDampStrengthX");
        PropertyT<double>                       MinDampStrengthY                = new PropertyT<double>("MinDampStrengthY");
        PropertyT<double>                       MinDampStrengthZ                = new PropertyT<double>("MinDampStrengthZ");
        PropertyT<double>                       MaxDampStrengthX                = new PropertyT<double>("MaxDampStrengthX");
        PropertyT<double>                       MaxDampStrengthY                = new PropertyT<double>("MaxDampStrengthY");
        PropertyT<double>                       MaxDampStrengthZ                = new PropertyT<double>("MaxDampStrengthZ");
        PropertyT<double>                       PreferedAngleX                  = new PropertyT<double>("PreferedAngleX");
        PropertyT<double>                       PreferedAngleY                  = new PropertyT<double>("PreferedAngleY");
        PropertyT<double>                       PreferedAngleZ                  = new PropertyT<double>("PreferedAngleZ");
        PropertyT<FbxObject>                    LookAtProperty                  = new PropertyT<FbxObject>("LookAtProperty");
        PropertyT<FbxObject>                    UpVectorProperty                = new PropertyT<FbxObject>("UpVectorProperty");
        PropertyT<bool>                         Show                            = new PropertyT<bool>("Show");
        PropertyT<bool>                         NegativePercentShapeSupport     = new PropertyT<bool>("NegativePercentShapeSupport");
        PropertyT<int>                          DefaultAttributeIndex           = new PropertyT<int>("DefaultAttributeIndex");
        PropertyT<bool>                         Freeze                          = new PropertyT<bool>("Freeze");
        PropertyT<bool>                         LODBox                          = new PropertyT<bool>("LODBox");

        #endregion
    }
}

