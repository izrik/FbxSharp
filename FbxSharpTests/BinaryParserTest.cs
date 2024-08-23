using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests;

[TestFixture]
public class BinaryParserTest : TestBase
{
    [Test]
    public void FromFileVersion_7700_CreatesParser()
    {
        // when
        var bp = BinaryParser.FromFileVersion(7700, null, "filename");

        // then
        Assert.That(bp, Is.Not.Null);
        Assert.That(bp, Is.InstanceOf<BinaryParser7700>());
    }

    [Test]
    public void FromFileVersion_7500_Creates7700Parser()
    {
        // when
        var bp = BinaryParser.FromFileVersion(7500, null, "filename");

        // then
        Assert.That(bp, Is.Not.Null);
        Assert.That(bp, Is.InstanceOf<BinaryParser7700>());
    }

    [Test]
    public void FromFileVersion_7400_CreatesParser()
    {
        // when
        var bp = BinaryParser.FromFileVersion(7400, null, "filename");

        // then
        Assert.That(bp, Is.Not.Null);
        Assert.That(bp, Is.InstanceOf<BinaryParser7400>());
    }

    [Test]
    public void FromFileVersion_7300_Creates7400Parser()
    {
        // when
        var bp = BinaryParser.FromFileVersion(7300, null, "filename");

        // then
        Assert.That(bp, Is.Not.Null);
        Assert.That(bp, Is.InstanceOf<BinaryParser7400>());
    }

    [Test]
    [TestCase(7701)]
    [TestCase(7699)]
    [TestCase(7600)]
    [TestCase(7200)]
    [TestCase(7100)]
    [TestCase(7000)]
    [TestCase(6100)]
    [TestCase(6000)]
    public void FromFileVersion_UnsupportedVersion_Throws(int version)
    {
        // expect
        var ex = Assert.Throws<ArgumentException>(
            () => BinaryParser.FromFileVersion(
                version, null, "filename"));

        // and
        Assert.That(ex.Message,
            Is.EqualTo(
                $"Unrecognized file version: {version} " +
                $"(Parameter 'fileVersion')"));
    }
}
