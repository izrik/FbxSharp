using System;
using NUnit.Framework;
using System.Collections.Generic;
using FbxSharp;
using System.Linq;

namespace FbxSharpTests
{
    [TestFixture]
    public class IListHelperTest
    {

        [Test]
        public void TestBinarySearchLessThanZerothValue()
        {
            // given
            IList<float> values = new List<float> { 1, 3, 4, 7.5f, };
            const int expected = -1;

            // when
            int actual = values.BinarySearchEqualOrLessThan(0);

            // then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestBinarySearchGreaterThanLastValue()
        {
            // given
            IList<float> values = new List<float> { 1, 3, 4, 7.5f, };
            const int expected = 3;

            // when
            int actual = values.BinarySearchEqualOrLessThan(8);

            // then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(1f, 0)]
        [TestCase(3f, 1)]
        [TestCase(4f, 2)]
        [TestCase(7.5f, 3)]
        [TestCase(7f, 2)]
        [TestCase(7.49999f, 2)]
        [TestCase(3.5f, 1)]
        [TestCase(1.000001f, 0)]
        public void TestBinarySearch(float value, int expected)
        {
            // given
            IList<float> values = new List<float> { 1, 3, 4, 7.5f, };

            // when
            int actual = values.BinarySearchEqualOrLessThan(value);

            // then
            Assert.AreEqual(expected, actual);
        }
    }
}

