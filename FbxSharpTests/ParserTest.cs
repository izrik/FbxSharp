using System;
using NUnit.Framework;
using FbxSharp;
using System.Collections.Generic;
using System.IO;

namespace FbxSharpTests
{
    [TestFixture]
    public class ParserTest
    {
        [Test]
        public void TestPeek()
        {
            // given
            const string input = "*";
            var parser = new Parser(new Tokenizer(input));

            // when
            var token = parser.PeekNextToken();

            // then
            Assert.That(token.HasValue);
            Assert.AreEqual(new Token(TokenType.Star, "*"), token.Value);
        }

        [Test]
        public void TestGetNextToken()
        {
            // given
            const string input = "name1 name2";
            var parser = new Parser(new Tokenizer(input));

            // when
            var token = parser.PeekNextToken();

            // then
            Assert.That(token.HasValue);
            Assert.AreEqual(new Token(TokenType.Name, "name1"), token.Value);

            // when
            token = parser.GetNextToken();

            // then
            Assert.That(token.HasValue);
            Assert.AreEqual(new Token(TokenType.Name, "name1"), token.Value);

            // when
            token = parser.PeekNextToken();

            // then
            Assert.That(token.HasValue);
            Assert.AreEqual(new Token(TokenType.Name, "name2"), token.Value);

            // when
            token = parser.GetNextToken();

            // then
            Assert.That(token.HasValue);
            Assert.AreEqual(new Token(TokenType.Name, "name2"), token.Value);

            // when
            token = parser.PeekNextToken();

            // then
            Assert.That(!token.HasValue);
        }

        [Test]
        public void TestReadObjectSimple()
        {
            // given
            const string input = "Object: \"value1\", \"value2\",3.0 \n";
            var parser = new Parser(new Tokenizer(input));

            // when
            var obj = parser.ReadObject();

            // then
            Assert.IsNotNull(obj);
            Assert.AreEqual("Object", obj.Name);
            Assert.AreEqual(3, obj.Values.Count);
            Assert.IsInstanceOf<string>(obj.Values[0]);
            Assert.IsInstanceOf<string>(obj.Values[1]);
            Assert.IsInstanceOf<Number>(obj.Values[2]);
            Assert.AreEqual("value1", (string)obj.Values[0]);
            Assert.AreEqual("value2", (string)obj.Values[1]);
            Assert.AreEqual(3.0, ((Number)obj.Values[2]).AsDouble.Value);
            Assert.IsNull(obj.Properties);
        }

        [Test]
        public void TestReadBlockSimple()
        {
            // given
            const string input =
                "{\n" +
                "    x: 1,\"two\"\n" +
                "    y: \"three\",4\n" +
                "}";
            var parser = new Parser(new Tokenizer(input));

            // when
            var objs = parser.ReadBlock();

            // then
            Assert.IsNotNull(objs);
            Assert.AreEqual(2, objs.Count);
            Assert.IsNotNull(objs[0]);
            Assert.AreEqual("x", objs[0].Name);
            Assert.AreEqual(2, objs[0].Values.Count);
            Assert.IsInstanceOf<Number>(objs[0].Values[0]);
            Assert.AreEqual(1, ((Number)objs[0].Values[0]).AsLong.Value);
            Assert.IsInstanceOf<string>(objs[0].Values[1]);
            Assert.AreEqual("two", (string)objs[0].Values[1]);
            Assert.IsNull(objs[0].Properties);
            Assert.That(!objs[0].HasEmptyBlock);
            Assert.IsNotNull(objs[1]);
            Assert.AreEqual("y", objs[1].Name);
            Assert.AreEqual(2, objs[1].Values.Count);
            Assert.IsInstanceOf<string>(objs[1].Values[0]);
            Assert.AreEqual("three", (string)objs[1].Values[0]);
            Assert.IsInstanceOf<Number>(objs[1].Values[1]);
            Assert.AreEqual(4, ((Number)objs[1].Values[1]).AsLong.Value);
            Assert.IsNull(objs[1].Properties);
            Assert.That(!objs[1].HasEmptyBlock);
        }

