using System;
using System.Collections.Generic;
using System.Linq;

namespace FbxSharp
{
    public class FbxObject : FbxEmitter
    {
        static ulong __uniqueId = 0;

        public FbxObject(String name="")
        {
            SetInitialName(name ?? "");

            Properties = new FbxObjectPropertyCollection(this);
            SrcObjects = new ObjectSrcObjectCollection(this);
            DstObjects = new ObjectDstObjectCollection(this);

            SrcProperties = new ObjectSrcPropertyCollection(this);
            DstProperties = new ObjectDstPropertyCollection(this);

            UniqueId = __uniqueId;
            __uniqueId++;

            _scene = DstObjects.CreateObjectView<FbxScene>();
        }

        public override string ToString()
        {
            return string.Format("[{2}: Name={0}, UniqueId={1}]", Name, UniqueId, this.GetType().Name);
        }

        #region General Object Management

        protected readonly ObjectView<FbxScene> _scene;
        public FbxScene Scene
        {
            get
            {
                return _scene.Get();
            }
        }
        public FbxScene GetScene()
        {
            return Scene;
        }

        #endregion

        #region Selection Management

        public virtual bool GetSelected()
        {
            throw new NotImplementedException();
        }

        public virtual void SetSelected(bool pSelected)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region User Data

        public void SetUserDataPtr(ulong pUserID, object pUserData)
        {
            throw new NotImplementedException();
        }

        public object GetUserDataPtr(ulong pUserID)
        {
            throw new NotImplementedException();
        }

        public void SetUserDataPtr(object pUserData)
        {
            throw new NotImplementedException();
        }

        public object GetUserDataPtr()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region General Object Connection and Relationship Management

        public readonly ObjectSrcObjectCollection SrcObjects;
        public readonly ObjectDstObjectCollection DstObjects;

