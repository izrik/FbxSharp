using System;

namespace FbxSharp;

public class FbxIOSettings : FbxObject
{
    #region Public Types

    public enum ELanguage
    {
        eENU = 0,
        eDEU = 1,
        eFRA = 2,
        eJPN = 3,
        eKOR = 4,
        eCHS = 5,
        ePTB = 6,
        eLanguageCount = 7,
    }

    #endregion

    #region Public Member Functions

    public virtual FbxClassId GetClassId()
    {
        throw new NotImplementedException();
    }

    public FbxProperty AddPropertyGroup(string pName, FbxDataType pDataType,
        string pLabel = "") =>
        AddPropertyGroup(RootProperty, pName, pDataType, pLabel);

    public FbxProperty AddPropertyGroup(FbxProperty pParentProperty,
        string pName, FbxDataType pDataType = null, string pLabel = "",
        bool pVisible = true, bool pSavable = true, bool pEnabled = true)
    {
        var prop =
            FbxProperty.FromEFbxType(pDataType.GetFbxType(), pName);
        if (prop is FbxPropertyT<string> propt)
            propt.Set("");
        if (pParentProperty == null)
            pParentProperty = RootProperty;
        prop.SetParent(pParentProperty);
        prop.SetLabel(pLabel);
        Properties.Add(prop);
        return prop;
    }

    public FbxProperty AddProperty(FbxProperty pParentProperty, string pName,
        FbxDataType pDataType = null, string pLabel = "",
        object pValue = null, bool pVisible = true, bool pSavable = true,
        bool pEnabled = true)
    {
        FbxProperty prop;
        if (pValue == null)
            prop = FbxProperty.FromEFbxType(pDataType.GetFbxType(), pName);
        else
            prop = FbxProperty.FromEFbxType(pDataType.GetFbxType(), pName,
                pValue);
        if (pParentProperty == null)
            pParentProperty = RootProperty;
        prop.SetParent(pParentProperty);
        prop.SetLabel(pLabel);
        Properties.Add(prop);
        return prop;
    }

    public FbxProperty AddPropertyMinMax(FbxProperty pParentProperty,
        string pName, FbxDataType pDataType = null, string pLabel = "",
        object pValue = null, double? pMinValue = null,
        double? pMaxValue = null, bool pVisible = true, bool pSavable = true,
        bool pEnabled = true) =>
        throw new NotImplementedException();

    public FbxProperty GetProperty(string pName)
    {
        if (pName == FbxIOSettingsPath.IOSROOT)
            return RootProperty;
        foreach (var p in Properties)
        {
            if (p.GetHierarchicalName() == pName)
                return p;
        }

        return FbxProperty.NotValid;
    }

    public FbxProperty GetProperty(FbxProperty pParentProperty, string pName)
    {
        throw new NotImplementedException();
    }

    public bool GetBoolProp(string pName, bool pDefValue)
    {
        throw new NotImplementedException();
    }

    public void SetBoolProp(string pName, bool pValue)
    {
        throw new NotImplementedException();
    }

    public double GetDoubleProp(string pName, double pDefValue)
    {
        throw new NotImplementedException();
    }

    public void SetDoubleProp(string pName, double pValue)
    {
        throw new NotImplementedException();
    }

    public int GetIntProp(string pName, int pDefValue)
    {
        throw new NotImplementedException();
    }

    public void SetIntProp(string pName, int pValue)
    {
        throw new NotImplementedException();
    }

    public FbxTime GetTimeProp(string pName, FbxTime pDefValue)
    {
        throw new NotImplementedException();
    }

    public void SetTimeProp(string pName, FbxTime pValue)
    {
        throw new NotImplementedException();
    }

    // public bool SetFlag(string pName, FbxPropertyFlags.EFlags propFlag, bool pValue)
    // {
    // }

    public string GetStringProp(string pName, string pDefValue)
    {
        throw new NotImplementedException();
    }

    public void SetStringProp(string pName, string pValue)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Enum Properties

    public string GetEnumProp(string pName, string pDefValue) =>
        throw new NotImplementedException();

    public int GetEnumProp(string pName, int pDefValue) =>
        throw new NotImplementedException();

    public int GetEnumIndex(string pName, string pValue) =>
        throw new NotImplementedException();

    public void SetEnumProp(string pName, string pValue) =>
        throw new NotImplementedException();

    public void SetEnumProp(string pName, int pValue) =>
        throw new NotImplementedException();

