﻿
using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class PropertyChildrenCollection : IList<FbxProperty>
    {
        // An ordered collection of Property objects

        public PropertyChildrenCollection(FbxProperty container)
        {
            _container = container;
        }

        public void AddRange(params FbxProperty [] items)
        {
            AddRange((IEnumerable<FbxProperty>)items);
        }

        public void AddRange(IEnumerable<FbxProperty> items)
        {
            foreach (FbxProperty item in items)
            {
                Add(item);
            }
        }

        public void RemoveRange(params FbxProperty [] items)
        {
            RemoveRange((IEnumerable<FbxProperty>)items);
        }

        public void RemoveRange(IEnumerable<FbxProperty> items)
        {
            foreach (FbxProperty item in items)
            {
                Remove(item);
            }
        }

        //ICollection<Property>
        public virtual void Add(FbxProperty item)
        {
            if (!Contains(item))
            {
                _list.Add(item);
                item.ParentProperty = _container;
            }
        }

        public virtual bool Contains(FbxProperty item)
        {
            return _list.Contains(item);
        }

        public virtual bool Remove(FbxProperty item)
        {
            if (Contains(item))
            {
                bool ret = _list.Remove(item);
                item.ParentProperty = null;
                return ret;
            }

            return false;
        }

        public virtual void Clear()
        {
            FbxProperty [] array = new FbxProperty[Count];

            CopyTo(array, 0);

            foreach (FbxProperty item in array)
            {
                Remove(item);
            }

            _list.Clear();
        }

        public virtual void CopyTo(FbxProperty [] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public List<FbxProperty>.Enumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator<FbxProperty> IEnumerable<FbxProperty>.GetEnumerator()
        {
            return GetEnumerator();
        }

        //IList<Property>
        public virtual int IndexOf(FbxProperty item)
        {
            return _list.IndexOf(item);
        }

        public virtual void Insert(int index, FbxProperty item)
        {
            if (Contains(item))
            {
                if (IndexOf(item) < index)
                {
                    index--;
                }

                Remove(item);
            }

            item.ParentProperty = null;
            _list.Insert(index, item);
            item.ParentProperty = _container;
        }

        public virtual void RemoveAt(int index)
        {
            Remove(this[index]);
        }

        //ICollection<Property>
        public virtual int Count {
            get { return _list.Count; }
        }

        public virtual bool IsReadOnly {
            get { return (_list as ICollection<FbxProperty>).IsReadOnly; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //IList<Property>
        public virtual FbxProperty this [int index] {
            get { return _list[index]; }
            set {
                RemoveAt(index);
                Insert(index, value);
            }
        }

        readonly FbxProperty _container;
        readonly List<FbxProperty> _list = new List<FbxProperty>();
    }
}
