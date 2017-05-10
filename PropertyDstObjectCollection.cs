using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class PropertyDstObjectCollection : IList<FbxObject>
    {
        // An ordered collection of FbxObject objects

        public PropertyDstObjectCollection(FbxProperty container)
        {
            _container = container;
        }

        public override string ToString()
        {
            return string.Format("[PropertyDstObjectCollection: Count={0}]", Count);
        }

        public void AddRange(params FbxObject[] items)
        {
            AddRange((IEnumerable<FbxObject>)items);
        }
        public void AddRange(IEnumerable<FbxObject> items)
        {
            foreach (FbxObject item in items)
            {
                Add(item);
            }
        }
        public void RemoveRange(params FbxObject[] items)
        {
            RemoveRange((IEnumerable<FbxObject>)items);
        }
        public void RemoveRange(IEnumerable<FbxObject> items)
        {
            foreach (FbxObject item in items)
            {
                Remove(item);
            }
        }

        //ICollection<FbxObject>
        public virtual void Add(FbxObject item)
        {
            if (!Contains(item))
            {
                _list.Add(item);
                item.SrcProperties.Add(_container);
            }
        }

        public virtual bool Contains(FbxObject item)
        {
            return _list.Contains(item);
        }

        public virtual bool Remove(FbxObject item)
        {
            if (Contains(item))
            {
                bool ret = _list.Remove(item);
                item.SrcProperties.Remove(_container);
                return ret;
            }

            return false;
        }

        public virtual void Clear()
        {
            FbxObject[] array = new FbxObject[Count];

            CopyTo(array, 0);

            foreach (FbxObject item in array)
            {
                Remove(item);
            }

            _list.Clear();
        }

        public virtual void CopyTo(FbxObject[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public virtual IEnumerator<FbxObject> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        //IList<FbxObject>
        public virtual int IndexOf(FbxObject item)
        {
            return _list.IndexOf(item);
        }

        public virtual void Insert(int index, FbxObject item)
        {
            if (Contains(item))
            {
                if (IndexOf(item) < index)
                {
                    index--;
                }

                Remove(item);
            }

            item.SrcProperties.Remove(_container);
            _list.Insert(index, item);
            item.SrcProperties.Add(_container);
        }

        public virtual void RemoveAt(int index)
        {
            Remove(this[index]);
        }

        //ICollection<FbxObject>
        public virtual int Count
        {
            get { return _list.Count; }
        }

        public virtual bool IsReadOnly
        {
            get { return (_list as ICollection<FbxObject>).IsReadOnly; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //IList<FbxObject>
        public virtual FbxObject this [ int index ]
        {
            get { return _list[index]; }
            set
            {
                RemoveAt(index);
                Insert(index, value);
            }
        }

        private FbxProperty _container;
        private List<FbxObject> _list = new List<FbxObject>();
    }
}