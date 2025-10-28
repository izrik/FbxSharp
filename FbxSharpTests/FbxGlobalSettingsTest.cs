using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class FbxGlobalSettingsTest : TestBase
    {
        [Test]
        public void FbxGlobalSettings_Create_HasDefaults()
        {
            // given:
            var settings = new FbxGlobalSettings("");
            FbxProperty prop;

            // expect:
            Assert.NotNull(settings);
            Assert.That(settings.GetSrcObjectCount(), Is.EqualTo(0));
            Assert.That(settings.GetDstObjectCount(), Is.EqualTo(0));
            Assert.That(settings.GetSrcPropertyCount(), Is.EqualTo(0));
            Assert.That(settings.GetDstPropertyCount(), Is.EqualTo(0));

            Assert.That(CountProperties(settings), Is.EqualTo(20));

            prop = settings.FindProperty("UpAxis");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("UpAxis"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("UpAxis"));
            Assert.That(prop.GetPropertyDataType().GetFbxType(), Is.EqualTo(EFbxType.eFbxInt));
            Assert.That(prop.Get<int>(), Is.EqualTo((int)FbxAxisSystem.EUpVector.eXAxis));

            prop = settings.FindProperty("UpAxisSign");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("UpAxisSign"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("UpAxisSign"));
            Assert.That(prop.GetPropertyDataType().GetFbxType(), Is.EqualTo(EFbxType.eFbxInt));
            Assert.That(prop.Get<int>(), Is.EqualTo(1));

            prop = settings.FindProperty("FrontAxis");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("FrontAxis"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("FrontAxis"));
            Assert.That(prop.GetPropertyDataType().GetFbxType(), Is.EqualTo(EFbxType.eFbxInt));
            Assert.That(prop.Get<int>(), Is.EqualTo((int)FbxAxisSystem.EFrontVector.eParityOdd));

            prop = settings.FindProperty("FrontAxisSign");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("FrontAxisSign"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("FrontAxisSign"));
            Assert.That(prop.GetPropertyDataType().GetFbxType(), Is.EqualTo(EFbxType.eFbxInt));
            Assert.That(prop.Get<int>(), Is.EqualTo(1));

            prop = settings.FindProperty("CoordAxis");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("CoordAxis"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("CoordAxis"));
            Assert.That(prop.GetPropertyDataType().GetFbxType(), Is.EqualTo(EFbxType.eFbxInt));
            Assert.That(prop.Get<int>(), Is.EqualTo((int)FbxAxisSystem.ECoordSystem.eRightHanded));

            prop = settings.FindProperty("CoordAxisSign");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("CoordAxisSign"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("CoordAxisSign"));
            Assert.That(prop.GetPropertyDataType().GetFbxType(), Is.EqualTo(EFbxType.eFbxInt));
            Assert.That(prop.Get<int>(), Is.EqualTo(1));

            prop = settings.FindProperty("OriginalUpAxis");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("OriginalUpAxis"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("OriginalUpAxis"));
            Assert.That(prop.GetPropertyDataType().GetFbxType(), Is.EqualTo(EFbxType.eFbxInt));
            Assert.That(prop.Get<int>(), Is.EqualTo(-1));

            prop = settings.FindProperty("OriginalUpAxisSign");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("OriginalUpAxisSign"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("OriginalUpAxisSign"));
            Assert.That(prop.GetPropertyDataType().GetFbxType(), Is.EqualTo(EFbxType.eFbxInt));
            Assert.That(prop.Get<int>(), Is.EqualTo(1));

            prop = settings.FindProperty("UnitScaleFactor");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("UnitScaleFactor"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("UnitScaleFactor"));
            Assert.That(prop.GetPropertyDataType().GetFbxType(), Is.EqualTo(EFbxType.eFbxDouble));
            Assert.That(prop.Get<double>(), Is.EqualTo(1.0d));

            prop = settings.FindProperty("OriginalUnitScaleFactor");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("OriginalUnitScaleFactor"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("OriginalUnitScaleFactor"));
            Assert.That(prop.GetPropertyDataType().GetFbxType(), Is.EqualTo(EFbxType.eFbxDouble));
            Assert.That(prop.Get<double>(), Is.EqualTo(1.0d));

            prop = settings.FindProperty("AmbientColor");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("AmbientColor"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("AmbientColor"));
            Assert.That(prop.GetPropertyDataType().GetFbxType(), Is.EqualTo(EFbxType.eFbxDouble3));
            var color = prop.Get<FbxColor>();
            Assert.That(color.mRed, Is.EqualTo(0.0d));
            Assert.That(color.mGreen, Is.EqualTo(0.0d));
            Assert.That(color.mBlue, Is.EqualTo(0.0d));

            prop = settings.FindProperty("DefaultCamera");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("DefaultCamera"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("DefaultCamera"));
            Assert.That(prop.GetPropertyDataType().GetFbxType(), Is.EqualTo(EFbxType.eFbxString));
            Assert.That(prop.Get<string>(), Is.EqualTo("Producer Perspective"));

            prop = settings.FindProperty("TimeMode");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("TimeMode"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("TimeMode"));
            Assert.That(prop.GetPropertyDataType().GetFbxType(), Is.EqualTo(EFbxType.eFbxEnum));
            Assert.That(prop.Get<int>(), Is.EqualTo((int)FbxTime.EMode.eDefaultMode));

            prop = settings.FindProperty("TimeProtocol");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("TimeProtocol"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("TimeProtocol"));
            Assert.That(prop.GetPropertyDataType().GetFbxType(), Is.EqualTo(EFbxType.eFbxEnum));
            Assert.That(prop.Get<int>(), Is.EqualTo((int)FbxTime.EProtocol.eDefaultProtocol));

            prop = settings.FindProperty("SnapOnFrameMode");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("SnapOnFrameMode"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("SnapOnFrameMode"));
            Assert.That(prop.GetPropertyDataType().GetFbxType(), Is.EqualTo(EFbxType.eFbxEnum));
            Assert.That(prop.Get<int>(), Is.EqualTo((int)FbxGlobalSettings.ESnapOnFrameMode.eNoSnap));

            prop = settings.FindProperty("TimeSpanStart");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("TimeSpanStart"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("TimeSpanStart"));
            Assert.That(prop.GetPropertyDataType().GetFbxType(), Is.EqualTo(EFbxType.eFbxTime));
            Assert.That(prop.Get<FbxTime>(), Is.EqualTo(new FbxTime(0)));

            prop = settings.FindProperty("TimeSpanStop");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("TimeSpanStop"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("TimeSpanStop"));
            Assert.That(prop.GetPropertyDataType().GetFbxType(), Is.EqualTo(EFbxType.eFbxTime));
            Assert.That(prop.Get<FbxTime>(), Is.EqualTo(new FbxTime(141120000L)));

            prop = settings.FindProperty("CustomFrameRate");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("CustomFrameRate"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("CustomFrameRate"));
            Assert.That(prop.GetPropertyDataType().GetFbxType(), Is.EqualTo(EFbxType.eFbxDouble));
            Assert.That(prop.Get<double>(), Is.EqualTo(-1.0d));

            prop = settings.FindProperty("TimeMarker");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("TimeMarker"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("TimeMarker"));
            Assert.That(prop.GetPropertyDataType().GetFbxType(), Is.EqualTo(EFbxType.eFbxUndefined));
            Assert.That(prop.Get<double>(), Is.EqualTo(0.0d));

            prop = settings.FindProperty("CurrentTimeMarker");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("CurrentTimeMarker"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("CurrentTimeMarker"));
            Assert.That(prop.GetPropertyDataType().GetFbxType(), Is.EqualTo(EFbxType.eFbxInt));
            Assert.That(prop.Get<int>(), Is.EqualTo(-1));

            Assert.That(settings.GetOriginalUpAxis(), Is.EqualTo(-1));

            var a = settings.GetAxisSystem();
            var sign = 0;
            Assert.That(a.GetUpVector(ref sign), Is.EqualTo(FbxAxisSystem.EUpVector.eYAxis));
            Assert.That(sign, Is.EqualTo(1));
            Assert.That(a.GetFrontVector(ref sign), Is.EqualTo(FbxAxisSystem.EFrontVector.eParityOdd));
            Assert.That(sign, Is.EqualTo(1));
            Assert.That(a.GetCoorSystem( ), Is.EqualTo(FbxAxisSystem.ECoordSystem.eRightHanded));

            var su = settings.GetSystemUnit();
            Assert.That(su.GetMultiplier(), Is.EqualTo(1.0d));
            Assert.That(su.GetScaleFactorAsString(), Is.EqualTo("cm"));
            Assert.That(su.GetScaleFactorAsString_Plurial(), Is.EqualTo("Centimeters"));
            Assert.True(FbxSystemUnit.cm == su);

            su = settings.GetOriginalSystemUnit();
            Assert.That(su.GetMultiplier(), Is.EqualTo(1.0d));
            Assert.That(su.GetScaleFactorAsString(), Is.EqualTo("cm"));
            Assert.That(su.GetScaleFactorAsString_Plurial(), Is.EqualTo("Centimeters"));
            Assert.True(FbxSystemUnit.cm == su);

            color = settings.GetAmbientColor();
            Assert.That(color.mRed, Is.EqualTo(0.0d));
            Assert.That(color.mGreen, Is.EqualTo(0.0d));
            Assert.That(color.mBlue, Is.EqualTo(0.0d));

            Assert.That(settings.GetDefaultCamera(), Is.EqualTo("Producer Perspective"));

            Assert.That(settings.GetTimeMode(), Is.EqualTo(FbxTime.EMode.eFrames30));
            Assert.That(settings.GetTimeProtocol(), Is.EqualTo(FbxTime.EProtocol.eFrameCount));
            Assert.That(settings.GetSnapOnFrameMode(), Is.EqualTo(FbxGlobalSettings.ESnapOnFrameMode.eNoSnap));
            FbxTimeSpan ts;
            settings.GetTimelineDefaultTimeSpan(out ts);
            Assert.That(ts.GetStart().Get(), Is.EqualTo(0L));
            Assert.That(ts.GetStop().Get(), Is.EqualTo(141120000L));
            Assert.That(ts.GetDuration().Get(), Is.EqualTo(141120000L));
            Assert.That(settings.GetCustomFrameRate(), Is.EqualTo(-1.0d));

            Assert.That(settings.GetTimeMarkerCount(), Is.EqualTo(0));
            Assert.That(settings.GetCurrentTimeMarker(), Is.EqualTo(-1));
        }

        [Test]
        public void FbxGlobalSettings_SetTimeMode_DifferentFromProperty()
        {
            // given:
            var settings = new FbxGlobalSettings("");
            FbxProperty prop;
            prop = settings.FindProperty("TimeMode");

            // expect:
            Assert.That(prop.Get<int>(), Is.EqualTo((int)FbxTime.EMode.eDefaultMode));
            Assert.That(settings.GetTimeMode(), Is.EqualTo(FbxTime.EMode.eFrames30));

            // when:
            settings.SetTimeMode(FbxTime.EMode.eFrames48);
            // then:
            Assert.That(prop.Get<int>(), Is.EqualTo((int)FbxTime.EMode.eFrames48));
            Assert.That(settings.GetTimeMode(), Is.EqualTo(FbxTime.EMode.eFrames48));

            // when:
            settings.SetTimeMode(FbxTime.EMode.eFrames30);
            // then:
            Assert.That(prop.Get<int>(), Is.EqualTo((int)FbxTime.EMode.eFrames30));
            Assert.That(settings.GetTimeMode(), Is.EqualTo(FbxTime.EMode.eFrames30));

            // when:
            settings.SetTimeMode(FbxTime.EMode.eDefaultMode);
            // then:
            Assert.That(prop.Get<int>(), Is.EqualTo((int)FbxTime.EMode.eDefaultMode));
            Assert.That(settings.GetTimeMode(), Is.EqualTo(FbxTime.EMode.eFrames30));
        }
    }
}
