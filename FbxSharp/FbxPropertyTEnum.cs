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
        if ((typeof(U).IsAssignableFrom(typeof(int))))
        {
            Value = (int)(object)value;
            return true;
        }

        var tuple = new Tuple<Type, Type>(typeof(U), typeof(int));
        if (Converters.ContainsKey(tuple))
        {
            var converter = Converters[tuple];
            Value = (int)converter(value);
            return true;
        }

        throw new InvalidCastException(); // maybe find a better exception to throw
    }

    public override bool Set(object value)
    {
        return Set<object>(value);
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