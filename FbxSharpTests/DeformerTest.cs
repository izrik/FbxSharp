using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class DeformerTest : TestBase
    {
        [Test]
        public void Deformer_Create_HasNamespacePrefix()
        {
            // given:
            var obj = new FbxSkin("asdf");

            // then:
            Assert.AreEqual("Deformer::", obj.GetNameSpacePrefix());;
        }
    }
}
