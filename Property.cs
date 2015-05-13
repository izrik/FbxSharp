using System;
using System.Collections.Generic;
using System.Linq;

namespace FbxSharp
{
    public abstract class Property
    {
        static Property()
        {
            AddConverter(typeof(Vector4), typeof(Vector3), (v4) => ((Vector4)v4).ToVector3());
            AddConverter(typeof(Vector3), typeof(Vector4), (v3) => ((Vector3)v3).ToVector4());
        }

        protected Property(string name)
        {
            Name = name;

            Children = new PropertyChildrenCollection(this);
            SrcObjects = new PropertySrcObjectCollection(this);
            DstObjects = new PropertyDstObjectCollection(this);
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Name, GetValue());
        }

        #region Static Public Attributes

        public static string sHierarchicalSeparator = "|";

        #endregion

        #region Property Identification

        public string Name { get; protected set; }

        public abstract Type PropertyDataType { get; }
        public Type GetPropertyDataType()
        {
            return PropertyDataType;
        }
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

        public string GetLabel(bool pReturnNameIfEmpty = true)
        {
            throw new NotImplementedException();
        }

        public void SetLabel(string pLabel)
        {
            throw new NotImplementedException();
        }

        private FbxObject _parentFbxObject;
        public FbxObject ParentFbxObject
        {
            get { return _parentFbxObject; }
            set
            {
                if (value != _parentFbxObject)
                {
                    if (_parentFbxObject != null)
                    {
                        _parentFbxObject.Properties.Remove(this);
                    }

                    _parentFbxObject = value;

                    if (_parentFbxObject != null)
                    {
                        _parentFbxObject.Properties.Add(this);
                    }
                }
            }
        }
        public FbxObject GetFbxObject()
        {
            return ParentFbxObject;
        }

        #endregion

        #region Value Management

        public static readonly Dictionary<Tuple<Type,Type>, Func<object, object>> Converters = new Dictionary<Tuple<Type, Type>, Func<object, object>>();
        public static void AddConverter(Type from, Type to, Func<object, object> converter)
        {
            Converters.Add(new Tuple<Type, Type>(from, to), converter);
        }

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

        public virtual bool IsValid()
        {
            return true;
        }

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

        #region Hierarchical Properties

        private Property _parentProperty;
        public Property ParentProperty
        {
            get { return _parentProperty; }
            set
            {
                if (value != _parentProperty)
                {
                    if (_parentProperty != null)
                    {
                        _parentProperty.Children.Remove(this);
                    }

                    _parentProperty = value;

                    if (_parentProperty != null)
                    {
                        _parentProperty.Children.Add(this);
                    }
                }
            }
        }

        public readonly PropertyChildrenCollection Children;

        public bool IsRoot()
        {
            return (ParentProperty == null);
        }

        public bool IsChildOf(Property pParent)
        {
            return (ParentProperty == pParent);
        }

        public bool IsDescendentOf(Property pAncestor)
        {
            var c = ParentProperty;
            while (c != null)
            {
                if (c == pAncestor) return true;

                c = c.GetParent();
            }

            return false;
        }

        public Property GetParent()
        {
            return ParentProperty;
        }

        public /*FBX_DEPRECATED*/ bool SetParent(Property pOther)
        {
            //throw new NotImplementedException();
            //ParentProperty = pOther;
            return false;
        }

        public Property GetChild()
        {
            return Children.FirstOrDefault();
        }

        public Property GetSibling()
        {
            if (GetParent() == null) return null;

            return GetParent().GetNextDescendent(this);
        }

        public Property GetFirstDescendent()
        {
            return Children.FirstOrDefault();
        }

        public Property GetNextDescendent(Property pProperty)
        {
            if (pProperty.ParentProperty != this) return null;

            var index = Children.IndexOf(pProperty);
            if (index + 1 >= Children.Count) return null;

            return Children[index + 1];
        }

        public Property Find(string pName, bool pCaseSensitive = true)
        {
            throw new NotImplementedException();
        }

        //public Property Find(string pName, FbxDataType &pDataType, bool pCaseSensitive=true)
        //{
        //    throw new NotImplementedException();
        //}

        public Property FindHierarchical(string pName, bool pCaseSensitive = true)
        {
            throw new NotImplementedException();
        }

