using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class SubDeformerTest : TestBase
    {
        [Test]
        public void SubDeformer_Create_HasNamespacePrefix()
        {
            // given:
            var obj = new FbxCluster("asdf");

            // then:
            Assert.AreEqual("SubDeformer::", obj.GetNameSpacePrefix());;
        }
    }
}
