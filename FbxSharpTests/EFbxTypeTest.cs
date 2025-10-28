using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class EFbxTypeTest : TestBase
    {
        [Test]
        public void EFbxType_IdentifiersHaveSpecificValues()
        {
            // expect:
            Assert.That((int)EFbxType.eFbxUndefined, Is.EqualTo(0));
            Assert.That((int)EFbxType.eFbxChar, Is.EqualTo(1));
            Assert.That((int)EFbxType.eFbxUChar, Is.EqualTo(2));
            Assert.That((int)EFbxType.eFbxShort, Is.EqualTo(3));
            Assert.That((int)EFbxType.eFbxUShort, Is.EqualTo(4));
            Assert.That((int)EFbxType.eFbxUInt, Is.EqualTo(5));
            Assert.That((int)EFbxType.eFbxLongLong, Is.EqualTo(6));
            Assert.That((int)EFbxType.eFbxULongLong, Is.EqualTo(7));
            Assert.That((int)EFbxType.eFbxHalfFloat, Is.EqualTo(8));
            Assert.That((int)EFbxType.eFbxBool, Is.EqualTo(9));
            Assert.That((int)EFbxType.eFbxInt, Is.EqualTo(10));
            Assert.That((int)EFbxType.eFbxFloat, Is.EqualTo(11));
            Assert.That((int)EFbxType.eFbxDouble, Is.EqualTo(12));
            Assert.That((int)EFbxType.eFbxDouble2, Is.EqualTo(13));
            Assert.That((int)EFbxType.eFbxDouble3, Is.EqualTo(14));
            Assert.That((int)EFbxType.eFbxDouble4, Is.EqualTo(15));
            Assert.That((int)EFbxType.eFbxDouble4x4, Is.EqualTo(16));
            Assert.That((int)EFbxType.eFbxEnum, Is.EqualTo(17));
            Assert.That((int)EFbxType.eFbxEnumM, Is.EqualTo(-17));
            Assert.That((int)EFbxType.eFbxString, Is.EqualTo(18));
            Assert.That((int)EFbxType.eFbxTime, Is.EqualTo(19));
            Assert.That((int)EFbxType.eFbxReference, Is.EqualTo(20));
            Assert.That((int)EFbxType.eFbxBlob, Is.EqualTo(21));
            Assert.That((int)EFbxType.eFbxDistance, Is.EqualTo(22));
            Assert.That((int)EFbxType.eFbxDateTime, Is.EqualTo(23));
            Assert.That((int)EFbxType.eFbxTypeCount, Is.EqualTo(24));
        }
    }
}
