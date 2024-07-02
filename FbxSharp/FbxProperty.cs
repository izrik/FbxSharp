using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FbxSharp
{
    public abstract class FbxProperty
    {
        [NotSdk]
        public class NotValidT
        {
        }

        [NotSdk]
        public static readonly FbxProperty NotValid =
            FbxPropertyT<NotValidT>.StaticInit((FbxProperty)null, null, null,
                null, false);

        [NotSdk]
        static FbxProperty()
        {
            AddConverter(typeof(FbxVector4), typeof(FbxVector3), (v4) => ((FbxVector4)v4).ToVector3());
            AddConverter(typeof(FbxVector3), typeof(FbxVector4), (v3) => ((FbxVector3)v3).ToVector4());
        }

        [NotSdk]
        public override string ToString()
        {
            return string.Format("{0}: {1}", Name, GetValue());
        }

        #region Public Member Functions

        public bool CopyValue(FbxProperty pProperty) =>
            throw new NotImplementedException();

        #endregion

        #region Static Public Attributes

        public static string sHierarchicalSeparator = "|";

        #endregion

        #region Constructor and Destructor

        [DeviationFromSdk(
            "static FbxProperty Create(" +
            "const FbxProperty &pCompoundProperty, " +
            "const FbxDataType &pDataType, " +
            "const char *pName, " +
            "const char *pLabel=\"\", " +
            "bool pCheckForDup=true, " +
            "bool *pWasFound=((void *) 0))")]
        public static FbxProperty Create(FbxProperty pCompoundProperty,
            FbxDataType pDataType, string pName, string pLabel = "",
            bool pCheckForDup = true) =>
            Create(pCompoundProperty, pDataType, pName, pLabel,
                pCheckForDup, out _);

        [DeviationFromSdk(
            "static FbxProperty Create(" +
            "const FbxProperty &pCompoundProperty, " +
            "const FbxDataType &pDataType, " +
            "const char *pName, " +
            "const char *pLabel=\"\", " +
            "bool pCheckForDup=true, " +
            "bool *pWasFound=((void *) 0))")]
        public static FbxProperty Create(FbxProperty pCompoundProperty,
            FbxDataType pDataType, string pName, out bool pWasFound) =>
            Create(pCompoundProperty, pDataType, pName, "",
                true, out pWasFound);

        [DeviationFromSdk(
            "static FbxProperty Create(" +
            "const FbxProperty &pCompoundProperty, " +
            "const FbxDataType &pDataType, " +
            "const char *pName, " +
            "const char *pLabel=\"\", " +
            "bool pCheckForDup=true, " +
            "bool *pWasFound=((void *) 0))")]
        public static FbxProperty Create(FbxProperty pCompoundProperty,
            FbxDataType pDataType, string pName, bool pCheckForDup,
            out bool pWasFound) =>
            Create(pCompoundProperty, pDataType, pName, "",
                pCheckForDup, out pWasFound);

        [DeviationFromSdk(
            "static FbxProperty Create(" +
            "const FbxProperty &pCompoundProperty, " +
            "const FbxDataType &pDataType, " +
            "const char *pName, " +
            "const char *pLabel=\"\", " +
            "bool pCheckForDup=true, " +
            "bool *pWasFound=((void *) 0))")]
        public static FbxProperty Create(FbxProperty pCompoundProperty,
            FbxDataType pDataType, string pName, string pLabel,
            out bool pWasFound) =>
            Create(pCompoundProperty, pDataType, pName, pLabel,
                true, out pWasFound);

        [DeviationFromSdk(
            "static FbxProperty Create(" +
            "const FbxProperty &pCompoundProperty, " +
            "const FbxDataType &pDataType, " +
            "const char *pName, " +
            "const char *pLabel=\"\", " +
            "bool pCheckForDup=true, " +
            "bool *pWasFound=((void *) 0))")]
        public static FbxProperty Create(FbxProperty pCompoundProperty,
            FbxDataType pDataType, string pName, string pLabel,
            bool pCheckForDup, out bool pWasFound)
        {
            var prop = FromFbxDataType(pCompoundProperty, pDataType, pName, default);
            prop.SetLabel(pLabel);
            prop.SetParent(pCompoundProperty);
            pWasFound = false;
            return prop;
        }

        [DeviationFromSdk(
            "static FbxProperty Create(" +
            "FbxObject *pObject, " +
            "const FbxDataType &pDataType, " +
            "const char *pName, " +
            "const char *pLabel=\"\", " +
            "bool pCheckForDup=true, " +
            "bool *pWasFound=((void *) 0))")]
        public static FbxProperty Create(FbxObject pObject,
            FbxDataType pDataType, string pName, string pLabel = "",
            bool pCheckForDup = true) =>
            Create(pObject, pDataType, pName, pLabel, pCheckForDup,
                out _);

        [DeviationFromSdk(
            "static FbxProperty Create(" +
            "FbxObject *pObject, " +
            "const FbxDataType &pDataType, " +
            "const char *pName, " +
            "const char *pLabel=\"\", " +
            "bool pCheckForDup=true, " +
            "bool *pWasFound=((void *) 0))")]
        public static FbxProperty Create(FbxObject pObject,
            FbxDataType pDataType, string pName, out bool pWasFound) =>
            Create(pObject, pDataType, pName, "", true,
                out pWasFound);

        [DeviationFromSdk(
            "static FbxProperty Create(" +
            "FbxObject *pObject, " +
            "const FbxDataType &pDataType, " +
            "const char *pName, " +
            "const char *pLabel=\"\", " +
            "bool pCheckForDup=true, " +
            "bool *pWasFound=((void *) 0))")]
        public static FbxProperty Create(FbxObject pObject,
            FbxDataType pDataType, string pName, string pLabel,
            out bool pWasFound) =>
            Create(pObject, pDataType, pName, pLabel, true,
                out pWasFound);

        [DeviationFromSdk(
            "static FbxProperty Create(" +
            "FbxObject *pObject, " +
            "const FbxDataType &pDataType, " +
            "const char *pName, " +
            "const char *pLabel=\"\", " +
            "bool pCheckForDup=true, " +
            "bool *pWasFound=((void *) 0))")]
        public static FbxProperty Create(FbxObject pObject,
            FbxDataType pDataType, string pName, bool pCheckForDup,
            out bool pWasFound) =>
            Create(pObject, pDataType, pName, "", pCheckForDup,
                out pWasFound);

        [DeviationFromSdk(
            "static FbxProperty Create(" +
            "FbxObject *pObject, " +
            "const FbxDataType &pDataType, " +
            "const char *pName, " +
            "const char *pLabel=\"\", " +
            "bool pCheckForDup=true, " +
            "bool *pWasFound=((void *) 0))")]
        public static FbxProperty Create(FbxObject pObject,
            FbxDataType pDataType, string pName, string pLabel,
            bool pCheckForDup, out bool pWasFound)
        {
            var prop = FromFbxDataType(pObject.RootProperty, pDataType,
                pName);
            prop.SetLabel(pLabel);
            pWasFound = false;
            return prop;
        }

        public static FbxProperty CreateFrom(FbxProperty pCompoundProperty,
            FbxProperty pFromProperty, bool pCheckForDup = true) =>
            throw new NotImplementedException();

        public static FbxProperty CreateFrom(FbxObject pObject,
            FbxProperty pFromProperty, bool pCheckForDup = true) =>
            throw new NotImplementedException();

        public void Destroy() => throw new NotImplementedException();

        public void DestroyRecursively() => throw new NotImplementedException();

        public void DestroyChildren() => throw new NotImplementedException();

        public FbxProperty() => throw new NotImplementedException();

        public FbxProperty(FbxProperty pProperty) =>
            throw new NotImplementedException();

        public FbxProperty(FbxPropertyHandle pPropertyHandle) =>
            throw new NotImplementedException();

        [NotSdk]
        protected FbxProperty(string name, EFbxType fbxType)
            : this(name, FbxDataType.FbxGetDataTypeFromEnum(fbxType))
        {
        }

        [NotSdk]
        protected FbxProperty(string name, FbxDataType dataType)
        {
            Name = name;
            fbxDataType = dataType;

            Children = new PropertyChildrenCollection(this);
            SrcObjects = new PropertySrcObjectCollection(this);
            DstObjects = new PropertyDstObjectCollection(this);
        }

        [NotSdk]
        protected static FbxProperty FromFbxDataType(FbxProperty parent,
            FbxDataType dataType, string name)
        {
            switch (dataType.GetFbxType())
            {
                case EFbxType.eFbxChar:
                    return FbxPropertyT<char>.StaticInit(parent, name, dataType,
                        default);
                case EFbxType.eFbxUChar:
                    return FbxPropertyT<byte>.StaticInit(parent, name, dataType,
                        default);
                case EFbxType.eFbxShort:
                    return FbxPropertyT<short>.StaticInit(parent, name,
                        dataType, default);
                case EFbxType.eFbxUShort:
                    return FbxPropertyT<ushort>.StaticInit(parent, name,
                        dataType, default);
                case EFbxType.eFbxUInt:
                    return FbxPropertyT<uint>.StaticInit(parent, name, dataType,
                        default);
                case EFbxType.eFbxLongLong:
                    return FbxPropertyT<long>.StaticInit(parent, name, dataType,
                        default);
                case EFbxType.eFbxULongLong:
                    return FbxPropertyT<ulong>.StaticInit(parent, name,
                        dataType, default);
                case EFbxType.eFbxHalfFloat:
                    return FbxPropertyT<Half>.StaticInit(parent, name, dataType,
                        default);
                case EFbxType.eFbxBool:
                    return FbxPropertyT<bool>.StaticInit(parent, name, dataType,
                        default);
                case EFbxType.eFbxInt:
                    return FbxPropertyT<int>.StaticInit(parent, name, dataType,
                        default);
                case EFbxType.eFbxFloat:
                    return FbxPropertyT<float>.StaticInit(parent, name,
                        dataType, default);
                case EFbxType.eFbxDouble:
                    return FbxPropertyT<double>.StaticInit(parent, name,
                        dataType, default);
                case EFbxType.eFbxDouble2:
                    return FbxPropertyT<FbxVector2>.StaticInit(parent, name,
                        dataType, default);
                case EFbxType.eFbxDouble3:
                    return FbxPropertyT<FbxVector3>.StaticInit(parent, name,
                        dataType, default);
                case EFbxType.eFbxDouble4:
                    return FbxPropertyT<FbxVector4>.StaticInit(parent, name,
                        dataType, default);
                case EFbxType.eFbxDouble4x4:
                    return FbxPropertyT<FbxMatrix>.StaticInit(parent, name,
                        dataType, default);

                case EFbxType.eFbxEnum:
                case EFbxType.eFbxEnumM:
                    return new FbxPropertyTEnum(name);

                case EFbxType.eFbxString:
                    return FbxPropertyT<string>.StaticInit(parent, name,
                        dataType, default);
                case EFbxType.eFbxTime:
                    return FbxPropertyT<FbxTime>.StaticInit(parent, name,
                        dataType, default);
                case EFbxType.eFbxReference:
                    return FbxPropertyT<FbxObject>.StaticInit(parent, name,
                        dataType, default);

                case EFbxType.eFbxBlob:
                case EFbxType.eFbxDistance:
                    throw new NotImplementedException();

                case EFbxType.eFbxDateTime:
                    return FbxPropertyT<FbxDateTime>.StaticInit(parent, name,
                        dataType, default);

                case EFbxType.eFbxUndefined:
                    // TODO: FbxPropertyTUndefined
                    return FbxPropertyT<object>.StaticInit(parent, name,
                        dataType, default);

                case EFbxType.eFbxTypeCount:
                default:
                    throw new ArgumentOutOfRangeException(
                        paramName: nameof(dataType), dataType, null);
            }
        }

        [NotSdk]
        protected static FbxProperty FromFbxDataType(FbxProperty parent,
            FbxDataType dataType, string name, object value)
        {
            switch (dataType.GetFbxType())
            {
                case EFbxType.eFbxChar:
                    return FbxPropertyT<char>.StaticInit(parent, name, dataType,
                        value == null ? default : (char)value);
                case EFbxType.eFbxUChar:
                    return FbxPropertyT<byte>.StaticInit(parent, name, dataType,
                        value == null ? default : (byte)value);
                case EFbxType.eFbxShort:
                    return FbxPropertyT<short>.StaticInit(parent, name,
                        dataType, value == null ? default : (short)value);
                case EFbxType.eFbxUShort:
                    return FbxPropertyT<ushort>.StaticInit(parent, name,
                        dataType, value == null ? default : (ushort)value);
                case EFbxType.eFbxUInt:
                    return FbxPropertyT<uint>.StaticInit(parent, name, dataType,
                        value == null ? default : (uint)value);
                case EFbxType.eFbxLongLong:
                    return FbxPropertyT<long>.StaticInit(parent, name, dataType,
                        value == null ? default : (long)value);
                case EFbxType.eFbxULongLong:
                    return FbxPropertyT<ulong>.StaticInit(parent, name,
                        dataType, value == null ? default : (ulong)value);
                case EFbxType.eFbxHalfFloat:
                    return FbxPropertyT<Half>.StaticInit(parent, name, dataType,
                        value == null ? default : (Half)value);
                case EFbxType.eFbxBool:
                    return FbxPropertyT<bool>.StaticInit(parent, name, dataType,
                        value == null ? default : (bool)value);
                case EFbxType.eFbxInt:
                    return FbxPropertyT<int>.StaticInit(parent, name, dataType,
                        value == null ? default : value == null ? default : (int)value);
                case EFbxType.eFbxFloat:
                    return FbxPropertyT<float>.StaticInit(parent, name,
                        dataType, value == null ? default : (float)value);
                case EFbxType.eFbxDouble:
                    return FbxPropertyT<double>.StaticInit(parent, name,
                        dataType, value == null ? default : (double)value);
                case EFbxType.eFbxDouble2:
                    return FbxPropertyT<FbxVector2>.StaticInit(parent, name,
                        dataType, value == null ? default : (FbxVector2)value);
                case EFbxType.eFbxDouble3:
                    return FbxPropertyT<FbxVector3>.StaticInit(parent, name,
                        dataType, value == null ? default : (FbxVector3)value);
                case EFbxType.eFbxDouble4:
                    return FbxPropertyT<FbxVector4>.StaticInit(parent, name,
                        dataType, value == null ? default : (FbxVector4)value);
                case EFbxType.eFbxDouble4x4:
                    return FbxPropertyT<FbxMatrix>.StaticInit(parent, name,
                        dataType, value == null ? default : (FbxMatrix)value);

                case EFbxType.eFbxEnum:
                case EFbxType.eFbxEnumM:
                    return new FbxPropertyTEnum(name);

                case EFbxType.eFbxString:
                    return FbxPropertyT<string>.StaticInit(parent, name,
                        dataType, (string)value );
                case EFbxType.eFbxTime:
                    return FbxPropertyT<FbxTime>.StaticInit(parent, name,
                        dataType, value == null ? default : (FbxTime)value);
                case EFbxType.eFbxReference:
                    return FbxPropertyT<FbxObject>.StaticInit(parent, name,
                        dataType,(FbxObject)value);

                case EFbxType.eFbxBlob:
                case EFbxType.eFbxDistance:
                    throw new NotImplementedException();

                case EFbxType.eFbxDateTime:
                    return FbxPropertyT<FbxDateTime>.StaticInit(parent, name,
                        dataType, value == null ? default : (FbxDateTime)value);

                case EFbxType.eFbxUndefined:
                    // TODO: FbxPropertyTUndefined
                    return FbxPropertyT<object>.StaticInit(parent, name,
                        dataType, (object)value);

                case EFbxType.eFbxTypeCount:
                default:
                    throw new ArgumentOutOfRangeException(
                        paramName: nameof(dataType), dataType, null);
            }
        }

        ~FbxProperty()
        {
            // Note: C# finalizers are not the same thing as C++ destructors.
        }

        # endregion

        #region Property Identification

        [NotSdk] public string Name { get; }

        [NotSdk]
        public Type PropertyDataType =>
            GetPropertyDataType().GetFbxType().ToDotnetType();

        private readonly FbxDataType fbxDataType;
        public FbxDataType GetPropertyDataType() => fbxDataType;

        [NotSdk]
        public abstract Type GetDotnetType();

        //public Object FbxObject { get; protected set; }

        public string GetName()
        {
            return Name;
        }

        public string GetHierarchicalName()
        {
            var names = new List<string>();
            var p = this;
            names.Add(p.GetName());
            while (p.GetParent() != null &&
                   p.GetParent().IsValid() &&
                   !p.GetParent().IsRoot())
            {
                p = p.GetParent();
                names.Insert(0, p.GetName());
            }

            var sb = new StringBuilder();
            var first = true;
            foreach (var name in names)
            {
                if (!first)
                    sb.Append(sHierarchicalSeparator);
                first = false;
                sb.Append(name);
            }

            return sb.ToString();
        }

        private string label;
        public string GetLabel(bool pReturnNameIfEmpty = true)
        {
            return label ?? "";
        }

        public void SetLabel(string pLabel)
        {
            label = pLabel ?? "";
        }

        public virtual FbxObject GetFbxObject()
        {
            var parent = GetParent();
            if (parent != null && parent.IsValid())
                return GetParent().GetFbxObject();
            return null;
        }

        #endregion

        #region User data

        public void SetUserTag(int pTag) => throw new NotImplementedException();
        public int GetUserTag() => throw new NotImplementedException();

        public void SetUserDataPtr(object pUserData) =>
            throw new NotImplementedException();

        public object GetUserDataPtr() => throw new NotImplementedException();

        #endregion

        #region Property Flags.

        public void ModifyFlag(FbxPropertyFlags.EFlags pFlag, bool pValue) =>
            throw new NotImplementedException();

        public bool GetFlag(FbxPropertyFlags.EFlags pFlag) =>
            throw new NotImplementedException();

        public FbxPropertyFlags.EFlags GetFlags() =>
            throw new NotImplementedException();

        public FbxPropertyFlags.EInheritType GetFlagInheritType(
            FbxPropertyFlags.EFlags pFlag) =>
            throw new NotImplementedException();

        public bool SetFlagInheritType(FbxPropertyFlags.EFlags pFlag,
            FbxPropertyFlags.EInheritType pType) =>
            throw new NotImplementedException();

        public bool ModifiedFlag(FbxPropertyFlags.EFlags pFlag) =>
            throw new NotImplementedException();

        #endregion

        #region Assignment and comparison operators

        // public FbxProperty operator= (FbxProperty pProperty) =>
        //     throw new NotImplementedException();
        //
        // public bool operator ==(FbxProperty &pProperty) =>
        //     throw new NotImplementedException();
        //
        // public bool operator !=(FbxProperty &pProperty) =>
        //     throw new NotImplementedException();
        //
        // public bool operator <(FbxProperty &pProperty) =>
        //     throw new NotImplementedException();
        //
        // public bool operator >(FbxProperty &pProperty) =>
        //     throw new NotImplementedException();
        //
        // public bool operator ==(int pValue) =>
        //     throw new NotImplementedException();
        //
        // public bool operator !=(int pValue) =>
        //     throw new NotImplementedException();

        public bool CompareValue(FbxProperty pProperty) =>
            throw new NotImplementedException();

        #endregion

        #region Value Management

        public static readonly
            Dictionary<Tuple<Type, Type>, Func<object, object>> Converters =
                new();
        [NotSdk]
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
            if (this == FbxProperty.NotValid)
                return false;
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

        #region Property Limits.

        public bool SupportSetLimitAsDouble() =>
            throw new NotImplementedException();

        public bool SetMinLimit(double pMin) =>
            throw new NotImplementedException();

        public bool HasMinLimit() => throw new NotImplementedException();
        public double GetMinLimit() => throw new NotImplementedException();
        public bool HasMaxLimit() => throw new NotImplementedException();

        public bool SetMaxLimit(double pMax) =>
            throw new NotImplementedException();

        public double GetMaxLimit() => throw new NotImplementedException();

        public bool SetLimits(double pMin, double pMax) =>
            throw new NotImplementedException();

        #endregion

        #region Enum and property list

        public virtual int AddEnumValue(string pStringValue) =>
            throw new NotImplementedException();

        public virtual void InsertEnumValue(int pIndex, string pStringValue) =>
            throw new NotImplementedException();

        public virtual int GetEnumCount() => throw new NotImplementedException();

        public virtual void SetEnumValue(int pIndex, string pStringValue) =>
            throw new NotImplementedException();

        public virtual void RemoveEnumValue(int pIndex) =>
            throw new NotImplementedException();

        public virtual string GetEnumValue(int pIndex) =>
            throw new NotImplementedException();

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

        public virtual bool IsRoot() => false;

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
            return ParentProperty ?? NotValid;
        }

        [NotSdk]
        public void SetParent(FbxProperty pOther)
        {
            ParentProperty = pOther;
        }

        public FbxProperty GetChild()
        {
            return Children.FirstOrDefault() ?? NotValid;
        }

        public FbxProperty GetSibling()
        {
            if (GetParent() == null) return NotValid;

            return GetParent().GetNextDescendent(this) ?? NotValid;
        }

        public FbxProperty GetFirstDescendent()
        {
            return Children.FirstOrDefault() ?? NotValid;
        }

        public FbxProperty GetNextDescendent(FbxProperty pProperty)
        {
            if (pProperty.ParentProperty != this)
                return NotValid;

            var index = Children.IndexOf(pProperty);
            if (index + 1 >= Children.Count)
                return NotValid;

            return Children[index + 1] ?? NotValid;
        }

        public FbxProperty Find(string pName, bool pCaseSensitive = true) =>
            Find(pName, null, pCaseSensitive);

        public FbxProperty Find(string pName, FbxDataType pDataType, bool pCaseSensitive=true)
        {
            foreach (var child in Children)
            {
                // TODO: case-insensitive
                if (child.Name == pName)
                    return child;
            }

            return NotValid;
        }

        public FbxProperty FindHierarchical(string pName,
            bool pCaseSensitive = true)
        {
            var nameComponents = pName.Split(sHierarchicalSeparator);
            return FindHierarchical(nameComponents, 0, null, pCaseSensitive);
        }

        public FbxProperty FindHierarchical(string pName,
            FbxDataType pDataType, bool pCaseSensitive = true)
        {
            var nameComponents = pName.Split(sHierarchicalSeparator);
            return FindHierarchical(nameComponents, 0, pDataType, pCaseSensitive);
        }

        [NotSdk]
        protected FbxProperty FindHierarchical(
            string[] nameComponents, int index,
            FbxDataType pDataType=null, bool pCaseSensitive = true)
        {
            foreach (var child in Children)
            {
                // TODO: case-insensitive
                if (child.Name == nameComponents[index])
                {
                    if (index < nameComponents.Length - 1)
                        return child.FindHierarchical(nameComponents, index + 1,
                            pDataType, pCaseSensitive);

                    if (pDataType != null)
                    {
                        if (child.IsValid() &&
                            child.GetPropertyDataType() == pDataType)
                            return child;
                    }
                    else
                        return child;
                }
            }

            return NotValid;
        }

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
            var obj = GetFbxObject();
            if (obj?.Scene == null)
                return null;
            var stack = obj.Scene.GetCurrentAnimationStack();
            return GetCurveNode(stack);
        }

        public FbxAnimCurveNode GetCurveNode(FbxAnimStack pAnimStack, bool pCreate=false)
        {
            if (pAnimStack == null) return null;

            foreach (var src in SrcObjects)
            {
                if (!(src is FbxAnimCurveNode)) continue;
                var acn = (FbxAnimCurveNode)src;
                int i;
                int n = acn.GetDstObjectCount<FbxAnimLayer>();
                for (i = 0; i < n; i++)
                {
                    var layer = acn.GetDstObject<FbxAnimLayer>(i);
                    int j;
                    for (j = 0; j < pAnimStack.GetSrcObjectCount(); j++)
                    {
                        if (pAnimStack.GetSrcObject(j) == layer)
                            return acn;
                    }
                }
            }
            return null;
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

