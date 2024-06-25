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
        FbxProperty prop0, prop1, prop2, prop3, prop4, prop5, prop6;
        prop0 = RootProperty;

        prop1 = AddPropertyGroup(prop0, "Import", FbxDataTypes.FbxStringDT);
        prop1.Set("");
        prop2 = AddPropertyGroup(prop1, "FirstTimeRunNotice", FbxDataTypes.FbxStringDT);
        prop2.Set("");
        prop3 = AddProperty(prop2, "FirstTimeRunNotice", FbxDataTypes.FbxStringDT);
        prop3.Set("*** Welcome! ***");
        prop2 = AddPropertyGroup(prop1, "PlugInGrp", FbxDataTypes.FbxStringDT);
        prop2.Set("");
        prop3 = AddProperty(prop2, "PlugInUIWidth", FbxDataTypes.FbxIntDT);
        prop3.Set(500);
        prop3 = AddProperty(prop2, "PlugInUIHeight", FbxDataTypes.FbxIntDT);
        prop3.Set(500);
        prop3 = AddProperty(prop2, "PlugInUIXpos", FbxDataTypes.FbxIntDT);
        prop3.Set(100);
        prop3 = AddProperty(prop2, "PlugInUIYpos", FbxDataTypes.FbxIntDT);
        prop3.Set(100);
        prop3 = AddProperty(prop2, "PresetSelected", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop3 = AddProperty(prop2, "UILIndex", FbxDataTypes.FbxEnumDT);
        prop3.Set(0);
        prop3.AddEnumValue("ENU");
        prop3.AddEnumValue("DEU");
        prop3.AddEnumValue("FRA");
        prop3.AddEnumValue("JPN");
        prop3.AddEnumValue("KOR");
        prop3.AddEnumValue("CHS");
        prop3.AddEnumValue("PTB");
        prop3 = AddProperty(prop2, "PluginProductFamily", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop2 = AddPropertyGroup(prop1, "PresetsGrp", FbxDataTypes.FbxStringDT);
        prop2.Set("");
        prop3 = AddProperty(prop2, "Presets", FbxDataTypes.FbxEnumDT);
        prop3.Set(0);
        prop2 = AddPropertyGroup(prop1, "StatisticsGrp", FbxDataTypes.FbxStringDT);
        prop2.Set("");
        prop3 = AddProperty(prop2, "Statistics", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop2 = AddPropertyGroup(prop1, "IncludeGrp", FbxDataTypes.FbxStringDT);
        prop2.Set("");
        prop3 = AddProperty(prop2, "MergeMode", FbxDataTypes.FbxEnumDT);
        prop3.Set(1);
        prop3.AddEnumValue("Add");
        prop3.AddEnumValue("Add and update animation");
        prop3.AddEnumValue("Update animation");
        prop3 = AddProperty(prop2, "MergeModeDescription", FbxDataTypes.FbxStringDT);
        prop3.Set("---");
        prop3 = AddProperty(prop2, "OneClickMerge", FbxDataTypes.FbxBoolDT);
        prop3.Set(false);
        prop3 = AddProperty(prop2, "OneClickMergeTexture", FbxDataTypes.FbxBoolDT);
        prop3.Set(false);
        prop3 = AddProperty(prop2, "Geometry", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop3 = AddPropertyGroup(prop2, "Animation", FbxDataTypes.FbxBoolDT);
        prop3.Set(true);
        prop4 = AddPropertyGroup(prop3, "ExtraGrp", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop5 = AddProperty(prop4, "Take", FbxDataTypes.FbxEnumDT);
        prop5.Set(-1);
        prop5 = AddProperty(prop4, "KeepFrameRate", FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "TimeLine", FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "TimeLineSpan", FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "BakeAnimationLayers", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Markers", FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop4 = AddPropertyGroup(prop3, "Deformation", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop5 = AddProperty(prop4, "Skins", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "UseMatrixFromPose", FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop4 = AddPropertyGroup(prop3, "SamplingPanel", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop5 = AddProperty(prop4, "SamplingRateSelector", FbxDataTypes.FbxEnumDT);
        prop5.Set(0);
        prop5.AddEnumValue("Scene");
        prop5.AddEnumValue("File");
        prop5.AddEnumValue("Custom");
        prop5 = AddProperty(prop4, "CurveFilterSamplingRate", FbxDataTypes.FbxDoubleDT);
        prop5.Set(30.000000);
        prop4 = AddProperty(prop3, "CurveFilter", FbxDataTypes.FbxBoolDT);
        prop4.Set(false);
        prop3 = AddPropertyGroup(prop2, "CameraGrp", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop4 = AddProperty(prop3, "Camera", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop3 = AddPropertyGroup(prop2, "LightGrp", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop4 = AddProperty(prop3, "Light", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop3 = AddProperty(prop2, "Audio", FbxDataTypes.FbxBoolDT);
        prop3.Set(true);
        prop3 = AddPropertyGroup(prop2, "EmbedTexture", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop4 = AddProperty(prop3, "ExtractFolder", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop2 = AddPropertyGroup(prop1, "AdvOptGrp", FbxDataTypes.FbxStringDT);
        prop2.Set("");
        prop3 = AddPropertyGroup(prop2, "UnitsGrp", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop4 = AddProperty(prop3, "ScaleConversion", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "TotalUnitsScale", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop4 = AddProperty(prop3, "DynamicScaleConversion", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "UnitsSelector", FbxDataTypes.FbxEnumDT);
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
        prop4 = AddProperty(prop3, "MasterScale", FbxDataTypes.FbxDoubleDT);
        prop4.Set(1.000000);
        prop4 = AddProperty(prop3, "UnitsScale", FbxDataTypes.FbxDoubleDT);
        prop4.Set(1.000000);
        prop3 = AddPropertyGroup(prop2, "AxisConvGrp", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop4 = AddProperty(prop3, "AxisConversion", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "AutoAxis", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop3 = AddPropertyGroup(prop2, "UI", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop4 = AddProperty(prop3, "ShowWarningsManager", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "GenerateLogData", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "PluginVersionsURL", FbxDataTypes.FbxStringDT);
        prop4.Set(
            "http://download.autodesk.com/us/fbx/versions/fbxversion.xml");
        prop4 = AddProperty(prop3, "ShowUIMode", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop3 = AddPropertyGroup(prop2, "Cache", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop4 = AddProperty(prop3, "CacheSize", FbxDataTypes.FbxIntDT);
        prop4.Set(8);
        prop3 = AddPropertyGroup(prop2, "FileFormat", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop4 = AddPropertyGroup(prop3, "Fbx", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop5 = AddProperty(prop4, "Current_Take_Name", FbxDataTypes.FbxStringDT);
        prop5.Set("");
        prop5 = AddProperty(prop4, "Model", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementNormal", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementBinormal", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementTangent", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementVertexColor", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementPolygroup", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementSmoothing", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementUserData", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementVisibility", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementEdgeCrease", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementVertexCrease", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "LayerElementHole", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Texture", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Material", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Link", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Shape", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Gobo", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Audio", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Animation", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Character", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Global_Settings", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Pivot", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Merge_Layer_and_Timewarp", FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "Template", FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "Constraint", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "ExtractEmbeddedData", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "CalculateLegacyShapeNormal", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Password_Enable", FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "Password", FbxDataTypes.FbxStringDT);
        prop5.Set("");
        prop5 = AddProperty(prop4, "Model_Count", FbxDataTypes.FbxIntDT);
        prop5.Set(0);
        prop5 = AddProperty(prop4, "Device_Count", FbxDataTypes.FbxIntDT);
        prop5.Set(0);
        prop5 = AddProperty(prop4, "Character_Count", FbxDataTypes.FbxIntDT);
        prop5.Set(0);
        prop5 = AddProperty(prop4, "Actor_Count", FbxDataTypes.FbxIntDT);
        prop5.Set(0);
        prop5 = AddProperty(prop4, "Constraint_Count", FbxDataTypes.FbxIntDT);
        prop5.Set(0);
        prop5 = AddProperty(prop4, "Media_Count", FbxDataTypes.FbxIntDT);
        prop5.Set(0);
        prop5 = AddProperty(prop4, "RelaxedFbxCheck", FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "KeepProducerCamSrcObj", FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop4 = AddPropertyGroup(prop3, "Obj", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop5 = AddProperty(prop4, "ReferenceNode", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop4 = AddPropertyGroup(prop3, "Max_3ds", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop5 = AddProperty(prop4, "ReferenceNode", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Texture", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Material", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Animation", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Mesh", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Light", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Camera", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "AmbientLight", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Rescaling", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Filter", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Smoothgroup", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop4 = AddPropertyGroup(prop3, "Motion_Base", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop5 = AddProperty(prop4, "MotionStart", FbxDataTypes.FbxTimeDT);
        prop5.Set(new FbxTime(0L));
        prop5 = AddProperty(prop4, "MotionFrameCount", FbxDataTypes.FbxIntDT);
        prop5.Set(0);
        prop5 = AddProperty(prop4, "MotionFrameRate", FbxDataTypes.FbxDoubleDT);
        prop5.Set(0.000000);
        prop5 = AddProperty(prop4, "MotionActorPrefix", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionRenameDuplicateNames", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionExactZeroAsOccluded", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionSetOccludedToLastValidPos",
            FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionAsOpticalSegments", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionASFSceneOwned", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionUpAxisUsedInFile", FbxDataTypes.FbxIntDT);
        prop5.Set(3);
        prop4 = AddPropertyGroup(prop3, "Biovision_BVH", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop5 = AddProperty(prop4, "MotionCreateReferenceNode", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop4 = AddPropertyGroup(prop3, "MotionAnalysis_HTR", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop5 = AddProperty(prop4, "MotionCreateReferenceNode", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionBaseTInOffset", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionBaseRInPrerotation", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop4 = AddProperty(prop3, "MotionAnalysis_TRC", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop4 = AddPropertyGroup(prop3, "Acclaim_ASF", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop5 = AddProperty(prop4, "MotionCreateReferenceNode", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionDummyNodes", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionLimits", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionBaseTInOffset", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionBaseRInPrerotation", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop4 = AddPropertyGroup(prop3, "Acclaim_AMC", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop5 = AddProperty(prop4, "MotionCreateReferenceNode", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionDummyNodes", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionLimits", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionBaseTInOffset", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionBaseRInPrerotation", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop3 = AddPropertyGroup(prop2, "Dxf", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop4 = AddProperty(prop3, "WeldVertices", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "ObjectDerivation", FbxDataTypes.FbxEnumDT);
        prop4.Set(0);
        prop4.AddEnumValue("By layer");
        prop4.AddEnumValue("By entity");
        prop4.AddEnumValue("By block");
        prop4 = AddProperty(prop3, "ReferenceNode", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop2 = AddPropertyGroup(prop1, "FBXExtentionsSDK", FbxDataTypes.FbxStringDT);
        prop2.Set("");
        prop3 = AddProperty(prop2, "FBXExtentionsSDKWarning", FbxDataTypes.FbxStringDT);
        prop3.Set("Add your custom properties here.");
        prop1 = AddPropertyGroup(prop0, "Export", FbxDataTypes.FbxStringDT);
        prop1.Set("");
        prop2 = AddPropertyGroup(prop1, "FirstTimeRunNotice", FbxDataTypes.FbxStringDT);
        prop2.Set("");
        prop3 = AddProperty(prop2, "FirstTimeRunNotice", FbxDataTypes.FbxStringDT);
        prop3.Set("*** Welcome! ***");
        prop2 = AddPropertyGroup(prop1, "PlugInGrp", FbxDataTypes.FbxStringDT);
        prop2.Set("");
        prop3 = AddProperty(prop2, "PlugInUIWidth", FbxDataTypes.FbxIntDT);
        prop3.Set(500);
        prop3 = AddProperty(prop2, "PlugInUIHeight", FbxDataTypes.FbxIntDT);
        prop3.Set(500);
        prop3 = AddProperty(prop2, "PlugInUIXpos", FbxDataTypes.FbxIntDT);
        prop3.Set(100);
        prop3 = AddProperty(prop2, "PlugInUIYpos", FbxDataTypes.FbxIntDT);
        prop3.Set(100);
        prop3 = AddProperty(prop2, "UILIndex", FbxDataTypes.FbxEnumDT);
        prop3.Set(0);
        prop3.AddEnumValue("ENU");
        prop3.AddEnumValue("DEU");
        prop3.AddEnumValue("FRA");
        prop3.AddEnumValue("JPN");
        prop3.AddEnumValue("KOR");
        prop3.AddEnumValue("CHS");
        prop3.AddEnumValue("PTB");
        prop3 = AddProperty(prop2, "PluginProductFamily", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop3 = AddProperty(prop2, "PresetSelected", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop3 = AddProperty(prop2, "UseTmpFilePeripheral", FbxDataTypes.FbxBoolDT);
        prop3.Set(false);
        prop2 = AddPropertyGroup(prop1, "PresetsGrp", FbxDataTypes.FbxStringDT);
        prop2.Set("");
        prop3 = AddProperty(prop2, "Presets", FbxDataTypes.FbxEnumDT);
        prop3.Set(0);
        prop2 = AddPropertyGroup(prop1, "StatisticsGrp", FbxDataTypes.FbxStringDT);
        prop2.Set("");
        prop3 = AddProperty(prop2, "Statistics", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop2 = AddPropertyGroup(prop1, "IncludeGrp", FbxDataTypes.FbxStringDT);
        prop2.Set("");
        prop3 = AddProperty(prop2, "Geometry", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop3 = AddPropertyGroup(prop2, "Animation", FbxDataTypes.FbxBoolDT);
        prop3.Set(true);
        prop4 = AddPropertyGroup(prop3, "ExtraGrp", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop5 = AddProperty(prop4, "UseSceneName", FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "RemoveSingleKey", FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop4 = AddPropertyGroup(prop3, "BakeComplexAnimation", FbxDataTypes.FbxBoolDT);
        prop4.Set(false);
        prop5 = AddProperty(prop4, "BakeFrameStart", FbxDataTypes.FbxIntDT);
        prop5.Set(1);
        prop5 = AddProperty(prop4, "BakeFrameEnd", FbxDataTypes.FbxIntDT);
        prop5.Set(200);
        prop5 = AddProperty(prop4, "BakeFrameStep", FbxDataTypes.FbxIntDT);
        prop5.Set(1);
        prop5 = AddProperty(prop4, "ResampleAnimationCurves", FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "BakeFrameStartNoReset", FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "BakeFrameEndNoReset", FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "BakeFrameStepNoReset", FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop4 = AddPropertyGroup(prop3, "Deformation", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop5 = AddProperty(prop4, "Skins", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop4 = AddPropertyGroup(prop3, "CurveFilter", FbxDataTypes.FbxBoolDT);
        prop4.Set(false);
        prop5 = AddPropertyGroup(prop4, "CurveFilterApplyCstKeyRed",
            FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop6 = AddProperty(prop5, "CurveFilterSamplingRate", FbxDataTypes.FbxDoubleDT);
        prop6.Set(30.000000);
        prop6 = AddProperty(prop5, "CurveFilterCstKeyRedTPrec", FbxDataTypes.FbxDoubleDT);
        prop6.Set(0.000090);
        prop6 = AddProperty(prop5, "CurveFilterCstKeyRedRPrec", FbxDataTypes.FbxDoubleDT);
        prop6.Set(0.009000);
        prop6 = AddProperty(prop5, "CurveFilterCstKeyRedSPrec", FbxDataTypes.FbxDoubleDT);
        prop6.Set(0.004000);
        prop6 = AddProperty(prop5, "CurveFilterCstKeyRedOPrec", FbxDataTypes.FbxDoubleDT);
        prop6.Set(0.009000);
        prop6 = AddProperty(prop5, "AutoTangentsOnly", FbxDataTypes.FbxBoolDT);
        prop6.Set(true);
        prop3 = AddPropertyGroup(prop2, "CameraGrp", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop4 = AddProperty(prop3, "Camera", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop3 = AddPropertyGroup(prop2, "LightGrp", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop4 = AddProperty(prop3, "Light", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop3 = AddProperty(prop2, "Audio", FbxDataTypes.FbxBoolDT);
        prop3.Set(true);
        prop3 = AddPropertyGroup(prop2, "EmbedTextureGrp", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop4 = AddProperty(prop3, "EmbedTexture", FbxDataTypes.FbxBoolDT);
        prop4.Set(false);
        prop3 = AddProperty(prop2, "BindPose", FbxDataTypes.FbxBoolDT);
        prop3.Set(true);
        prop3 = AddProperty(prop2, "PivotToNulls", FbxDataTypes.FbxBoolDT);
        prop3.Set(false);
        prop2 = AddPropertyGroup(prop1, "AdvOptGrp", FbxDataTypes.FbxStringDT);
        prop2.Set("");
        prop3 = AddPropertyGroup(prop2, "UnitsGrp", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop4 = AddProperty(prop3, "TotalUnitsScale", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop4 = AddProperty(prop3, "DynamicScaleConversion", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "UnitsSelector", FbxDataTypes.FbxEnumDT);
        prop4.Set(0);
        prop4 = AddProperty(prop3, "UnitsScale", FbxDataTypes.FbxDoubleDT);
        prop4.Set(1.000000);
        prop4 = AddProperty(prop3, "MasterScale", FbxDataTypes.FbxDoubleDT);
        prop4.Set(1.000000);
        prop3 = AddProperty(prop2, "AxisConvGrp", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop3 = AddPropertyGroup(prop2, "UI", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop4 = AddProperty(prop3, "ShowWarningsManager", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "GenerateLogData", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "PluginVersionsURL", FbxDataTypes.FbxStringDT);
        prop4.Set(
            "http://download.autodesk.com/us/fbx/versions/fbxversion.xml");
        prop4 = AddProperty(prop3, "ShowUIMode", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop3 = AddPropertyGroup(prop2, "Cache", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop4 = AddProperty(prop3, "CacheSize", FbxDataTypes.FbxIntDT);
        prop4.Set(8);
        prop3 = AddPropertyGroup(prop2, "FileFormat", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop4 = AddPropertyGroup(prop3, "Obj", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop5 = AddProperty(prop4, "Triangulate", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "Deformation", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop4 = AddPropertyGroup(prop3, "Motion_Base", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop5 = AddProperty(prop4, "MotionStart", FbxDataTypes.FbxTimeDT);
        prop5.Set(new FbxTime(0L));
        prop5 = AddProperty(prop4, "MotionFrameCount", FbxDataTypes.FbxIntDT);
        prop5.Set(0);
        prop5 = AddProperty(prop4, "MotionFromGlobalPosition", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionFrameRate", FbxDataTypes.FbxDoubleDT);
        prop5.Set(30.000000);
        prop5 = AddProperty(prop4, "MotionGapsAsValidData", FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "MotionC3DRealFormat", FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop5 = AddProperty(prop4, "MotionASFSceneOwned", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop4 = AddPropertyGroup(prop3, "Biovision_BVH", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop5 = AddProperty(prop4, "MotionTranslation", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop4 = AddProperty(prop3, "MotionAnalysis_HTR", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop4 = AddProperty(prop3, "MotionAnalysis_TRC", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop4 = AddPropertyGroup(prop3, "Acclaim_ASF", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop5 = AddProperty(prop4, "MotionTranslation", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionFrameRateUsed", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionFrameRange", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionWriteDefaultAsBaseTR", FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop4 = AddPropertyGroup(prop3, "Acclaim_AMC", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop5 = AddProperty(prop4, "MotionTranslation", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionFrameRateUsed", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionFrameRange", FbxDataTypes.FbxBoolDT);
        prop5.Set(true);
        prop5 = AddProperty(prop4, "MotionWriteDefaultAsBaseTR", FbxDataTypes.FbxBoolDT);
        prop5.Set(false);
        prop3 = AddPropertyGroup(prop2, "Fbx", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop4 = AddProperty(prop3, "AsciiFbx", FbxDataTypes.FbxEnumDT);
        prop4.Set(0);
        prop4.AddEnumValue("Binary");
        prop4.AddEnumValue("ASCII");
        prop4 = AddProperty(prop3, "ExportFileVersion", FbxDataTypes.FbxEnumDT);
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
        prop4 = AddProperty(prop3, "VersionsUIAlias", FbxDataTypes.FbxEnumDT);
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
        prop4 = AddProperty(prop3, "VersionsCompDescriptions", FbxDataTypes.FbxEnumDT);
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
        prop4 = AddProperty(prop3, "Model", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Texture", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Material", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Shape", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Gobo", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Audio", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Animation", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Character", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Global_Settings", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Pivot", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Template", FbxDataTypes.FbxBoolDT);
        prop4.Set(false);
        prop4 = AddProperty(prop3, "Constraint", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "EMBEDDED", FbxDataTypes.FbxBoolDT);
        prop4.Set(false);
        prop4 = AddProperty(prop3, "Password_Enable", FbxDataTypes.FbxBoolDT);
        prop4.Set(false);
        prop4 = AddProperty(prop3, "Password", FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop4 = AddProperty(prop3, "COLLAPSE EXTERNALS", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Compress_Arrays", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Compress_Level", FbxDataTypes.FbxIntDT);
        prop4.Set(1);
        prop4 = AddProperty(prop3, "Compress_Minsize", FbxDataTypes.FbxIntDT);
        prop4.Set(1024);
        prop4 = AddProperty(prop3, "Embedded_Skipped_Properties",
            FbxDataTypes.FbxStringDT);
        prop4.Set("");
        prop3 = AddPropertyGroup(prop2, "Dxf", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop4 = AddProperty(prop3, "Deformation", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "Triangulate", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop3 = AddPropertyGroup(prop2, "Collada", FbxDataTypes.FbxStringDT);
        prop3.Set("");
        prop4 = AddProperty(prop3, "Triangulate", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "SingleMatrix", FbxDataTypes.FbxBoolDT);
        prop4.Set(true);
        prop4 = AddProperty(prop3, "FrameRate", FbxDataTypes.FbxDoubleDT);
        prop4.Set(30.000000);
        prop2 = AddPropertyGroup(prop1, "FBXExtentionsSDK", FbxDataTypes.FbxStringDT);
        prop2.Set("");
        prop3 = AddProperty(prop2, "FBXExtentionsSDKWarning", FbxDataTypes.FbxStringDT);
        prop3.Set("Add your custom properties here.");
    }

    #endregion

    #region Static Protected MemberFunctions

    // static FbxIOSettings * 	Allocate (FbxManager *pManager, const char *pName, const FbxIOSettings *pFrom)

    #endregion
}
