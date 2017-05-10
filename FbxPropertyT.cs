using System;

namespace FbxSharp
{
    public class FbxPropertyT<T> : FbxProperty
    {
        public FbxPropertyT(string name="")
            : base(name)
        {
        }
        public FbxPropertyT(string name, T initialValue)
            : base(name)
        {
            Value = initialValue;
        }

        public override Type PropertyDataType { get { return typeof(T); } }

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

