using System;
namespace FbxSharp
{
    public struct STuple<T1, T2>
    {
        public readonly T1 First;
        public readonly T2 Second;

        public STuple(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is STuple<T1, T2>)) return false;
            return this.Equals((STuple<T1, T2>)obj);
        }
        public bool Equals(STuple<T1,T2> obj)
        {
            return this.First.Equals(obj.First) &&
                this.Second.Equals(obj.Second);
        }

        public override int GetHashCode()
        {
            return First.GetHashCode() ^ Second.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", First, Second);
        }
    }
}
