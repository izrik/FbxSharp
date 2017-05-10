using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class GeometryBaseTest : TestBase
    {
        [Test]
        public void GeometryBase_InitControlPoints_InitsControlPoints()
        {
            // given:
            var gb = new FbxMesh("");

            // require:
            Assert.AreEqual(0, gb.GetControlPointsCount());

            // when:
            gb.InitControlPoints(4);

            // then:
            Assert.AreEqual(4, gb.GetControlPointsCount());

            // when:
            gb.InitControlPoints(20);

            // then:
            Assert.AreEqual(20, gb.GetControlPointsCount());

            // when:
            gb.InitControlPoints(3);

            // then:
            Assert.AreEqual(3, gb.GetControlPointsCount());
        }

        [Test]
        public void GeometryBase_SetControlPointAt_SetsControlPoint()
        {
            // given:
            var gb = new FbxMesh("");
            gb.InitControlPoints(4);

            // require:
            Assert.AreEqual(4, gb.GetControlPointsCount());
            Assert.AreEqual(new FbxVector4(0, 0, 0, 0), gb.GetControlPointAt(0));
            Assert.AreEqual(new FbxVector4(0, 0, 0, 0), gb.GetControlPointAt(1));
            Assert.AreEqual(new FbxVector4(0, 0, 0, 0), gb.GetControlPointAt(2));
            Assert.AreEqual(new FbxVector4(0, 0, 0, 0), gb.GetControlPointAt(3));

            // when:
            gb.SetControlPointAt(new FbxVector4(1.2, 3.4, 5.6, 7.8), 2);

            // then:
            Assert.AreEqual(new FbxVector4(0, 0, 0, 0), gb.GetControlPointAt(0));
            Assert.AreEqual(new FbxVector4(0, 0, 0, 0), gb.GetControlPointAt(1));
            Assert.AreEqual(new FbxVector4(1.2, 3.4, 5.6, 7.8), gb.GetControlPointAt(2));
            Assert.AreEqual(new FbxVector4(0, 0, 0, 0), gb.GetControlPointAt(3));
        }
    }
}
