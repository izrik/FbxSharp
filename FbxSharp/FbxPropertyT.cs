using System;

namespace FbxSharp
{
    public class FbxPropertyT<T> : FbxProperty
    {
        #region Public Types

        // typedef T ValueType

        #endregion

        #region Static Initialization

        [DeviationFromSdk(notes: "Changed return type to generic to " +
                                 "avoid type casts.")]
        public static FbxPropertyT<T> StaticInit(FbxObject pObject,
            string pName,
            T pValue, bool pForceSet,
            FbxPropertyFlags.EFlags pFlags = FbxPropertyFlags.EFlags.eNone) =>
            StaticInit(pObject.RootProperty, pName, null, pValue, pForceSet,
                pFlags);

        [DeviationFromSdk(notes: "Changed return type to generic to " +
                                 "avoid type casts.")]
        public static FbxPropertyT<T> StaticInit(FbxObject pObject,
            string pName, FbxDataType pDataType, T pValue, bool pForceSet,
            FbxPropertyFlags.EFlags pFlags = FbxPropertyFlags.EFlags.eNone) =>
            StaticInit(pObject.RootProperty, pName, pDataType, pValue,
                pForceSet, pFlags);

        [DeviationFromSdk(notes: "Changed return type to generic to " +
                                 "avoid type casts.")]
        public static FbxPropertyT<T> StaticInit(FbxProperty pCompound,
            string pName, FbxDataType pDataType, T pValue,
            bool pForceSet = true,
            FbxPropertyFlags.EFlags pFlags = FbxPropertyFlags.EFlags.eNone)
        {
            var prop = new FbxPropertyT<T>(pName, pDataType);
            prop.SetParent(pCompound);
            if (pValue != null)
                prop.Set(pValue);
            return prop;
        }

        #endregion

        protected FbxPropertyT(string name="", FbxDataType dataType = null,
            T initialValue = default)
            : base(
                name,
                dataType ?? FbxDataType.FbxGetDataTypeFromEnum(
                    typeof(T).ToFbxType()))
        {
            Value = initialValue;
        }

        public override Type GetDotnetType() => typeof(T);

        public T Value { get; set; }

        //FbxPropertyT &      Set (const T &pValue)
        public FbxPropertyT<T> Set(T value)
        {
            Value = value;
            return this;
        }

        public T Get()
        {
            return Value;
        }

        public override U Get<U>()
        {
            if (Value is U uValue)
                return uValue;
            if (Value == null)
                return default;

            if (!(Value is U))
            {
                var tuple = new Tuple<Type, Type>(typeof(T), typeof(U));
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

        public override bool Set<U>(U pValue)
        {
            return Set(pValue, typeof(U).ToFbxType());
        }

        public /*override*/ bool Set<U>(U value, int x)
        where U :T
        {
            // if U can be assigned to a prop/field of type T,
            //  then do so
            // else if there is a converter available
            //  then use that
            // else
            //  throw

            return Set(value, typeof(U).ToFbxType());

            throw new InvalidCastException(); // maybe find a better exception to throw
        }

        [DeviationFromSdk("change parameter type to object from void*")]
        protected override bool Set(object pValue, EFbxType pValueType, bool pCheckForValueEquality=true)
        {
            var actualType = pValue.GetType();
            if (typeof(T).IsAssignableFrom(actualType))
            {
                Value = (T)pValue;
                return true;
            }

            if (typeof(T).IsEnum)
            {
                object v = null;
                if (actualType == typeof(long))
                    v = (T)Enum.ToObject(typeof(T), (long)(object)pValue);
                else if (actualType == typeof(ulong))
                    v = (T)Enum.ToObject(typeof(T), (ulong)(object)pValue);
                else if (actualType == typeof(int))
                    v = (T)Enum.ToObject(typeof(T), (int)(object)pValue);
                else if (actualType == typeof(uint))
                    v = (T)Enum.ToObject(typeof(T), (uint)(object)pValue);
                else if (actualType == typeof(short))
                    v = (T)Enum.ToObject(typeof(T), (short)(object)pValue);
                else if (actualType == typeof(ushort))
                    v = (T)Enum.ToObject(typeof(T), (ushort)(object)pValue);
                else if (actualType == typeof(byte))
                    v = (T)Enum.ToObject(typeof(T), (byte)(object)pValue);
                else if (actualType == typeof(sbyte))
                    v = (T)Enum.ToObject(typeof(T), (sbyte)(object)pValue);
                if (v != null)
                {
                    Value = (T)v;
                    return true;
                }
            }

            var tuple = new Tuple<Type, Type>(actualType, typeof(T));
            if (Converters.TryGetValue(tuple, out var converter))
            {
                Value = (T)converter(pValue);
                return true;
            }

            throw new NotImplementedException();
            // return Set<object>(pValue);
        }
    }
}

