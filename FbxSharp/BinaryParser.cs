using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace FbxSharp;

[NotSdk]
public abstract class BinaryParser(Stream stream, string filename = null)
{
    public static BinaryParser FromFileVersion(int fileVersion, Stream stream, string filename)
    {
        switch (fileVersion)
        {
            case 7700:
            case 7500:
                return new BinaryParser7700(stream, filename);
            case 7400:
            case 7300:
                return new BinaryParser7400(stream, filename);
            default:
                throw new ArgumentException(
                    $"Unrecognized file version: {fileVersion}",
                    nameof(fileVersion));
        }
    }

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

    protected float ReadFloat()
    {
        const int length = 4;
        Span<byte> buffer = stackalloc byte[length];
        var count = stream.Read(buffer);
        if (count != length)
            throw new InvalidOperationException("count != length");
        return BinaryPrimitives.ReadSingleLittleEndian(buffer);
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

    protected object ReadFloatingPointArray()
    {
        var _arrayPosition = stream.Position;
        var numElements = ReadInt32();
        var elementType = ReadInt32();
        switch (elementType)
        {
            case 0: return ReadDoubleArrayElements(numElements);
            case 1: return ReadFloatArrayElements(numElements);
            default:
                throw new InvalidOperationException(
                    $"Unrecognized element type:" +
                    $" {elementType} {elementType:x8}");
        }
    }

    protected double[] ReadDoubleArrayElements(int numElements)
    {
        var _elementsPosition = stream.Position;
        var numBytes = ReadInt32();
        if (numBytes != numElements * 8)
            throw new InvalidOperationException(
                "numBytes != numElements * 8");
        var rv = new double[numElements];
        for (var i = 0; i < numElements; i++)
            rv[i] = ReadDouble();
        return rv;
    }

    protected float[] ReadFloatArrayElements(int numElements)
    {
        var _elementsPosition = stream.Position;
        var numBytes = ReadInt32();
        if (numBytes != numElements * 4)
            throw new InvalidOperationException(
                $"numBytes != numElements * 4 " +
                $"({numBytes} != {numElements * 4})");
        var rv = new float[numElements];
        for (var i = 0; i < numElements; i++)
            rv[i] = ReadFloat();
        return rv;
    }

    protected int[] ReadInt32Array()
    {
        var numElements = ReadInt32();
        var reserved = ReadInt32();
        if (reserved != 0)
            throw new InvalidOperationException("reserved != 0");
        // alternately, the number of elements might be an int64, and the
        // reserved field is not actually a field of its own.

        var numBytes = ReadInt32();
        if (numBytes != numElements * 4)
            throw new InvalidOperationException(
                "numBytes != numElements * 4");
        var rv = new int[numElements];
        for (var i = 0; i < numElements; i++)
            rv[i] = ReadInt32();
        return rv;
    }

    public abstract ParseObject ReadObject();


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