        [Test]
        public void TestReadObjectWithBlock()
        {
            // given
            const string input =
                "Object: \"value\" {\n" +
                "    x: 1,\"two\"\n" +
                "}";
            var parser = new Parser(new Tokenizer(input));

            // when
            var obj = parser.ReadObject();

            // then
            Assert.IsNotNull(obj);
            Assert.AreEqual("Object", obj.Name);
            Assert.AreEqual(1, obj.Values.Count);
            Assert.IsInstanceOf<string>(obj.Values[0]);
            Assert.AreEqual("value", (string)obj.Values[0]);
            Assert.IsNotNull(obj.Properties);
            Assert.That(!obj.HasEmptyBlock);
            Assert.AreEqual(1, obj.Properties.Count);

            var sub = obj.Properties[0];
            Assert.IsNotNull(sub);
            Assert.AreEqual("x", sub.Name);
            Assert.AreEqual(2, sub.Values.Count);
            Assert.IsInstanceOf<Number>(sub.Values[0]);
            Assert.AreEqual(1, ((Number)sub.Values[0]).AsLong.Value);
            Assert.IsInstanceOf<string>(sub.Values[1]);
            Assert.AreEqual("two", (string)sub.Values[1]);
            Assert.IsNull(sub.Properties);
            Assert.That(!sub.HasEmptyBlock);
        }

        [Test]
        public void TestReadObjectWithEmptyBlock()
        {
            // given
            const string input =
                "Object: {\n" +
                "}";
            var parser = new Parser(new Tokenizer(input));

            // when
            var obj = parser.ReadObject();

            // then
            Assert.IsNotNull(obj);
            Assert.AreEqual("Object", obj.Name);
            Assert.AreEqual(0, obj.Values.Count);
            Assert.IsNotNull(obj.Properties);
            Assert.That(obj.HasEmptyBlock);
            Assert.AreEqual(0, obj.Properties.Count);
        }

        [Test]
        public void TestReadArray()
        {
            // given
            const string input =
                "*4 {\n" +
                "    a: 1,2,3,4\n" +
                "}";
            var parser = new Parser(new Tokenizer(input));

            // when
            var objects = parser.ReadArray();

            // then
            Assert.AreEqual(1, objects.Count);
            Assert.AreEqual("a", objects[0].Name);
            Assert.AreEqual(4, objects[0].Values.Count);
            CollectionAssert.AllItemsAreInstancesOfType(objects[0].Values, typeof(Number));
            Assert.AreEqual(1, ((Number)objects[0].Values[0]).AsLong.Value);
            Assert.AreEqual(2, ((Number)objects[0].Values[1]).AsLong.Value);
            Assert.AreEqual(3, ((Number)objects[0].Values[2]).AsLong.Value);
            Assert.AreEqual(4, ((Number)objects[0].Values[3]).AsLong.Value);
            Assert.IsNull(objects[0].Properties);
        }

