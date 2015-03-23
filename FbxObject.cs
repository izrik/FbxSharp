using System;
using System.Collections.Generic;
using System.Linq;

namespace FbxSharp
{
    public class FbxObject : Emitter
    {
        static ulong __uniqueId = 0;

        public FbxObject(String name="")
        {
            Name = name ?? "";

            DstObjects = new DstObjectCollection(this);
            SrcObjects = new SrcObjectCollection(this);

            UniqueId = __uniqueId;
            __uniqueId++;

            _scene = DstObjects.CreateObjectView<Scene>();
        }

        public override string ToString()
        {
            return string.Format("[{2}: Name={0}, UniqueId={1}]", Name, UniqueId, this.GetType().Name);
        }

        #region General Object Management

        protected readonly ObjectView<Scene> _scene;
        public Scene Scene
        {
            get
            {
                return _scene.Get();
            }
        }
        public Scene GetScene()
        {
            return Scene;
        }

        #endregion

        #region General Object Connection and Relationship Management

        public readonly SrcObjectCollection SrcObjects;
        public readonly DstObjectCollection DstObjects;

        public virtual void ConnectSrcObject(FbxObject fbxObject, Connection.EType type = Connection.EType.None)
        {
            SrcObjects.Add(fbxObject);
        }

        public bool IsConnectedSrcObject(FbxObject pObject)
        {
            return SrcObjects.Contains(pObject);
        }

        public virtual bool DisconnectSrcObject(FbxObject pObject)
        {
            return SrcObjects.Remove(pObject);
        }

        public bool DisconnectAllSrcObject()
        {
            foreach (var src in SrcObjects.ToArray())
            {
                DisconnectSrcObject(src);
            }
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

        public virtual bool ConnectDstObject(FbxObject pObject, Connection.EType pType = Connection.EType.None)
        {
            DstObjects.Add(pObject);
            return true;
        }

        public bool IsConnectedDstObject(FbxObject pObject)
        {
            return DstObjects.Contains(pObject);
        }

        public virtual bool DisconnectDstObject(FbxObject pObject)
        {
            return DstObjects.Remove(pObject);
        }

        public bool DisconnectAllDstObject()
        {
            foreach (var dst in DstObjects.ToArray())
            {
                DisconnectDstObject(dst);
            }
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

        public readonly List<Property> Properties = new List<Property>();

        public Property GetFirstProperty()
        {
            throw new NotImplementedException();
        }

        public Property GetNextProperty(Property pProperty)
        {
            throw new NotImplementedException();
        }

        public Property FindProperty(string pName, bool pCaseSensitive=true)
        {
            return Properties.FirstOrDefault(p => string.Compare(p.Name, pName, ignoreCase: !pCaseSensitive) == 0);
        }

        //public Property FindProperty(string pName, FbxDataType pDataType, bool pCaseSensitive=true)
        public Property FindProperty(string pName, Type pDataType, bool pCaseSensitive=true)
        {
            return FindProperty(prop =>
                string.Compare(prop.Name, pName, ignoreCase: !pCaseSensitive) == 0 &&
                prop.PropertyDataType == pDataType);
        }

        public Property FindProperty(Func<Property, bool> predicate)
        {
            return FindProperties(predicate).FirstOrDefault();
        }

        public IEnumerable<Property> FindProperties(Func<Property, bool> predicate)
        {
            return Properties.Where(predicate);
        }

        public Property FindPropertyHierarchical(string pName, bool pCaseSensitive=true)
        {
            throw new NotImplementedException();
        }

        //public Property FindPropertyHierarchical(string pName, FbxDataType pDataType, bool pCaseSensitive=true)
        //{
        //    throw new NotImplementedException();
        //}

        readonly static PropertyT<object> classRootProperty = new PropertyT<object>();
        public Property GetClassRootProperty()
        {
            return classRootProperty;
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

        public Property GetSrcProperty(int pIndex=0)
        {
            throw new NotImplementedException();
        }

        public Property FindSrcProperty(string pName, int pStartIndex=0)
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

        public Property GetDstProperty(int pIndex=0)
        {
            throw new NotImplementedException();
        }

        public Property FindDstProperty(string pName, int pStartIndex=0)
        {
            throw new NotImplementedException();
        }

        public Property CreateProperty(string name, Type type)
        {
            var concreteType = typeof(PropertyT<>).MakeGenericType(type);
            var prop = (Property)Activator.CreateInstance(concreteType, (object)name);
            Properties.Add(prop);
            return prop;
        }

        #endregion

        #region Public Attributes

        public readonly Property RootProperty = new PropertyT<object>();

        #endregion

        #region Object Name Management

        public string Name { get; set; }

        //Returns the unique ID of this object.
        public ulong UniqueId { get; set; } //protected set; }

        #endregion
    }
}

