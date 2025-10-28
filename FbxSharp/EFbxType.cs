using System;

namespace FbxSharp;

public enum EFbxType
{
    eFbxUndefined,
    eFbxChar,
    eFbxUChar,
    eFbxShort,
    eFbxUShort,
    eFbxUInt,
    eFbxLongLong,
    eFbxULongLong,
    eFbxHalfFloat,
    eFbxBool,
    eFbxInt,
    eFbxFloat,
    eFbxDouble,
    eFbxDouble2,
    eFbxDouble3,
    eFbxDouble4,
    eFbxDouble4x4,
    eFbxEnum = 17,
    eFbxEnumM = -17,
    eFbxString = 18,
    eFbxTime,
    eFbxReference,
    eFbxBlob,
    eFbxDistance,
    eFbxDateTime,
    eFbxTypeCount = 24
}

public static class EFbxTypeHelper
{
    [NotSdk]
    public static Type ToDotnetType(this EFbxType fbxType)
    {
        switch (fbxType)
        {
            case EFbxType.eFbxUndefined:
                throw new NotImplementedException();
            case EFbxType.eFbxChar:
                return typeof(sbyte);
            case EFbxType.eFbxUChar:
                return typeof(char);
            case EFbxType.eFbxShort:
                return typeof(short);
            case EFbxType.eFbxUShort:
                return typeof(ushort);
            case EFbxType.eFbxUInt:
                return typeof(uint);
            case EFbxType.eFbxLongLong:
                return typeof(long);
            case EFbxType.eFbxULongLong:
                return typeof(ulong);
            case EFbxType.eFbxHalfFloat:
                return typeof(Half);
            case EFbxType.eFbxBool:
                return typeof(bool);
            case EFbxType.eFbxInt:
                return typeof(int);
            case EFbxType.eFbxFloat:
                return typeof(float);
            case EFbxType.eFbxDouble:
                return typeof(double);
            case EFbxType.eFbxDouble2:
            case EFbxType.eFbxDouble3:
            case EFbxType.eFbxDouble4:
            case EFbxType.eFbxDouble4x4:
            case EFbxType.eFbxEnum:
            case EFbxType.eFbxEnumM:
                throw new NotImplementedException();
            case EFbxType.eFbxString:
                return typeof(string);
            case EFbxType.eFbxTime:
                return typeof(FbxTime);
            case EFbxType.eFbxReference:
            case EFbxType.eFbxBlob:
            case EFbxType.eFbxDistance:
                throw new NotImplementedException($"Not implemented for type {fbxType}");
            case EFbxType.eFbxDateTime:
                return typeof(FbxDateTime);
            case EFbxType.eFbxTypeCount:
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    [NotSdk]
    public static EFbxType ToFbxType(this Type type)
    {
        if (type == typeof(sbyte))
            return EFbxType.eFbxChar;
        if (type == typeof(sbyte))
            return EFbxType.eFbxChar;
        if (type == typeof(char))
            return EFbxType.eFbxUChar;
        if (type == typeof(short))
            return EFbxType.eFbxShort;
        if (type == typeof(ushort))
            return EFbxType.eFbxUShort;
        if (type == typeof(uint))
            return EFbxType.eFbxUInt;
        if (type == typeof(long))
            return EFbxType.eFbxLongLong;
        if (type == typeof(ulong))
            return EFbxType.eFbxULongLong;
        if (type == typeof(Half))
            return EFbxType.eFbxHalfFloat;
        if (type == typeof(bool))
            return EFbxType.eFbxBool;
        if (type == typeof(int))
            return EFbxType.eFbxInt;
        if (type == typeof(float))
            return EFbxType.eFbxFloat;
        if (type == typeof(double))
            return EFbxType.eFbxDouble;
        if (type == typeof(string))
            return EFbxType.eFbxString;
        // TODO: EFbxType.eFbxDouble2
        // TODO: EFbxType.eFbxDouble3
        if (type == typeof(FbxVector3))
            return EFbxType.eFbxDouble3;
        if (type == typeof(FbxColor))
            return EFbxType.eFbxDouble3;
        if (type == typeof(FbxVector4))
            return EFbxType.eFbxDouble4;
        // TODO: EFbxType.eFbxDouble4x4

        // TODO: EFbxType.eFbxEnumM
        if (type.IsEnum)
            return EFbxType.eFbxEnum;

        if (type == typeof(FbxTime))
            return EFbxType.eFbxTime;

        if (type.IsAssignableTo(typeof(FbxObject)))
            // TODO: FbxProperty?
            return EFbxType.eFbxReference;

        // TODO: EFbxType.eFbxBlob
        // TODO: EFbxType.eFbxDistance

        if (type == typeof(FbxDateTime))
            return EFbxType.eFbxDateTime;

        if (type == typeof(object) ||
            type == typeof(FbxProperty.NotValidT))
            return EFbxType.eFbxUndefined;
        throw new ArgumentOutOfRangeException(nameof(type), type, null);
    }

    public static EFbxType FbxTypeOf(sbyte value) => EFbxType.eFbxChar;
    public static EFbxType FbxTypeOf(char value) => EFbxType.eFbxUChar;
    public static EFbxType FbxTypeOf(short value) => EFbxType.eFbxShort;
    public static EFbxType FbxTypeOf(ushort value) => EFbxType.eFbxUShort;
    public static EFbxType FbxTypeOf(uint value) => EFbxType.eFbxUInt;
    public static EFbxType FbxTypeOf(long value) => EFbxType.eFbxLongLong;
    public static EFbxType FbxTypeOf(ulong value) => EFbxType.eFbxULongLong;
    public static EFbxType FbxTypeOf(Half value) => EFbxType.eFbxHalfFloat;
    public static EFbxType FbxTypeOf(bool value) => EFbxType.eFbxBool;
    public static EFbxType FbxTypeOf(int value) => EFbxType.eFbxInt;
    public static EFbxType FbxTypeOf(float value) => EFbxType.eFbxFloat;
    public static EFbxType FbxTypeOf(double value) => EFbxType.eFbxDouble;

    public static EFbxType FbxTypeOf(string value) => EFbxType.eFbxString;

    // TODO: EFbxType.eFbxDouble2
    // TODO: EFbxType.eFbxDouble3
    public static EFbxType FbxTypeOf(FbxVector3 value) => EFbxType.eFbxDouble3;
    // TODO: EFbxType.eFbxDouble4
    // TODO: EFbxType.eFbxDouble4x4

    // TODO: EFbxType.eFbxEnumM

    public static EFbxType FbxTypeOf(FbxTime value) => EFbxType.eFbxTime;

    public static EFbxType FbxTypeOf(FbxObject value) => EFbxType.eFbxReference;
    // TODO: FbxProperty?

    // TODO: EFbxType.eFbxBlob
    // TODO: EFbxType.eFbxDistance
    // TODO: EFbxType.eFbxDateTime
}