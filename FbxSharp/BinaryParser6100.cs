using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace FbxSharp;

[NotSdk]
public class BinaryParser6100(Stream stream, string filename = null)
    : BinaryParser(stream, filename)
{
    public override ParseObject ReadObject()
    {
        throw new NotImplementedException();
    }
}
