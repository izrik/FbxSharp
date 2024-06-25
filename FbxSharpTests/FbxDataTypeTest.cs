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
    }
}
