using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class NumberTest : TestBase
    {
        [Test]
        public void Create_ValuesAreNull()
        {
            // when:
	    var n = new Number();

            // then:
	    Assert.IsNull(n.AsDouble);
	    Assert.IsNull(n.AsLong);
	    Assert.IsNull(n.StringRepresentation);
	    // Assert.AreEqual("null", n.ToString());
        }
    }
}
