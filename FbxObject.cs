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

            Properties = new FbxObjectPropertyCollection(this);
            SrcObjects = new ObjectSrcObjectCollection(this);
            DstObjects = new ObjectDstObjectCollection(this);

            SrcProperties = new ObjectSrcPropertyCollection(this);
            DstProperties = new ObjectDstPropertyCollection(this);

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


        public int GetSrcObjectCount()
        {
            return SrcObjects.Count;
        }

        public FbxObject GetSrcObject(int pIndex = 0)
        {
            return SrcObjects[pIndex];
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

        public readonly FbxObjectPropertyCollection Properties;

        public readonly ObjectSrcPropertyCollection SrcProperties;
        public readonly ObjectDstPropertyCollection DstProperties;

        public Property GetFirstProperty()
        {
            if (Properties.Count == 0) return null;

            return Properties[0];
        }

        public Property GetNextProperty(Property pProperty)
        {
            if (!Properties.Contains(pProperty)) return null;

            var index = Properties.IndexOf(pProperty);
            if (index + 1 >= Properties.Count) return null;
            if (index < 0) return null;

            return Properties[index + 1];
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
            if (SrcProperties.Contains(pProperty))
                return false;

            SrcProperties.Add(pProperty);

            return true;
        }

        public bool IsConnectedSrcProperty(Property pProperty)
        {
            return SrcProperties.Contains(pProperty);
        }

        public bool DisconnectSrcProperty(Property pProperty)
        {
            return SrcProperties.Remove(pProperty);
        }

        public int GetSrcPropertyCount()
        {
            return SrcProperties.Count;
        }

        public Property GetSrcProperty(int pIndex=0)
        {
            return SrcProperties[pIndex];
        }

        public Property FindSrcProperty(string pName, int pStartIndex=0)
        {
            throw new NotImplementedException();
        }

        public bool ConnectDstProperty(Property pProperty)
        {
            if (DstProperties.Contains(pProperty))
                return false;

            DstProperties.Add(pProperty);

            return true;
        }

        public bool IsConnectedDstProperty(Property pProperty)
        {
            return DstProperties.Contains(pProperty);
        }

        public bool DisconnectDstProperty(Property pProperty)
        {
            return DstProperties.Remove(pProperty);
        }

        public int GetDstPropertyCount()
        {
            return DstProperties.Count;
        }

        public Property GetDstProperty(int pIndex=0)
        {
            return DstProperties[pIndex];
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
            throw new NotImplementedException();
        }

        public string GetNameWithNameSpacePrefix()
        {
            throw new NotImplementedException();
        }

        public void SetInitialName(string pName)
        {
            throw new NotImplementedException();
        }

        public string GetInitialName()
        {
            throw new NotImplementedException();
        }

        public string GetNameSpaceOnly()
        {
            throw new NotImplementedException();
        }

        public void SetNameSpace(string pNameSpace)
        {
            throw new NotImplementedException();
        }

        public string[] GetNameSpaceArray(char identifier)
        {
            throw new NotImplementedException();
        }

        public string GetNameOnly()
        {
            throw new NotImplementedException();
        }

        public string GetNameSpacePrefix()
        {
            throw new NotImplementedException();
        }

        public ulong GetUniqueID()
        {
            return UniqueId;
        }

        public static string RemovePrefix(string pName)
        {
            throw new NotImplementedException();
        }

        public static string StripPrefix(string lName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

