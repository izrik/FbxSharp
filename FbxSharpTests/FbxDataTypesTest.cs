using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class FbxDataTypesTest : TestBase
    {
        [Test]
        public void FbxDataTypes_FbxUndefinedDT_HasDefaultsAndIsNotValid()
        {
            // expect:
            Assert.False(FbxDataTypes.FbxUndefinedDT.Valid());
            Assert.AreEqual(EFbxType.eFbxUndefined, FbxDataTypes.FbxUndefinedDT.GetFbxType());
            Assert.AreEqual("", FbxDataTypes.FbxUndefinedDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxBoolDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxBoolDT.Valid());
            Assert.AreEqual(EFbxType.eFbxBool, FbxDataTypes.FbxBoolDT.GetFbxType());
            Assert.AreEqual("Bool", FbxDataTypes.FbxBoolDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxCharDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxCharDT.Valid());
            Assert.AreEqual(EFbxType.eFbxChar, FbxDataTypes.FbxCharDT.GetFbxType());
            Assert.AreEqual("Byte", FbxDataTypes.FbxCharDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxUCharDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxUCharDT.Valid());
            Assert.AreEqual(EFbxType.eFbxUChar, FbxDataTypes.FbxUCharDT.GetFbxType());
            Assert.AreEqual("UByte", FbxDataTypes.FbxUCharDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxShortDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxShortDT.Valid());
            Assert.AreEqual(EFbxType.eFbxShort, FbxDataTypes.FbxShortDT.GetFbxType());
            Assert.AreEqual("Short", FbxDataTypes.FbxShortDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxUShortDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxUShortDT.Valid());
            Assert.AreEqual(EFbxType.eFbxUShort, FbxDataTypes.FbxUShortDT.GetFbxType());
            Assert.AreEqual("UShort", FbxDataTypes.FbxUShortDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxIntDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxIntDT.Valid());
            Assert.AreEqual(EFbxType.eFbxInt, FbxDataTypes.FbxIntDT.GetFbxType());
            Assert.AreEqual("Integer", FbxDataTypes.FbxIntDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxUIntDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxUIntDT.Valid());
            Assert.AreEqual(EFbxType.eFbxUInt, FbxDataTypes.FbxUIntDT.GetFbxType());
            Assert.AreEqual("UInteger", FbxDataTypes.FbxUIntDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxLongLongDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxLongLongDT.Valid());
            Assert.AreEqual(EFbxType.eFbxLongLong, FbxDataTypes.FbxLongLongDT.GetFbxType());
            Assert.AreEqual("LongLong", FbxDataTypes.FbxLongLongDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxULongLongDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxULongLongDT.Valid());
            Assert.AreEqual(EFbxType.eFbxULongLong, FbxDataTypes.FbxULongLongDT.GetFbxType());
            Assert.AreEqual("ULongLong", FbxDataTypes.FbxULongLongDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxFloatDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxFloatDT.Valid());
            Assert.AreEqual(EFbxType.eFbxFloat, FbxDataTypes.FbxFloatDT.GetFbxType());
            Assert.AreEqual("Float", FbxDataTypes.FbxFloatDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxHalfFloatDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxHalfFloatDT.Valid());
            Assert.AreEqual(EFbxType.eFbxHalfFloat, FbxDataTypes.FbxHalfFloatDT.GetFbxType());
            Assert.AreEqual("HalfFloat", FbxDataTypes.FbxHalfFloatDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxDoubleDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxDoubleDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxDoubleDT.GetFbxType());
            Assert.AreEqual("Number", FbxDataTypes.FbxDoubleDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxDouble2DT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxDouble2DT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble2, FbxDataTypes.FbxDouble2DT.GetFbxType());
            Assert.AreEqual("Vector2", FbxDataTypes.FbxDouble2DT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxDouble3DT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxDouble3DT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxDouble3DT.GetFbxType());
            Assert.AreEqual("Vector", FbxDataTypes.FbxDouble3DT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxDouble4DT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxDouble4DT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble4, FbxDataTypes.FbxDouble4DT.GetFbxType());
            Assert.AreEqual("Vector4", FbxDataTypes.FbxDouble4DT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxDouble4x4DT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxDouble4x4DT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble4x4, FbxDataTypes.FbxDouble4x4DT.GetFbxType());
            Assert.AreEqual("Matrix", FbxDataTypes.FbxDouble4x4DT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxEnumDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxEnumDT.Valid());
            Assert.AreEqual(EFbxType.eFbxEnum, FbxDataTypes.FbxEnumDT.GetFbxType());
            Assert.AreEqual("Enum", FbxDataTypes.FbxEnumDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxStringDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxStringDT.Valid());
            Assert.AreEqual(EFbxType.eFbxString, FbxDataTypes.FbxStringDT.GetFbxType());
            Assert.AreEqual("KString", FbxDataTypes.FbxStringDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxTimeDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxTimeDT.Valid());
            Assert.AreEqual(EFbxType.eFbxTime, FbxDataTypes.FbxTimeDT.GetFbxType());
            Assert.AreEqual("Time", FbxDataTypes.FbxTimeDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxReferenceDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxReferenceDT.Valid());
            Assert.AreEqual(EFbxType.eFbxReference, FbxDataTypes.FbxReferenceDT.GetFbxType());
            Assert.AreEqual("Reference", FbxDataTypes.FbxReferenceDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxBlobDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxBlobDT.Valid());
            Assert.AreEqual(EFbxType.eFbxBlob, FbxDataTypes.FbxBlobDT.GetFbxType());
            Assert.AreEqual("Blob", FbxDataTypes.FbxBlobDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxDistanceDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxDistanceDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDistance, FbxDataTypes.FbxDistanceDT.GetFbxType());
            Assert.AreEqual("Distance", FbxDataTypes.FbxDistanceDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxDateTimeDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxDateTimeDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDateTime, FbxDataTypes.FbxDateTimeDT.GetFbxType());
            Assert.AreEqual("DateTime", FbxDataTypes.FbxDateTimeDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxColor3DT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxColor3DT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxColor3DT.GetFbxType());
            Assert.AreEqual("Color", FbxDataTypes.FbxColor3DT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxColor4DT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxColor4DT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble4, FbxDataTypes.FbxColor4DT.GetFbxType());
            Assert.AreEqual("ColorAndAlpha", FbxDataTypes.FbxColor4DT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxCompoundDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxCompoundDT.Valid());
            Assert.AreEqual(EFbxType.eFbxUndefined, FbxDataTypes.FbxCompoundDT.GetFbxType());
            Assert.AreEqual("Compound", FbxDataTypes.FbxCompoundDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxReferenceObjectDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxReferenceObjectDT.Valid());
            Assert.AreEqual(EFbxType.eFbxReference, FbxDataTypes.FbxReferenceObjectDT.GetFbxType());
            Assert.AreEqual("object", FbxDataTypes.FbxReferenceObjectDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxReferencePropertyDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxReferencePropertyDT.Valid());
            Assert.AreEqual(EFbxType.eFbxReference, FbxDataTypes.FbxReferencePropertyDT.GetFbxType());
            Assert.AreEqual("ReferenceProperty", FbxDataTypes.FbxReferencePropertyDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxVisibilityDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxVisibilityDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxVisibilityDT.GetFbxType());
            Assert.AreEqual("Visibility", FbxDataTypes.FbxVisibilityDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxVisibilityInheritanceDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxVisibilityInheritanceDT.Valid());
            Assert.AreEqual(EFbxType.eFbxBool, FbxDataTypes.FbxVisibilityInheritanceDT.GetFbxType());
            Assert.AreEqual("Visibility Inheritance", FbxDataTypes.FbxVisibilityInheritanceDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxUrlDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxUrlDT.Valid());
            Assert.AreEqual(EFbxType.eFbxString, FbxDataTypes.FbxUrlDT.GetFbxType());
            Assert.AreEqual("Url", FbxDataTypes.FbxUrlDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxXRefUrlDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxXRefUrlDT.Valid());
            Assert.AreEqual(EFbxType.eFbxString, FbxDataTypes.FbxXRefUrlDT.GetFbxType());
            Assert.AreEqual("XRefUrl", FbxDataTypes.FbxXRefUrlDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxTranslationDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxTranslationDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxTranslationDT.GetFbxType());
            Assert.AreEqual("Translation", FbxDataTypes.FbxTranslationDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxRotationDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxRotationDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxRotationDT.GetFbxType());
            Assert.AreEqual("Rotation", FbxDataTypes.FbxRotationDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxScalingDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxScalingDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxScalingDT.GetFbxType());
            Assert.AreEqual("Scaling", FbxDataTypes.FbxScalingDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxQuaternionDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxQuaternionDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble4, FbxDataTypes.FbxQuaternionDT.GetFbxType());
            Assert.AreEqual("Quaternion", FbxDataTypes.FbxQuaternionDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxLocalTranslationDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxLocalTranslationDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxLocalTranslationDT.GetFbxType());
            Assert.AreEqual("Lcl Translation", FbxDataTypes.FbxLocalTranslationDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxLocalRotationDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxLocalRotationDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxLocalRotationDT.GetFbxType());
            Assert.AreEqual("Lcl Rotation", FbxDataTypes.FbxLocalRotationDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxLocalScalingDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxLocalScalingDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxLocalScalingDT.GetFbxType());
            Assert.AreEqual("Lcl Scaling", FbxDataTypes.FbxLocalScalingDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxLocalQuaternionDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxLocalQuaternionDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble4, FbxDataTypes.FbxLocalQuaternionDT.GetFbxType());
            Assert.AreEqual("Lcl Quaternion", FbxDataTypes.FbxLocalQuaternionDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxTransformMatrixDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxTransformMatrixDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble4x4, FbxDataTypes.FbxTransformMatrixDT.GetFbxType());
            Assert.AreEqual("Matrix Transformation", FbxDataTypes.FbxTransformMatrixDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxTranslationMatrixDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxTranslationMatrixDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble4x4, FbxDataTypes.FbxTranslationMatrixDT.GetFbxType());
            Assert.AreEqual("Matrix Translation", FbxDataTypes.FbxTranslationMatrixDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxRotationMatrixDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxRotationMatrixDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble4x4, FbxDataTypes.FbxRotationMatrixDT.GetFbxType());
            Assert.AreEqual("Matrix Rotation", FbxDataTypes.FbxRotationMatrixDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxScalingMatrixDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxScalingMatrixDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble4x4, FbxDataTypes.FbxScalingMatrixDT.GetFbxType());
            Assert.AreEqual("Matrix Scaling", FbxDataTypes.FbxScalingMatrixDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxMaterialEmissiveDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxMaterialEmissiveDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxMaterialEmissiveDT.GetFbxType());
            Assert.AreEqual("Emissive", FbxDataTypes.FbxMaterialEmissiveDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxMaterialEmissiveFactorDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxMaterialEmissiveFactorDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxMaterialEmissiveFactorDT.GetFbxType());
            Assert.AreEqual("EmissiveFactor", FbxDataTypes.FbxMaterialEmissiveFactorDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxMaterialAmbientDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxMaterialAmbientDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxMaterialAmbientDT.GetFbxType());
            Assert.AreEqual("Ambient", FbxDataTypes.FbxMaterialAmbientDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxMaterialAmbientFactorDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxMaterialAmbientFactorDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxMaterialAmbientFactorDT.GetFbxType());
            Assert.AreEqual("AmbientFactor", FbxDataTypes.FbxMaterialAmbientFactorDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxMaterialDiffuseDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxMaterialDiffuseDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxMaterialDiffuseDT.GetFbxType());
            Assert.AreEqual("Diffuse", FbxDataTypes.FbxMaterialDiffuseDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxMaterialDiffuseFactorDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxMaterialDiffuseFactorDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxMaterialDiffuseFactorDT.GetFbxType());
            Assert.AreEqual("DiffuseFactor", FbxDataTypes.FbxMaterialDiffuseFactorDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxMaterialBumpDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxMaterialBumpDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxMaterialBumpDT.GetFbxType());
            Assert.AreEqual("Bump", FbxDataTypes.FbxMaterialBumpDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxMaterialNormalMapDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxMaterialNormalMapDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxMaterialNormalMapDT.GetFbxType());
            Assert.AreEqual("NormalMap", FbxDataTypes.FbxMaterialNormalMapDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxMaterialTransparentColorDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxMaterialTransparentColorDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxMaterialTransparentColorDT.GetFbxType());
            Assert.AreEqual("Transparent", FbxDataTypes.FbxMaterialTransparentColorDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxMaterialTransparencyFactorDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxMaterialTransparencyFactorDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxMaterialTransparencyFactorDT.GetFbxType());
            Assert.AreEqual("TransparencyFactor", FbxDataTypes.FbxMaterialTransparencyFactorDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxMaterialSpecularDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxMaterialSpecularDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxMaterialSpecularDT.GetFbxType());
            Assert.AreEqual("Specular", FbxDataTypes.FbxMaterialSpecularDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxMaterialSpecularFactorDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxMaterialSpecularFactorDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxMaterialSpecularFactorDT.GetFbxType());
            Assert.AreEqual("SpecularFactor", FbxDataTypes.FbxMaterialSpecularFactorDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxMaterialShininessDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxMaterialShininessDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxMaterialShininessDT.GetFbxType());
            Assert.AreEqual("Shininess", FbxDataTypes.FbxMaterialShininessDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxMaterialReflectionDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxMaterialReflectionDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxMaterialReflectionDT.GetFbxType());
            Assert.AreEqual("Reflection", FbxDataTypes.FbxMaterialReflectionDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxMaterialReflectionFactorDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxMaterialReflectionFactorDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxMaterialReflectionFactorDT.GetFbxType());
            Assert.AreEqual("ReflectionFactor", FbxDataTypes.FbxMaterialReflectionFactorDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxMaterialDisplacementDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxMaterialDisplacementDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxMaterialDisplacementDT.GetFbxType());
            Assert.AreEqual("Displacement", FbxDataTypes.FbxMaterialDisplacementDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxMaterialVectorDisplacementDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxMaterialVectorDisplacementDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxMaterialVectorDisplacementDT.GetFbxType());
            Assert.AreEqual("VectorDisplacement", FbxDataTypes.FbxMaterialVectorDisplacementDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxMaterialCommonFactorDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxMaterialCommonFactorDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxMaterialCommonFactorDT.GetFbxType());
            Assert.AreEqual("Unknown Factor", FbxDataTypes.FbxMaterialCommonFactorDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxMaterialCommonTextureDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxMaterialCommonTextureDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxMaterialCommonTextureDT.GetFbxType());
            Assert.AreEqual("Unknown texture", FbxDataTypes.FbxMaterialCommonTextureDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxLayerElementUndefinedDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxLayerElementUndefinedDT.Valid());
            Assert.AreEqual(EFbxType.eFbxUndefined, FbxDataTypes.FbxLayerElementUndefinedDT.GetFbxType());
            Assert.AreEqual("LayerElementUndefined", FbxDataTypes.FbxLayerElementUndefinedDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxLayerElementNormalDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxLayerElementNormalDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble4, FbxDataTypes.FbxLayerElementNormalDT.GetFbxType());
            Assert.AreEqual("LayerElementNormal", FbxDataTypes.FbxLayerElementNormalDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxLayerElementBinormalDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxLayerElementBinormalDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble4, FbxDataTypes.FbxLayerElementBinormalDT.GetFbxType());
            Assert.AreEqual("LayerElementBinormal", FbxDataTypes.FbxLayerElementBinormalDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxLayerElementTangentDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxLayerElementTangentDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble4, FbxDataTypes.FbxLayerElementTangentDT.GetFbxType());
            Assert.AreEqual("LayerElementTangent", FbxDataTypes.FbxLayerElementTangentDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxLayerElementMaterialDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxLayerElementMaterialDT.Valid());
            Assert.AreEqual(EFbxType.eFbxReference, FbxDataTypes.FbxLayerElementMaterialDT.GetFbxType());
            Assert.AreEqual("LayerElementMaterial", FbxDataTypes.FbxLayerElementMaterialDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxLayerElementTextureDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxLayerElementTextureDT.Valid());
            Assert.AreEqual(EFbxType.eFbxReference, FbxDataTypes.FbxLayerElementTextureDT.GetFbxType());
            Assert.AreEqual("LayerElementTexture", FbxDataTypes.FbxLayerElementTextureDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxLayerElementPolygonGroupDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxLayerElementPolygonGroupDT.Valid());
            Assert.AreEqual(EFbxType.eFbxInt, FbxDataTypes.FbxLayerElementPolygonGroupDT.GetFbxType());
            Assert.AreEqual("LayerElementPolygonGroup", FbxDataTypes.FbxLayerElementPolygonGroupDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxLayerElementUVDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxLayerElementUVDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble2, FbxDataTypes.FbxLayerElementUVDT.GetFbxType());
            Assert.AreEqual("LayerElementUV", FbxDataTypes.FbxLayerElementUVDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxLayerElementVertexColorDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxLayerElementVertexColorDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble4, FbxDataTypes.FbxLayerElementVertexColorDT.GetFbxType());
            Assert.AreEqual("LayerElementVertexColor", FbxDataTypes.FbxLayerElementVertexColorDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxLayerElementSmoothingDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxLayerElementSmoothingDT.Valid());
            Assert.AreEqual(EFbxType.eFbxInt, FbxDataTypes.FbxLayerElementSmoothingDT.GetFbxType());
            Assert.AreEqual("LayerElementSmoothing", FbxDataTypes.FbxLayerElementSmoothingDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxLayerElementCreaseDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxLayerElementCreaseDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxLayerElementCreaseDT.GetFbxType());
            Assert.AreEqual("LayerElementCrease", FbxDataTypes.FbxLayerElementCreaseDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxLayerElementHoleDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxLayerElementHoleDT.Valid());
            Assert.AreEqual(EFbxType.eFbxBool, FbxDataTypes.FbxLayerElementHoleDT.GetFbxType());
            Assert.AreEqual("LayerElementHole", FbxDataTypes.FbxLayerElementHoleDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxLayerElementUserDataDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxLayerElementUserDataDT.Valid());
            Assert.AreEqual(EFbxType.eFbxReference, FbxDataTypes.FbxLayerElementUserDataDT.GetFbxType());
            Assert.AreEqual("LayerElementUserData", FbxDataTypes.FbxLayerElementUserDataDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxLayerElementVisibilityDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxLayerElementVisibilityDT.Valid());
            Assert.AreEqual(EFbxType.eFbxBool, FbxDataTypes.FbxLayerElementVisibilityDT.GetFbxType());
            Assert.AreEqual("LayerElementVisibility", FbxDataTypes.FbxLayerElementVisibilityDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxAliasDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxAliasDT.Valid());
            Assert.AreEqual(EFbxType.eFbxEnum, FbxDataTypes.FbxAliasDT.GetFbxType());
            Assert.AreEqual("Alias", FbxDataTypes.FbxAliasDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxPresetsDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxPresetsDT.Valid());
            Assert.AreEqual(EFbxType.eFbxEnum, FbxDataTypes.FbxPresetsDT.GetFbxType());
            Assert.AreEqual("Presets", FbxDataTypes.FbxPresetsDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxStatisticsDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxStatisticsDT.Valid());
            Assert.AreEqual(EFbxType.eFbxString, FbxDataTypes.FbxStatisticsDT.GetFbxType());
            Assert.AreEqual("Statistics", FbxDataTypes.FbxStatisticsDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxTextLineDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxTextLineDT.Valid());
            Assert.AreEqual(EFbxType.eFbxString, FbxDataTypes.FbxTextLineDT.GetFbxType());
            Assert.AreEqual("TextLine", FbxDataTypes.FbxTextLineDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxUnitsDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxUnitsDT.Valid());
            Assert.AreEqual(EFbxType.eFbxString, FbxDataTypes.FbxUnitsDT.GetFbxType());
            Assert.AreEqual("Units", FbxDataTypes.FbxUnitsDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxWarningDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxWarningDT.Valid());
            Assert.AreEqual(EFbxType.eFbxString, FbxDataTypes.FbxWarningDT.GetFbxType());
            Assert.AreEqual("Warning", FbxDataTypes.FbxWarningDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxWebDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxWebDT.Valid());
            Assert.AreEqual(EFbxType.eFbxString, FbxDataTypes.FbxWebDT.GetFbxType());
            Assert.AreEqual("Web", FbxDataTypes.FbxWebDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxActionDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxActionDT.Valid());
            Assert.AreEqual(EFbxType.eFbxBool, FbxDataTypes.FbxActionDT.GetFbxType());
            Assert.AreEqual("Action", FbxDataTypes.FbxActionDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxCameraIndexDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxCameraIndexDT.Valid());
            Assert.AreEqual(EFbxType.eFbxInt, FbxDataTypes.FbxCameraIndexDT.GetFbxType());
            Assert.AreEqual("Camera Index", FbxDataTypes.FbxCameraIndexDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxCharPtrDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxCharPtrDT.Valid());
            Assert.AreEqual(EFbxType.eFbxString, FbxDataTypes.FbxCharPtrDT.GetFbxType());
            Assert.AreEqual("charptr", FbxDataTypes.FbxCharPtrDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxConeAngleDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxConeAngleDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxConeAngleDT.GetFbxType());
            Assert.AreEqual("Cone angle", FbxDataTypes.FbxConeAngleDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxEventDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxEventDT.Valid());
            Assert.AreEqual(EFbxType.eFbxUndefined, FbxDataTypes.FbxEventDT.GetFbxType());
            Assert.AreEqual("event", FbxDataTypes.FbxEventDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxFieldOfViewDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxFieldOfViewDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxFieldOfViewDT.GetFbxType());
            Assert.AreEqual("FieldOfView", FbxDataTypes.FbxFieldOfViewDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxFieldOfViewXDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxFieldOfViewXDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxFieldOfViewXDT.GetFbxType());
            Assert.AreEqual("FieldOfViewX", FbxDataTypes.FbxFieldOfViewXDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxFieldOfViewYDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxFieldOfViewYDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxFieldOfViewYDT.GetFbxType());
            Assert.AreEqual("FieldOfViewY", FbxDataTypes.FbxFieldOfViewYDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxFogDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxFogDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxFogDT.GetFbxType());
            Assert.AreEqual("Fog", FbxDataTypes.FbxFogDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxHSBDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxHSBDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxHSBDT.GetFbxType());
            Assert.AreEqual("HSB", FbxDataTypes.FbxHSBDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxIKReachTranslationDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxIKReachTranslationDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxIKReachTranslationDT.GetFbxType());
            Assert.AreEqual("IK Reach Translation", FbxDataTypes.FbxIKReachTranslationDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxIKReachRotationDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxIKReachRotationDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxIKReachRotationDT.GetFbxType());
            Assert.AreEqual("IK Reach Rotation", FbxDataTypes.FbxIKReachRotationDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxIntensityDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxIntensityDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxIntensityDT.GetFbxType());
            Assert.AreEqual("Intensity", FbxDataTypes.FbxIntensityDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxLookAtDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxLookAtDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxLookAtDT.GetFbxType());
            Assert.AreEqual("Look at", FbxDataTypes.FbxLookAtDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxOcclusionDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxOcclusionDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxOcclusionDT.GetFbxType());
            Assert.AreEqual("Occlusion", FbxDataTypes.FbxOcclusionDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxOpticalCenterXDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxOpticalCenterXDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxOpticalCenterXDT.GetFbxType());
            Assert.AreEqual("OpticalCenterX", FbxDataTypes.FbxOpticalCenterXDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxOpticalCenterYDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxOpticalCenterYDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxOpticalCenterYDT.GetFbxType());
            Assert.AreEqual("OpticalCenterY", FbxDataTypes.FbxOpticalCenterYDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxOrientationDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxOrientationDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxOrientationDT.GetFbxType());
            Assert.AreEqual("Orientation", FbxDataTypes.FbxOrientationDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxRealDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxRealDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxRealDT.GetFbxType());
            Assert.AreEqual("Real", FbxDataTypes.FbxRealDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxRollDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxRollDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxRollDT.GetFbxType());
            Assert.AreEqual("Roll", FbxDataTypes.FbxRollDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxScalingUVDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxScalingUVDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxScalingUVDT.GetFbxType());
            Assert.AreEqual("Scaling UV", FbxDataTypes.FbxScalingUVDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxShapeDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxShapeDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxShapeDT.GetFbxType());
            Assert.AreEqual("Shape", FbxDataTypes.FbxShapeDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxStringListDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxStringListDT.Valid());
            Assert.AreEqual(EFbxType.eFbxEnumM, FbxDataTypes.FbxStringListDT.GetFbxType());
            Assert.AreEqual("stringlist", FbxDataTypes.FbxStringListDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxTextureRotationDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxTextureRotationDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxTextureRotationDT.GetFbxType());
            Assert.AreEqual("TextureRotation", FbxDataTypes.FbxTextureRotationDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxTimeCodeDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxTimeCodeDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxTimeCodeDT.GetFbxType());
            Assert.AreEqual("TimeCode", FbxDataTypes.FbxTimeCodeDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxTimeWarpDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxTimeWarpDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxTimeWarpDT.GetFbxType());
            Assert.AreEqual("TimeWarp", FbxDataTypes.FbxTimeWarpDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxTranslationUVDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxTranslationUVDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble3, FbxDataTypes.FbxTranslationUVDT.GetFbxType());
            Assert.AreEqual("Translation UV", FbxDataTypes.FbxTranslationUVDT.GetName());
        }

        [Test]
        public void FbxDataTypes_FbxWeightDT_HasDefaults()
        {
            // expect:
            Assert.True(FbxDataTypes.FbxWeightDT.Valid());
            Assert.AreEqual(EFbxType.eFbxDouble, FbxDataTypes.FbxWeightDT.GetFbxType());
            Assert.AreEqual("Weight", FbxDataTypes.FbxWeightDT.GetName());
        }
    }
}
