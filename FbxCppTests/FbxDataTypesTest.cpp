
#include "Tests.h"

using namespace std;

void FbxDataTypes_FbxUndefinedDT_HasDefaultsAndIsNotValid()
{
    // expect:
    AssertFalse(FbxUndefinedDT.Valid());
    AssertEqual(EFbxType::eFbxUndefined, FbxUndefinedDT.GetType());
    AssertEqual("", FbxUndefinedDT.GetName());
}

void FbxDataTypes_FbxBoolDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxBoolDT.Valid());
    AssertEqual(EFbxType::eFbxBool, FbxBoolDT.GetType());
    AssertEqual("Bool", FbxBoolDT.GetName());
}

void FbxDataTypes_FbxCharDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxCharDT.Valid());
    AssertEqual(EFbxType::eFbxChar, FbxCharDT.GetType());
    AssertEqual("Byte", FbxCharDT.GetName());
}

void FbxDataTypes_FbxUCharDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxUCharDT.Valid());
    AssertEqual(EFbxType::eFbxUChar, FbxUCharDT.GetType());
    AssertEqual("UByte", FbxUCharDT.GetName());
}

void FbxDataTypes_FbxShortDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxShortDT.Valid());
    AssertEqual(EFbxType::eFbxShort, FbxShortDT.GetType());
    AssertEqual("Short", FbxShortDT.GetName());
}

void FbxDataTypes_FbxUShortDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxUShortDT.Valid());
    AssertEqual(EFbxType::eFbxUShort, FbxUShortDT.GetType());
    AssertEqual("UShort", FbxUShortDT.GetName());
}

void FbxDataTypes_FbxIntDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxIntDT.Valid());
    AssertEqual(EFbxType::eFbxInt, FbxIntDT.GetType());
    AssertEqual("Integer", FbxIntDT.GetName());
}

void FbxDataTypes_FbxUIntDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxUIntDT.Valid());
    AssertEqual(EFbxType::eFbxUInt, FbxUIntDT.GetType());
    AssertEqual("UInteger", FbxUIntDT.GetName());
}

void FbxDataTypes_FbxLongLongDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxLongLongDT.Valid());
    AssertEqual(EFbxType::eFbxLongLong, FbxLongLongDT.GetType());
    AssertEqual("LongLong", FbxLongLongDT.GetName());
}

void FbxDataTypes_FbxULongLongDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxULongLongDT.Valid());
    AssertEqual(EFbxType::eFbxULongLong, FbxULongLongDT.GetType());
    AssertEqual("ULongLong", FbxULongLongDT.GetName());
}

void FbxDataTypes_FbxFloatDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxFloatDT.Valid());
    AssertEqual(EFbxType::eFbxFloat, FbxFloatDT.GetType());
    AssertEqual("Float", FbxFloatDT.GetName());
}

void FbxDataTypes_FbxHalfFloatDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxHalfFloatDT.Valid());
    AssertEqual(EFbxType::eFbxHalfFloat, FbxHalfFloatDT.GetType());
    AssertEqual("HalfFloat", FbxHalfFloatDT.GetName());
}

void FbxDataTypes_FbxDoubleDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxDoubleDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxDoubleDT.GetType());
    AssertEqual("Number", FbxDoubleDT.GetName());
}

void FbxDataTypes_FbxDouble2DT_HasDefaults()
{
    // expect:
    AssertTrue(FbxDouble2DT.Valid());
    AssertEqual(EFbxType::eFbxDouble2, FbxDouble2DT.GetType());
    AssertEqual("Vector2", FbxDouble2DT.GetName());
}

void FbxDataTypes_FbxDouble3DT_HasDefaults()
{
    // expect:
    AssertTrue(FbxDouble3DT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxDouble3DT.GetType());
    AssertEqual("Vector", FbxDouble3DT.GetName());
}

void FbxDataTypes_FbxDouble4DT_HasDefaults()
{
    // expect:
    AssertTrue(FbxDouble4DT.Valid());
    AssertEqual(EFbxType::eFbxDouble4, FbxDouble4DT.GetType());
    AssertEqual("Vector4", FbxDouble4DT.GetName());
}

void FbxDataTypes_FbxDouble4x4DT_HasDefaults()
{
    // expect:
    AssertTrue(FbxDouble4x4DT.Valid());
    AssertEqual(EFbxType::eFbxDouble4x4, FbxDouble4x4DT.GetType());
    AssertEqual("Matrix", FbxDouble4x4DT.GetName());
}

