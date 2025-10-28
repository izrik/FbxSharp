namespace FbxSharp;

public static class FbxDataTypes
{
    #region Basic Data Types

    public static readonly FbxDataType FbxUndefinedDT =
        FbxDataType.Create("", EFbxType.eFbxUndefined, false);

    public static readonly FbxDataType FbxBoolDT =
        FbxDataType.Create("Bool", EFbxType.eFbxBool);

    public static readonly FbxDataType FbxCharDT =
        FbxDataType.Create("Byte", EFbxType.eFbxChar);

    public static readonly FbxDataType FbxUCharDT =
        FbxDataType.Create("UByte", EFbxType.eFbxUChar);

    public static readonly FbxDataType FbxShortDT =
        FbxDataType.Create("Short", EFbxType.eFbxShort);

    public static readonly FbxDataType FbxUShortDT =
        FbxDataType.Create("UShort", EFbxType.eFbxUShort);

    public static readonly FbxDataType FbxIntDT =
        FbxDataType.Create("Integer", EFbxType.eFbxInt);

    public static readonly FbxDataType FbxUIntDT =
        FbxDataType.Create("UInteger", EFbxType.eFbxUInt);

    public static readonly FbxDataType FbxLongLongDT =
        FbxDataType.Create("LongLong", EFbxType.eFbxLongLong);

    public static readonly FbxDataType FbxULongLongDT =
        FbxDataType.Create("ULongLong", EFbxType.eFbxULongLong);

    public static readonly FbxDataType FbxFloatDT =
        FbxDataType.Create("Float", EFbxType.eFbxFloat);

    public static readonly FbxDataType FbxHalfFloatDT =
        FbxDataType.Create("HalfFloat", EFbxType.eFbxHalfFloat);

