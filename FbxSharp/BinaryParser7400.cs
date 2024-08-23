using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace FbxSharp;

[NotSdk]
public class BinaryParser7400(Stream stream, string filename = null)
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

        var numValues = (uint)ReadInt32();
        var numValueBytes = (uint)ReadInt32();

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
                numValues = numValues,
                numValuesBytes = numValueBytes,
                namelen = (byte)name.Length,
            }
        };
        int i;
        for (i = 0; i < numValues; i++)
        {
            var _typePosition = stream.Position;
            var type = (byte)stream.ReadByte();
            object value = type switch
            {
                0x44 =>  new Number(ReadDouble()),
                0x49 => new Number(ReadInt32()),
                0x4c => new Number(ReadInt64()),
                0x52 => ReadByteSequence(),
                0x53 => ReadStringN(),
                0x64 => ReadFloatingPointArray(),
                069 => ReadInt32Array(),
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
            var _firstSubObjectPosition = stream.Position;
            while (true)
            {
                var _subObjectPosition = stream.Position;
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