        public virtual void ConnectSrcObject(FbxObject fbxObject/*, Connection.EType type = Connection.EType.None*/)
        {
            SrcObjects.Add(fbxObject);

            if (Scene != null)
            {
                Scene.ConnectSrcObject(fbxObject);
            }
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

        public bool DisconnectAllSrcObject(FbxCriteria pCriteria)
        {
            throw new NotImplementedException();
        }

        [Obsolete("Deprecated, please use DisconnectAllSrcObject<T>() instead.")]
        public bool DisconnectAllSrcObject(FbxClassId pClassId)
        {
            throw new NotImplementedException();
        }

        public int GetSrcObjectCount()
        {
            return SrcObjects.Count;
        }

        public int GetSrcObjectCount(FbxCriteria pCriteria)
        {
            throw new NotImplementedException();
        }

        [Obsolete("Deprecated, please use GetSrcObjectCount<T>() instead.")]
        public int GetSrcObjectCount(FbxClassId pClassId)
        {
            throw new NotImplementedException();
        }

        public FbxObject GetSrcObject(int pIndex = 0)
        {
            return SrcObjects[pIndex];
        }

        public FbxObject GetSrcObject(FbxCriteria pCriteria, int pIndex=0)
        {
            throw new NotImplementedException();
        }

        [Obsolete("Deprecated, please use GetSrcObject<T>() instead.")]
        public FbxObject GetSrcObject(FbxClassId pClassId, int pIndex=0)
        {
            throw new NotImplementedException();
        }

        public FbxObject FindSrcObject(string pName, int pStartIndex=0)
        {
            throw new NotImplementedException();
        }

        public FbxObject FindSrcObject(FbxCriteria pCriteria, string pName, int pStartIndex=0)
        {
            throw new NotImplementedException();
        }

        [Obsolete("Deprecated, please use FindSrcObject<T>() instead.")]
        public FbxObject FindSrcObject(FbxClassId pClassId, string pName, int pStartIndex=0)
        {
            throw new NotImplementedException();
        }

        public bool DisconnectAllSrcObject<T>()
        {
            var objectsToDisconnect = SrcObjects.Where(obj => obj is T).ToArray();
            bool succeeded = true;
            foreach (var obj in objectsToDisconnect)
            {
                // failure modes?
                succeeded &= DisconnectSrcObject(obj);
            }

            return succeeded;
        }

        public bool DisconnectAllSrcObject<T>(FbxCriteria pCriteria)
        {
            throw new NotImplementedException();
        }

        public int GetSrcObjectCount<T>()
        {
            return SrcObjects.Count(obj => obj is T);
        }

        public int GetSrcObjectCount<T>(FbxCriteria pCriteria)
        {
            throw new NotImplementedException();
        }

        public T GetSrcObject<T>(int pIndex=0)
        {
            return SrcObjects.Where(obj => obj is T).Cast<T>().ElementAt(pIndex);
        }

        public T GetSrcObject<T>(FbxCriteria pCriteria, int pIndex=0)
        {
            throw new NotImplementedException();
        }

        public T FindSrcObject<T>(string pName, int pStartIndex=0)
        {
            throw new NotImplementedException();
        }

        public T FindSrcObject<T>(FbxCriteria pCriteria, string pName, int pStartIndex=0)
        {
            throw new NotImplementedException();
        }

        public virtual bool ConnectDstObject(FbxObject pObject/*, Connection.EType pType = Connection.EType.None*/)
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

        public bool DisconnectAllDstObject(FbxCriteria pCriteria)
        {
            throw new NotImplementedException();
        }

        [Obsolete("Deprecated, please use DisconnectAllDstObject<T>() instead.")]
        public bool DisconnectAllDstObject(FbxClassId pClassId)
        {
            throw new NotImplementedException();
        }

        public int GetDstObjectCount()
        {
            return DstObjects.Count;
        }

        public int GetDstObjectCount(FbxCriteria pCriteria)
        {
            throw new NotImplementedException();
        }

        [Obsolete("Deprecated, please use GetDstObjectCount<T>() instead.")]
        public int GetDstObjectCount(FbxClassId pClassId)
        {
            throw new NotImplementedException();
        }

        public FbxObject GetDstObject(int pIndex = 0)
        {
            return DstObjects[pIndex];
        }

        FbxObject FindDstObject(string pName, int pStartIndex=0)
        {
            throw new NotImplementedException();
        }

        FbxObject FindDstObject(FbxCriteria pCriteria, string pName, int pStartIndex=0)
        {
            throw new NotImplementedException();
        }

        [Obsolete("Deprecated, please use FindDstObject<T>() instead.")]
        public FbxObject FindDstObject(FbxClassId pClassId, string pName, int pStartIndex=0)
        {
            throw new NotImplementedException();
        }

        public bool DisconnectAllDstObject<T>()
        {
            throw new NotImplementedException();
        }

        public bool DisconnectAllDstObject<T>(FbxCriteria pCriteria)
        {
            throw new NotImplementedException();
        }

        public int GetDstObjectCount<T>()
        {
            throw new NotImplementedException();
        }

        public int GetDstObjectCount<T>(FbxCriteria pCriteria)
        {
            throw new NotImplementedException();
        }

        public T GetDstObject<T>(int pIndex=0)
        {
            throw new NotImplementedException();
        }

        public T GetDstObject<T>(FbxCriteria pCriteria, int pIndex=0)
        {
            throw new NotImplementedException();
        }

        public T FindDstObject<T>(string pName, int pStartIndex=0)
        {
            throw new NotImplementedException();
        }

        public T FindDstObject<T>(FbxCriteria pCriteria, string pName, int pStartIndex=0)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Extended Object Connection and Relationship Management

        public IEnumerable<T> GetSrcObjects<T>()
        {
            return SrcObjects.Where(obj => obj is T).Cast<T>();
        }

        public IEnumerable<T> GetDstObjects<T>()
        {
            return DstObjects.Where(obj => obj is T).Cast<T>();
        }

        #endregion

        #region Property Management

        public readonly FbxObjectPropertyCollection Properties;

        public readonly ObjectSrcPropertyCollection SrcProperties;
        public readonly ObjectDstPropertyCollection DstProperties;

        public FbxProperty GetFirstProperty()
        {
            if (Properties.Count == 0) return null;

            return Properties[0];
        }

        public FbxProperty GetNextProperty(FbxProperty pProperty)
        {
            if (!Properties.Contains(pProperty)) return null;

            var index = Properties.IndexOf(pProperty);
            if (index + 1 >= Properties.Count) return null;
            if (index < 0) return null;

            return Properties[index + 1];
        }

        public FbxProperty FindProperty(string pName, bool pCaseSensitive=true)
        {
            return Properties.FirstOrDefault(p => string.Compare(p.Name, pName, ignoreCase: !pCaseSensitive) == 0);
        }

        //public Property FindProperty(string pName, FbxDataType pDataType, bool pCaseSensitive=true)
        public FbxProperty FindProperty(string pName, Type pDataType, bool pCaseSensitive=true)
        {
            return FindProperty(prop =>
                string.Compare(prop.Name, pName, ignoreCase: !pCaseSensitive) == 0 &&
                prop.PropertyDataType == pDataType);
        }

        public FbxProperty FindProperty(Func<FbxProperty, bool> predicate)
        {
            return FindProperties(predicate).FirstOrDefault();
        }

        public IEnumerable<FbxProperty> FindProperties(Func<FbxProperty, bool> predicate)
        {
            return Properties.Where(predicate);
        }

        public FbxProperty FindPropertyHierarchical(string pName, bool pCaseSensitive=true)
        {
            throw new NotImplementedException();
        }

        //public Property FindPropertyHierarchical(string pName, FbxDataType pDataType, bool pCaseSensitive=true)
        //{
        //    throw new NotImplementedException();
        //}

        readonly static FbxPropertyT<object> classRootProperty = new FbxPropertyT<object>();
        public FbxProperty GetClassRootProperty()
        {
            return classRootProperty;
        }

        public bool ConnectSrcProperty(FbxProperty pProperty)
        {
            if (SrcProperties.Contains(pProperty))
                return false;

            SrcProperties.Add(pProperty);

            return true;
        }

        public bool IsConnectedSrcProperty(FbxProperty pProperty)
        {
            return SrcProperties.Contains(pProperty);
        }

        public bool DisconnectSrcProperty(FbxProperty pProperty)
        {
            return SrcProperties.Remove(pProperty);
        }

        public int GetSrcPropertyCount()
        {
            return SrcProperties.Count;
        }

        public FbxProperty GetSrcProperty(int pIndex=0)
        {
            return SrcProperties[pIndex];
        }

        public FbxProperty FindSrcProperty(string pName, int pStartIndex=0)
        {
            throw new NotImplementedException();
        }

        public bool ConnectDstProperty(FbxProperty pProperty)
        {
            if (DstProperties.Contains(pProperty))
                return false;

            DstProperties.Add(pProperty);

            return true;
        }

        public bool IsConnectedDstProperty(FbxProperty pProperty)
        {
            return DstProperties.Contains(pProperty);
        }

        public bool DisconnectDstProperty(FbxProperty pProperty)
        {
            return DstProperties.Remove(pProperty);
        }

        public int GetDstPropertyCount()
        {
            return DstProperties.Count;
        }

        public FbxProperty GetDstProperty(int pIndex=0)
        {
            return DstProperties[pIndex];
        }

        public FbxProperty FindDstProperty(string pName, int pStartIndex=0)
        {
            throw new NotImplementedException();
        }

        public FbxProperty CreateProperty(string name, Type type)
        {
            var concreteType = typeof(FbxPropertyT<>).MakeGenericType(type);
            var prop = (FbxProperty)Activator.CreateInstance(concreteType, (object)name);
            Properties.Add(prop);
            return prop;
        }

        #endregion

        #region Public Attributes

        public readonly FbxProperty RootProperty = new FbxPropertyT<object>();

        #endregion

        #region Object Name Management

        public string Name { get; set; }
        public ulong UniqueId { get; set; }

        public void SetName(string pName)
        {
            Name = pName;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetNameWithoutNameSpacePrefix()
        {
            return Name;
        }

        public string GetNameWithNameSpacePrefix()
        {
            return GetNameSpacePrefix() + GetName();
        }

        public void SetInitialName(string pName)
        {
            initialName = pName;
            SetName(pName);
        }

        string initialName = "";
        public string GetInitialName()
        {
            return initialName;
        }

        string _namespace = "";
        public string GetNameSpaceOnly()
        {
            return _namespace;
        }

        public void SetNameSpace(string pNameSpace)
        {
            _namespace = pNameSpace;
            FirstCharIsMissing = true;
        }

        public string[] GetNameSpaceArray(char identifier)
        {
            return _namespace.Split(identifier).Reverse().ToArray();
        }

        bool FirstCharIsMissing = false;
        public string GetNameOnly()
        {
            if (FirstCharIsMissing)
                return Name.Substring(1);
            return Name;
        }

        public virtual string GetNameSpacePrefix()
        {
            return "";
        }

        public ulong GetUniqueID()
        {
            return UniqueId;
        }

        public static string RemovePrefix(string pName)
        {
            int index = pName.LastIndexOf("::");
            return pName.Substring(index+2);
        }

        public static string StripPrefix(string lName)
        {
            int index = lName.IndexOf("::");
            return lName.Substring(index+2);
        }

        #endregion
    }
}