        //public Property FindHierarchical(string pName, FbxDataType &pDataType, bool pCaseSensitive=true)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        #region Animation Curve Management

        public AnimEvaluator GetAnimationEvaluator()
        {
            throw new NotImplementedException();
        }

        public bool IsAnimated(AnimLayer pAnimLayer=null)
        {
            // TODO: curve node shouold have channels and curves attached
            // TODO: curve node should be attached to scene, stack, and layer
            // TODO: pAnimLayer parameter
            return (GetCurveNode() != null);
        }

        public T EvaluateValue<T>()
        {
            return EvaluateValue<T>(FbxTime.Infinite);
        }
        public T EvaluateValue<T>(FbxTime pTime, bool pForceEval=false)
        {
            if (IsAnimated())
            {
                var acn = GetCurveNode();
                float[] values = new float[4]{0,0,0,0};
                uint i;
                for (i = 0; i < Math.Min(4, acn.GetChannelsCount()); i++)
                {
                    if (acn.GetCurveCount(i) < 1) throw new NotImplementedException();
                    var curve = acn.GetCurve(i);
                    values[i] = curve.Evaluate(pTime);
                }

                var type = typeof(T);

                if (type == typeof(float))
                    return (T)(object)values[0];
                if (type ==  typeof(double))
                    return (T)(object)(double)values[0];
                if (type ==  typeof(Vector2))
                    return (T)(object)(new Vector2(values[0], values[1]));
                if (type ==  typeof(Vector3))
                    return (T)(object)(new Vector3(values[0], values[1], values[2]));
                if (type ==  typeof(Vector4))
                    return (T)(object)(new Vector4(values[0], values[1], values[2], values[3]));

                throw new NotImplementedException();
            }
            else
            {
                return Get<T>();
            }
        }

        public /*FbxPropertyValue*/object EvaluateValue()
        {
            return EvaluateValue(FbxTime.Infinite);
        }
        public /*FbxPropertyValue*/object EvaluateValue(FbxTime pTime, bool pForceEval=false)
        {
            throw new NotImplementedException();
        }

        public AnimCurveNode CreateCurveNode(AnimLayer pAnimLayer)
        {
            throw new NotImplementedException();
        }

        public AnimCurveNode GetCurveNode(bool pCreate=false)
        {
            return (AnimCurveNode)SrcObjects.FirstOrDefault(x => x is AnimCurveNode);
        }

        public AnimCurveNode GetCurveNode(AnimStack pAnimStack, bool pCreate=false)
        {
            throw new NotImplementedException();
        }

        public AnimCurveNode GetCurveNode(AnimLayer pAnimLayer, bool pCreate=false)
        {
            throw new NotImplementedException();
        }

        public AnimCurve GetCurve(AnimLayer pAnimLayer, bool pCreate=false)
        {
            throw new NotImplementedException();
        }

        public AnimCurve GetCurve(AnimLayer pAnimLayer, string pChannel, bool pCreate=false)
        {
            throw new NotImplementedException();
        }

        public AnimCurve GetCurve(AnimLayer pAnimLayer, string pName, string pChannel, bool pCreate)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region General Object Connection and Relationship Management

        public readonly PropertySrcObjectCollection SrcObjects;
        public readonly PropertyDstObjectCollection DstObjects;

        public bool ConnectSrcObject(FbxObject pObject/*, Connection.EType pType=Connection.EType.None*/)
        {
            if (SrcObjects.Contains(pObject))
                return false;

            SrcObjects.Add(pObject);

            return true;
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
            foreach (var src in SrcObjects.ToArray())
            {
                DisconnectSrcObject(src);
            }
            return true;
        }

        //public bool DisconnectAllSrcObject(FbxCriteria pCriteria)
        //{
        //    throw new NotImplementedException();
        //}

        public int GetSrcObjectCount()
        {
            return SrcObjects.Count;
        }

        //public int GetSrcObjectCount(FbxCriteria pCriteria)
        //{
        //    throw new NotImplementedException();
        //}

        public FbxObject GetSrcObject(int pIndex=0)
        {
            return SrcObjects[pIndex];
        }

        //public FbxObject GetSrcObject(FbxCriteria pCriteria, int pIndex=0)
        //{
        //    throw new NotImplementedException();
        //}

        public FbxObject FindSrcObject(string pName, int pStartIndex=0)
        {
            throw new NotImplementedException();
        }

