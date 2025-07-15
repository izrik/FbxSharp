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

        [Test]
        public void FbxTime_GetFieldCount_ZeroYieldsZero()
        {
            // given:
            var time = new FbxTime(0);
            // when:
            var result = time.GetFieldCount();
            // then:
            Assert.AreEqual(0, result);
        }

        [Test]
        public void FbxTime_GetFieldCount_OneYieldsTwo()
        {
            // given:
            var time = new FbxTime(4704000L);
            // when:
            var result = time.GetFieldCount();
            // then:
            Assert.AreEqual(2, result);
        }

        [Test]
        public void FbxTime_GetFieldCount_NegativeYieldsNegative()
        {
            // given:
            var time = new FbxTime(-4704000);
            // when:
            var result = time.GetFieldCount();
            // then:
            Assert.AreEqual(-2, result);
        }

        [Test]
        public void FbxTime_GetFieldCount_FractionYieldsInteger()
        {
            // given:
            var time = new FbxTime(4703999);
            // when:
            var result = time.GetFieldCount();
            // then:
            Assert.AreEqual(1, result);
        }

        [Test]
        public void FbxTime_GetFieldCount_FractionYieldsInteger2()
        {
            // given:
            var time = new FbxTime(4704001);
            // when:
            var result = time.GetFieldCount();
            // then:
            Assert.AreEqual(2, result);
        }

        [Test]
        public void FbxTime_GetFieldCount_NegFractionYieldsInteger()
        {
            // given:
            var time = new FbxTime(-1);
            // when:
            var result = time.GetFieldCount();
            // then:
            Assert.AreEqual(0, result);
        }

        [Test]
        public void FbxTime_GetFieldCount_NegFractionYieldsInteger2()
        {
            // given:
            var time = new FbxTime(-4703999);
            // when:
            var result = time.GetFieldCount();
            // then:
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void FbxTime_GetFieldCount_NegFractionYieldsInteger3()
        {
            // given:
            var time = new FbxTime(-4704001);
            // when:
            var result = time.GetFieldCount();
            // then:
            Assert.AreEqual(-2, result);
        }

        [Test]
        public void FbxTime_GetFieldCount_HalfYieldsOne()
        {
            // given:
            var time = new FbxTime(2352000);
            // when:
            var result = time.GetFieldCount();
            // then:
            Assert.AreEqual(1, result);
        }

        [Test]
        public void FbxTime_GetFieldCount_HalfYieldsOne2()
        {
            // given:
            var time = new FbxTime(2351999);
            // when:
            var result = time.GetFieldCount();
            // then:
            Assert.AreEqual(0, result);
        }

        [Test]
        public void FbxTime_GetFieldCount_HalfYieldsOne3()
        {
            // given:
            var time = new FbxTime(2352001);
            // when:
            var result = time.GetFieldCount();
            // then:
            Assert.AreEqual(1, result);
        }

        [Test]
        public void FbxTime_GetFieldCount_NegHalfYieldsOne()
        {
            // given:
            var time = new FbxTime(-2352000);
            // when:
            var result = time.GetFieldCount();
            // then:
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void FbxTime_GetFieldCount_NegHalfYieldsOne2()
        {
            // given:
            var time = new FbxTime(-2351999);
            // when:
            var result = time.GetFieldCount();
            // then:
            Assert.AreEqual(0, result);
        }

        [Test]
        public void FbxTime_GetFieldCount_NegHalfYieldsOne3()
        {
            // given:
            var time = new FbxTime(-2352001);
            // when:
            var result = time.GetFieldCount();
            // then:
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void FbxTime_GetGlobalTimeMode()
        {
            // expect:
            Assert.AreEqual(FbxTime.EMode.eFrames30, FbxTime.GetGlobalTimeMode());
        }

        [Test]
        public void FbxTime_Get_YieldsInternalRepresentation()
        {
            // when:
            var time = new FbxTime(0L);
            // then:
            Assert.That(time.Get(), Is.EqualTo(0L));
            // when:
            time = new FbxTime(1L);
            // then:
            Assert.That(time.Get(), Is.EqualTo(1L));
            // when:
            time = new FbxTime(2L);
            // then:
            Assert.That(time.Get(), Is.EqualTo(2L));
            // when:
            time = new FbxTime(141119999L);
            // then:
            Assert.That(time.Get(), Is.EqualTo(141119999L));
            // when:
            time = new FbxTime(141120000L);
            // then:
            Assert.That(time.Get(), Is.EqualTo(141120000L));
            // when:
            time = new FbxTime(141120001L);
            // then:
            Assert.That(time.Get(), Is.EqualTo(141120001L));
            // when:
            time = new FbxTime(-1L);
            // then:
            Assert.That(time.Get(), Is.EqualTo(-1L));
            // when:
            time = new FbxTime(-2L);
            // then:
            Assert.That(time.Get(), Is.EqualTo(-2L));
            // when:
            time = new FbxTime(-141119999L);
            // then:
            Assert.That(time.Get(), Is.EqualTo(-141119999L));
            // when:
            time = new FbxTime(-141120000L);
            // then:
            Assert.That(time.Get(), Is.EqualTo(-141120000L));
            // when:
            time = new FbxTime(-141120001L);
            // then:
            Assert.That(time.Get(), Is.EqualTo(-141120001L));
        }

        [Test]
        public void FbxTime_CountFunctionAreIndependent()
        {
            // when:
            var time = new FbxTime(516640320000L);
            // then:
            Assert.That(time.GetMilliSeconds(), Is.EqualTo(3661000L));
            Assert.That(time.GetSecondCount(), Is.EqualTo(3661));
            Assert.That(time.GetMinuteCount(), Is.EqualTo(61));
            Assert.That(time.GetHourCount(), Is.EqualTo(1));
            Assert.That(time.GetSecondDouble(), Is.EqualTo(3661.0));

            // when:
            time = new FbxTime(516640461120L);
            Assert.That(time.GetMilliSeconds(), Is.EqualTo(3661001L));
            Assert.That(time.GetSecondCount(), Is.EqualTo(3661));
            Assert.That(time.GetMinuteCount(), Is.EqualTo(61));
            Assert.That(time.GetHourCount(), Is.EqualTo(1));
            Assert.That(time.GetSecondDouble(), Is.EqualTo(3661.001));
        }

        [Test]
        public void FbxTime_EMode_Values()
        {
            // expect:
            Assert.That((int)FbxTime.EMode.eDefaultMode, Is.EqualTo(0));
            Assert.That((int)FbxTime.EMode.eFrames120, Is.EqualTo(1));
            Assert.That((int)FbxTime.EMode.eFrames100, Is.EqualTo(2));
            Assert.That((int)FbxTime.EMode.eFrames60, Is.EqualTo(3));
            Assert.That((int)FbxTime.EMode.eFrames50, Is.EqualTo(4));
            Assert.That((int)FbxTime.EMode.eFrames48, Is.EqualTo(5));
            Assert.That((int)FbxTime.EMode.eFrames30, Is.EqualTo(6));
            Assert.That((int)FbxTime.EMode.eFrames30Drop, Is.EqualTo(7));
            Assert.That((int)FbxTime.EMode.eNTSCDropFrame, Is.EqualTo(8));
            Assert.That((int)FbxTime.EMode.eNTSCFullFrame, Is.EqualTo(9));
            Assert.That((int)FbxTime.EMode.ePAL, Is.EqualTo(10));
            Assert.That((int)FbxTime.EMode.eFrames24, Is.EqualTo(11));
            Assert.That((int)FbxTime.EMode.eFrames1000, Is.EqualTo(12));
            Assert.That((int)FbxTime.EMode.eFilmFullFrame, Is.EqualTo(13));
            Assert.That((int)FbxTime.EMode.eCustom, Is.EqualTo(14));
            Assert.That((int)FbxTime.EMode.eFrames96, Is.EqualTo(15));
            Assert.That((int)FbxTime.EMode.eFrames72, Is.EqualTo(16));
            Assert.That((int)FbxTime.EMode.eFrames59dot94, Is.EqualTo(17));
            Assert.That((int)FbxTime.EMode.eFrames119dot88, Is.EqualTo(18));
            Assert.That((int)FbxTime.EMode.eModesCount, Is.EqualTo(19));
        }

        [Test]
        public void FbxTime_EProtocol_Values()
        {
            // expect:
            Assert.That((int)FbxTime.EProtocol.eSMPTE, Is.EqualTo(0));
            Assert.That((int)FbxTime.EProtocol.eFrameCount, Is.EqualTo(1));
            Assert.That((int)FbxTime.EProtocol.eDefaultProtocol, Is.EqualTo(2));
        }

        [Test]
        public void FbxTime_GetOneFrameValue()
        {
            // expect:
            Assert.That(FbxTime.GetOneFrameValue(FbxTime.EMode.eDefaultMode), Is.EqualTo(4704000L));
            Assert.That(FbxTime.GetOneFrameValue(FbxTime.EMode.eFrames120), Is.EqualTo(1176000L));
            Assert.That(FbxTime.GetOneFrameValue(FbxTime.EMode.eFrames100), Is.EqualTo(1411200L));
            Assert.That(FbxTime.GetOneFrameValue(FbxTime.EMode.eFrames60), Is.EqualTo(2352000L));
            Assert.That(FbxTime.GetOneFrameValue(FbxTime.EMode.eFrames50), Is.EqualTo(2822400L));
            Assert.That(FbxTime.GetOneFrameValue(FbxTime.EMode.eFrames48), Is.EqualTo(2940000L));
            Assert.That(FbxTime.GetOneFrameValue(FbxTime.EMode.eFrames30), Is.EqualTo(4704000L));
            Assert.That(FbxTime.GetOneFrameValue(FbxTime.EMode.eFrames30Drop), Is.EqualTo(0L));
            Assert.That(FbxTime.GetOneFrameValue(FbxTime.EMode.eNTSCDropFrame), Is.EqualTo(4708704L));
            Assert.That(FbxTime.GetOneFrameValue(FbxTime.EMode.eNTSCFullFrame), Is.EqualTo(4708704L));
            Assert.That(FbxTime.GetOneFrameValue(FbxTime.EMode.ePAL), Is.EqualTo(5644800L));
            Assert.That(FbxTime.GetOneFrameValue(FbxTime.EMode.eFrames24), Is.EqualTo(5880000L));
            Assert.That(FbxTime.GetOneFrameValue(FbxTime.EMode.eFrames1000), Is.EqualTo(141120L));
            Assert.That(FbxTime.GetOneFrameValue(FbxTime.EMode.eFilmFullFrame), Is.EqualTo(5885880L));
            Assert.That(FbxTime.GetOneFrameValue(FbxTime.EMode.eCustom), Is.EqualTo(11289600L));
            Assert.That(FbxTime.GetOneFrameValue(FbxTime.EMode.eFrames96), Is.EqualTo(1470000L));
            Assert.That(FbxTime.GetOneFrameValue(FbxTime.EMode.eFrames72), Is.EqualTo(1960000L));
            Assert.That(FbxTime.GetOneFrameValue(FbxTime.EMode.eFrames59dot94), Is.EqualTo(2354352L));
            Assert.That(FbxTime.GetOneFrameValue(FbxTime.EMode.eFrames119dot88), Is.EqualTo(1177176L));
            Assert.That(FbxTime.GetOneFrameValue(FbxTime.EMode.eModesCount), Is.EqualTo(0L));
        }

        [Test]
        public void FbxTime_GetGlobalTimeProtocol()
        {
            // expect:
            Assert.That(FbxTime.GetGlobalTimeProtocol(), Is.EqualTo(FbxTime.EProtocol.eFrameCount));
        }

        [Test]
        public void FbxTime_GetFrameRate()
        {
            // expect:
            Assert.That(FbxTime.GetFrameRate(FbxTime.EMode.eDefaultMode), Is.EqualTo(30.0));
            Assert.That(FbxTime.GetFrameRate(FbxTime.EMode.eFrames120), Is.EqualTo(120.0));
            Assert.That(FbxTime.GetFrameRate(FbxTime.EMode.eFrames100), Is.EqualTo(100.0));
            Assert.That(FbxTime.GetFrameRate(FbxTime.EMode.eFrames60), Is.EqualTo(60.0));
            Assert.That(FbxTime.GetFrameRate(FbxTime.EMode.eFrames50), Is.EqualTo(50.0));
            Assert.That(FbxTime.GetFrameRate(FbxTime.EMode.eFrames48), Is.EqualTo(48.0));
            Assert.That(FbxTime.GetFrameRate(FbxTime.EMode.eFrames30), Is.EqualTo(30.0));
            Assert.That(FbxTime.GetFrameRate(FbxTime.EMode.eFrames30Drop), Is.EqualTo(0.0));
            Assert.That(FbxTime.GetFrameRate(FbxTime.EMode.eNTSCDropFrame), Is.EqualTo(29.970029970029969490497023798525333404541015625));
            Assert.That(FbxTime.GetFrameRate(FbxTime.EMode.eNTSCFullFrame), Is.EqualTo(29.970029970029969490497023798525333404541015625));
            Assert.That(FbxTime.GetFrameRate(FbxTime.EMode.ePAL), Is.EqualTo(25.0));
            Assert.That(FbxTime.GetFrameRate(FbxTime.EMode.eFrames24), Is.EqualTo(24.0));
            Assert.That(FbxTime.GetFrameRate(FbxTime.EMode.eFrames1000), Is.EqualTo(1000.0));
            Assert.That(FbxTime.GetFrameRate(FbxTime.EMode.eFilmFullFrame), Is.EqualTo(23.976023976023977724025826319120824337005615234375));
            Assert.That(FbxTime.GetFrameRate(FbxTime.EMode.eCustom), Is.EqualTo(12.5));
            Assert.That(FbxTime.GetFrameRate(FbxTime.EMode.eFrames96), Is.EqualTo(96.0));
            Assert.That(FbxTime.GetFrameRate(FbxTime.EMode.eFrames72), Is.EqualTo(72.0));
            Assert.That(FbxTime.GetFrameRate(FbxTime.EMode.eFrames59dot94), Is.EqualTo(59.94005994005993898099404759705066680908203125));
            Assert.That(FbxTime.GetFrameRate(FbxTime.EMode.eFrames119dot88), Is.EqualTo(119.8801198801198779619880951941013336181640625));
            Assert.That(FbxTime.GetFrameRate(FbxTime.EMode.eModesCount), Is.EqualTo(0.0));
        }

        [Test]
        public void FbxTime_ConvertFrameRateToTimeMode()
        {
            // expect:
            Assert.AreEqual(FbxTime.EMode.eFrames30, FbxTime.ConvertFrameRateToTimeMode(30.0));
            Assert.AreEqual(FbxTime.EMode.eFrames120, FbxTime.ConvertFrameRateToTimeMode(120.0));
            Assert.AreEqual(FbxTime.EMode.eFrames100, FbxTime.ConvertFrameRateToTimeMode(100.0));
            Assert.AreEqual(FbxTime.EMode.eFrames60, FbxTime.ConvertFrameRateToTimeMode(60.0));
            Assert.AreEqual(FbxTime.EMode.eFrames50, FbxTime.ConvertFrameRateToTimeMode(50.0));
            Assert.AreEqual(FbxTime.EMode.eFrames48, FbxTime.ConvertFrameRateToTimeMode(48.0));
            Assert.AreEqual(FbxTime.EMode.eFrames30, FbxTime.ConvertFrameRateToTimeMode(30.0));
            Assert.AreEqual(FbxTime.EMode.eNTSCDropFrame, FbxTime.ConvertFrameRateToTimeMode(29.970029970029969490497023798525333404541015625));
            Assert.AreEqual(FbxTime.EMode.ePAL, FbxTime.ConvertFrameRateToTimeMode(25.0));
            Assert.AreEqual(FbxTime.EMode.eFrames24, FbxTime.ConvertFrameRateToTimeMode(24.0));
            Assert.AreEqual(FbxTime.EMode.eFrames1000, FbxTime.ConvertFrameRateToTimeMode(1000.0));
            Assert.AreEqual(FbxTime.EMode.eFilmFullFrame, FbxTime.ConvertFrameRateToTimeMode(23.976023976023977724025826319120824337005615234375));
            Assert.AreEqual(FbxTime.EMode.eCustom, FbxTime.ConvertFrameRateToTimeMode(12.5));
            Assert.AreEqual(FbxTime.EMode.eFrames96, FbxTime.ConvertFrameRateToTimeMode(96.0));
            Assert.AreEqual(FbxTime.EMode.eFrames72, FbxTime.ConvertFrameRateToTimeMode(72.0));
            Assert.AreEqual(FbxTime.EMode.eFrames59dot94, FbxTime.ConvertFrameRateToTimeMode(59.94005994005993898099404759705066680908203125));
            Assert.AreEqual(FbxTime.EMode.eFrames119dot88, FbxTime.ConvertFrameRateToTimeMode(119.8801198801198779619880951941013336181640625));

            Assert.AreEqual(FbxTime.EMode.eFrames30Drop, FbxTime.ConvertFrameRateToTimeMode(0.0));
            Assert.AreEqual(FbxTime.EMode.eDefaultMode, FbxTime.ConvertFrameRateToTimeMode(1.0));
            Assert.AreEqual(FbxTime.EMode.eDefaultMode, FbxTime.ConvertFrameRateToTimeMode(10.0));

            Assert.AreEqual(FbxTime.EMode.ePAL, FbxTime.ConvertFrameRateToTimeMode(27.0, 2.9));
            Assert.AreEqual(FbxTime.EMode.eFrames30, FbxTime.ConvertFrameRateToTimeMode(27.0, 3.0));
            Assert.AreEqual(FbxTime.EMode.eFrames30, FbxTime.ConvertFrameRateToTimeMode(27.0, 3.1));

            Assert.AreEqual(FbxTime.EMode.ePAL, FbxTime.ConvertFrameRateToTimeMode(24.5, 0.5));
            Assert.AreEqual(FbxTime.EMode.eDefaultMode, FbxTime.ConvertFrameRateToTimeMode(24.5, 0.4));
            Assert.AreEqual(FbxTime.EMode.ePAL, FbxTime.ConvertFrameRateToTimeMode(24.6, 0.4));
            Assert.AreEqual(FbxTime.EMode.eDefaultMode, FbxTime.ConvertFrameRateToTimeMode(24.41, 0.4));
            Assert.AreEqual(FbxTime.EMode.eFrames24, FbxTime.ConvertFrameRateToTimeMode(24.4, 0.4));
            Assert.AreEqual(FbxTime.EMode.eFrames24, FbxTime.ConvertFrameRateToTimeMode(24.3, 0.4));
        }
    }
}
