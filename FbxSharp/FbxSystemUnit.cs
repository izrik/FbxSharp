using System;
using System.Diagnostics;

namespace FbxSharp;

public class FbxSystemUnit
{
    #region Classes

    public class ConversionOptions
    {
    }

    #endregion

    #region Public Member Functions

    public FbxSystemUnit()
        : this(1)
    {
    }

    public FbxSystemUnit(double pScaleFactor, double pMultiplier = 1.0)
    {
        scaleFactor = pScaleFactor;
        multiplier = pMultiplier;
    }

    // public ~FbxSystemUnit ()=>throw new NotImplementedException();

    [DeviationFromSdk("C# doesn't allow non-null default value for pOptions")]
    public void ConvertScene(FbxScene pScene) => ConvertScene(pScene, DefaultConversionOptions);

    [DeviationFromSdk("C# doesn't allow non-null default value for pOptions")]
    public void ConvertScene(FbxScene pScene, ConversionOptions pOptions) => throw new NotImplementedException();

    [DeviationFromSdk("C# doesn't allow non-null default value for pOptions")]
    public void ConvertChildren(FbxNode pRoot, FbxSystemUnit pSrcUnit) =>
        ConvertChildren(pRoot, pSrcUnit, DefaultConversionOptions);

    [DeviationFromSdk("C# doesn't allow non-null default value for pOptions")]
    public void ConvertChildren(FbxNode pRoot, FbxSystemUnit pSrcUnit, ConversionOptions pOptions) =>
        throw new NotImplementedException();

    public void ConvertScene(FbxScene pScene, FbxNode pFbxRoot) =>
        ConvertScene(pScene, pFbxRoot, DefaultConversionOptions);

    public void ConvertScene(FbxScene pScene, FbxNode pFbxRoot, ConversionOptions pOptions) =>
        throw new NotImplementedException();

    public double GetScaleFactor() => scaleFactor;

    public string GetScaleFactorAsString(bool pAbbreviated = true)
    {
        switch (scaleFactor)
        {
            case 0.1: return "mm";
            case 1: return "cm";
            case 10: return "dm";
            case 100: return "m";
            case 100000: return "km";
            case 2.54: return "in";
            case 30.48: return "ft";
            case 91.44: return "yd";
            case 160934.4: return "mi";
        }

        return "un";
    }
    
    public string GetScaleFactorAsString_Plurial() 
    {
        switch (scaleFactor)
        {
            case 0.1: return "Millimeters";
            case 1: return "Centimeters";
            case 10: return "Decimeters";
            case 100: return "Meters";
            case 100000: return "Kilometers";
            case 2.54: return "Inches";
            case 30.48: return "Feet";
            case 91.44: return "Yards";
            case 160934.4: return "Miles";
        }

        return "un";
    }

    public double GetMultiplier() => multiplier;

    // public bool 	operator== (FbxSystemUnit &pOther)=>throw new NotImplementedException();
    // public bool 	operator!= (FbxSystemUnit &pOther)=>throw new NotImplementedException();
    // public FbxSystemUnit & 	operator= (FbxSystemUnit &pSystemUnit)=>throw new NotImplementedException();
    public double GetConversionFactorTo(FbxSystemUnit pTarget) => throw new NotImplementedException();
    public double GetConversionFactorFrom(FbxSystemUnit pSource) => throw new NotImplementedException();

    #endregion

    #region Static Public Attributes

    public static FbxSystemUnit mm = new FbxSystemUnit(0.1);
    public static FbxSystemUnit dm = new FbxSystemUnit(10);
    public static FbxSystemUnit cm = new FbxSystemUnit();
    public static FbxSystemUnit m = new FbxSystemUnit(100);
    public static FbxSystemUnit km = new FbxSystemUnit(100000);
    public static FbxSystemUnit Inch = new FbxSystemUnit(2.54);
    public static FbxSystemUnit Foot = new FbxSystemUnit(30.48);
    public static FbxSystemUnit Mile = new FbxSystemUnit(160934.4);
    public static FbxSystemUnit Yard = new FbxSystemUnit(91.44);
    public static FbxSystemUnit sPredefinedUnits = mm;
    public static ConversionOptions DefaultConversionOptions = new ConversionOptions();

    #endregion

    private double scaleFactor;
    private double multiplier;
}