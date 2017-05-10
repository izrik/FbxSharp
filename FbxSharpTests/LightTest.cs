using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class LightTest : TestBase
    {
        [Test]
        public void Light_Create_HasProperties()
        {
            // given:
            var light = new FbxLight("light");
            FbxProperty prop;

            // then:
            Assert.AreEqual(27, CountProperties(light));
            Assert.AreEqual(0, light.GetSrcPropertyCount());
            Assert.AreEqual(0, light.GetDstPropertyCount());

            prop = light.FindProperty("LightType");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.LightType);
            Assert.True(light.LightType.IsValid());
            Assert.AreEqual("LightType", light.LightType.GetName());
            Assert.AreSame(prop, light.LightType);

            prop = light.FindProperty("CastLightOnObject");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.CastLight);
            Assert.True(light.CastLight.IsValid());
            Assert.AreEqual("CastLightOnObject", light.CastLight.GetName());
            Assert.AreSame(prop, light.CastLight);

            prop = light.FindProperty("DrawVolumetricLight");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.DrawVolumetricLight);
            Assert.True(light.DrawVolumetricLight.IsValid());
            Assert.AreEqual("DrawVolumetricLight", light.DrawVolumetricLight.GetName());
            Assert.AreSame(prop, light.DrawVolumetricLight);

            prop = light.FindProperty("DrawGroundProjection");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.DrawGroundProjection);
            Assert.True(light.DrawGroundProjection.IsValid());
            Assert.AreEqual("DrawGroundProjection", light.DrawGroundProjection.GetName());
            Assert.AreSame(prop, light.DrawGroundProjection);

            prop = light.FindProperty("DrawFrontFacingVolumetricLight");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.DrawFrontFacingVolumetricLight);
            Assert.True(light.DrawFrontFacingVolumetricLight.IsValid());
            Assert.AreEqual("DrawFrontFacingVolumetricLight", light.DrawFrontFacingVolumetricLight.GetName());
            Assert.AreSame(prop, light.DrawFrontFacingVolumetricLight);

            prop = light.FindProperty("Color");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.Color);
            Assert.True(light.Color.IsValid());
            Assert.AreEqual("Color", light.Color.GetName());
            Assert.AreSame(prop, light.Color);

            prop = light.FindProperty("Intensity");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.Intensity);
            Assert.True(light.Intensity.IsValid());
            Assert.AreEqual("Intensity", light.Intensity.GetName());
            Assert.AreSame(prop, light.Intensity);

            prop = light.FindProperty("InnerAngle");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.InnerAngle);
            Assert.True(light.InnerAngle.IsValid());
            Assert.AreEqual("InnerAngle", light.InnerAngle.GetName());
            Assert.AreSame(prop, light.InnerAngle);

            prop = light.FindProperty("OuterAngle");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.OuterAngle);
            Assert.True(light.OuterAngle.IsValid());
            Assert.AreEqual("OuterAngle", light.OuterAngle.GetName());
            Assert.AreSame(prop, light.OuterAngle);

            prop = light.FindProperty("Fog");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.Fog);
            Assert.True(light.Fog.IsValid());
            Assert.AreEqual("Fog", light.Fog.GetName());
            Assert.AreSame(prop, light.Fog);

            prop = light.FindProperty("DecayType");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.DecayType);
            Assert.True(light.DecayType.IsValid());
            Assert.AreEqual("DecayType", light.DecayType.GetName());
            Assert.AreSame(prop, light.DecayType);

            prop = light.FindProperty("DecayStart");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.DecayStart);
            Assert.True(light.DecayStart.IsValid());
            Assert.AreEqual("DecayStart", light.DecayStart.GetName());
            Assert.AreSame(prop, light.DecayStart);

            prop = light.FindProperty("FileName");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.FileName);
            Assert.True(light.FileName.IsValid());
            Assert.AreEqual("FileName", light.FileName.GetName());
            Assert.AreSame(prop, light.FileName);

            prop = light.FindProperty("EnableNearAttenuation");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.EnableNearAttenuation);
            Assert.True(light.EnableNearAttenuation.IsValid());
            Assert.AreEqual("EnableNearAttenuation", light.EnableNearAttenuation.GetName());
            Assert.AreSame(prop, light.EnableNearAttenuation);

            prop = light.FindProperty("NearAttenuationStart");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.NearAttenuationStart);
            Assert.True(light.NearAttenuationStart.IsValid());
            Assert.AreEqual("NearAttenuationStart", light.NearAttenuationStart.GetName());
            Assert.AreSame(prop, light.NearAttenuationStart);

            prop = light.FindProperty("NearAttenuationEnd");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.NearAttenuationEnd);
            Assert.True(light.NearAttenuationEnd.IsValid());
            Assert.AreEqual("NearAttenuationEnd", light.NearAttenuationEnd.GetName());
            Assert.AreSame(prop, light.NearAttenuationEnd);

            prop = light.FindProperty("EnableFarAttenuation");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.EnableFarAttenuation);
            Assert.True(light.EnableFarAttenuation.IsValid());
            Assert.AreEqual("EnableFarAttenuation", light.EnableFarAttenuation.GetName());
            Assert.AreSame(prop, light.EnableFarAttenuation);

            prop = light.FindProperty("FarAttenuationStart");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.FarAttenuationStart);
            Assert.True(light.FarAttenuationStart.IsValid());
            Assert.AreEqual("FarAttenuationStart", light.FarAttenuationStart.GetName());
            Assert.AreSame(prop, light.FarAttenuationStart);

            prop = light.FindProperty("FarAttenuationEnd");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.FarAttenuationEnd);
            Assert.True(light.FarAttenuationEnd.IsValid());
            Assert.AreEqual("FarAttenuationEnd", light.FarAttenuationEnd.GetName());
            Assert.AreSame(prop, light.FarAttenuationEnd);

            prop = light.FindProperty("CastShadows");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.CastShadows);
            Assert.True(light.CastShadows.IsValid());
            Assert.AreEqual("CastShadows", light.CastShadows.GetName());
            Assert.AreSame(prop, light.CastShadows);

            prop = light.FindProperty("ShadowColor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.ShadowColor);
            Assert.True(light.ShadowColor.IsValid());
            Assert.AreEqual("ShadowColor", light.ShadowColor.GetName());
            Assert.AreSame(prop, light.ShadowColor);

            prop = light.FindProperty("AreaLightShape");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.AreaLightShape);
            Assert.True(light.AreaLightShape.IsValid());
            Assert.AreEqual("AreaLightShape", light.AreaLightShape.GetName());
            Assert.AreSame(prop, light.AreaLightShape);

            prop = light.FindProperty("LeftBarnDoor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.LeftBarnDoor);
            Assert.True(light.LeftBarnDoor.IsValid());
            Assert.AreEqual("LeftBarnDoor", light.LeftBarnDoor.GetName());
            Assert.AreSame(prop, light.LeftBarnDoor);

            prop = light.FindProperty("RightBarnDoor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.RightBarnDoor);
            Assert.True(light.RightBarnDoor.IsValid());
            Assert.AreEqual("RightBarnDoor", light.RightBarnDoor.GetName());
            Assert.AreSame(prop, light.RightBarnDoor);

            prop = light.FindProperty("TopBarnDoor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.TopBarnDoor);
            Assert.True(light.TopBarnDoor.IsValid());
            Assert.AreEqual("TopBarnDoor", light.TopBarnDoor.GetName());
            Assert.AreSame(prop, light.TopBarnDoor);

            prop = light.FindProperty("BottomBarnDoor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.BottomBarnDoor);
            Assert.True(light.BottomBarnDoor.IsValid());
            Assert.AreEqual("BottomBarnDoor", light.BottomBarnDoor.GetName());
            Assert.AreSame(prop, light.BottomBarnDoor);

            prop = light.FindProperty("EnableBarnDoor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(light.EnableBarnDoor);
            Assert.True(light.EnableBarnDoor.IsValid());
            Assert.AreEqual("EnableBarnDoor", light.EnableBarnDoor.GetName());
            Assert.AreSame(prop, light.EnableBarnDoor);
        }

        [Test]
        public void Light_Create_HasNamespacePrefix()
        {
            // given:
            var obj = new FbxLight("asdf");

            // then:
            Assert.AreEqual("NodeAttribute::", obj.GetNameSpacePrefix());
        }
    }
}
