using System;

namespace FbxSharp
{
    public class FbxSystemUnit
    {
        public FbxSystemUnit()
        {
            throw new NotImplementedException();
        }
        public FbxSystemUnit(double pScaleFactor, double pMultiplier=1.0)
        {
            throw new NotImplementedException();
        }

        public struct ConversionOptions
        {
            public bool mConvertRrsNodes;
            public bool mConvertLimits;
            public bool mConvertClusters;
            public bool mConvertLightIntensity;
            public bool mConvertPhotometricLProperties;
            public bool mConvertCameraClipPlanes;
        }

        public static /*const*/ FbxSystemUnit mm;
        public static /*const*/ FbxSystemUnit dm;
        public static /*const*/ FbxSystemUnit cm;
        public static /*const*/ FbxSystemUnit m;
        public static /*const*/ FbxSystemUnit km;
        public static /*const*/ FbxSystemUnit Inch;
        public static /*const*/ FbxSystemUnit Foot;
        public static /*const*/ FbxSystemUnit Mile;
        public static /*const*/ FbxSystemUnit Yard;

        public static /*const*/ FbxSystemUnit /***/sPredefinedUnits;

        public static /*const*/ ConversionOptions DefaultConversionOptions;

        public void ConvertScene(Scene /***/pScene) /*const*/
        {
            ConvertScene(pScene, DefaultConversionOptions);
        }
        public void ConvertScene(Scene /***/pScene, /*const*/ ConversionOptions /*&*/pOptions) /*const*/
        {
            throw new NotImplementedException();
        }

        public void ConvertChildren(Node /***/pRoot, /*const*/ FbxSystemUnit /*&*/pSrcUnit) /*const*/
        {
            ConvertChildren(pRoot, pSrcUnit, DefaultConversionOptions);
        }
        public void ConvertChildren(Node /***/pRoot, /*const*/ FbxSystemUnit /*&*/pSrcUnit, /*const*/ ConversionOptions /*&*/pOptions) /*const*/
        {
            throw new NotImplementedException();
        }

        public void ConvertScene(Scene /***/pScene, Node /***/pFbxRoot) /*const*/
        {
            ConvertScene(pScene, pFbxRoot);
        }
        public void ConvertScene(Scene /***/pScene, Node /***/pFbxRoot, /*const*/ ConversionOptions /*&*/pOptions) /*const*/
        {
            throw new NotImplementedException();
        }

        public double GetScaleFactor() /*const*/
        {
            throw new NotImplementedException();
        }

        public string GetScaleFactorAsString(bool pAbbreviated=true) /*const*/
        {
            throw new NotImplementedException();
        }

        public string GetScaleFactorAsString_Plurial() /*const*/
        {
            throw new NotImplementedException();
        }

        public double GetMultiplier() /*const*/
        {
            throw new NotImplementedException();
        }

        //public bool operator == (/*const*/ FbxSystemUnit &pOther) /*const*/
        //{
        //    throw new NotImplementedException();
        //}

        //public bool operator != (/*const*/ FbxSystemUnit &pOther) /*const*/
        //{
        //    throw new NotImplementedException();
        //}

        //public FbxSystemUnit& operator = (/*const*/ FbxSystemUnit &pSystemUnit)
        //{
        //    throw new NotImplementedException();
        //}

        public double GetConversionFactorTo(/*const*/ FbxSystemUnit /*&*/pTarget) /*const*/
        {
            throw new NotImplementedException();
        }

        public double GetConversionFactorFrom(/*const*/ FbxSystemUnit /*&*/pSource) /*const*/
        {
            throw new NotImplementedException();
        }
    }
}

