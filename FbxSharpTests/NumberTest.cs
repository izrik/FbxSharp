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

	[Test]
	public void CreateWithLong_HasLongAndDoubleValue()
	{
	    // when
	    var n = new Number("123");

	    // then
	    Assert.IsTrue(n.AsDouble.HasValue);
	    Assert.AreEqual(123d, n.AsDouble.Value);
	    Assert.IsTrue(n.AsLong.HasValue);
	    Assert.AreEqual(123, n.AsLong.Value);
	    Assert.AreEqual("123", n.ToString());
	    Assert.AreEqual("123", n.StringRepresentation);

	    // when
	    n = new Number("12345678900");

	    // then
	    Assert.IsTrue(n.AsDouble.HasValue);
	    Assert.AreEqual(12345678900d, n.AsDouble.Value);
	    Assert.IsTrue(n.AsLong.HasValue);
	    Assert.AreEqual(12345678900, n.AsLong.Value);
	    Assert.AreEqual("12345678900", n.ToString());
	    Assert.AreEqual("12345678900", n.StringRepresentation);

	    // when
	    n = new Number("0");

	    // then
	    Assert.IsTrue(n.AsDouble.HasValue);
	    Assert.AreEqual(0d, n.AsDouble.Value);
	    Assert.IsTrue(n.AsLong.HasValue);
	    Assert.AreEqual(0L, n.AsLong.Value);
	    Assert.AreEqual("0", n.ToString());
	    Assert.AreEqual("0", n.StringRepresentation);
	}

	[Test]
	public void CreateWithDouble_HasOnlyDoubleValue()
	{
	    // when
	    var n = new Number("0.0");

	    // then
	    Assert.IsTrue(n.AsDouble.HasValue);
	    Assert.AreEqual(0d, n.AsDouble.Value);
	    Assert.IsFalse(n.AsLong.HasValue);
	    Assert.AreEqual("0", n.ToString());
	    Assert.AreEqual("0.0", n.StringRepresentation);

	    // when
	    n = new Number("0.000000000000000");

	    // then
	    Assert.IsTrue(n.AsDouble.HasValue);
	    Assert.AreEqual(0d, n.AsDouble.Value);
	    Assert.IsFalse(n.AsLong.HasValue);
	    Assert.AreEqual("0", n.ToString());
	    Assert.AreEqual("0.000000000000000", n.StringRepresentation);
	}
    }
}
