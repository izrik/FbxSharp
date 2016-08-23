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

        [Test]
        public void FbxSystemUnitTest_Create_SettingScaleFactorSetsScaleFactor()
        {
            // given:
            FbxSystemUnit su;

            // when:
            su = new FbxSystemUnit(2);

            // then:
            Assert.AreEqual(2, su.GetScaleFactor(), 0.00001);
            Assert.AreEqual(1, su.GetMultiplier(), 0.00001);

            // when:
            su = new FbxSystemUnit(2.3);

            // then:
            Assert.AreEqual(2.3, su.GetScaleFactor(), 0.00001);
            Assert.AreEqual(1, su.GetMultiplier(), 0.00001);
        }

        [Test]
        public void FbxSystemUnitTest_Create_SettingMultiplierSetsMultiplier()
        {
            // given:
            FbxSystemUnit su;

            // when:
            su = new FbxSystemUnit(1, 3);

            // then:
            Assert.AreEqual(1, su.GetScaleFactor(), 0.00001);
            Assert.AreEqual(3, su.GetMultiplier(), 0.00001);

            // when:
            su = new FbxSystemUnit(1, 4.5);

            // then:
            Assert.AreEqual(1, su.GetScaleFactor(), 0.00001);
            Assert.AreEqual(4.5, su.GetMultiplier(), 0.00001);
        }

        [Test]
        public void FbxSystemUnitTest_Create_SettingBothSetsBoth()
        {
            // given:
            FbxSystemUnit su;

            // when:
            su = new FbxSystemUnit(5, 6);

            // then:
            Assert.AreEqual(5, su.GetScaleFactor(), 0.00001);
            Assert.AreEqual(6, su.GetMultiplier(), 0.00001);

            // when:
            su = new FbxSystemUnit(7.8, 8.9);

            // then:
            Assert.AreEqual(7.8, su.GetScaleFactor(), 0.00001);
            Assert.AreEqual(8.9, su.GetMultiplier(), 0.00001);
        }

        [Test]
        public void FbxSystemUnitTest_Create_NegativeValuesAreAllowed()
        {
            // given:
            FbxSystemUnit su;

            // when:
            su = new FbxSystemUnit(-2, 1);

            // then:
            Assert.AreEqual(-2, su.GetScaleFactor(), 0.00001);
            Assert.AreEqual(1, su.GetMultiplier(), 0.00001);

            // when:
            su = new FbxSystemUnit(1, -3);

            // then:
            Assert.AreEqual(1, su.GetScaleFactor(), 0.00001);
            Assert.AreEqual(-3, su.GetMultiplier(), 0.00001);

            // when:
            su = new FbxSystemUnit(-4, -5);

            // then:
            Assert.AreEqual(-4, su.GetScaleFactor(), 0.00001);
            Assert.AreEqual(-5, su.GetMultiplier(), 0.00001);
        }

        [Test]
        public void FbxSystemUnitTest_GetScaleFactorAsString_AsString()
        {
            // given:
            FbxSystemUnit su;

            // when:
            su = new FbxSystemUnit(1, 1);

            // then:
            Assert.AreEqual("cm", su.GetScaleFactorAsString());

            // when:
            su = new FbxSystemUnit(100, 3);

            // then:
            Assert.AreEqual("custom unit", su.GetScaleFactorAsString());
        }
    }
}
