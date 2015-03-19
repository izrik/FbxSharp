using System;

namespace FbxSharp
{
    public class PropertyT<T> : Property
    {
        public PropertyT(string name="")
            : base(name)
        {
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
            // else
            //  throw
            if (!(typeof(U).IsAssignableFrom(typeof(T)))) // is this reversed? i can never remember 
            {
                throw new InvalidCastException(); // maybe find a better exception to throw
            }

            Value = (T)(object)value;

            return true;
        }

        public override bool Set(object value)
        {
            return Set<object>(value);
        }
    }
}