        [Test]
        public void TestReadObjectComplex()
        {
            // given
            const string input =
                "ObjectType: \"Geometry\" {\n" +
                "    Count: 1\n" +
                "    PropertyTemplate: \"KFbxMesh\" {\n" +
                "        Properties70:  {\n" +
                "            P: \"Color\", \"ColorRGB\", \"Color\", \"\",0.8,0.8,0.8\n" +
                "            P: \"BBoxMin\", \"Vector3D\", \"Vector\", \"\",0,0,0\n" +
                "            P: \"BBoxMax\", \"Vector3D\", \"Vector\", \"\",0,0,0\n" +
                "        }\n" +
                "    }\n" +
                "}";
            var parser = new Parser(new Tokenizer(input));

            // when
            var obj = parser.ReadObject();

            // then
            Assert.IsNotNull(obj);
            Assert.AreEqual("ObjectType", obj.Name);
            Assert.AreEqual(1, obj.Values.Count);
            Assert.IsInstanceOf<string>(obj.Values[0]);
            Assert.AreEqual("Geometry", (string)obj.Values[0]);
            Assert.IsNotNull(obj.Properties);
            Assert.That(!obj.HasEmptyBlock);
            Assert.AreEqual(2, obj.Properties.Count);

            var sub = obj.Properties[0];
            Assert.IsNotNull(sub);
            Assert.AreEqual("Count", sub.Name);
            Assert.AreEqual(1, sub.Values.Count);
            Assert.IsInstanceOf<Number>(sub.Values[0]);
            Assert.AreEqual(1, ((Number)sub.Values[0]).AsLong.Value);
            Assert.IsNull(sub.Properties);
            Assert.That(!sub.HasEmptyBlock);

            sub = obj.Properties[1];
            Assert.IsNotNull(sub);
            Assert.AreEqual("PropertyTemplate", sub.Name);
            Assert.AreEqual(1, sub.Values.Count);
            Assert.IsInstanceOf<string>(sub.Values[0]);
            Assert.AreEqual("KFbxMesh", (string)sub.Values[0]);
            Assert.IsNotNull(sub.Properties);
            Assert.That(!sub.HasEmptyBlock);
            Assert.AreEqual(1, sub.Properties.Count);

            sub = sub.Properties[0];
            Assert.IsNotNull(sub);
            Assert.IsNotNull(sub.Values);
            Assert.AreEqual(0, sub.Values.Count);
            Assert.IsNotNull(sub.Properties);
            Assert.That(!sub.HasEmptyBlock);
            Assert.AreEqual(3, sub.Properties.Count);

            var subsub = sub.Properties[0];
            Assert.IsNotNull(subsub);
            Assert.AreEqual("P", subsub.Name);
            Assert.IsNotNull(subsub.Values);
            Assert.AreEqual(7, subsub.Values.Count);
            Assert.AreEqual("Color", (string)subsub.Values[0]);
            Assert.AreEqual("ColorRGB", (string)subsub.Values[1]);
            Assert.AreEqual("Color", (string)subsub.Values[2]);
            Assert.AreEqual("", (string)subsub.Values[3]);
            Assert.AreEqual(0.8, ((Number)subsub.Values[4]).AsDouble.Value);
            Assert.AreEqual(0.8, ((Number)subsub.Values[5]).AsDouble.Value);
            Assert.AreEqual(0.8, ((Number)subsub.Values[6]).AsDouble.Value);
            Assert.IsNull(subsub.Properties);
            Assert.That(!subsub.HasEmptyBlock);

            subsub = sub.Properties[1];
            Assert.IsNotNull(subsub);
            Assert.AreEqual("P", subsub.Name);
            Assert.IsNotNull(subsub.Values);
            Assert.AreEqual(7, subsub.Values.Count);
            Assert.AreEqual("BBoxMin", (string)subsub.Values[0]);
            Assert.AreEqual("Vector3D", (string)subsub.Values[1]);
            Assert.AreEqual("Vector", (string)subsub.Values[2]);
            Assert.AreEqual("", (string)subsub.Values[3]);
            Assert.AreEqual(0.0, ((Number)subsub.Values[4]).AsDouble.Value);
            Assert.AreEqual(0, ((Number)subsub.Values[4]).AsLong.Value);
            Assert.AreEqual(0.0, ((Number)subsub.Values[5]).AsDouble.Value);
            Assert.AreEqual(0, ((Number)subsub.Values[5]).AsLong.Value);
            Assert.AreEqual(0.0, ((Number)subsub.Values[6]).AsDouble.Value);
            Assert.AreEqual(0, ((Number)subsub.Values[6]).AsLong.Value);
            Assert.IsNull(subsub.Properties);
            Assert.That(!subsub.HasEmptyBlock);

            subsub = sub.Properties[2];
            Assert.IsNotNull(subsub);
            Assert.AreEqual("P", subsub.Name);
            Assert.IsNotNull(subsub.Values);
            Assert.AreEqual(7, subsub.Values.Count);
            Assert.AreEqual("BBoxMax", (string)subsub.Values[0]);
            Assert.AreEqual("Vector3D", (string)subsub.Values[1]);
            Assert.AreEqual("Vector", (string)subsub.Values[2]);
            Assert.AreEqual("", (string)subsub.Values[3]);
            Assert.AreEqual(0.0, ((Number)subsub.Values[4]).AsDouble.Value);
            Assert.AreEqual(0, ((Number)subsub.Values[4]).AsLong.Value);
            Assert.AreEqual(0.0, ((Number)subsub.Values[5]).AsDouble.Value);
            Assert.AreEqual(0, ((Number)subsub.Values[5]).AsLong.Value);
            Assert.AreEqual(0.0, ((Number)subsub.Values[6]).AsDouble.Value);
            Assert.AreEqual(0, ((Number)subsub.Values[6]).AsLong.Value);
            Assert.IsNull(subsub.Properties);
            Assert.That(!subsub.HasEmptyBlock);
        }
    }
}

