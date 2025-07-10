using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class FbxSystemUnitTest : TestBase
    {
        [Test]
        public void FbxSystemUnit_Create_HasDefaults()
        {
            // given:
            FbxSystemUnit obj;

            // when:
            obj = new FbxSystemUnit();

            // then:
            Assert.That(obj.GetScaleFactor(), Is.EqualTo(1.0d));
            Assert.That(obj.GetScaleFactorAsString(), Is.EqualTo("cm"));
            Assert.That(obj.GetScaleFactorAsString_Plurial(), Is.EqualTo("Centimeters"));
            Assert.That(obj.GetMultiplier(), Is.EqualTo(1.0d));
        }

        [Test]
        public void FbxSystemUnit_StaticBuiltinsHaveDefaults()
        {
            // given:
            FbxSystemUnit obj;

            // when:
            obj = new FbxSystemUnit();

            // then:
            Assert.That(FbxSystemUnit.mm.GetScaleFactor(), Is.EqualTo(0.1d));
            Assert.That(FbxSystemUnit.mm.GetScaleFactorAsString(), Is.EqualTo("mm"));
            Assert.That(FbxSystemUnit.mm.GetScaleFactorAsString_Plurial(), Is.EqualTo("Millimeters"));
            Assert.That(FbxSystemUnit.mm.GetMultiplier(), Is.EqualTo(1.0d));

            Assert.That(FbxSystemUnit.dm.GetScaleFactor(), Is.EqualTo(10.0d));
            Assert.That(FbxSystemUnit.dm.GetScaleFactorAsString(), Is.EqualTo("dm"));
            Assert.That(FbxSystemUnit.dm.GetScaleFactorAsString_Plurial(), Is.EqualTo("Decimeters"));
            Assert.That(FbxSystemUnit.dm.GetMultiplier(), Is.EqualTo(1.0d));

            Assert.That(FbxSystemUnit.cm.GetScaleFactor(), Is.EqualTo(1.0d));
            Assert.That(FbxSystemUnit.cm.GetScaleFactorAsString(), Is.EqualTo("cm"));
            Assert.That(FbxSystemUnit.cm.GetScaleFactorAsString_Plurial(), Is.EqualTo("Centimeters"));
            Assert.That(FbxSystemUnit.cm.GetMultiplier(), Is.EqualTo(1.0d));

            Assert.That(FbxSystemUnit.m.GetScaleFactor(), Is.EqualTo(100.0d));
            Assert.That(FbxSystemUnit.m.GetScaleFactorAsString(), Is.EqualTo("m"));
            Assert.That(FbxSystemUnit.m.GetScaleFactorAsString_Plurial(), Is.EqualTo("Meters"));
            Assert.That(FbxSystemUnit.m.GetMultiplier(), Is.EqualTo(1.0d));

            Assert.That(FbxSystemUnit.km.GetScaleFactor(), Is.EqualTo(100000.0d));
            Assert.That(FbxSystemUnit.km.GetScaleFactorAsString(), Is.EqualTo("km"));
            Assert.That(FbxSystemUnit.km.GetScaleFactorAsString_Plurial(), Is.EqualTo("Kilometers"));
            Assert.That(FbxSystemUnit.km.GetMultiplier(), Is.EqualTo(1.0d));

            Assert.That(FbxSystemUnit.Inch.GetScaleFactor(), Is.EqualTo(2.54d));
            Assert.That(FbxSystemUnit.Inch.GetScaleFactorAsString(), Is.EqualTo("in"));
            Assert.That(FbxSystemUnit.Inch.GetScaleFactorAsString_Plurial(), Is.EqualTo("Inches"));
            Assert.That(FbxSystemUnit.Inch.GetMultiplier(), Is.EqualTo(1.0d));

            Assert.That(FbxSystemUnit.Foot.GetScaleFactor(), Is.EqualTo(30.48d));
            Assert.That(FbxSystemUnit.Foot.GetScaleFactorAsString(), Is.EqualTo("ft"));
            Assert.That(FbxSystemUnit.Foot.GetScaleFactorAsString_Plurial(), Is.EqualTo("Feet"));
            Assert.That(FbxSystemUnit.Foot.GetMultiplier(), Is.EqualTo(1.0d));

            Assert.That(FbxSystemUnit.Mile.GetScaleFactor(), Is.EqualTo(160934.4d));
            Assert.That(FbxSystemUnit.Mile.GetScaleFactorAsString(), Is.EqualTo("mi"));
            Assert.That(FbxSystemUnit.Mile.GetScaleFactorAsString_Plurial(), Is.EqualTo("Miles"));
            Assert.That(FbxSystemUnit.Mile.GetMultiplier(), Is.EqualTo(1.0d));

            Assert.That(FbxSystemUnit.Yard.GetScaleFactor(), Is.EqualTo(91.44d));
            Assert.That(FbxSystemUnit.Yard.GetScaleFactorAsString(), Is.EqualTo("yd"));
            Assert.That(FbxSystemUnit.Yard.GetScaleFactorAsString_Plurial(), Is.EqualTo("Yards"));
            Assert.That(FbxSystemUnit.Yard.GetMultiplier(), Is.EqualTo(1.0d));

            Assert.That(FbxSystemUnit.sPredefinedUnits.GetScaleFactor(), Is.EqualTo(0.1d));
            Assert.That(FbxSystemUnit.sPredefinedUnits.GetScaleFactorAsString(), Is.EqualTo("mm"));
            Assert.That(FbxSystemUnit.sPredefinedUnits.GetScaleFactorAsString_Plurial(), Is.EqualTo("Millimeters"));
            Assert.That(FbxSystemUnit.sPredefinedUnits.GetMultiplier(), Is.EqualTo(1.0d));
        }
    }
}
