using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class FbxAxisSystemTest : TestBase
    {
        [Test]
        public void FbxAxisSystem_Create_HasDefaults()
        {
            // given:
            FbxAxisSystem obj;

            // when:
            obj = new FbxAxisSystem();

            // then:
            var sign = 0;
            Assert.That(obj.GetFrontVector(ref sign), Is.EqualTo(FbxAxisSystem.EFrontVector.eParityOdd));
            Assert.That(sign, Is.EqualTo(1));
            Assert.That(obj.GetUpVector(ref sign), Is.EqualTo(FbxAxisSystem.EUpVector.eYAxis));
            Assert.That(sign, Is.EqualTo(1));
            Assert.That(obj.GetCoorSystem(), Is.EqualTo(FbxAxisSystem.ECoordSystem.eRightHanded));
        }
    }
}
