using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class FbxTimeTest : TestBase
    {
        [Test]
        public void FbxTime_Constants()
        {
            // expect:
            Assert.AreEqual(141120L, FbxTime.FBXSDK_TC_MILLISECOND);
            Assert.AreEqual(141120000L, FbxTime.FBXSDK_TC_SECOND);
        }

        [Test]
        public void FbxTime_CreateLongLong_HasSeconds()
        {
            // given:
            FbxTime time;

            // when:
            time = new FbxTime(0);

            // then:
            Assert.AreEqual(0.0, time.GetSecondDouble());
            Assert.AreEqual(0L, time.GetFrameCount());

            // when:
            time = new FbxTime(-23520000L);

            // then:
            Assert.AreEqual(-5/30.0, time.GetSecondDouble());
            Assert.AreEqual(-5L, time.GetFrameCount());
        }

        [Test]
        public void FbxTime_GetSecondCount_ZeroYieldsCount()
        {
            // given:
            var time = new FbxTime(0);

            // when:
            var result = time.GetSecondCount();

            // then:
            Assert.AreEqual(0, result);
        }

        [Test]
        public void FbxTime_GetSecondCount_OneYieldsCount()
        {
            // given:
            var time = new FbxTime(141120000L);

            // when:
            var result = time.GetSecondCount();

            // then:
            Assert.AreEqual(1, result);
        }

        [Test]
        public void FbxTime_GetSecondCount_FractionYieldsCount()
        {
            // given:
            var time = new FbxTime(70560000L);

            // when:
            var result = time.GetSecondCount();

            // then:
            Assert.AreEqual(0, result);
        }

        [Test]
        public void FbxTime_GetSecondCount_FractionYieldsCount2()
        {
            // given:
            var time = new FbxTime(141119999L);

            // when:
            var result = time.GetSecondCount();

            // then:
            Assert.AreEqual(0, result);
        }

        [Test]
        public void FbxTime_GetSecondCount_FractionYieldsCount3()
        {
            // given:
            var time = new FbxTime(141120001L);

            // when:
            var result = time.GetSecondCount();

            // then:
            Assert.AreEqual(1, result);
        }

        [Test]
        public void FbxTime_GetMilliSeconds_ZeroYieldsCount()
        {
            // given:
            var time = new FbxTime(0);
            // when:
            var result = time.GetMilliSeconds();
            // then:
            Assert.AreEqual(0, result);
        }

        [Test]
        public void FbxTime_GetMilliSeconds_OneYieldsCount()
        {
            // given:
            var time = new FbxTime(141120L);
            // when:
            var result = time.GetMilliSeconds();
            // then:
            Assert.AreEqual(1, result);
        }

        [Test]
        public void FbxTime_GetMilliSeconds_FractionYieldsCount()
        {
            // given:
            var time = new FbxTime(70560L);
            // when:
            var result = time.GetMilliSeconds();
            // then:
            Assert.AreEqual(0, result);
        }

        [Test]
        public void FbxTime_GetMilliSeconds_FractionYieldsCount2()
        {
            // given:
            var time = new FbxTime(141119L);
            // when:
            var result = time.GetMilliSeconds();
            // then:
            Assert.AreEqual(0, result);
        }

        [Test]
        public void FbxTime_GetMilliSeconds_FractionYieldsCount3()
        {
            // given:
            var time = new FbxTime(141121L);
            // when:
            var result = time.GetMilliSeconds();
            // then:
            Assert.AreEqual(1, result);
        }

        [Test]
        public void FbxTime_GetMilliSeconds_NegativeYieldsCount()
        {
            // given:
            var time = new FbxTime(-141120L);
            // when:
            var result = time.GetMilliSeconds();
            // then:
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void FbxTime_GetFrameCountPrecise_ZeroYieldsZero()
        {
            // given:
            var time = new FbxTime(0);
            // when:
            var result = time.GetFrameCountPrecise();
            // then:
            Assert.AreEqual(0, result, 0);
        }

        [Test]
        public void FbxTime_GetFrameCountPrecise_OneYieldsOne()
        {
            // given:
            var time = new FbxTime(4704000L);
            // when:
            var result = time.GetFrameCountPrecise();
            // then:
            Assert.AreEqual(1, result, 0);
        }

        [Test]
        public void FbxTime_GetFrameCountPrecise_NegativeYieldsNegative()
        {
            // given:
            var time = new FbxTime(-4704000);
            // when:
            var result = time.GetFrameCountPrecise();
            // then:
            Assert.AreEqual(-1, result, 0);
        }

        [Test]
        public void FbxTime_GetFrameCountPrecise_FractionYieldsFraction()
        {
            // given:
            var time = new FbxTime(4703999);
            // when:
            var result = time.GetFrameCountPrecise();
            // then:
            Assert.AreEqual(0.999999787414966, result, 0);
        }

        [Test]
        public void FbxTime_GetFrameCountPrecise_FractionYieldsFraction2()
        {
            // given:
            var time = new FbxTime(4704001);
            // when:
            var result = time.GetFrameCountPrecise();
            // then:
            Assert.AreEqual(1.000000212585034, result, 0);
        }
    }
}
