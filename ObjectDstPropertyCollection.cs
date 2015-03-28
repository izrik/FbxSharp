using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class ObjectDstPropertyCollection : IList<Property>
    {
        // An ordered collection of Property objects

        public ObjectDstPropertyCollection(FbxObject container)
        {
            _container = container;
        }

        public override string ToString()
        {
            return string.Format("[ObjectDstPropertyCollection: Count={0}]", Count);
        }

        public void AddRange(params Property[] items)
        {
            AddRange((IEnumerable<Property>)items);
        }
        public void AddRange(IEnumerable<Property> items)
        {
            foreach (Property item in items)
            {
                Add(item);
            }
        }
        public void RemoveRange(params Property[] items)
        {
            RemoveRange((IEnumerable<Property>)items);
        }
        public void RemoveRange(IEnumerable<Property> items)
        {
            foreach (Property item in items)
            {
                Remove(item);
            }
        }

        //ICollection<Property>
        public virtual void Add(Property item)
        {
            if (!Contains(item))
            {
                _list.Add(item);
                item.SrcObjects.Add(_container);
            }
        }

        public virtual bool Contains(Property item)
        {
            return _list.Contains(item);
        }

        public virtual bool Remove(Property item)
        {
            if (Contains(item))
            {
                bool ret = _list.Remove(item);
                item.SrcObjects.Remove(_container);
                return ret;
            }

            return false;
        }

        public virtual void Clear()
        {
            Property[] array = new Property[Count];

            CopyTo(array, 0);

            foreach (Property item in array)
            {
                Remove(item);
            }

            _list.Clear();
        }

        public virtual void CopyTo(Property[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public virtual IEnumerator<Property> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        //IList<Property>
        public virtual int IndexOf(Property item)
        {
            return _list.IndexOf(item);
        }

        public virtual void Insert(int index, Property item)
        {
            if (Contains(item))
            {
                if (IndexOf(item) < index)
                {
                    index--;
                }

                Remove(item);
            }

            item.SrcObjects.Remove(_container);
            _list.Insert(index, item);
            item.SrcObjects.Add(_container);
        }

        public virtual void RemoveAt(int index)
        {
            Remove(this[index]);
        }

        //ICollection<Property>
        public virtual int Count
        {
            get { return _list.Count; }
        }

        public virtual bool IsReadOnly
        {
            get { return (_list as ICollection<Property>).IsReadOnly; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //IList<Property>
        public virtual Property this [ int index ]
        {
            get { return _list[index]; }
            set
            {
                RemoveAt(index);
                Insert(index, value);
            }
        }

        private FbxObject _container;
        private List<Property> _list = new List<Property>();
    }
}