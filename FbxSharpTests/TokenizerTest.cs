using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class TokenizerTest
    {
        [Test]
        public void TestWhitespace()
        {
            // given
            const string input = "    ";
            var tokenizer = new Tokenizer();

            // when
            var tokens = tokenizer.Tokenize(input);

            // then
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.Whitespace, tokens[0].Type);
            Assert.AreEqual("    ", tokens[0].Value);
        }
    }
}