        //public FbxObject FindSrcObject(FbxCriteria pCriteria, string pName, int pStartIndex=0)
        //{
        //    throw new NotImplementedException();
        //}

        public bool DisconnectAllSrcObject<T>()
            where T : FbxObject
        {
            throw new NotImplementedException();
        }

        //public bool DisconnectAllSrcObject<T>(FbxCriteria pCriteria)
        //    where T : FbxObject
        //{
        //    throw new NotImplementedException();
        //}

        public int GetSrcObjectCount<T>()
            where T : FbxObject
        {
            throw new NotImplementedException();
        }

        //public int GetSrcObjectCount<T>(FbxCriteria pCriteria)
        //    where T : FbxObject
        //{
        //    throw new NotImplementedException();
        //}

        public T GetSrcObject<T>(int pIndex=0)
            where T : FbxObject
        {
            throw new NotImplementedException();
        }

        //public T GetSrcObject<T>(FbxCriteria pCriteria, int pIndex=0)
        //    where T : FbxObject
        //{
        //    throw new NotImplementedException();
        //}

        public T FindSrcObject<T>(string pName, int pStartIndex=0)
            where T : FbxObject
        {
            throw new NotImplementedException();
        }

        //public T FindSrcObject<T>(FbxCriteria pCriteria, string pName, int pStartIndex=0)
        //    where T : FbxObject
        //{
        //    throw new NotImplementedException();
        //}

        public bool ConnectDstObject(FbxObject pObject, Connection.EType pType=Connection.EType.None)
        {
            if (DstObjects.Contains(pObject))
                return false;

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
            foreach (var dst in DstObjects.ToArray())
            {
                DisconnectDstObject(dst);
            }
            return true;
        }

        //public bool DisconnectAllDstObject(FbxCriteria pCriteria)
        //{
        //    throw new NotImplementedException();
        //}

        public int GetDstObjectCount()
        {
            return DstObjects.Count;
        }

        //public int GetDstObjectCount(FbxCriteria pCriteria)
        //{
        //    throw new NotImplementedException();
        //}

        public FbxObject GetDstObject(int pIndex=0)
        {
            return DstObjects[pIndex];
        }

        //public FbxObject GetDstObject(FbxCriteria pCriteria, int pIndex=0)
        //{
        //    throw new NotImplementedException();
        //}

        public FbxObject FindDstObject(string pName, int pStartIndex=0)
        {
            throw new NotImplementedException();
        }

        //public FbxObject FindDstObject(FbxCriteria pCriteria, string pName, int pStartIndex=0)
        //{
        //    throw new NotImplementedException();
        //}

        public bool DisconnectAllDstObject<T>()
            where T : FbxObject
        {
            throw new NotImplementedException();
        }

        //public bool DisconnectAllDstObject<T>(FbxCriteria pCriteria)
        //    where T : FbxObject
        //{
        //    throw new NotImplementedException();
        //}

        public int GetDstObjectCount<T>()
            where T : FbxObject
        {
            throw new NotImplementedException();
        }

        //public int GetDstObjectCount<T>(FbxCriteria pCriteria)
        //    where T : FbxObject
        //{
        //    throw new NotImplementedException();
        //}

        public T GetDstObject<T>(int pIndex=0)
            where T : FbxObject
        {
            throw new NotImplementedException();
        }

        //public T GetDstObject<T>(FbxCriteria pCriteria, int pIndex=0)
        //    where T : FbxObject
        //{
        //    throw new NotImplementedException();
        //}

        public T FindDstObject<T>(string pName, int pStartIndex=0)
            where T : FbxObject
        {
            throw new NotImplementedException();
        }

        //public T FindDstObject<T>(FbxCriteria pCriteria, string pName, int pStartIndex=0)
        //    where T : FbxObject
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        #region General Property Connection and Relationship Management

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
            throw new NotImplementedException();
        }

        public void ClearConnectCache()
        {
            throw new NotImplementedException();
        }

        public Property GetSrcProperty(int pIndex=0)
        {
            throw new NotImplementedException();
        }

        public Property FindSrcProperty(string pName, int pStartIndex=0)
        {
            throw new NotImplementedException();
        }

        public Property GetDstProperty(int pIndex=0)
        {
            throw new NotImplementedException();
        }

        public Property FindDstProperty(string pName, int pStartIndex=0)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

