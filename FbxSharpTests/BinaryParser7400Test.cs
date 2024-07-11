using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests;

[TestFixture]
public class BinaryParser7400Test : TestBase
{
    [Test]
    public void TestReadObject()
    {
        // given
        var filename = GetSample("empty_7b_FBX201400.fbx");
        using var fs = File.Open(filename, FileMode.Open);
        fs.Seek(27, SeekOrigin.Begin);
        var parser = new BinaryParser7400(fs, filename);
        var pos = new List<ParseObject>();

        // when
        var po = parser.ReadObject();
        // then
        Assert.That(po, Is.Not.Null);
        Assert.That(po.Name, Is.EqualTo("FBXHeaderExtension"));
        Assert.That(po.Values, Is.Empty);
        Assert.That(po.Properties.Count, Is.EqualTo(6));
        Assert.That(po.Properties[0].Name, Is.EqualTo("FBXHeaderVersion"));
        Assert.That(po.Properties[0].Values[0].Equals(1003));
        Assert.That(po.Properties[1].Name, Is.EqualTo("FBXVersion"));
        Assert.That(po.Properties[1].Values[0].Equals(7400));
        Assert.That(po.Properties[2].Name, Is.EqualTo("EncryptionType"));
        Assert.That(po.Properties[2].Values[0].Equals(0));
        Assert.That(po.Properties[3].Name, Is.EqualTo("CreationTimeStamp"));
        Assert.That(po.Properties[3].Values, Is.Empty);
        Assert.That(po.Properties[4].Name, Is.EqualTo("Creator"));
        Assert.That(po.Properties[4].Values[0], Is.EqualTo("FBX SDK/FBX Plugins version 2020.3.4"));
        Assert.That(po.Properties[5].Name, Is.EqualTo("SceneInfo"));
        Assert.That(po.Properties[5].Values[0], Is.EqualTo("SceneInfo::GlobalInfo"));
        Assert.That(po.Properties[5].Values[1], Is.EqualTo("UserData"));
    }
}
