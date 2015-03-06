using System;
using System.Collections.Generic;
using System.Linq;

namespace FbxSharp
{
    // An ordered, interlinking collection of Node objects.
    public class NodeNodeOrderedParentChildrenCollection : IList<Node>
    {
        public NodeNodeOrderedParentChildrenCollection(Node container)
        {
            _container = container;
        }

        //ICollection<Node>
        public virtual void Add(Node item)
        {
            if (!Contains(item))
            {
                item.ParentNode = null;
                _list.Add(item);
                item.ParentNode = _container;
            }
        }

        public virtual bool Contains(Node item)
        {
            return _list.Contains(item);
        }

        public virtual bool Remove(Node item)
        {
            if (Contains(item))
            {
                bool ret = _list.Remove(item);
                item.ParentNode = null;
                return ret;
            }

            return false;
        }

        public virtual void Clear()
        {
            foreach (Node item in this.ToArray())
            {
                Remove(item);
            }

            _list.Clear();
        }

        public virtual void CopyTo(Node[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public virtual IEnumerator<Node> GetEnumerator()
        {
            return _list.GetEnumerator();
        }


        //IList<Node>
        public virtual int IndexOf(Node item)
        {
            return _list.IndexOf(item);
        }

        public virtual void Insert(int index, Node item)
        {
            if (Contains(item))
            {
                if (IndexOf(item) < index)
                {
                    index--;
                }

                Remove(item);
            }

            item.ParentNode = null;
            _list.Insert(index, item);
            item.ParentNode = _container;
        }

        public virtual void RemoveAt(int index)
        {
            Remove(this[index]);
        }


        //ICollection<Node>
        public virtual int Count
        {
            get
            {
                return _list.Count;
            }
        }

        public virtual bool IsReadOnly
        {
            get
            {
                return (_list as ICollection<Node>).IsReadOnly;
            }
        }

        //IList<Node>
        public virtual Node this [ int index ]
        {
            get
            {
                return _list[index];
            }
            set
            {
                RemoveAt(index);
                Insert(index, value);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        private Node _container;
        private List<Node> _list = new List<Node>();
    }
}



