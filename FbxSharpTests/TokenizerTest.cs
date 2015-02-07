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

        [Test]
        public void TestComment()
        {
            // given
            const string input = "; comment\n";
            var tokenizer = new Tokenizer();

            // when
            var tokens = tokenizer.Tokenize(input);

            // then
            Assert.AreEqual(1, tokens.Count);
			Assert.AreEqual(TokenType.Comment, tokens[0].Type);
			Assert.AreEqual(input, tokens[0].Value);
        }

		[Test]
		public void TestStar()
		{
			// given
			const string input = "*";
			var tokenizer = new Tokenizer();

			// when
			var tokens = tokenizer.Tokenize(input);

			// then
			Assert.AreEqual(1, tokens.Count);
			Assert.AreEqual(TokenType.Star, tokens[0].Type);
			Assert.AreEqual(input, tokens[0].Value);
		}

		[Test]
		public void TestOpenBrace()
		{
			// given
			const string input = "{";
			var tokenizer = new Tokenizer();

			// when
			var tokens = tokenizer.Tokenize(input);

			// then
			Assert.AreEqual(1, tokens.Count);
			Assert.AreEqual(TokenType.OpenBrace, tokens[0].Type);
			Assert.AreEqual(input, tokens[0].Value);
		}

		[Test]
		public void TestCloseBrace()
		{
			// given
			const string input = "}";
			var tokenizer = new Tokenizer();

			// when
			var tokens = tokenizer.Tokenize(input);

			// then
			Assert.AreEqual(1, tokens.Count);
			Assert.AreEqual(TokenType.CloseBrace, tokens[0].Type);
			Assert.AreEqual(input, tokens[0].Value);
		}

		[Test]
		public void TestColon()
		{
			// given
			const string input = ":";
			var tokenizer = new Tokenizer();

			// when
			var tokens = tokenizer.Tokenize(input);

			// then
			Assert.AreEqual(1, tokens.Count);
			Assert.AreEqual(TokenType.Colon, tokens[0].Type);
			Assert.AreEqual(input, tokens[0].Value);
		}

		[Test]
		public void TestComma()
		{
			// given
			const string input = ",";
			var tokenizer = new Tokenizer();

			// when
			var tokens = tokenizer.Tokenize(input);

			// then
			Assert.AreEqual(1, tokens.Count);
			Assert.AreEqual(TokenType.Comma, tokens[0].Type);
			Assert.AreEqual(input, tokens[0].Value);
		}

		[Test]
		public void TestString()
		{
			// given
			const string input = "\"this is a ; string \n\"";
			var tokenizer = new Tokenizer();

			// when
			var tokens = tokenizer.Tokenize(input);

			// then
			Assert.AreEqual(1, tokens.Count);
			Assert.AreEqual(TokenType.String, tokens[0].Type);
			Assert.AreEqual(input, tokens[0].Value);
		}

		[Test]
		public void TestName()
		{
			// given
			const string input = "asdf";
			var tokenizer = new Tokenizer();

			// when
			var tokens = tokenizer.Tokenize(input);

			// then
			Assert.AreEqual(1, tokens.Count);
			Assert.AreEqual(TokenType.Name, tokens[0].Type);
			Assert.AreEqual(input, tokens[0].Value);
		}

		[Test]
		public void TestNumber()
		{
			// given
			const string input = "123.45e67";
			var tokenizer = new Tokenizer();

			// when
			var tokens = tokenizer.Tokenize(input);

			// then
			Assert.AreEqual(1, tokens.Count);
			Assert.AreEqual(TokenType.Number, tokens[0].Type);
			Assert.AreEqual(input, tokens[0].Value);
		}
    }
}
