using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class FbxTimeCodeTest : TestBase
    {
        [Test]
        public void FbxTimeCode_Constants()
        {
            // expect:
            Assert.That(FbxTimeCode.FBXSDK_TC_MILLISECOND, Is.EqualTo(141120L));
            Assert.That(FbxTimeCode.FBXSDK_TC_SECOND, Is.EqualTo(141120000L));
            Assert.That(FbxTimeCode.FBXSDK_TC_LEGACY_MILLISECOND, Is.EqualTo(46186158L));
            Assert.That(FbxTimeCode.FBXSDK_TC_LEGACY_SECOND, Is.EqualTo(46186158000L));
        }
    }
}
