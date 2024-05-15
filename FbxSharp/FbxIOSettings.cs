using System;

namespace FbxSharp;

public class FbxIOSettings : FbxObject
{
    public virtual FbxClassId GetClassId()
    {
        throw new NotImplementedException();
    }

    // public FbxProperty AddPropertyGroup(string pName, FbxDataType pDataType,
    //     string pLabel = "")
    // {
    // }

    // public FbxProperty AddPropertyGroup(FbxProperty pParentProperty, string pName,
    // const FbxDataType &pDataType=FbxDataType(), string pLabel = "", bool pVisible = true,
    //     bool pSavable = true, bool pEnabled = true)
    // {
    // }

    // public FbxProperty AddProperty(FbxProperty pParentProperty, string pName,
    //     FbxDataType pDataType = null, string pLabel = "", 
    //     const void* pValue = null,  bool pVisible = true, bool
    //     pSavable = true, bool pEnabled = true){
    // }

    // public FbxProperty AddPropertyMinMax(FbxProperty pParentProperty, string pName,
    //     FbxDataType pDataType = null, string pLabel = "",
    //     object pValue = null, double? pMinValue = null,
    //     double? pMaxValue = null, bool pVisible = true, bool pSavable = true,
    //     bool pEnabled = true)
    // {
    // }

    public FbxProperty GetProperty(string pName)
    {
        throw new NotImplementedException();
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
}