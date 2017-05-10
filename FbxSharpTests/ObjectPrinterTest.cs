using System;
using NUnit.Framework;
using FbxSharp;
using System.IO;

namespace FbxSharpTests
{
    [TestFixture]
    public class ObjectPrinterTest
    {
        [Test]
        public void QuoteQuotesAndEscapeStrings()
        {
            Assert.AreEqual("\"abcdefghijklmnopqrstuvwxyz\"", ObjectPrinter.quote("abcdefghijklmnopqrstuvwxyz"));
            Assert.AreEqual("\"ABCDEFGHIJKLMNOPQRSTUVWXYZ\"", ObjectPrinter.quote("ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
            Assert.AreEqual("\"0123456789\"", ObjectPrinter.quote("0123456789"));
            Assert.AreEqual("\"`~!@#$%^&*()_+-=\"", ObjectPrinter.quote("`~!@#$%^&*()_+-="));
//            Assert.AreEqual("\"\\\\\"", ObjectPrinter.quote("\\"));
//            Assert.AreEqual("\"\\\"\"", ObjectPrinter.quote("\""));
            Assert.AreEqual("\"[]{}|;:',<.>/?\"", ObjectPrinter.quote("[]{}|;:',<.>/?"));
            Assert.AreEqual("\"\\r\"", ObjectPrinter.quote("\r"));
            Assert.AreEqual("\"\\n\"", ObjectPrinter.quote("\n"));
            Assert.AreEqual("\"\\t\"", ObjectPrinter.quote("\t"));
        }

        [Test]
        public void PrintPropertyPrintsTheProperty()
        {
            // given
            var prop = new FbxPropertyT<double>("something");
            var printer = new ObjectPrinter();
            var writer = new StringWriter();
            var expected =
@"        Name = something
        Type = Double
        Value = 0
        SrcObjectCount = 0
        DstObjectCount = 0
";

            // when
            printer.PrintProperty(prop, writer);

            // then
            Assert.AreEqual(expected, writer.ToString());
        }
    }
}