void FbxDataTypes_FbxEnumDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxEnumDT.Valid());
    AssertEqual(EFbxType::eFbxEnum, FbxEnumDT.GetType());
    AssertEqual("Enum", FbxEnumDT.GetName());
}

void FbxDataTypes_FbxStringDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxStringDT.Valid());
    AssertEqual(EFbxType::eFbxString, FbxStringDT.GetType());
    AssertEqual("KString", FbxStringDT.GetName());
}

void FbxDataTypes_FbxTimeDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxTimeDT.Valid());
    AssertEqual(EFbxType::eFbxTime, FbxTimeDT.GetType());
    AssertEqual("Time", FbxTimeDT.GetName());
}

void FbxDataTypes_FbxReferenceDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxReferenceDT.Valid());
    AssertEqual(EFbxType::eFbxReference, FbxReferenceDT.GetType());
    AssertEqual("Reference", FbxReferenceDT.GetName());
}

void FbxDataTypes_FbxBlobDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxBlobDT.Valid());
    AssertEqual(EFbxType::eFbxBlob, FbxBlobDT.GetType());
    AssertEqual("Blob", FbxBlobDT.GetName());
}

void FbxDataTypes_FbxDistanceDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxDistanceDT.Valid());
    AssertEqual(EFbxType::eFbxDistance, FbxDistanceDT.GetType());
    AssertEqual("Distance", FbxDistanceDT.GetName());
}

void FbxDataTypes_FbxDateTimeDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxDateTimeDT.Valid());
    AssertEqual(EFbxType::eFbxDateTime, FbxDateTimeDT.GetType());
    AssertEqual("DateTime", FbxDateTimeDT.GetName());
}

void FbxDataTypes_FbxColor3DT_HasDefaults()
{
    // expect:
    AssertTrue(FbxColor3DT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxColor3DT.GetType());
    AssertEqual("Color", FbxColor3DT.GetName());
}

void FbxDataTypes_FbxColor4DT_HasDefaults()
{
    // expect:
    AssertTrue(FbxColor4DT.Valid());
    AssertEqual(EFbxType::eFbxDouble4, FbxColor4DT.GetType());
    AssertEqual("ColorAndAlpha", FbxColor4DT.GetName());
}

void FbxDataTypes_FbxCompoundDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxCompoundDT.Valid());
    AssertEqual(EFbxType::eFbxUndefined, FbxCompoundDT.GetType());
    AssertEqual("Compound", FbxCompoundDT.GetName());
}

void FbxDataTypes_FbxReferenceObjectDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxReferenceObjectDT.Valid());
    AssertEqual(EFbxType::eFbxReference, FbxReferenceObjectDT.GetType());
    AssertEqual("object", FbxReferenceObjectDT.GetName());
}

void FbxDataTypes_FbxReferencePropertyDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxReferencePropertyDT.Valid());
    AssertEqual(EFbxType::eFbxReference, FbxReferencePropertyDT.GetType());
    AssertEqual("ReferenceProperty", FbxReferencePropertyDT.GetName());
}

void FbxDataTypes_FbxVisibilityDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxVisibilityDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxVisibilityDT.GetType());
    AssertEqual("Visibility", FbxVisibilityDT.GetName());
}

void FbxDataTypes_FbxVisibilityInheritanceDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxVisibilityInheritanceDT.Valid());
    AssertEqual(EFbxType::eFbxBool, FbxVisibilityInheritanceDT.GetType());
    AssertEqual("Visibility Inheritance", FbxVisibilityInheritanceDT.GetName());
}

void FbxDataTypes_FbxUrlDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxUrlDT.Valid());
    AssertEqual(EFbxType::eFbxString, FbxUrlDT.GetType());
    AssertEqual("Url", FbxUrlDT.GetName());
}

void FbxDataTypes_FbxXRefUrlDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxXRefUrlDT.Valid());
    AssertEqual(EFbxType::eFbxString, FbxXRefUrlDT.GetType());
    AssertEqual("XRefUrl", FbxXRefUrlDT.GetName());
}

void FbxDataTypes_FbxTranslationDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxTranslationDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxTranslationDT.GetType());
    AssertEqual("Translation", FbxTranslationDT.GetName());
}