    public static readonly FbxDataType FbxDoubleDT =
        FbxDataType.Create("Number", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxDouble2DT =
        FbxDataType.Create("Vector2", EFbxType.eFbxDouble2);

    public static readonly FbxDataType FbxDouble3DT =
        FbxDataType.Create("Vector", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxDouble4DT =
        FbxDataType.Create("Vector4", EFbxType.eFbxDouble4);

    public static readonly FbxDataType FbxDouble4x4DT =
        FbxDataType.Create("Matrix", EFbxType.eFbxDouble4x4);

    public static readonly FbxDataType FbxEnumDT =
        FbxDataType.Create("Enum", EFbxType.eFbxEnum);

    public static readonly FbxDataType FbxStringDT =
        FbxDataType.Create("KString", EFbxType.eFbxString);

    public static readonly FbxDataType FbxTimeDT =
        FbxDataType.Create("Time", EFbxType.eFbxTime);

    public static readonly FbxDataType FbxReferenceDT =
        FbxDataType.Create("Reference", EFbxType.eFbxReference);

    public static readonly FbxDataType FbxBlobDT =
        FbxDataType.Create("Blob", EFbxType.eFbxBlob);

    public static readonly FbxDataType FbxDistanceDT =
        FbxDataType.Create("Distance", EFbxType.eFbxDistance);

    public static readonly FbxDataType FbxDateTimeDT =
        FbxDataType.Create("DateTime", EFbxType.eFbxDateTime);

    #endregion

    #region Extended Data Types

    public static readonly FbxDataType FbxColor3DT =
        FbxDataType.Create("Color", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxColor4DT =
        FbxDataType.Create("ColorAndAlpha", EFbxType.eFbxDouble4);

    public static readonly FbxDataType FbxCompoundDT =
        FbxDataType.Create("Compound", EFbxType.eFbxUndefined);

    public static readonly FbxDataType FbxReferenceObjectDT =
        FbxDataType.Create("object", EFbxType.eFbxReference);

    public static readonly FbxDataType FbxReferencePropertyDT =
        FbxDataType.Create("ReferenceProperty", EFbxType.eFbxReference);

    public static readonly FbxDataType FbxVisibilityDT =
        FbxDataType.Create("Visibility", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxVisibilityInheritanceDT =
        FbxDataType.Create("Visibility Inheritance", EFbxType.eFbxBool);

    public static readonly FbxDataType FbxUrlDT =
        FbxDataType.Create("Url", EFbxType.eFbxString);

    public static readonly FbxDataType FbxXRefUrlDT =
        FbxDataType.Create("XRefUrl", EFbxType.eFbxString);

    #endregion

    #region Transform Data Types

    public static readonly FbxDataType FbxTranslationDT =
        FbxDataType.Create("Translation", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxRotationDT =
        FbxDataType.Create("Rotation", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxScalingDT =
        FbxDataType.Create("Scaling", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxQuaternionDT =
        FbxDataType.Create("Quaternion", EFbxType.eFbxDouble4);

    public static readonly FbxDataType FbxLocalTranslationDT =
        FbxDataType.Create("Lcl Translation", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxLocalRotationDT =
        FbxDataType.Create("Lcl Rotation", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxLocalScalingDT =
        FbxDataType.Create("Lcl Scaling", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxLocalQuaternionDT =
        FbxDataType.Create("Lcl Quaternion", EFbxType.eFbxDouble4);

    public static readonly FbxDataType FbxTransformMatrixDT =
        FbxDataType.Create("Matrix Transformation", EFbxType.eFbxDouble4x4);

    public static readonly FbxDataType FbxTranslationMatrixDT =
        FbxDataType.Create("Matrix Translation", EFbxType.eFbxDouble4x4);

    public static readonly FbxDataType FbxRotationMatrixDT =
        FbxDataType.Create("Matrix Rotation", EFbxType.eFbxDouble4x4);

    public static readonly FbxDataType FbxScalingMatrixDT =
        FbxDataType.Create("Matrix Scaling", EFbxType.eFbxDouble4x4);

    #endregion


    #region Material Data Types

    public static readonly FbxDataType FbxMaterialEmissiveDT =
        FbxDataType.Create("Emissive", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxMaterialEmissiveFactorDT =
        FbxDataType.Create("EmissiveFactor", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxMaterialAmbientDT =
        FbxDataType.Create("Ambient", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxMaterialAmbientFactorDT =
        FbxDataType.Create("AmbientFactor", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxMaterialDiffuseDT =
        FbxDataType.Create("Diffuse", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxMaterialDiffuseFactorDT =
        FbxDataType.Create("DiffuseFactor", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxMaterialBumpDT =
        FbxDataType.Create("Bump", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxMaterialNormalMapDT =
        FbxDataType.Create("NormalMap", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxMaterialTransparentColorDT =
        FbxDataType.Create("Transparent", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxMaterialTransparencyFactorDT =
        FbxDataType.Create("TransparencyFactor", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxMaterialSpecularDT =
        FbxDataType.Create("Specular", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxMaterialSpecularFactorDT =
        FbxDataType.Create("SpecularFactor", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxMaterialShininessDT =
        FbxDataType.Create("Shininess", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxMaterialReflectionDT =
        FbxDataType.Create("Reflection", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxMaterialReflectionFactorDT =
        FbxDataType.Create("ReflectionFactor", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxMaterialDisplacementDT =
        FbxDataType.Create("Displacement", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxMaterialVectorDisplacementDT =
        FbxDataType.Create("VectorDisplacement", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxMaterialCommonFactorDT =
        FbxDataType.Create("Unknown Factor", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxMaterialCommonTextureDT =
        FbxDataType.Create("Unknown texture", EFbxType.eFbxDouble3);

    #endregion


    #region Layer Element Data Types

    public static readonly FbxDataType FbxLayerElementUndefinedDT =
        FbxDataType.Create("LayerElementUndefined", EFbxType.eFbxUndefined);

    public static readonly FbxDataType FbxLayerElementNormalDT =
        FbxDataType.Create("LayerElementNormal", EFbxType.eFbxDouble4);

    public static readonly FbxDataType FbxLayerElementBinormalDT =
        FbxDataType.Create("LayerElementBinormal", EFbxType.eFbxDouble4);

    public static readonly FbxDataType FbxLayerElementTangentDT =
        FbxDataType.Create("LayerElementTangent", EFbxType.eFbxDouble4);

    public static readonly FbxDataType FbxLayerElementMaterialDT =
        FbxDataType.Create("LayerElementMaterial", EFbxType.eFbxReference);

    public static readonly FbxDataType FbxLayerElementTextureDT =
        FbxDataType.Create("LayerElementTexture", EFbxType.eFbxReference);

    public static readonly FbxDataType FbxLayerElementPolygonGroupDT =
        FbxDataType.Create("LayerElementPolygonGroup", EFbxType.eFbxInt);

    public static readonly FbxDataType FbxLayerElementUVDT =
        FbxDataType.Create("LayerElementUV", EFbxType.eFbxDouble2);

    public static readonly FbxDataType FbxLayerElementVertexColorDT =
        FbxDataType.Create("LayerElementVertexColor", EFbxType.eFbxDouble4);

    public static readonly FbxDataType FbxLayerElementSmoothingDT =
        FbxDataType.Create("LayerElementSmoothing", EFbxType.eFbxInt);

    public static readonly FbxDataType FbxLayerElementCreaseDT =
        FbxDataType.Create("LayerElementCrease", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxLayerElementHoleDT =
        FbxDataType.Create("LayerElementHole", EFbxType.eFbxBool);

    public static readonly FbxDataType FbxLayerElementUserDataDT =
        FbxDataType.Create("LayerElementUserData", EFbxType.eFbxReference);

    public static readonly FbxDataType FbxLayerElementVisibilityDT =
        FbxDataType.Create("LayerElementVisibility", EFbxType.eFbxBool);

    #endregion


    #region I/O Specialized Data Types

    public static readonly FbxDataType FbxAliasDT =
        FbxDataType.Create("Alias", EFbxType.eFbxEnum);

    public static readonly FbxDataType FbxPresetsDT =
        FbxDataType.Create("Presets", EFbxType.eFbxEnum);

    public static readonly FbxDataType FbxStatisticsDT =
        FbxDataType.Create("Statistics", EFbxType.eFbxString);

    public static readonly FbxDataType FbxTextLineDT =
        FbxDataType.Create("TextLine", EFbxType.eFbxString);

    public static readonly FbxDataType FbxUnitsDT =
        FbxDataType.Create("Units", EFbxType.eFbxString);

    public static readonly FbxDataType FbxWarningDT =
        FbxDataType.Create("Warning", EFbxType.eFbxString);

    public static readonly FbxDataType FbxWebDT =
        FbxDataType.Create("Web", EFbxType.eFbxString);

    #endregion


    #region External Support Data Types

    public static readonly FbxDataType FbxActionDT =
        FbxDataType.Create("Action", EFbxType.eFbxBool);

    public static readonly FbxDataType FbxCameraIndexDT =
        FbxDataType.Create("Camera Index", EFbxType.eFbxInt);

    public static readonly FbxDataType FbxCharPtrDT =
        FbxDataType.Create("charptr", EFbxType.eFbxString);

    public static readonly FbxDataType FbxConeAngleDT =
        FbxDataType.Create("Cone angle", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxEventDT =
        FbxDataType.Create("event", EFbxType.eFbxUndefined);

    public static readonly FbxDataType FbxFieldOfViewDT =
        FbxDataType.Create("FieldOfView", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxFieldOfViewXDT =
        FbxDataType.Create("FieldOfViewX", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxFieldOfViewYDT =
        FbxDataType.Create("FieldOfViewY", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxFogDT =
        FbxDataType.Create("Fog", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxHSBDT =
        FbxDataType.Create("HSB", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxIKReachTranslationDT =
        FbxDataType.Create("IK Reach Translation", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxIKReachRotationDT =
        FbxDataType.Create("IK Reach Rotation", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxIntensityDT =
        FbxDataType.Create("Intensity", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxLookAtDT =
        FbxDataType.Create("Look at", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxOcclusionDT =
        FbxDataType.Create("Occlusion", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxOpticalCenterXDT =
        FbxDataType.Create("OpticalCenterX", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxOpticalCenterYDT =
        FbxDataType.Create("OpticalCenterY", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxOrientationDT =
        FbxDataType.Create("Orientation", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxRealDT =
        FbxDataType.Create("Real", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxRollDT =
        FbxDataType.Create("Roll", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxScalingUVDT =
        FbxDataType.Create("Scaling UV", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxShapeDT =
        FbxDataType.Create("Shape", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxStringListDT =
        FbxDataType.Create("stringlist", EFbxType.eFbxEnumM);

    public static readonly FbxDataType FbxTextureRotationDT =
        FbxDataType.Create("TextureRotation", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxTimeCodeDT =
        FbxDataType.Create("TimeCode", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxTimeWarpDT =
        FbxDataType.Create("TimeWarp", EFbxType.eFbxDouble);

    public static readonly FbxDataType FbxTranslationUVDT =
        FbxDataType.Create("Translation UV", EFbxType.eFbxDouble3);

    public static readonly FbxDataType FbxWeightDT =
        FbxDataType.Create("Weight", EFbxType.eFbxDouble);

    #endregion
}
