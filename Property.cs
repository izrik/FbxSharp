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
        }

        protected Property(string name)
        {
            Name = name;

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
            throw new NotImplementedException();
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

