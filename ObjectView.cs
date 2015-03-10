using System;
using System.Linq;

namespace FbxSharp
{
    public class ObjectView<T>
        where T : FbxObject
    {
        public ObjectView(IConnectedObjectCollection collection)
        {
            if (collection == null) throw new ArgumentNullException("collection");

            this.collection = collection;
            this.collection.CollectionChanged += CollectionChanged;
        }

        readonly IConnectedObjectCollection collection;

        bool collectionHasChanged = true;
        T value = null;

        void CollectionChanged(object sender, EventArgs e)
        {
            value = null;
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

