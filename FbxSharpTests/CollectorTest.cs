using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class CollectorTest
    {
        Collector collector;

        [SetUp]
        public void Setup()
        {
            collector = new Collector();
        }

        [Test]
        public void SingleObjectGetsCollected()
        {
            // given
            var obj = new FbxObject();

            // when
            var result = collector.Collect(obj);

            // then
            Assert.NotNull(result);
            CollectionAssert.Contains(result, obj);
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void SrcObjectBothGetCollected()
        {
            // given
            var obj = new FbxObject();
            var other = new FbxObject();
            obj.ConnectSrcObject(other);

            // when
            var result = collector.Collect(obj);

            // then
            Assert.NotNull(result);
            CollectionAssert.Contains(result, obj);
            CollectionAssert.Contains(result, other);
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void DstObjectBothGetCollected()
        {
            // given
            var obj = new FbxObject();
            var other = new FbxObject();
            obj.ConnectDstObject(other);

            // when
            var result = collector.Collect(obj);

            // then
            Assert.NotNull(result);
            CollectionAssert.Contains(result, obj);
            CollectionAssert.Contains(result, other);
            Assert.AreEqual(2, result.Count);
        }
    }
}

