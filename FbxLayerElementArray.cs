using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class FbxLayerElementArray
    {
        public enum ELockMode
        {
            eReadLock = 1,
            eWriteLock = 2,
            eReadWriteLock = 3
        }

        public bool IsInUse()
        {
            throw new NotImplementedException();
        }

        public int ReadLock()
        {
            throw new NotImplementedException();
        }

        public int ReadUnlock()
        {
            throw new NotImplementedException();
        }

        public bool WriteLock()
        {
            throw new NotImplementedException();
        }

        public void WriteUnlock()
        {
            throw new NotImplementedException();
        }

        public bool ReadWriteLock()
        {
            throw new NotImplementedException();
        }

        public void ReadWriteUnlock()
        {
            throw new NotImplementedException();
        }
    }

    public class LayerElementArrayT<T> : FbxLayerElementArray
    {
        public LayerElementArrayT(/*EFbxType pDataType*/)
        {
        }

        readonly List<T> values = new List<T>();

        public List<T> List
        {
            get { return values; }
        }

        public int Add(T pItem)
        {
            values.Add(pItem);
            return values.Count - 1;
        }

        public int InsertAt(int pIndex, T pItem)
        {
            values.Insert(pIndex, pItem);
            return pIndex;
        }

        public void SetAt(int pIndex, T pItem)
        {
            values[pIndex] = pItem;
        }

        public void SetLast(T pItem)
        {
            values[values.Count - 1] = pItem;
        }

        public T RemoveAt(int pIndex)
        {
            var item = values[pIndex];
            values.RemoveAt(pIndex);
            return item;
        }

        public T RemoveLast()
        {
            var item = GetLast();
            values.RemoveAt(values.Count - 1);
            return item;
        }

        public bool RemoveIt(T pItem)
        {
            return values.Remove(pItem);
        }

        public T GetAt(int pIndex)
        {
            return values[pIndex];
        }

        public T GetFirst()
        {
            return values[0];
        }

        public T GetLast()
        {
            return values[values.Count - 1];
        }

        public int Find(T pItem)
        {
            return values.IndexOf(pItem);
        }

        public int FindAfter(int pAfterIndex, T pItem)
        {
            throw new NotImplementedException();
        }

        public int FindBefore(int pBeforeIndex, T pItem)
        {
            throw new NotImplementedException();
        }

        public T this [int index]
        {
            get { return values[index]; }
            set { values[index] = value; }
        }
    }
}

