using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class FbxTimeTest : TestBase
    {
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
            time = new FbxTime(-7697693000L);

            // then:
            Assert.AreEqual(-5/30.0, time.GetSecondDouble());
            Assert.AreEqual(-5L, time.GetFrameCount());
        }
    }
}