void FbxDataTypes_FbxRotationDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxRotationDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxRotationDT.GetType());
    AssertEqual("Rotation", FbxRotationDT.GetName());
}

void FbxDataTypes_FbxScalingDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxScalingDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxScalingDT.GetType());
    AssertEqual("Scaling", FbxScalingDT.GetName());
}

void FbxDataTypes_FbxQuaternionDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxQuaternionDT.Valid());
    AssertEqual(EFbxType::eFbxDouble4, FbxQuaternionDT.GetType());
    AssertEqual("Quaternion", FbxQuaternionDT.GetName());
}

void FbxDataTypes_FbxLocalTranslationDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxLocalTranslationDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxLocalTranslationDT.GetType());
    AssertEqual("Lcl Translation", FbxLocalTranslationDT.GetName());
}

void FbxDataTypes_FbxLocalRotationDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxLocalRotationDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxLocalRotationDT.GetType());
    AssertEqual("Lcl Rotation", FbxLocalRotationDT.GetName());
}

void FbxDataTypes_FbxLocalScalingDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxLocalScalingDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxLocalScalingDT.GetType());
    AssertEqual("Lcl Scaling", FbxLocalScalingDT.GetName());
}

void FbxDataTypes_FbxLocalQuaternionDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxLocalQuaternionDT.Valid());
    AssertEqual(EFbxType::eFbxDouble4, FbxLocalQuaternionDT.GetType());
    AssertEqual("Lcl Quaternion", FbxLocalQuaternionDT.GetName());
}

void FbxDataTypes_FbxTransformMatrixDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxTransformMatrixDT.Valid());
    AssertEqual(EFbxType::eFbxDouble4x4, FbxTransformMatrixDT.GetType());
    AssertEqual("Matrix Transformation", FbxTransformMatrixDT.GetName());
}

void FbxDataTypes_FbxTranslationMatrixDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxTranslationMatrixDT.Valid());
    AssertEqual(EFbxType::eFbxDouble4x4, FbxTranslationMatrixDT.GetType());
    AssertEqual("Matrix Translation", FbxTranslationMatrixDT.GetName());
}

void FbxDataTypes_FbxRotationMatrixDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxRotationMatrixDT.Valid());
    AssertEqual(EFbxType::eFbxDouble4x4, FbxRotationMatrixDT.GetType());
    AssertEqual("Matrix Rotation", FbxRotationMatrixDT.GetName());
}

void FbxDataTypes_FbxScalingMatrixDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxScalingMatrixDT.Valid());
    AssertEqual(EFbxType::eFbxDouble4x4, FbxScalingMatrixDT.GetType());
    AssertEqual("Matrix Scaling", FbxScalingMatrixDT.GetName());
}

void FbxDataTypes_FbxMaterialEmissiveDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxMaterialEmissiveDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxMaterialEmissiveDT.GetType());
    AssertEqual("Emissive", FbxMaterialEmissiveDT.GetName());
}

void FbxDataTypes_FbxMaterialEmissiveFactorDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxMaterialEmissiveFactorDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxMaterialEmissiveFactorDT.GetType());
    AssertEqual("EmissiveFactor", FbxMaterialEmissiveFactorDT.GetName());
}

void FbxDataTypes_FbxMaterialAmbientDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxMaterialAmbientDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxMaterialAmbientDT.GetType());
    AssertEqual("Ambient", FbxMaterialAmbientDT.GetName());
}

void FbxDataTypes_FbxMaterialAmbientFactorDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxMaterialAmbientFactorDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxMaterialAmbientFactorDT.GetType());
    AssertEqual("AmbientFactor", FbxMaterialAmbientFactorDT.GetName());
}

void FbxDataTypes_FbxMaterialDiffuseDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxMaterialDiffuseDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxMaterialDiffuseDT.GetType());
    AssertEqual("Diffuse", FbxMaterialDiffuseDT.GetName());
}

void FbxDataTypes_FbxMaterialDiffuseFactorDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxMaterialDiffuseFactorDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxMaterialDiffuseFactorDT.GetType());
    AssertEqual("DiffuseFactor", FbxMaterialDiffuseFactorDT.GetName());
}

void FbxDataTypes_FbxMaterialBumpDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxMaterialBumpDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxMaterialBumpDT.GetType());
    AssertEqual("Bump", FbxMaterialBumpDT.GetName());
}

