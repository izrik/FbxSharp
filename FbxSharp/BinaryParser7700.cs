using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace FbxSharp;

[NotSdk]
public class BinaryParser7700(Stream stream, string filename = null)
    : BinaryParser(stream, filename)
{
    public override ParseObject ReadObject()
    {
        var location = new InputLocation(
            line: 0,
            column: 0,
            index: (int)stream.Position,
            filename);

        var nextItemOffset = ReadInt32();

        var reserved0 = (uint)ReadInt32();
        var numValues = (uint)ReadInt32();
        var reserved2 = (uint)ReadInt32();
        var numValueBytes = (uint)ReadInt32();
        var reserved4 = (uint)ReadInt32();

        var name = ReadString256();
        if (nextItemOffset == 0)
            return null;
        var po = new ParseObject()
        {
            Name = name,
            Location = location,

            Extra = new ParseObject.BinaryParseInfo
            {
                nextItemOffset = nextItemOffset,
                reserved0 = reserved0,
                numValues = numValues,
                reserved2 = reserved2,
                numValuesBytes = numValueBytes,
                reserved4 = reserved4,
                namelen = (byte)name.Length, // eh...
            }
        };
        int i;
        for (i = 0; i < numValues; i++)
        {
            var type = (byte)stream.ReadByte();
            object value = type switch
            {
                0x44 =>  new Number(ReadDouble()),
                0x49 => new Number(ReadInt32()),
                0x4c => new Number(ReadInt64()),
                0x52 => ReadByteSequence(),
                0x53 => ReadStringN(),
                _ => throw new InvalidOperationException(
                    $"Unknown value type 0x{type:x8}")
            };

            po.Values.Add(value);
            po.Extra.valuesTypes.Add(type);
            uint? valueLength = null;
            if (type is 0x53 or 0x52)
                valueLength = (uint?)((string)value).Length;
            po.Extra.valuesLengths.Add(valueLength);
        }

        po.HasEmptyBlock = false;
        if (stream.Position < nextItemOffset)
        {
            po.HasEmptyBlock = true;
            // read sub-objects
            while (true)
            {
                var child = ReadObject();
                if (child == null)
                    break;
                po.HasEmptyBlock = false;
                po.Properties.Add(child);
            }
        }

        return po;
    }
}
