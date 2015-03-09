using System;
using System.Linq;

namespace FbxSharp
{
    public class SrcObjectView<T>
        where T : FbxObject
    {
        public SrcObjectView(SrcObjectCollection collection)
        {
            if (collection == null) throw new ArgumentNullException("collection");

            this.collection = collection;
            this.collection.CollectionChanged += CollectionChanged;
        }

        readonly SrcObjectCollection collection;

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

