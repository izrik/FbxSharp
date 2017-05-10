using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class AnimLayerTest : TestBase
    {
        [Test]
        public void FbxAnimLayer_Create_HasNamespacePrefix()
        {
            // given:
            var obj = new FbxAnimLayer("asdf");

            // then:
            Assert.AreEqual("AnimLayer::", obj.GetNameSpacePrefix());
        }
    }
}
