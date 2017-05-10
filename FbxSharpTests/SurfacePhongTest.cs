using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class SurfacePhongTest : TestBase
    {
        [Test]
        public void SurfacePhong_Create_HasProperties()
        {
            // given:
            var surface = new FbxSurfacePhong("");
            FbxProperty prop;

            // then:
            Assert.AreEqual(22, CountProperties(surface));
            Assert.AreEqual(0, surface.GetSrcPropertyCount());
            Assert.AreEqual(0, surface.GetDstPropertyCount());

            prop = surface.FindProperty("ShadingModel");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.ShadingModel);
            Assert.True(surface.ShadingModel.IsValid());
            Assert.AreEqual("ShadingModel", surface.ShadingModel.GetName());
            Assert.AreSame(prop, surface.ShadingModel);

            prop = surface.FindProperty("MultiLayer");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.MultiLayer);
            Assert.True(surface.MultiLayer.IsValid());
            Assert.AreEqual("MultiLayer", surface.MultiLayer.GetName());
            Assert.AreSame(prop, surface.MultiLayer);

            prop = surface.FindProperty("EmissiveColor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.Emissive);
            Assert.True(surface.Emissive.IsValid());
            Assert.AreEqual("EmissiveColor", surface.Emissive.GetName());
            Assert.AreSame(prop, surface.Emissive);

            prop = surface.FindProperty("EmissiveFactor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.EmissiveFactor);
            Assert.True(surface.EmissiveFactor.IsValid());
            Assert.AreEqual("EmissiveFactor", surface.EmissiveFactor.GetName());
            Assert.AreSame(prop, surface.EmissiveFactor);

            prop = surface.FindProperty("AmbientColor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.Ambient);
            Assert.True(surface.Ambient.IsValid());
            Assert.AreEqual("AmbientColor", surface.Ambient.GetName());
            Assert.AreSame(prop, surface.Ambient);

            prop = surface.FindProperty("AmbientFactor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.AmbientFactor);
            Assert.True(surface.AmbientFactor.IsValid());
            Assert.AreEqual("AmbientFactor", surface.AmbientFactor.GetName());
            Assert.AreSame(prop, surface.AmbientFactor);

            prop = surface.FindProperty("DiffuseColor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.Diffuse);
            Assert.True(surface.Diffuse.IsValid());
            Assert.AreEqual("DiffuseColor", surface.Diffuse.GetName());
            Assert.AreSame(prop, surface.Diffuse);

            prop = surface.FindProperty("DiffuseFactor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.DiffuseFactor);
            Assert.True(surface.DiffuseFactor.IsValid());
            Assert.AreEqual("DiffuseFactor", surface.DiffuseFactor.GetName());
            Assert.AreSame(prop, surface.DiffuseFactor);

            prop = surface.FindProperty("Bump");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.Bump);
            Assert.True(surface.Bump.IsValid());
            Assert.AreEqual("Bump", surface.Bump.GetName());
            Assert.AreSame(prop, surface.Bump);

            prop = surface.FindProperty("NormalMap");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.NormalMap);
            Assert.True(surface.NormalMap.IsValid());
            Assert.AreEqual("NormalMap", surface.NormalMap.GetName());
            Assert.AreSame(prop, surface.NormalMap);

            prop = surface.FindProperty("BumpFactor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.BumpFactor);
            Assert.True(surface.BumpFactor.IsValid());
            Assert.AreEqual("BumpFactor", surface.BumpFactor.GetName());
            Assert.AreSame(prop, surface.BumpFactor);

            prop = surface.FindProperty("TransparentColor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.TransparentColor);
            Assert.True(surface.TransparentColor.IsValid());
            Assert.AreEqual("TransparentColor", surface.TransparentColor.GetName());
            Assert.AreSame(prop, surface.TransparentColor);

            prop = surface.FindProperty("TransparencyFactor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.TransparencyFactor);
            Assert.True(surface.TransparencyFactor.IsValid());
            Assert.AreEqual("TransparencyFactor", surface.TransparencyFactor.GetName());
            Assert.AreSame(prop, surface.TransparencyFactor);

            prop = surface.FindProperty("DisplacementColor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.DisplacementColor);
            Assert.True(surface.DisplacementColor.IsValid());
            Assert.AreEqual("DisplacementColor", surface.DisplacementColor.GetName());
            Assert.AreSame(prop, surface.DisplacementColor);

            prop = surface.FindProperty("DisplacementFactor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.DisplacementFactor);
            Assert.True(surface.DisplacementFactor.IsValid());
            Assert.AreEqual("DisplacementFactor", surface.DisplacementFactor.GetName());
            Assert.AreSame(prop, surface.DisplacementFactor);

            prop = surface.FindProperty("VectorDisplacementColor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.VectorDisplacementColor);
            Assert.True(surface.VectorDisplacementColor.IsValid());
            Assert.AreEqual("VectorDisplacementColor", surface.VectorDisplacementColor.GetName());
            Assert.AreSame(prop, surface.VectorDisplacementColor);

            prop = surface.FindProperty("VectorDisplacementFactor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.VectorDisplacementFactor);
            Assert.True(surface.VectorDisplacementFactor.IsValid());
            Assert.AreEqual("VectorDisplacementFactor", surface.VectorDisplacementFactor.GetName());
            Assert.AreSame(prop, surface.VectorDisplacementFactor);

            prop = surface.FindProperty("SpecularColor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.Specular);
            Assert.True(surface.Specular.IsValid());
            Assert.AreEqual("SpecularColor", surface.Specular.GetName());
            Assert.AreSame(prop, surface.Specular);

            prop = surface.FindProperty("SpecularFactor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.SpecularFactor);
            Assert.True(surface.SpecularFactor.IsValid());
            Assert.AreEqual("SpecularFactor", surface.SpecularFactor.GetName());
            Assert.AreSame(prop, surface.SpecularFactor);

            prop = surface.FindProperty("ShininessExponent");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.Shininess);
            Assert.True(surface.Shininess.IsValid());
            Assert.AreEqual("ShininessExponent", surface.Shininess.GetName());
            Assert.AreSame(prop, surface.Shininess);

            prop = surface.FindProperty("ReflectionColor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.Reflection);
            Assert.True(surface.Reflection.IsValid());
            Assert.AreEqual("ReflectionColor", surface.Reflection.GetName());
            Assert.AreSame(prop, surface.Reflection);

            prop = surface.FindProperty("ReflectionFactor");
            Assert.NotNull(prop);
            Assert.True(prop.IsValid());
            Assert.NotNull(surface.ReflectionFactor);
            Assert.True(surface.ReflectionFactor.IsValid());
            Assert.AreEqual("ReflectionFactor", surface.ReflectionFactor.GetName());
            Assert.AreSame(prop, surface.ReflectionFactor);
        }

        [Test]
        public void SurfacePhong_Create_HasNamespacePrefix()
        {
            // given:
            var surface = new FbxSurfacePhong("asdf");

            // then:
            Assert.AreEqual("Material::", surface.GetNameSpacePrefix());
        }
    }
}
