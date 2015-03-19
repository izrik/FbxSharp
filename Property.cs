using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public abstract class Property
    {
        protected Property(string name)
        {
            Name = name;
        }

        #region Property Identification

        public string Name { get; protected set; }
        public abstract Type PropertyDataType { get; }
        //public Object FbxObject { get; protected set; }

        //FbxDataType GetPropertyDataType()

        public string GetName()
        {
            return Name;
        }

        public string GetHierarchicalName()
        {
            throw new NotImplementedException();
        }

        public string GetLabel(bool pReturnNameIfEmpty=true)
        {
            throw new NotImplementedException();
        }

        public void SetLabel(string pLabel)
        {
            throw new NotImplementedException();
        }

        public FbxObject GetFbxObject()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Value Management

        public static bool HasDefaultValue(Property pProperty)
        {
            throw new NotImplementedException();
        }

        public virtual T Get<T>()
        {
            throw new NotImplementedException();
        }
        public virtual object GetValue()
        {
            throw new NotImplementedException();
        }
        public virtual bool Set<T>(T pValue)
        {
            throw new NotImplementedException();
        }
        public virtual bool Set(object value)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsValid() { return true; }

        public PropertyFlags.EInheritType GetValueInheritType()
        {
            throw new NotImplementedException();
        }

        public bool SetValueInheritType(PropertyFlags.EInheritType pType)
        {
            throw new NotImplementedException();
        }

        public bool Modified()
        {
            throw new NotImplementedException();
        }

        #endregion


        public override string ToString()
        {
            return string.Format("{0}: {1}", Name, GetValue());
        }

        public List<FbxObject> SrcObjects = new List<FbxObject>();

        public bool ConnectSrcObject(FbxObject src, Connection.EType type=Connection.EType.None)
        {
            SrcObjects.Add(src);
            return true;
        }
    }
}

