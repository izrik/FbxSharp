using System;
using System.Linq;
using System.Collections.Generic;

namespace FbxSharp
{
    public class ObjectView<T> : ObjectView<T, FbxObject>
        where T : FbxObject
    {
        public ObjectView(IList<FbxObject> collection, Action<EventHandler> collectionChanged)
            : base(collection, collectionChanged)
        {
        }
    }
    public class ObjectView<T, U>
        where T : U
    {
        public ObjectView(IList<U> collection, Action<EventHandler> collectionChanged)
        {
            if (collection == null) throw new ArgumentNullException("collection");

            this.collection = collection;
            collectionChanged(this.CollectionChanged);
        }

        readonly IList<U> collection;

        bool collectionHasChanged = true;
        T value = default(T);

        void CollectionChanged(object sender, EventArgs e)
        {
            value = default(T);
            collectionHasChanged = true;
        }

        public T Get()
        {
            if (collectionHasChanged)
            {
                value = (T)collection.FirstOrDefault(x => x is T);
                collectionHasChanged = false;
            }

            return value;
        }
    }
}