void FbxDataTypes_FbxMaterialNormalMapDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxMaterialNormalMapDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxMaterialNormalMapDT.GetType());
    AssertEqual("NormalMap", FbxMaterialNormalMapDT.GetName());
}

void FbxDataTypes_FbxMaterialTransparentColorDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxMaterialTransparentColorDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxMaterialTransparentColorDT.GetType());
    AssertEqual("Transparent", FbxMaterialTransparentColorDT.GetName());
}

void FbxDataTypes_FbxMaterialTransparencyFactorDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxMaterialTransparencyFactorDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxMaterialTransparencyFactorDT.GetType());
    AssertEqual("TransparencyFactor", FbxMaterialTransparencyFactorDT.GetName());
}

void FbxDataTypes_FbxMaterialSpecularDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxMaterialSpecularDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxMaterialSpecularDT.GetType());
    AssertEqual("Specular", FbxMaterialSpecularDT.GetName());
}

void FbxDataTypes_FbxMaterialSpecularFactorDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxMaterialSpecularFactorDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxMaterialSpecularFactorDT.GetType());
    AssertEqual("SpecularFactor", FbxMaterialSpecularFactorDT.GetName());
}

void FbxDataTypes_FbxMaterialShininessDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxMaterialShininessDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxMaterialShininessDT.GetType());
    AssertEqual("Shininess", FbxMaterialShininessDT.GetName());
}

void FbxDataTypes_FbxMaterialReflectionDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxMaterialReflectionDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxMaterialReflectionDT.GetType());
    AssertEqual("Reflection", FbxMaterialReflectionDT.GetName());
}

void FbxDataTypes_FbxMaterialReflectionFactorDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxMaterialReflectionFactorDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxMaterialReflectionFactorDT.GetType());
    AssertEqual("ReflectionFactor", FbxMaterialReflectionFactorDT.GetName());
}

void FbxDataTypes_FbxMaterialDisplacementDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxMaterialDisplacementDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxMaterialDisplacementDT.GetType());
    AssertEqual("Displacement", FbxMaterialDisplacementDT.GetName());
}

void FbxDataTypes_FbxMaterialVectorDisplacementDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxMaterialVectorDisplacementDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxMaterialVectorDisplacementDT.GetType());
    AssertEqual("VectorDisplacement", FbxMaterialVectorDisplacementDT.GetName());
}

void FbxDataTypes_FbxMaterialCommonFactorDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxMaterialCommonFactorDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxMaterialCommonFactorDT.GetType());
    AssertEqual("Unknown Factor", FbxMaterialCommonFactorDT.GetName());
}

void FbxDataTypes_FbxMaterialCommonTextureDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxMaterialCommonTextureDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxMaterialCommonTextureDT.GetType());
    AssertEqual("Unknown texture", FbxMaterialCommonTextureDT.GetName());
}

void FbxDataTypes_FbxLayerElementUndefinedDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxLayerElementUndefinedDT.Valid());
    AssertEqual(EFbxType::eFbxUndefined, FbxLayerElementUndefinedDT.GetType());
    AssertEqual("LayerElementUndefined", FbxLayerElementUndefinedDT.GetName());
}

void FbxDataTypes_FbxLayerElementNormalDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxLayerElementNormalDT.Valid());
    AssertEqual(EFbxType::eFbxDouble4, FbxLayerElementNormalDT.GetType());
    AssertEqual("LayerElementNormal", FbxLayerElementNormalDT.GetName());
}

void FbxDataTypes_FbxLayerElementBinormalDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxLayerElementBinormalDT.Valid());
    AssertEqual(EFbxType::eFbxDouble4, FbxLayerElementBinormalDT.GetType());
    AssertEqual("LayerElementBinormal", FbxLayerElementBinormalDT.GetName());
}

void FbxDataTypes_FbxLayerElementTangentDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxLayerElementTangentDT.Valid());
    AssertEqual(EFbxType::eFbxDouble4, FbxLayerElementTangentDT.GetType());
    AssertEqual("LayerElementTangent", FbxLayerElementTangentDT.GetName());
}

void FbxDataTypes_FbxLayerElementMaterialDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxLayerElementMaterialDT.Valid());
    AssertEqual(EFbxType::eFbxReference, FbxLayerElementMaterialDT.GetType());
    AssertEqual("LayerElementMaterial", FbxLayerElementMaterialDT.GetName());
}

