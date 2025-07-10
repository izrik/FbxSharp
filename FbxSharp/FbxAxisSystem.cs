using System;

namespace FbxSharp;

public class FbxAxisSystem
{
    #region Public Types

    public enum EUpVector
    {
        eXAxis = 1,
        eYAxis = 2,
        eZAxis = 3
    }

    public enum EFrontVector
    {
        eParityEven = 1,
        eParityOdd = 2
    }

    public enum ECoordSystem
    {
        eRightHanded,
        eLeftHanded
    }

    public enum EPreDefinedAxisSystem
    {
        eMayaZUp,
        eMayaYUp,
        eMax,
        eMotionBuilder,
        eOpenGL,
        eDirectX,
        eLightwave
    }

    #endregion

    #region Public Member Functions

    // FbxAxisSystem  	operator= ( FbxAxisSystem pAxisSystem)
    public void DeepConvertScene(FbxScene pScene) =>
        throw new NotImplementedException();

    public void ConvertScene(FbxScene pScene) =>
        throw new NotImplementedException();

    public void ConvertScene(FbxScene pScene, FbxNode pFbxRoot) =>
        throw new NotImplementedException();

    public EFrontVector GetFrontVector(ref int pSign)
    {
        pSign = frontVectorSign;
        return frontVector;
    }

    public EUpVector GetUpVector(ref int pSign)
    {
        pSign = upVectorSign;
        return upVector;
    }

    public ECoordSystem GetCoorSystem() => coordSystem;

    // public void GetMatrix(ref FbxAMatrix pMatrix) =>
    //     throw new NotImplementedException();

    public void ConvertChildren(FbxNode pRoot, ref FbxAxisSystem pSrcSystem) =>
        throw new NotImplementedException();

    #endregion

    #region Constructor and Destructor

    public FbxAxisSystem()
    {
        upVector = EUpVector.eYAxis;
        upVectorSign = 1;
        frontVector = EFrontVector.eParityOdd;
        frontVectorSign = 1;
        coordSystem = ECoordSystem.eRightHanded;
    }

    public FbxAxisSystem(EUpVector pUpVector, EFrontVector pFrontVector, ECoordSystem pCoorSystem) =>
        throw new NotImplementedException();

    public FbxAxisSystem(FbxAxisSystem pAxisSystem) =>
        throw new NotImplementedException();

    public FbxAxisSystem(EPreDefinedAxisSystem pAxisSystem) =>
        throw new NotImplementedException();

    public virtual void Dispose() =>
        // ~FbxAxisSystem
        throw new NotImplementedException();

    public static bool ParseAxisSystem(string pAxes, ref FbxAxisSystem pOutput) =>
        throw new NotImplementedException();

    #endregion

    private EUpVector upVector;
    private int upVectorSign;
    private EFrontVector frontVector;
    private int frontVectorSign;
    private ECoordSystem coordSystem;
}