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
        public void Set(T value)
        {
            Value = value;
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

        public override bool Set<U>(U value)
        {
            // if U can be assigned to a prop/field of type T,
            //  then do so
            // else if there is a converter available
            //  then use that
            // else
            //  throw
            if ((typeof(U).IsAssignableFrom(typeof(T))))
            {
                Value = (T)(object)value;
                return true;
            }

            var tuple = new Tuple<Type, Type>(typeof(U), typeof(T));
            if (Converters.ContainsKey(tuple))
            {
                var converter = Converters[tuple];
                Value = (T)converter(value);
                return true;
            }

            throw new InvalidCastException(); // maybe find a better exception to throw
        }

        public override bool Set(object value)
        {
            return Set<object>(value);
        }
    }
}