void FbxDataTypes_FbxLayerElementTextureDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxLayerElementTextureDT.Valid());
    AssertEqual(EFbxType::eFbxReference, FbxLayerElementTextureDT.GetType());
    AssertEqual("LayerElementTexture", FbxLayerElementTextureDT.GetName());
}

void FbxDataTypes_FbxLayerElementPolygonGroupDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxLayerElementPolygonGroupDT.Valid());
    AssertEqual(EFbxType::eFbxInt, FbxLayerElementPolygonGroupDT.GetType());
    AssertEqual("LayerElementPolygonGroup", FbxLayerElementPolygonGroupDT.GetName());
}

void FbxDataTypes_FbxLayerElementUVDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxLayerElementUVDT.Valid());
    AssertEqual(EFbxType::eFbxDouble2, FbxLayerElementUVDT.GetType());
    AssertEqual("LayerElementUV", FbxLayerElementUVDT.GetName());
}

void FbxDataTypes_FbxLayerElementVertexColorDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxLayerElementVertexColorDT.Valid());
    AssertEqual(EFbxType::eFbxDouble4, FbxLayerElementVertexColorDT.GetType());
    AssertEqual("LayerElementVertexColor", FbxLayerElementVertexColorDT.GetName());
}

void FbxDataTypes_FbxLayerElementSmoothingDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxLayerElementSmoothingDT.Valid());
    AssertEqual(EFbxType::eFbxInt, FbxLayerElementSmoothingDT.GetType());
    AssertEqual("LayerElementSmoothing", FbxLayerElementSmoothingDT.GetName());
}

void FbxDataTypes_FbxLayerElementCreaseDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxLayerElementCreaseDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxLayerElementCreaseDT.GetType());
    AssertEqual("LayerElementCrease", FbxLayerElementCreaseDT.GetName());
}

void FbxDataTypes_FbxLayerElementHoleDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxLayerElementHoleDT.Valid());
    AssertEqual(EFbxType::eFbxBool, FbxLayerElementHoleDT.GetType());
    AssertEqual("LayerElementHole", FbxLayerElementHoleDT.GetName());
}

void FbxDataTypes_FbxLayerElementUserDataDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxLayerElementUserDataDT.Valid());
    AssertEqual(EFbxType::eFbxReference, FbxLayerElementUserDataDT.GetType());
    AssertEqual("LayerElementUserData", FbxLayerElementUserDataDT.GetName());
}

void FbxDataTypes_FbxLayerElementVisibilityDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxLayerElementVisibilityDT.Valid());
    AssertEqual(EFbxType::eFbxBool, FbxLayerElementVisibilityDT.GetType());
    AssertEqual("LayerElementVisibility", FbxLayerElementVisibilityDT.GetName());
}

void FbxDataTypes_FbxAliasDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxAliasDT.Valid());
    AssertEqual(EFbxType::eFbxEnum, FbxAliasDT.GetType());
    AssertEqual("Alias", FbxAliasDT.GetName());
}

void FbxDataTypes_FbxPresetsDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxPresetsDT.Valid());
    AssertEqual(EFbxType::eFbxEnum, FbxPresetsDT.GetType());
    AssertEqual("Presets", FbxPresetsDT.GetName());
}

void FbxDataTypes_FbxStatisticsDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxStatisticsDT.Valid());
    AssertEqual(EFbxType::eFbxString, FbxStatisticsDT.GetType());
    AssertEqual("Statistics", FbxStatisticsDT.GetName());
}

void FbxDataTypes_FbxTextLineDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxTextLineDT.Valid());
    AssertEqual(EFbxType::eFbxString, FbxTextLineDT.GetType());
    AssertEqual("TextLine", FbxTextLineDT.GetName());
}

void FbxDataTypes_FbxUnitsDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxUnitsDT.Valid());
    AssertEqual(EFbxType::eFbxString, FbxUnitsDT.GetType());
    AssertEqual("Units", FbxUnitsDT.GetName());
}

void FbxDataTypes_FbxWarningDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxWarningDT.Valid());
    AssertEqual(EFbxType::eFbxString, FbxWarningDT.GetType());
    AssertEqual("Warning", FbxWarningDT.GetName());
}

void FbxDataTypes_FbxWebDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxWebDT.Valid());
    AssertEqual(EFbxType::eFbxString, FbxWebDT.GetType());
    AssertEqual("Web", FbxWebDT.GetName());
}

