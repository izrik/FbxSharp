using System;
using NUnit.Framework;
using FbxSharp;

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
    }
}

