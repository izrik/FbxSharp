using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class FbxNullTest : TestBase
    {
        [Test]
        public void FbxNull_StaticInitialization()
        {
            // expect:
            Assert.AreEqual(100.0d, FbxNull.sDefaultSize);
            Assert.AreEqual(FbxNull.ELook.eCross, FbxNull.sDefaultLook);
            Assert.AreEqual("Size", FbxNull.sSize);
            Assert.AreEqual("Look", FbxNull.sLook);
        }

        [Test]
        public void FbxNull_Create_SetsDefaults()
        {
            // given:
            // when:
            var n = new FbxNull("name");
            // then:
            Assert.AreEqual("name", n.GetName());
            Assert.AreEqual(100.0d, n.GetSizeDefaultValue());
            Assert.AreEqual(100.0d, n.Size.Get());
            Assert.AreEqual(FbxNull.ELook.eCross, n.Look.Get());
        }

        [Test]
        public void FbxNull_Reset_ResetsPropertyValues()
        {
            // given:
            var n = new FbxNull("");
            n.Size.Set(234);
            n.Look.Set(FbxNull.ELook.eNone);
            // require:
            Assert.AreEqual(234.0d, n.Size.Get());
            Assert.AreEqual(FbxNull.ELook.eNone, n.Look.Get());
            // when:
            n.Reset();
            // then:
            Assert.AreEqual(FbxNull.sDefaultSize, n.Size.Get());
            Assert.AreEqual(FbxNull.sDefaultLook, n.Look.Get());
        }

        [Test]
        public void FbxNull_Create_HasNamespacePrefix()
        {
            // given:
            var obj = new FbxNull("asdf");

            // then:
            Assert.AreEqual("NodeAttribute::", obj.GetNameSpacePrefix());;
        }
    }
}
