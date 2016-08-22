using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class FbxSystemUnitTest : TestBase
    {
        [Test]
        public void FbxSystemUnitTest_Create_DefaultScaleFactorIsOne()
        {
            // given:
            FbxSystemUnit su;

            // when:
            su = new FbxSystemUnit();

            // then:
            Assert.AreEqual(1, su.GetScaleFactor(), 0.00001);
        }

        [Test]
        public void FbxSystemUnitTest_Create_DefaultMultiplierIsOne()
        {
            // given:
            FbxSystemUnit su;

            // when:
            su = new FbxSystemUnit();

            // then:
            Assert.AreEqual(1, su.GetMultiplier(), 0.00001);
        }
    }
}