void FbxDataTypes_FbxActionDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxActionDT.Valid());
    AssertEqual(EFbxType::eFbxBool, FbxActionDT.GetType());
    AssertEqual("Action", FbxActionDT.GetName());
}

void FbxDataTypes_FbxCameraIndexDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxCameraIndexDT.Valid());
    AssertEqual(EFbxType::eFbxInt, FbxCameraIndexDT.GetType());
    AssertEqual("Camera Index", FbxCameraIndexDT.GetName());
}

void FbxDataTypes_FbxCharPtrDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxCharPtrDT.Valid());
    AssertEqual(EFbxType::eFbxString, FbxCharPtrDT.GetType());
    AssertEqual("charptr", FbxCharPtrDT.GetName());
}

void FbxDataTypes_FbxConeAngleDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxConeAngleDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxConeAngleDT.GetType());
    AssertEqual("Cone angle", FbxConeAngleDT.GetName());
}

void FbxDataTypes_FbxEventDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxEventDT.Valid());
    AssertEqual(EFbxType::eFbxUndefined, FbxEventDT.GetType());
    AssertEqual("event", FbxEventDT.GetName());
}

void FbxDataTypes_FbxFieldOfViewDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxFieldOfViewDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxFieldOfViewDT.GetType());
    AssertEqual("FieldOfView", FbxFieldOfViewDT.GetName());
}

void FbxDataTypes_FbxFieldOfViewXDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxFieldOfViewXDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxFieldOfViewXDT.GetType());
    AssertEqual("FieldOfViewX", FbxFieldOfViewXDT.GetName());
}

void FbxDataTypes_FbxFieldOfViewYDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxFieldOfViewYDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxFieldOfViewYDT.GetType());
    AssertEqual("FieldOfViewY", FbxFieldOfViewYDT.GetName());
}

void FbxDataTypes_FbxFogDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxFogDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxFogDT.GetType());
    AssertEqual("Fog", FbxFogDT.GetName());
}

void FbxDataTypes_FbxHSBDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxHSBDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxHSBDT.GetType());
    AssertEqual("HSB", FbxHSBDT.GetName());
}

void FbxDataTypes_FbxIKReachTranslationDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxIKReachTranslationDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxIKReachTranslationDT.GetType());
    AssertEqual("IK Reach Translation", FbxIKReachTranslationDT.GetName());
}

void FbxDataTypes_FbxIKReachRotationDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxIKReachRotationDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxIKReachRotationDT.GetType());
    AssertEqual("IK Reach Rotation", FbxIKReachRotationDT.GetName());
}

void FbxDataTypes_FbxIntensityDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxIntensityDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxIntensityDT.GetType());
    AssertEqual("Intensity", FbxIntensityDT.GetName());
}

void FbxDataTypes_FbxLookAtDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxLookAtDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxLookAtDT.GetType());
    AssertEqual("Look at", FbxLookAtDT.GetName());
}

void FbxDataTypes_FbxOcclusionDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxOcclusionDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxOcclusionDT.GetType());
    AssertEqual("Occlusion", FbxOcclusionDT.GetName());
}

void FbxDataTypes_FbxOpticalCenterXDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxOpticalCenterXDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxOpticalCenterXDT.GetType());
    AssertEqual("OpticalCenterX", FbxOpticalCenterXDT.GetName());
}

void FbxDataTypes_FbxOpticalCenterYDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxOpticalCenterYDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxOpticalCenterYDT.GetType());
    AssertEqual("OpticalCenterY", FbxOpticalCenterYDT.GetName());
}

void FbxDataTypes_FbxOrientationDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxOrientationDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxOrientationDT.GetType());
    AssertEqual("Orientation", FbxOrientationDT.GetName());
}

void FbxDataTypes_FbxRealDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxRealDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxRealDT.GetType());
    AssertEqual("Real", FbxRealDT.GetName());
}

void FbxDataTypes_FbxRollDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxRollDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxRollDT.GetType());
    AssertEqual("Roll", FbxRollDT.GetName());
}

void FbxDataTypes_FbxScalingUVDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxScalingUVDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxScalingUVDT.GetType());
    AssertEqual("Scaling UV", FbxScalingUVDT.GetName());
}

void FbxDataTypes_FbxShapeDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxShapeDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxShapeDT.GetType());
    AssertEqual("Shape", FbxShapeDT.GetName());
}

