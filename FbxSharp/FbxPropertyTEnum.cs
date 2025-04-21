using System;
using System.Collections.Generic;

namespace FbxSharp;

/// <summary>
/// A kind of specialization of FbxPropertyT for eFbxEnum 
/// </summary>
[NotSdk]
public class FbxPropertyTEnum : FbxProperty
{
    public FbxPropertyTEnum(string name="")
        : base(name, EFbxType.eFbxEnum)
    {
    }
    public FbxPropertyTEnum(string name, int initialValue)
        : base(name, EFbxType.eFbxEnum)
    {
        Value = initialValue;
    }

    public override Type GetDotnetType() => typeof(int);

    public int Value { get; set; }

    //FbxPropertyT &      Set (const T &pValue)
    public void Set(int value)
    {
        Value = value;
    }

    public int Get()
    {
        return Value;
    }

    public override U Get<U>()
    {
        if (!(Value is U))
        {
            var tuple = new Tuple<Type, Type>(typeof(int), typeof(U));
            if (Converters.ContainsKey(tuple))
            {
                var converter = Converters[tuple];
                return (U)converter(Value);
            }

            throw new InvalidCastException(); // maybe find a better exception to throw
        }

        return (U)(object)Value;
    }

    public override object GetValue()
    {
        return Value;
    }

    public override bool Set<U>(U value)
    {
        // if U can be assigned to a prop/field of type T,
        //  then do so
        // else if there is a converter available
        //  then use that
        // else
        //  throw
        var actualType = value.GetType();
        if ((typeof(int).IsAssignableFrom(actualType)))
        {
            Value = (int)(object)value;
            return true;
        }

        var tuple = new Tuple<Type, Type>(actualType, typeof(int));
        if (Converters.ContainsKey(tuple))
        {
            var converter = Converters[tuple];
            Value = (int)converter(value);
            return true;
        }

        throw new InvalidCastException(); // maybe find a better exception to throw
    }

    public /*override*/ bool Set(object value)
    {
        var actualType = value.GetType();
        if (typeof(int).IsAssignableFrom(actualType))
        {
            Value = (int)value;
            return true;
        }

        if (typeof(long).IsAssignableFrom(actualType))
        {
            Value = Convert.ToInt32((long)value);
            return true;
        }

        if (typeof(int).IsEnum)
        {
            object v = null;
            if (actualType == typeof(long))
                v = (int)Enum.ToObject(typeof(int), (long)(object)value);
            else if (actualType == typeof(ulong))
                v = (int)Enum.ToObject(typeof(int), (ulong)(object)value);
            else if (actualType == typeof(int))
                v = (int)Enum.ToObject(typeof(int), (int)(object)value);
            else if (actualType == typeof(uint))
                v = (int)Enum.ToObject(typeof(int), (uint)(object)value);
            else if (actualType == typeof(short))
                v = (int)Enum.ToObject(typeof(int), (short)(object)value);
            else if (actualType == typeof(ushort))
                v = (int)Enum.ToObject(typeof(int), (ushort)(object)value);
            else if (actualType == typeof(byte))
                v = (int)Enum.ToObject(typeof(int), (byte)(object)value);
            else if (actualType == typeof(sbyte))
                v = (int)Enum.ToObject(typeof(int), (sbyte)(object)value);
            if (v != null)
            {
                Value = (int)v;
                return true;
            }
        }

        var tuple = new Tuple<Type, Type>(actualType, typeof(int));
        if (Converters.TryGetValue(tuple, out Func<object, object> converter))
        {
            Value = (int)converter(value);
            return true;
        }

        throw new NotImplementedException();
        // return Set<object>(value);
    }

    #region Enum and property list

    private readonly List<string> enumValues = [];

    public override int AddEnumValue(string pStringValue)
    {
        enumValues.Add(pStringValue);
        return enumValues.Count - 1;
    }

    public override void InsertEnumValue(int pIndex, string pStringValue)
    {
        enumValues.Insert(pIndex, pStringValue);
    }

    public override int GetEnumCount()
    {
        return enumValues.Count;
    }

    public override void SetEnumValue(int pIndex, string pStringValue)
    {
        enumValues[pIndex] = pStringValue;
    }

    public override void RemoveEnumValue(int pIndex)
    {
        enumValues.RemoveAt(pIndex);
    }

    public override string GetEnumValue(int pIndex)
    {
        return enumValues[pIndex];
    }

    #endregion
}