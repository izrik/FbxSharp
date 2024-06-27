using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class FbxDataTypeTest : TestBase
    {
        [Test]
        public void FbxDataType_DefaultConstructor_AttributesSet()
        {
            // when:
            var dt = FbxDataType.Create("int", EFbxType.eFbxInt);
            // then:
            Assert.True(dt.Valid());
            Assert.That(dt.GetName(), Is.EqualTo("int"));
            Assert.That(dt.GetFbxType(), Is.EqualTo(EFbxType.eFbxInt));
        }

        [Test]
        public void FbxDataType_OperatorEquals_MatchesSelfButNotIdenticalObjects()
        {
            // when:
            var dt1 = FbxDataType.Create("int", EFbxType.eFbxInt);
            var dt2 = FbxDataType.Create("int", EFbxType.eFbxInt);

            // then:
            Assert.True(dt1.Valid());
            Assert.True(dt2.Valid());
            Assert.That(dt2.GetName(), Is.EqualTo(dt1.GetName()));
            Assert.That(dt2.GetFbxType(), Is.EqualTo(dt1.GetFbxType()));
            Assert.That(dt1, Is.EqualTo(dt1));
            Assert.That(dt1, Is.EqualTo(dt1));
            Assert.True(dt1 == dt1);
            Assert.True(dt2 == dt2);
            Assert.False(dt1 != dt1);
            Assert.False(dt2 != dt2);
            Assert.That(dt1, Is.Not.EqualTo(FbxDataTypes.FbxIntDT));
            Assert.That(dt2, Is.Not.EqualTo(FbxDataTypes.FbxIntDT));
            Assert.False(FbxDataTypes.FbxIntDT == dt1);
            Assert.False(FbxDataTypes.FbxIntDT == dt2);
            Assert.True(FbxDataTypes.FbxIntDT != dt1);
            Assert.True(FbxDataTypes.FbxIntDT != dt2);
            Assert.That(dt2, Is.Not.EqualTo(dt1));
            Assert.False(dt1 == dt2);
            Assert.True(dt1 != dt2);
        }

        [Test]
        public void FbxDataType_FbxGetDataTypeFromEnum_YieldsCorrectDataType()
        {
            // expect:
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxUndefined), Is.EqualTo(FbxDataTypes.FbxUndefinedDT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxChar), Is.EqualTo(FbxDataTypes.FbxCharDT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxUChar), Is.EqualTo(FbxDataTypes.FbxUCharDT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxShort), Is.EqualTo(FbxDataTypes.FbxShortDT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxUShort), Is.EqualTo(FbxDataTypes.FbxUShortDT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxUInt), Is.EqualTo(FbxDataTypes.FbxUIntDT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxLongLong), Is.EqualTo(FbxDataTypes.FbxLongLongDT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxULongLong), Is.EqualTo(FbxDataTypes.FbxULongLongDT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxHalfFloat), Is.EqualTo(FbxDataTypes.FbxHalfFloatDT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxBool), Is.EqualTo(FbxDataTypes.FbxBoolDT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxInt), Is.EqualTo(FbxDataTypes.FbxIntDT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxFloat), Is.EqualTo(FbxDataTypes.FbxFloatDT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxDouble), Is.EqualTo(FbxDataTypes.FbxDoubleDT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxDouble2), Is.EqualTo(FbxDataTypes.FbxDouble2DT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxDouble3), Is.EqualTo(FbxDataTypes.FbxDouble3DT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxDouble4), Is.EqualTo(FbxDataTypes.FbxDouble4DT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxDouble4x4), Is.EqualTo(FbxDataTypes.FbxDouble4x4DT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxEnum), Is.EqualTo(FbxDataTypes.FbxEnumDT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxEnumM), Is.EqualTo(FbxDataTypes.FbxEnumDT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxString), Is.EqualTo(FbxDataTypes.FbxStringDT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxTime), Is.EqualTo(FbxDataTypes.FbxTimeDT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxReference), Is.EqualTo(FbxDataTypes.FbxReferenceDT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxBlob), Is.EqualTo(FbxDataTypes.FbxBlobDT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxDistance), Is.EqualTo(FbxDataTypes.FbxDistanceDT));
            Assert.That(FbxDataType.FbxGetDataTypeFromEnum(EFbxType.eFbxDateTime), Is.EqualTo(FbxDataTypes.FbxDateTimeDT));
        }
    }
}