    public void RemoveEnumPropValue(string pName, string pValue) =>
        throw new NotImplementedException();

    public void EmptyEnumProp(string pName) =>
        throw new NotImplementedException();

    public bool IsEnumExist(FbxProperty pProp, string enumString) =>
        throw new NotImplementedException();

    public int GetEnumIndex(FbxProperty pProp, string enumString,
        bool pNoCase = false) => throw new NotImplementedException();

    #endregion

    #region XML Serialization Function

    public virtual bool ReadXMLFile(string path) =>
        throw new NotImplementedException();

    public virtual bool WriteXMLFile(string path) =>
        throw new NotImplementedException();

    public bool WriteXmlPropToFile(string pFullPath, string propPath) =>
        throw new NotImplementedException();

    #endregion

    #region Static Public Member Functions

    static FbxIOSettings Create( /*Manager pManager,*/ string pName) =>
        throw new NotImplementedException();

    static FbxIOSettings Create(FbxObject pContainer, string pName) =>
        throw new NotImplementedException();

    #endregion

    #region Static Public Attributes

    public static FbxClassId ClassId;

    #endregion

    #region Protected Member Functions

    // protected virtual ~FbxIOSettings() => new NotImplementedException();

    [DeviationFromSdk(
        "protected FbxIOSettings(FbxManager *pManager, const char *pName) ")]
    public FbxIOSettings( /*FbxManager pManager,*/ string pName)
        : base(pName)
    {
        // TODO: use public static Create() to create instances, instead of
        //       constructor.
        FbxDataType dt_eFbxBool = new FbxDataType("FbxBool", EFbxType.eFbxBool);
        FbxDataType dt_eFbxDouble =
            new FbxDataType("FbxDouble", EFbxType.eFbxDouble);
        FbxDataType dt_eFbxEnum = new FbxDataType("FbxEnum", EFbxType.eFbxEnum);
        FbxDataType dt_eFbxInt = new FbxDataType("FbxInt", EFbxType.eFbxInt);
        FbxDataType dt_eFbxString =
            new FbxDataType("FbxString", EFbxType.eFbxString);
        FbxDataType dt_eFbxTime = new FbxDataType("FbxTime", EFbxType.eFbxTime);

        FbxProperty prop0, prop1, prop2, prop3, prop4, prop5, prop6;
        prop0 = RootProperty;

        prop1 = AddPropertyGroup(prop0, "Import", dt_eFbxString);
        prop1.Set("");
        prop2 = AddPropertyGroup(prop1, "FirstTimeRunNotice", dt_eFbxString);
        prop2.Set("");
        prop3 = AddProperty(prop2, "FirstTimeRunNotice", dt_eFbxString);
        prop3.Set("*** Welcome! ***");
        prop2 = AddPropertyGroup(prop1, "PlugInGrp", dt_eFbxString);
        prop2.Set("");
        prop3 = AddProperty(prop2, "PlugInUIWidth", dt_eFbxInt);
        prop3.Set(500);
        prop3 = AddProperty(prop2, "PlugInUIHeight", dt_eFbxInt);
        prop3.Set(500);
        prop3 = AddProperty(prop2, "PlugInUIXpos", dt_eFbxInt);
        prop3.Set(100);
        prop3 = AddProperty(prop2, "PlugInUIYpos", dt_eFbxInt);
        prop3.Set(100);
        prop3 = AddProperty(prop2, "PresetSelected", dt_eFbxString);
        prop3.Set("");
        prop3 = AddProperty(prop2, "UILIndex", dt_eFbxEnum);
        prop3.Set(0);
        prop3.AddEnumValue("ENU");
        prop3.AddEnumValue("DEU");
        prop3.AddEnumValue("FRA");
        prop3.AddEnumValue("JPN");
        prop3.AddEnumValue("KOR");
        prop3.AddEnumValue("CHS");
        prop3.AddEnumValue("PTB");
        prop3 = AddProperty(prop2, "PluginProductFamily", dt_eFbxString);
        prop3.Set("");
        prop2 = AddPropertyGroup(prop1, "PresetsGrp", dt_eFbxString);
        prop2.Set("");
        prop3 = AddProperty(prop2, "Presets", dt_eFbxEnum);
        prop3.Set(0);
        prop2 = AddPropertyGroup(prop1, "StatisticsGrp", dt_eFbxString);
        prop2.Set("");
        prop3 = AddProperty(prop2, "Statistics", dt_eFbxString);
        prop3.Set("");
        prop2 = AddPropertyGroup(prop1, "IncludeGrp", dt_eFbxString);
        prop2.Set("");
        prop3 = AddProperty(prop2, "MergeMode", dt_eFbxEnum);
        prop3.Set(1);
        prop3.AddEnumValue("Add");
        prop3.AddEnumValue("Add and update animation");
        prop3.AddEnumValue("Update animation");
        prop3 = AddProperty(prop2, "MergeModeDescription", dt_eFbxString);
        prop3.Set("---");
        prop3 = AddProperty(prop2, "OneClickMerge", dt_eFbxBool);
        prop3.Set(false);
        prop3 = AddProperty(prop2, "OneClickMergeTexture", dt_eFbxBool);
        prop3.Set(false);
        prop3 = AddProperty(prop2, "Geometry", dt_eFbxString);
        prop3.Set("");
        prop3 = AddPropertyGroup(prop2, "Animation", dt_eFbxBool);
        prop3.Set(true);
        prop4 = AddPropertyGroup(prop3, "ExtraGrp", dt_eFbxString);
        prop4.Set("");
        prop5 = AddProperty(prop4, "Take", dt_eFbxEnum);
        prop5.Set(-1);
        prop5 = AddProperty(prop4, "KeepFrameRate", dt_eFbxBool);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "TimeLine", dt_eFbxBool);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "TimeLineSpan", dt_eFbxBool);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "BakeAnimationLayers", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Markers", dt_eFbxBool);
        prop5.Set(false);
        prop4 = AddPropertyGroup(prop3, "Deformation", dt_eFbxBool);
        prop4.Set(true);
        prop5 = AddProperty(prop4, "Skins", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "UseMatrixFromPose", dt_eFbxBool);
        prop5.Set(false);
        prop4 = AddPropertyGroup(prop3, "SamplingPanel", dt_eFbxString);
        prop4.Set("");
        prop5 = AddProperty(prop4, "SamplingRateSelector", dt_eFbxEnum);
        prop5.Set(0);
        prop5.AddEnumValue("Scene");
        prop5.AddEnumValue("File");
        prop5.AddEnumValue("Custom");
        prop5 = AddProperty(prop4, "CurveFilterSamplingRate", dt_eFbxDouble);
        prop5.Set(30.000000);
        prop4 = AddProperty(prop3, "CurveFilter", dt_eFbxBool);
        prop4.Set(false);
        prop3 = AddPropertyGroup(prop2, "CameraGrp", dt_eFbxString);
        prop3.Set("");
        prop4 = AddProperty(prop3, "Camera", dt_eFbxBool);
        prop4.Set(true);
        prop3 = AddPropertyGroup(prop2, "LightGrp", dt_eFbxString);
        prop3.Set("");
        prop4 = AddProperty(prop3, "Light", dt_eFbxBool);
        prop4.Set(true);
        prop3 = AddProperty(prop2, "Audio", dt_eFbxBool);
        prop3.Set(true);
        prop3 = AddPropertyGroup(prop2, "EmbedTexture", dt_eFbxString);
        prop3.Set("");
        prop4 = AddProperty(prop3, "ExtractFolder", dt_eFbxString);
        prop4.Set("");
        prop2 = AddPropertyGroup(prop1, "AdvOptGrp", dt_eFbxString);
        prop2.Set("");
        prop3 = AddPropertyGroup(prop2, "UnitsGrp", dt_eFbxString);
        prop3.Set("");
        prop4 = AddProperty(prop3, "ScaleConversion", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "TotalUnitsScale", dt_eFbxString);
        prop4.Set("");
        prop4 = AddProperty(prop3, "DynamicScaleConversion", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "UnitsSelector", dt_eFbxEnum);
        prop4.Set(0);
        prop4.AddEnumValue("Millimeters");
        prop4.AddEnumValue("Centimeters");
        prop4.AddEnumValue("Decimeters");
        prop4.AddEnumValue("Meters");
        prop4.AddEnumValue("Kilometers");
        prop4.AddEnumValue("Inches");
        prop4.AddEnumValue("Feet");
        prop4.AddEnumValue("Yards");
        prop4.AddEnumValue("Miles");
        prop4 = AddProperty(prop3, "MasterScale", dt_eFbxDouble);
        prop4.Set(1.000000);
        prop4 = AddProperty(prop3, "UnitsScale", dt_eFbxDouble);
        prop4.Set(1.000000);
        prop3 = AddPropertyGroup(prop2, "AxisConvGrp", dt_eFbxString);
        prop3.Set("");
        prop4 = AddProperty(prop3, "AxisConversion", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "AutoAxis", dt_eFbxBool);
        prop4.Set(true);
        prop3 = AddPropertyGroup(prop2, "UI", dt_eFbxString);
        prop3.Set("");
        prop4 = AddProperty(prop3, "ShowWarningsManager", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "GenerateLogData", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "PluginVersionsURL", dt_eFbxString);
        prop4.Set(
            "http://download.autodesk.com/us/fbx/versions/fbxversion.xml");
        prop4 = AddProperty(prop3, "ShowUIMode", dt_eFbxBool);
        prop4.Set(true);
        prop3 = AddPropertyGroup(prop2, "Cache", dt_eFbxString);
        prop3.Set("");
        prop4 = AddProperty(prop3, "CacheSize", dt_eFbxInt);
        prop4.Set(8);
        prop3 = AddPropertyGroup(prop2, "FileFormat", dt_eFbxString);
        prop3.Set("");
        prop4 = AddPropertyGroup(prop3, "Fbx", dt_eFbxString);
        prop4.Set("");
        prop5 = AddProperty(prop4, "Current_Take_Name", dt_eFbxString);
        prop5.Set("");
        prop5 = AddProperty(prop4, "Model", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementNormal", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementBinormal", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementTangent", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementVertexColor", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementPolygroup", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementSmoothing", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementUserData", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementVisibility", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementEdgeCrease", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementVertexCrease", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementHole", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Texture", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Material", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Link", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Shape", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Gobo", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Audio", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Animation", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Character", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Global_Settings", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Pivot", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Merge_Layer_and_Timewarp", dt_eFbxBool);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "Template", dt_eFbxBool);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "Constraint", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "ExtractEmbeddedData", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "CalculateLegacyShapeNormal", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Password_Enable", dt_eFbxBool);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "Password", dt_eFbxString);
        prop5.Set("");
        prop5 = AddProperty(prop4, "Model_Count", dt_eFbxInt);
        prop5.Set(0);
        prop5 = AddProperty(prop4, "Device_Count", dt_eFbxInt);
        prop5.Set(0);
        prop5 = AddProperty(prop4, "Character_Count", dt_eFbxInt);
        prop5.Set(0);
        prop5 = AddProperty(prop4, "Actor_Count", dt_eFbxInt);
        prop5.Set(0);
        prop5 = AddProperty(prop4, "Constraint_Count", dt_eFbxInt);
        prop5.Set(0);
        prop5 = AddProperty(prop4, "Media_Count", dt_eFbxInt);
        prop5.Set(0);
        prop5 = AddProperty(prop4, "RelaxedFbxCheck", dt_eFbxBool);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "KeepProducerCamSrcObj", dt_eFbxBool);
        prop5.Set(false);
        prop4 = AddPropertyGroup(prop3, "Obj", dt_eFbxString);
        prop4.Set("");
        prop5 = AddProperty(prop4, "ReferenceNode", dt_eFbxBool);
        prop5.Set(true);
        prop4 = AddPropertyGroup(prop3, "Max_3ds", dt_eFbxString);
        prop4.Set("");
        prop5 = AddProperty(prop4, "ReferenceNode", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Texture", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Material", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Animation", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Mesh", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Light", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Camera", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "AmbientLight", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Rescaling", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Filter", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Smoothgroup", dt_eFbxBool);
        prop5.Set(true);
        prop4 = AddPropertyGroup(prop3, "Motion_Base", dt_eFbxString);
        prop4.Set("");
        prop5 = AddProperty(prop4, "MotionStart", dt_eFbxTime);
        prop5.Set(new FbxTime(0L));
        prop5 = AddProperty(prop4, "MotionFrameCount", dt_eFbxInt);
        prop5.Set(0);
        prop5 = AddProperty(prop4, "MotionFrameRate", dt_eFbxDouble);
        prop5.Set(0.000000);
        prop5 = AddProperty(prop4, "MotionActorPrefix", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionRenameDuplicateNames", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionExactZeroAsOccluded", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionSetOccludedToLastValidPos",
            dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionAsOpticalSegments", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionASFSceneOwned", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionUpAxisUsedInFile", dt_eFbxInt);
        prop5.Set(3);
        prop4 = AddPropertyGroup(prop3, "Biovision_BVH", dt_eFbxString);
        prop4.Set("");
        prop5 = AddProperty(prop4, "MotionCreateReferenceNode", dt_eFbxBool);
        prop5.Set(true);
        prop4 = AddPropertyGroup(prop3, "MotionAnalysis_HTR", dt_eFbxString);
        prop4.Set("");
        prop5 = AddProperty(prop4, "MotionCreateReferenceNode", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionBaseTInOffset", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionBaseRInPrerotation", dt_eFbxBool);
        prop5.Set(true);
        prop4 = AddProperty(prop3, "MotionAnalysis_TRC", dt_eFbxString);
        prop4.Set("");
        prop4 = AddPropertyGroup(prop3, "Acclaim_ASF", dt_eFbxString);
        prop4.Set("");
        prop5 = AddProperty(prop4, "MotionCreateReferenceNode", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionDummyNodes", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionLimits", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionBaseTInOffset", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionBaseRInPrerotation", dt_eFbxBool);
        prop5.Set(true);
        prop4 = AddPropertyGroup(prop3, "Acclaim_AMC", dt_eFbxString);
        prop4.Set("");
        prop5 = AddProperty(prop4, "MotionCreateReferenceNode", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionDummyNodes", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionLimits", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionBaseTInOffset", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionBaseRInPrerotation", dt_eFbxBool);
        prop5.Set(true);
        prop3 = AddPropertyGroup(prop2, "Dxf", dt_eFbxString);
        prop3.Set("");
        prop4 = AddProperty(prop3, "WeldVertices", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "ObjectDerivation", dt_eFbxEnum);
        prop4.Set(0);
        prop4.AddEnumValue("By layer");
        prop4.AddEnumValue("By entity");
        prop4.AddEnumValue("By block");
        prop4 = AddProperty(prop3, "ReferenceNode", dt_eFbxBool);
        prop4.Set(true);
        prop2 = AddPropertyGroup(prop1, "FBXExtentionsSDK", dt_eFbxString);
        prop2.Set("");
        prop3 = AddProperty(prop2, "FBXExtentionsSDKWarning", dt_eFbxString);
        prop3.Set("Add your custom properties here.");
        prop1 = AddPropertyGroup(prop0, "Export", dt_eFbxString);
        prop1.Set("");
        prop2 = AddPropertyGroup(prop1, "FirstTimeRunNotice", dt_eFbxString);
        prop2.Set("");
        prop3 = AddProperty(prop2, "FirstTimeRunNotice", dt_eFbxString);
        prop3.Set("*** Welcome! ***");
        prop2 = AddPropertyGroup(prop1, "PlugInGrp", dt_eFbxString);
        prop2.Set("");
        prop3 = AddProperty(prop2, "PlugInUIWidth", dt_eFbxInt);
        prop3.Set(500);
        prop3 = AddProperty(prop2, "PlugInUIHeight", dt_eFbxInt);
        prop3.Set(500);
        prop3 = AddProperty(prop2, "PlugInUIXpos", dt_eFbxInt);
        prop3.Set(100);
        prop3 = AddProperty(prop2, "PlugInUIYpos", dt_eFbxInt);
        prop3.Set(100);
        prop3 = AddProperty(prop2, "UILIndex", dt_eFbxEnum);
        prop3.Set(0);
        prop3.AddEnumValue("ENU");
        prop3.AddEnumValue("DEU");
        prop3.AddEnumValue("FRA");
        prop3.AddEnumValue("JPN");
        prop3.AddEnumValue("KOR");
        prop3.AddEnumValue("CHS");
        prop3.AddEnumValue("PTB");
        prop3 = AddProperty(prop2, "PluginProductFamily", dt_eFbxString);
        prop3.Set("");
        prop3 = AddProperty(prop2, "PresetSelected", dt_eFbxString);
        prop3.Set("");
        prop3 = AddProperty(prop2, "UseTmpFilePeripheral", dt_eFbxBool);
        prop3.Set(false);
        prop2 = AddPropertyGroup(prop1, "PresetsGrp", dt_eFbxString);
        prop2.Set("");
        prop3 = AddProperty(prop2, "Presets", dt_eFbxEnum);
        prop3.Set(0);
        prop2 = AddPropertyGroup(prop1, "StatisticsGrp", dt_eFbxString);
        prop2.Set("");
        prop3 = AddProperty(prop2, "Statistics", dt_eFbxString);
        prop3.Set("");
        prop2 = AddPropertyGroup(prop1, "IncludeGrp", dt_eFbxString);
        prop2.Set("");
        prop3 = AddProperty(prop2, "Geometry", dt_eFbxString);
        prop3.Set("");
        prop3 = AddPropertyGroup(prop2, "Animation", dt_eFbxBool);
        prop3.Set(true);
        prop4 = AddPropertyGroup(prop3, "ExtraGrp", dt_eFbxString);
        prop4.Set("");
        prop5 = AddProperty(prop4, "UseSceneName", dt_eFbxBool);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "RemoveSingleKey", dt_eFbxBool);
        prop5.Set(false);
        prop4 = AddPropertyGroup(prop3, "BakeComplexAnimation", dt_eFbxBool);
        prop4.Set(false);
        prop5 = AddProperty(prop4, "BakeFrameStart", dt_eFbxInt);
        prop5.Set(1);
        prop5 = AddProperty(prop4, "BakeFrameEnd", dt_eFbxInt);
        prop5.Set(200);
        prop5 = AddProperty(prop4, "BakeFrameStep", dt_eFbxInt);
        prop5.Set(1);
        prop5 = AddProperty(prop4, "ResampleAnimationCurves", dt_eFbxBool);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "BakeFrameStartNoReset", dt_eFbxBool);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "BakeFrameEndNoReset", dt_eFbxBool);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "BakeFrameStepNoReset", dt_eFbxBool);
        prop5.Set(false);
        prop4 = AddPropertyGroup(prop3, "Deformation", dt_eFbxBool);
        prop4.Set(true);
        prop5 = AddProperty(prop4, "Skins", dt_eFbxBool);
        prop5.Set(true);
        prop4 = AddPropertyGroup(prop3, "CurveFilter", dt_eFbxBool);
        prop4.Set(false);
        prop5 = AddPropertyGroup(prop4, "CurveFilterApplyCstKeyRed",
            dt_eFbxBool);
        prop5.Set(false);
        prop6 = AddProperty(prop5, "CurveFilterSamplingRate", dt_eFbxDouble);
        prop6.Set(30.000000);
        prop6 = AddProperty(prop5, "CurveFilterCstKeyRedTPrec", dt_eFbxDouble);
        prop6.Set(0.000090);
        prop6 = AddProperty(prop5, "CurveFilterCstKeyRedRPrec", dt_eFbxDouble);
        prop6.Set(0.009000);
        prop6 = AddProperty(prop5, "CurveFilterCstKeyRedSPrec", dt_eFbxDouble);
        prop6.Set(0.004000);
        prop6 = AddProperty(prop5, "CurveFilterCstKeyRedOPrec", dt_eFbxDouble);
        prop6.Set(0.009000);
        prop6 = AddProperty(prop5, "AutoTangentsOnly", dt_eFbxBool);
        prop6.Set(true);
        prop3 = AddPropertyGroup(prop2, "CameraGrp", dt_eFbxString);
        prop3.Set("");
        prop4 = AddProperty(prop3, "Camera", dt_eFbxBool);
        prop4.Set(true);
        prop3 = AddPropertyGroup(prop2, "LightGrp", dt_eFbxString);
        prop3.Set("");
        prop4 = AddProperty(prop3, "Light", dt_eFbxBool);
        prop4.Set(true);
        prop3 = AddProperty(prop2, "Audio", dt_eFbxBool);
        prop3.Set(true);
        prop3 = AddPropertyGroup(prop2, "EmbedTextureGrp", dt_eFbxString);
        prop3.Set("");
        prop4 = AddProperty(prop3, "EmbedTexture", dt_eFbxBool);
        prop4.Set(false);
        prop3 = AddProperty(prop2, "BindPose", dt_eFbxBool);
        prop3.Set(true);
        prop3 = AddProperty(prop2, "PivotToNulls", dt_eFbxBool);
        prop3.Set(false);
        prop2 = AddPropertyGroup(prop1, "AdvOptGrp", dt_eFbxString);
        prop2.Set("");
        prop3 = AddPropertyGroup(prop2, "UnitsGrp", dt_eFbxString);
        prop3.Set("");
        prop4 = AddProperty(prop3, "TotalUnitsScale", dt_eFbxString);
        prop4.Set("");
        prop4 = AddProperty(prop3, "DynamicScaleConversion", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "UnitsSelector", dt_eFbxEnum);
        prop4.Set(0);
        prop4 = AddProperty(prop3, "UnitsScale", dt_eFbxDouble);
        prop4.Set(1.000000);
        prop4 = AddProperty(prop3, "MasterScale", dt_eFbxDouble);
        prop4.Set(1.000000);
        prop3 = AddProperty(prop2, "AxisConvGrp", dt_eFbxString);
        prop3.Set("");
        prop3 = AddPropertyGroup(prop2, "UI", dt_eFbxString);
        prop3.Set("");
        prop4 = AddProperty(prop3, "ShowWarningsManager", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "GenerateLogData", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "PluginVersionsURL", dt_eFbxString);
        prop4.Set(
            "http://download.autodesk.com/us/fbx/versions/fbxversion.xml");
        prop4 = AddProperty(prop3, "ShowUIMode", dt_eFbxBool);
        prop4.Set(true);
        prop3 = AddPropertyGroup(prop2, "Cache", dt_eFbxString);
        prop3.Set("");
        prop4 = AddProperty(prop3, "CacheSize", dt_eFbxInt);
        prop4.Set(8);
        prop3 = AddPropertyGroup(prop2, "FileFormat", dt_eFbxString);
        prop3.Set("");
        prop4 = AddPropertyGroup(prop3, "Obj", dt_eFbxString);
        prop4.Set("");
        prop5 = AddProperty(prop4, "Triangulate", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Deformation", dt_eFbxBool);
        prop5.Set(true);
        prop4 = AddPropertyGroup(prop3, "Motion_Base", dt_eFbxString);
        prop4.Set("");
        prop5 = AddProperty(prop4, "MotionStart", dt_eFbxTime);
        prop5.Set(new FbxTime(0L));
        prop5 = AddProperty(prop4, "MotionFrameCount", dt_eFbxInt);
        prop5.Set(0);
        prop5 = AddProperty(prop4, "MotionFromGlobalPosition", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionFrameRate", dt_eFbxDouble);
        prop5.Set(30.000000);
        prop5 = AddProperty(prop4, "MotionGapsAsValidData", dt_eFbxBool);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "MotionC3DRealFormat", dt_eFbxBool);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "MotionASFSceneOwned", dt_eFbxBool);
        prop5.Set(true);
        prop4 = AddPropertyGroup(prop3, "Biovision_BVH", dt_eFbxString);
        prop4.Set("");
        prop5 = AddProperty(prop4, "MotionTranslation", dt_eFbxBool);
        prop5.Set(true);
        prop4 = AddProperty(prop3, "MotionAnalysis_HTR", dt_eFbxString);
        prop4.Set("");
        prop4 = AddProperty(prop3, "MotionAnalysis_TRC", dt_eFbxString);
        prop4.Set("");
        prop4 = AddPropertyGroup(prop3, "Acclaim_ASF", dt_eFbxString);
        prop4.Set("");
        prop5 = AddProperty(prop4, "MotionTranslation", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionFrameRateUsed", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionFrameRange", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionWriteDefaultAsBaseTR", dt_eFbxBool);
        prop5.Set(false);
        prop4 = AddPropertyGroup(prop3, "Acclaim_AMC", dt_eFbxString);
        prop4.Set("");
        prop5 = AddProperty(prop4, "MotionTranslation", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionFrameRateUsed", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionFrameRange", dt_eFbxBool);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionWriteDefaultAsBaseTR", dt_eFbxBool);
        prop5.Set(false);
        prop3 = AddPropertyGroup(prop2, "Fbx", dt_eFbxString);
        prop3.Set("");
        prop4 = AddProperty(prop3, "AsciiFbx", dt_eFbxEnum);
        prop4.Set(0);
        prop4.AddEnumValue("Binary");
        prop4.AddEnumValue("ASCII");
        prop4 = AddProperty(prop3, "ExportFileVersion", dt_eFbxEnum);
        prop4.Set(0);
        prop4.AddEnumValue("FBX202000");
        prop4.AddEnumValue("FBX201900");
        prop4.AddEnumValue("FBX201800");
        prop4.AddEnumValue("FBX201600");
        prop4.AddEnumValue("FBX201400");
        prop4.AddEnumValue("FBX201300");
        prop4.AddEnumValue("FBX201200");
        prop4.AddEnumValue("FBX201100");
        prop4.AddEnumValue("FBX201000");
        prop4.AddEnumValue("FBX200900");
        prop4.AddEnumValue("FBX200611");
        prop4 = AddProperty(prop3, "VersionsUIAlias", dt_eFbxEnum);
        prop4.Set(0);
        prop4.AddEnumValue("FBX 2020");
        prop4.AddEnumValue("FBX 2019");
        prop4.AddEnumValue("FBX 2018");
        prop4.AddEnumValue("FBX 2016/2017");
        prop4.AddEnumValue("FBX 2014/2015");
        prop4.AddEnumValue("FBX 2013");
        prop4.AddEnumValue("FBX 2012");
        prop4.AddEnumValue("FBX 2011");
        prop4.AddEnumValue("FBX 2010");
        prop4.AddEnumValue("FBX 2009");
        prop4.AddEnumValue("FBX 2006");
        prop4 = AddProperty(prop3, "VersionsCompDescriptions", dt_eFbxEnum);
        prop4.Set(0);
        prop4.AddEnumValue(
            "Compatible with Autodesk 2020 applications/FBX plug-ins");
        prop4.AddEnumValue(
            "Compatible with Autodesk 2019 applications/FBX plug-ins");
        prop4.AddEnumValue(
            "Compatible with Autodesk 2018 applications/FBX plug-ins");
        prop4.AddEnumValue(
            "Compatible with Autodesk 2016/2017 applications/FBX plug-ins");
        prop4.AddEnumValue(
            "Compatible with Autodesk 2014/2015 applications/FBX plug-ins");
        prop4.AddEnumValue(
            "Compatible with Autodesk 2013 applications/FBX plug-ins");
        prop4.AddEnumValue(
            "Compatible with Autodesk 2012 applications/FBX plug-ins");
        prop4.AddEnumValue(
            "Compatible with Autodesk 2011 applications/FBX plug-ins");
        prop4.AddEnumValue(
            "Compatible with Autodesk 2010 applications/FBX plug-ins and " +
            "MotionBuilder 2009");
        prop4.AddEnumValue(
            "Compatible with Autodesk 2009 applications/FBX plug-ins");
        prop4.AddEnumValue(
            "Compatible with Autodesk 2006 FBX plug-ins and MotionBuilder " +
            "7.5, 7.0 and 6.0");
        prop4 = AddProperty(prop3, "Model", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Texture", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Material", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Shape", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Gobo", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Audio", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Animation", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Character", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Global_Settings", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Pivot", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Template", dt_eFbxBool);
        prop4.Set(false);
        prop4 = AddProperty(prop3, "Constraint", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "EMBEDDED", dt_eFbxBool);
        prop4.Set(false);
        prop4 = AddProperty(prop3, "Password_Enable", dt_eFbxBool);
        prop4.Set(false);
        prop4 = AddProperty(prop3, "Password", dt_eFbxString);
        prop4.Set("");
        prop4 = AddProperty(prop3, "COLLAPSE EXTERNALS", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Compress_Arrays", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Compress_Level", dt_eFbxInt);
        prop4.Set(1);
        prop4 = AddProperty(prop3, "Compress_Minsize", dt_eFbxInt);
        prop4.Set(1024);
        prop4 = AddProperty(prop3, "Embedded_Skipped_Properties",
            dt_eFbxString);
        prop4.Set("");
        prop3 = AddPropertyGroup(prop2, "Dxf", dt_eFbxString);
        prop3.Set("");
        prop4 = AddProperty(prop3, "Deformation", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Triangulate", dt_eFbxBool);
        prop4.Set(true);
        prop3 = AddPropertyGroup(prop2, "Collada", dt_eFbxString);
        prop3.Set("");
        prop4 = AddProperty(prop3, "Triangulate", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "SingleMatrix", dt_eFbxBool);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "FrameRate", dt_eFbxDouble);
        prop4.Set(30.000000);
        prop2 = AddPropertyGroup(prop1, "FBXExtentionsSDK", dt_eFbxString);
        prop2.Set("");
        prop3 = AddProperty(prop2, "FBXExtentionsSDKWarning", dt_eFbxString);
        prop3.Set("Add your custom properties here.");
    }

    #endregion

    #region Static Protected MemberFunctions

    // static FbxIOSettings * 	Allocate (FbxManager *pManager, const char *pName, const FbxIOSettings *pFrom)

    #endregion
}
