using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace FbxSharp;

[NotSdk]
public class BinaryParser(Stream stream, string filename = null)
{
    private Stream stream = stream;
    private string filename = filename;

    public List<ParseObject> ReadFile(int maxObjectsToRead = 1000)
    {
        var pobjects = new List<ParseObject>();
        int i;
        for (i = 0; i < maxObjectsToRead; i++)
        {
            var po = ReadObject();
            if (po == null) break;
            pobjects.Add(po);
        }

        return pobjects;
    }

    protected double ReadDouble()
    {
        const int length = 8;
        Span<byte> buffer = stackalloc byte[length];
        var count = stream.Read(buffer);
        if (count != length)
            throw new InvalidOperationException("count != length");
        return BinaryPrimitives.ReadDoubleLittleEndian(buffer);
    }

    protected int ReadInt32()
    {
        // Little-endian
        var b0 = stream.ReadByte();
        var b1 = stream.ReadByte();
        var b2 = stream.ReadByte();
        var b3 = stream.ReadByte();
        return (b3 << 24) | (b2 << 16) | (b1 << 8) | b0;
    }

    protected long ReadInt64()
    {
        // Little-endian
        long b0 = stream.ReadByte();
        long b1 = stream.ReadByte();
        long b2 = stream.ReadByte();
        long b3 = stream.ReadByte();
        long b4 = stream.ReadByte();
        long b5 = stream.ReadByte();
        long b6 = stream.ReadByte();
        long b7 = stream.ReadByte();
        return (b7 << 56) |
               (b6 << 48) |
               (b5 << 40) |
               (b4 << 32) |
               (b3 << 24) |
               (b2 << 16) |
               (b1 << 8) |
               b0;
    }

    protected string ReadString256()
    {
        var length = stream.ReadByte();
        Span<byte> buffer = stackalloc byte[length];
        var count = stream.Read(buffer);
        if (count != length)
            throw new InvalidOperationException("count != length");
        return Encoding.ASCII.GetString(buffer);
    }

    protected string ReadStringN()
    {
        var length = ReadInt32();
        Span<byte> buffer = stackalloc byte[length];
        var count = stream.Read(buffer);
        if (count != length)
            throw new InvalidOperationException("count != length");
        var s = Encoding.ASCII.GetString(buffer);
        if (s.Contains("\x00\x01"))
            s = Regex.Replace(s, @"(.*)\000\001(.*)", "$2::$1");
        return s;
    }

    protected string ReadByteSequence()
    {
        var length = ReadInt32();
        Span<byte> buffer = stackalloc byte[length];
        var count = stream.Read(buffer);
        if (count != length)
            throw new InvalidOperationException("count != length");
        // TODO: base64
        const string s = "byte_sequence:";
        var rv = s;
        while (rv.Length < length)
            rv += s;
        rv = rv.Substring(0, length);
        return rv;
    }

    public ParseObject ReadObject()
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


    private ParseObject nullParseObject = new();

    public void PrintParseObject(ParseObject po, TextWriter writer,
        string indent = "")
    {
        writer.WriteLine($"{indent}{po.Location.Index:x4}:");
        var indent2 = indent + "    ";
        writer.WriteLine($"{indent2}next={po.Extra.nextItemOffset:x4}");
        writer.WriteLine($"{indent2}???={po.Extra.reserved0:x8}");
        writer.WriteLine($"{indent2}???={po.Extra.numValues:x8}");
        writer.WriteLine($"{indent2}???={po.Extra.reserved2:x8}");
        writer.WriteLine($"{indent2}???={po.Extra.numValuesBytes:x8}");
        writer.WriteLine($"{indent2}???={po.Extra.reserved4:x8}");
        writer.WriteLine($"{indent2}namelen={po.Extra.namelen:x2}");
        writer.WriteLine($"{indent2}name={po.Name}");

        if (po == nullParseObject)
            return;

        int i;
        for (i = 0; i < po.Extra.numValues; i++)
        {
            writer.WriteLine($"{indent2}type={po.Extra.valuesTypes[i]:x2}");
            if (po.Extra.valuesLengths[i].HasValue)
                writer.WriteLine($"{indent2}length={po.Extra.valuesLengths[i]:x8}");
            var value = po.Values[i];
            if (value is long || value is ulong)
                writer.WriteLine($"{indent2}value={value:x16} ({value})");
            else if (value is uint || value is int)
                writer.WriteLine($"{indent2}value={value:x8} ({value})");
            else if (value is short || value is ushort)
                writer.WriteLine($"{indent2}value={value:x4} ({value})");
            else if (value is byte || value is sbyte)
                writer.WriteLine($"{indent2}value={value:x2} ({value})");
            else
                writer.WriteLine($"{indent2}value={value}");
        }

        foreach (var child in po.Properties)
        {
            PrintParseObject(child, writer, indent2);
        }

        if (po.Properties.Count > 0 || po.HasEmptyBlock)
            PrintParseObject(nullParseObject, writer, indent2);
    }
}
