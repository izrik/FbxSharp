using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public class FbxObject : Emitter
    {
        static ulong __uniqueId = 0;

        public FbxObject()
        {
            DstObjects = new DstObjectCollection(this);
            SrcObjects = new SrcObjectCollection(this);

            UniqueId = __uniqueId;
            __uniqueId++;
        }

        public override string ToString()
        {
            return string.Format("[{2}: Name={0}, UniqueId={1}]", Name, UniqueId, this.GetType().Name);
        }

        #region General Object Connection and Relationship Management

        public readonly SrcObjectCollection SrcObjects;
        public readonly DstObjectCollection DstObjects;

        public void ConnectSrcObject(FbxObject fbxObject, Connection.EType type = Connection.EType.None)
        {
            SrcObjects.Add(fbxObject);
        }

        public bool IsConnectedSrcObject(FbxObject pObject)
        {
            return SrcObjects.Contains(pObject);
        }

        public bool DisconnectSrcObject(FbxObject pObject)
        {
            return SrcObjects.Remove(pObject);
        }

        public bool DisconnectAllSrcObject()
        {
            SrcObjects.Clear();
            return true;
        }


        public int GetSrcObjectCount()
        {
            return SrcObjects.Count;
        }

        public FbxObject GetSrcObject(int pIndex = 0)
        {
            return SrcObjects[pIndex];
        }

        public bool ConnectDstObject(FbxObject pObject, Connection.EType pType = Connection.EType.None)
        {
            DstObjects.Add(pObject);
            return true;
        }

        public bool IsConnectedDstObject(FbxObject pObject)
        {
            return DstObjects.Contains(pObject);
        }

        public bool DisconnectDstObject(FbxObject pObject)
        {
            return DstObjects.Remove(pObject);
        }

        public bool DisconnectAllDstObject()
        {
            DstObjects.Clear();
            return true;
        }

        public int GetDstObjectCount()
        {
            return DstObjects.Count;
        }

        public FbxObject GetDstObject(int pIndex = 0)
        {
            return DstObjects[pIndex];
        }


        #endregion

        #region Property Management

        public List<Property> Properties = new List<Property>();

        public Property FindProperty(string name, bool caseSensitive=true)
        {
            return Properties.Find(p =>
                string.Compare(p.Name, name, ignoreCase: !caseSensitive) == 0
            );
        }

        public Property FindProperty(string name, Type type, bool caseSensitive=true)
        {
            return Properties.Find(p => {
                if (p.PropertyDataType != type) return false;

                return string.Compare(p.Name, name, ignoreCase: !caseSensitive) == 0;
            });
        }
        public PropertyT<T> FindProperty<T>(string name, bool caseSensitive=true)
        {
            return (PropertyT<T>)Properties.Find(p => {
                if (!(p is PropertyT<T>)) return false;

                return string.Compare(p.Name, name, ignoreCase: !caseSensitive) == 0;
            });
        }



        public bool ConnectSrcProperty(Property pProperty)
        {
            throw new NotImplementedException();
        }

        public bool IsConnectedSrcProperty(Property pProperty)
        {
            throw new NotImplementedException();
        }

        public bool DisconnectSrcProperty(Property pProperty)
        {
            throw new NotImplementedException();
        }

        public int GetSrcPropertyCount()
        {
            return 0;
        }

        public Property GetSrcProperty(int pIndex = 0)
        {
            throw new NotImplementedException();
        }

        public Property FindSrcProperty(string pName, int pStartIndex = 0)
        {
            throw new NotImplementedException();
        }

        public bool ConnectDstProperty(Property pProperty)
        {
            throw new NotImplementedException();
        }

        public bool IsConnectedDstProperty(Property pProperty)
        {
            throw new NotImplementedException();
        }

        public bool DisconnectDstProperty(Property pProperty)
        {
            throw new NotImplementedException();
        }

        public int GetDstPropertyCount()
        {
            return 0;
        }

        public Property GetDstProperty(int pIndex = 0)
        {
            throw new NotImplementedException();
        }

        public Property FindDstProperty(string pName, int pStartIndex = 0)
        {
            throw new NotImplementedException();
        }



        public PropertyT<T> CreateProperty<T>(string name)
        {
            var prop = new PropertyT<T>(name);
            Properties.Add(prop);
            return prop;
        }
        public Property CreateProperty(string name, Type type)
        {
            var concreteType = typeof(PropertyT<>).MakeGenericType(type);
            var prop = (Property)Activator.CreateInstance(concreteType, (object)name);
            Properties.Add(prop);
            return prop;
        }

        #endregion

        public string Name { get; set; }

        //Returns the unique ID of this object.
        public ulong UniqueId { get; set; } //protected set; }
    }
}

