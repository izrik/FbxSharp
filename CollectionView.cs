using System;
using System.Collections.Generic;
using System.Linq;

namespace FbxSharp
{
    public class CollectionView<T> : CollectionView<T, FbxObject>
        where T : FbxObject
    {
        public CollectionView(IList<FbxObject> collection, Action<EventHandler> collectionChanged)
            : base(collection, collectionChanged)
        {
        }

    }
    public class CollectionView<T, U> : IEnumerable<T>
        where T : U
    {
        public CollectionView(IList<U> collection, Action<EventHandler> collectionChanged)
        {
            if (collection == null) throw new ArgumentNullException("collection");

            this.collection = collection;
            collectionChanged(this.CollectionChanged);
        }

        readonly IList<U> collection;

        bool collectionHasChanged = true;
        readonly List<T> _list = new List<T>();

        void CollectionChanged(object sender, EventArgs e)
        {
            _list.Clear();
            collectionHasChanged = true;
        }

        List<T> List
        {
            get
            {
                if (collectionHasChanged)
                {
                    _list.Clear();
                    _list.AddRange(collection.Where(x => x is T).Cast<T>());
                    collectionHasChanged = false;
                }

                return _list;
            }
        }

        public int IndexOf(T item)
        {
            return List.IndexOf(item);
        }

        public T this[int index]
        {
            get { return List[index]; }
        }

        public bool Contains(T item)
        {
            return List.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            List.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return List.Count; }
        }

        #region IEnumerable implementation

        public IEnumerator<T> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        #endregion

        #region IEnumerable implementation

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}

