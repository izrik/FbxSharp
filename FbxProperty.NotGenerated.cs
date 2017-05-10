using System;
using System.Collections.Generic;
using System.Linq;

namespace FbxSharp
{
    public abstract class FbxProperty
    {
        static FbxProperty()
        {
            AddConverter(typeof(FbxVector4), typeof(FbxVector3), (v4) => ((FbxVector4)v4).ToVector3());
            AddConverter(typeof(FbxVector3), typeof(FbxVector4), (v3) => ((FbxVector3)v3).ToVector4());
        }

        protected FbxProperty(string name)
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

        public static bool HasDefaultValue(FbxProperty pProperty)
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

        public FbxPropertyFlags.EInheritType GetValueInheritType()
        {
            throw new NotImplementedException();
        }

        public bool SetValueInheritType(FbxPropertyFlags.EInheritType pType)
        {
            throw new NotImplementedException();
        }

        public bool Modified()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Hierarchical Properties

        private FbxProperty _parentProperty;
        public FbxProperty ParentProperty
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

        public bool IsChildOf(FbxProperty pParent)
        {
            return (ParentProperty == pParent);
        }

        public bool IsDescendentOf(FbxProperty pAncestor)
        {
            var c = ParentProperty;
            while (c != null)
            {
                if (c == pAncestor) return true;

                c = c.GetParent();
            }

            return false;
        }

        public FbxProperty GetParent()
        {
            return ParentProperty;
        }

        public /*FBX_DEPRECATED*/ bool SetParent(FbxProperty pOther)
        {
            //throw new NotImplementedException();
            //ParentProperty = pOther;
            return false;
        }

        public FbxProperty GetChild()
        {
            return Children.FirstOrDefault();
        }

        public FbxProperty GetSibling()
        {
            if (GetParent() == null) return null;

            return GetParent().GetNextDescendent(this);
        }

        public FbxProperty GetFirstDescendent()
        {
            return Children.FirstOrDefault();
        }

        public FbxProperty GetNextDescendent(FbxProperty pProperty)
        {
            if (pProperty.ParentProperty != this) return null;

            var index = Children.IndexOf(pProperty);
            if (index + 1 >= Children.Count) return null;

            return Children[index + 1];
        }

        public FbxProperty Find(string pName, bool pCaseSensitive = true)
        {
            throw new NotImplementedException();
        }

        //public Property Find(string pName, FbxDataType &pDataType, bool pCaseSensitive=true)
        //{
        //    throw new NotImplementedException();
        //}

        public FbxProperty FindHierarchical(string pName, bool pCaseSensitive = true)
        {
            throw new NotImplementedException();
        }

        //public Property FindHierarchical(string pName, FbxDataType &pDataType, bool pCaseSensitive=true)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        #region Animation Curve Management

        public FbxAnimEvaluator GetAnimationEvaluator()
        {
            throw new NotImplementedException();
        }

        public bool IsAnimated(FbxAnimLayer pAnimLayer=null)
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
                    if (acn.GetCurveCount(i) < 1)
                        //throw new NotImplementedException(
                        //    string.Format(
                        //        "The AnimCurveNode channel #{0} doesn't have any curves attached", i));
                        continue;

                    var curve = acn.GetCurve(i);
                    values[i] = curve.Evaluate(pTime);
                }

                var type = typeof(T);

                if (type == typeof(float))
                    return (T)(object)values[0];
                if (type ==  typeof(double))
                    return (T)(object)(double)values[0];
                if (type ==  typeof(FbxVector2))
                    return (T)(object)(new FbxVector2(values[0], values[1]));
                if (type ==  typeof(FbxVector3))
                    return (T)(object)(new FbxVector3(values[0], values[1], values[2]));
                if (type ==  typeof(FbxVector4))
                    return (T)(object)(new FbxVector4(values[0], values[1], values[2], values[3]));

                throw new NotImplementedException(
                    string.Format(
                        "The property \"{0}\" cannot be evaluated because " +
                            "the type is not a float, double, or vector",
                        this.Name));
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

        public FbxAnimCurveNode CreateCurveNode(FbxAnimLayer pAnimLayer)
        {
            throw new NotImplementedException();
        }

        public FbxAnimCurveNode GetCurveNode(bool pCreate=false)
        {
            if (this.ParentFbxObject == null || this.ParentFbxObject.Scene == null) return null;
            var stack = this.ParentFbxObject.Scene.GetCurrentAnimationStack();
            return GetCurveNode(stack);
        }

        public FbxAnimCurveNode GetCurveNode(FbxAnimStack pAnimStack, bool pCreate=false)
        {
            if (pAnimStack == null) return null;

            var currentLayers = new HashSet<FbxAnimLayer>(pAnimStack.GetSrcObjects<FbxAnimLayer>());

            return (FbxAnimCurveNode)SrcObjects.FirstOrDefault(x =>
            {
                if (!(x is FbxAnimCurveNode)) return false;
                var acn = (FbxAnimCurveNode)x;
                var layers = new HashSet<FbxAnimLayer>(acn.GetDstObjects<FbxAnimLayer>());
                return layers.Intersect(currentLayers).Any();
            });
        }

        public FbxAnimCurveNode GetCurveNode(FbxAnimLayer pAnimLayer, bool pCreate=false)
        {
            throw new NotImplementedException();
        }

        public FbxAnimCurve GetCurve(FbxAnimLayer pAnimLayer, bool pCreate=false)
        {
            throw new NotImplementedException();
        }

        public FbxAnimCurve GetCurve(FbxAnimLayer pAnimLayer, string pChannel, bool pCreate=false)
        {
            throw new NotImplementedException();
        }

        public FbxAnimCurve GetCurve(FbxAnimLayer pAnimLayer, string pName, string pChannel, bool pCreate)
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

        public bool ConnectDstObject(FbxObject pObject, FbxConnection.EType pType=FbxConnection.EType.None)
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

        public bool ConnectSrcProperty(FbxProperty pProperty)
        {
            throw new NotImplementedException();
        }

        public bool IsConnectedSrcProperty(FbxProperty pProperty)
        {
            throw new NotImplementedException();
        }

        public bool DisconnectSrcProperty(FbxProperty pProperty)
        {
            throw new NotImplementedException();
        }

        public int GetSrcPropertyCount()
        {
            throw new NotImplementedException();
        }

        public bool ConnectDstProperty(FbxProperty pProperty)
        {
            throw new NotImplementedException();
        }

        public bool IsConnectedDstProperty(FbxProperty pProperty)
        {
            throw new NotImplementedException();
        }

        public bool DisconnectDstProperty(FbxProperty pProperty)
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

        public FbxProperty GetSrcProperty(int pIndex=0)
        {
            throw new NotImplementedException();
        }

        public FbxProperty FindSrcProperty(string pName, int pStartIndex=0)
        {
            throw new NotImplementedException();
        }

        public FbxProperty GetDstProperty(int pIndex=0)
        {
            throw new NotImplementedException();
        }

        public FbxProperty FindDstProperty(string pName, int pStartIndex=0)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