void FbxDataTypes_FbxStringListDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxStringListDT.Valid());
    AssertEqual(EFbxType::eFbxEnumM, FbxStringListDT.GetType());
    AssertEqual("stringlist", FbxStringListDT.GetName());
}

void FbxDataTypes_FbxTextureRotationDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxTextureRotationDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxTextureRotationDT.GetType());
    AssertEqual("TextureRotation", FbxTextureRotationDT.GetName());
}

void FbxDataTypes_FbxTimeCodeDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxTimeCodeDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxTimeCodeDT.GetType());
    AssertEqual("TimeCode", FbxTimeCodeDT.GetName());
}

void FbxDataTypes_FbxTimeWarpDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxTimeWarpDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxTimeWarpDT.GetType());
    AssertEqual("TimeWarp", FbxTimeWarpDT.GetName());
}

void FbxDataTypes_FbxTranslationUVDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxTranslationUVDT.Valid());
    AssertEqual(EFbxType::eFbxDouble3, FbxTranslationUVDT.GetType());
    AssertEqual("Translation UV", FbxTranslationUVDT.GetName());
}

void FbxDataTypes_FbxWeightDT_HasDefaults()
{
    // expect:
    AssertTrue(FbxWeightDT.Valid());
    AssertEqual(EFbxType::eFbxDouble, FbxWeightDT.GetType());
    AssertEqual("Weight", FbxWeightDT.GetName());
}

void FbxDataTypesTest::RegisterTestCases()
{
    AddTestCase(FbxDataTypes_FbxUndefinedDT_HasDefaultsAndIsNotValid);
    AddTestCase(FbxDataTypes_FbxBoolDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxCharDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxUCharDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxShortDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxUShortDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxIntDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxUIntDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxLongLongDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxULongLongDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxFloatDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxHalfFloatDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxDoubleDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxDouble2DT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxDouble3DT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxDouble4DT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxDouble4x4DT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxEnumDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxStringDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxTimeDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxReferenceDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxBlobDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxDistanceDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxDateTimeDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxColor3DT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxColor4DT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxCompoundDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxReferenceObjectDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxReferencePropertyDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxVisibilityDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxVisibilityInheritanceDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxUrlDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxXRefUrlDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxTranslationDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxRotationDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxScalingDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxQuaternionDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxLocalTranslationDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxLocalRotationDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxLocalScalingDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxLocalQuaternionDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxTransformMatrixDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxTranslationMatrixDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxRotationMatrixDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxScalingMatrixDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxMaterialEmissiveDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxMaterialEmissiveFactorDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxMaterialAmbientDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxMaterialAmbientFactorDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxMaterialDiffuseDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxMaterialDiffuseFactorDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxMaterialBumpDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxMaterialNormalMapDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxMaterialTransparentColorDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxMaterialTransparencyFactorDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxMaterialSpecularDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxMaterialSpecularFactorDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxMaterialShininessDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxMaterialReflectionDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxMaterialReflectionFactorDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxMaterialDisplacementDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxMaterialVectorDisplacementDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxMaterialCommonFactorDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxMaterialCommonTextureDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxLayerElementUndefinedDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxLayerElementNormalDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxLayerElementBinormalDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxLayerElementTangentDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxLayerElementMaterialDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxLayerElementTextureDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxLayerElementPolygonGroupDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxLayerElementUVDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxLayerElementVertexColorDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxLayerElementSmoothingDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxLayerElementCreaseDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxLayerElementHoleDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxLayerElementUserDataDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxLayerElementVisibilityDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxAliasDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxPresetsDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxStatisticsDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxTextLineDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxUnitsDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxWarningDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxWebDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxActionDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxCameraIndexDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxCharPtrDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxConeAngleDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxEventDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxFieldOfViewDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxFieldOfViewXDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxFieldOfViewYDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxFogDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxHSBDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxIKReachTranslationDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxIKReachRotationDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxIntensityDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxLookAtDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxOcclusionDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxOpticalCenterXDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxOpticalCenterYDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxOrientationDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxRealDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxRollDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxScalingUVDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxShapeDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxStringListDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxTextureRotationDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxTimeCodeDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxTimeWarpDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxTranslationUVDT_HasDefaults);
    AddTestCase(FbxDataTypes_FbxWeightDT_HasDefaults);
}

