using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class ChangeNotifyList<T> : IList<T>
    {
        public ChangeNotifyList(List<T> list=null)
        {
            if (list == null)
                list = new List<T>();

            this.list = list;
        }

        readonly List<T> list;

        public event EventHandler CollectionChanged;

        protected void OnCollectionChanged()
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, EventArgs.Empty);
            }
        }

        #region IList implementation

        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            list.Insert(index, item);

            OnCollectionChanged();
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);

            OnCollectionChanged();
        }

        public T this[int index] {
            get { return list[index]; }
            set
            {
                list[index] = value;

                OnCollectionChanged();
            }
        }

        #endregion

        #region ICollection implementation

        public void Add(T item)
        {
            list.Add(item);

            OnCollectionChanged();
        }

        public void Clear()
        {
            list.Clear();

            OnCollectionChanged();
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            var r = list.Remove(item);
            OnCollectionChanged();
            return r;
        }

        public int Count {
            get { return list.Count; }
        }

        public bool IsReadOnly {
            get { return ((IList<T>)list).IsReadOnly; }
        }

        #endregion

        #region IEnumerable implementation

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        #endregion

        #region IEnumerable implementation

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.IEnumerable)list).GetEnumerator();
        }

        #endregion

        public int FindIndex(Predicate<T> match)
        {
            return list.FindIndex(match);
        }
    }
}

