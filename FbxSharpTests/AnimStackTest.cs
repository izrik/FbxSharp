using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class AnimStackTest : TestBase
    {
        [Test]
        public void FbxAnimStack_Create_HasNamespacePrefix()
        {
            // given:
            var obj = new FbxAnimStack("asdf");

            // then:
            Assert.AreEqual("AnimStack::", obj.GetNameSpacePrefix());
        }
    }
}
