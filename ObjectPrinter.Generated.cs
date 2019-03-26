using System;
using System.IO;
using System.Collections.Generic;

namespace FbxSharp
{
    public partial class ObjectPrinter
    {
        public void Print(object obj, TextWriter writer=null)
        {
            if (obj == null) return;
            if (writer == null) writer = Console.Out;

            if (obj is FbxObject)
                PrintFbxObject((FbxObject)obj, writer);

            writer.WriteLine();
        }

        protected void PrintFbxObject(FbxObject obj, TextWriter writer)
        {
            _PrintFbxObject(obj, writer);

            if (obj is FbxAnimCurveBase)
                PrintFbxAnimCurveBase((FbxAnimCurveBase)obj, writer);
            if (obj is FbxAnimCurveNode)
                PrintFbxAnimCurveNode((FbxAnimCurveNode)obj, writer);
            if (obj is FbxAnimEvaluator)
                PrintFbxAnimEvaluator((FbxAnimEvaluator)obj, writer);
            if (obj is FbxCollection)
                PrintFbxCollection((FbxCollection)obj, writer);
            if (obj is FbxDeformer)
                PrintFbxDeformer((FbxDeformer)obj, writer);
            if (obj is FbxGlobalSettings)
                PrintFbxGlobalSettings((FbxGlobalSettings)obj, writer);
            if (obj is FbxIOBase)
                PrintFbxIOBase((FbxIOBase)obj, writer);
            if (obj is FbxNode)
                PrintFbxNode((FbxNode)obj, writer);
            if (obj is FbxNodeAttribute)
                PrintFbxNodeAttribute((FbxNodeAttribute)obj, writer);
            if (obj is FbxPose)
                PrintFbxPose((FbxPose)obj, writer);
            if (obj is FbxSubDeformer)
                PrintFbxSubDeformer((FbxSubDeformer)obj, writer);
            if (obj is FbxSurfaceMaterial)
                PrintFbxSurfaceMaterial((FbxSurfaceMaterial)obj, writer);
            if (obj is FbxTexture)
                PrintFbxTexture((FbxTexture)obj, writer);
            if (obj is FbxVideo)
                PrintFbxVideo((FbxVideo)obj, writer);
        }

        protected void PrintFbxAnimCurveBase(FbxAnimCurveBase obj, TextWriter writer)
        {
            _PrintFbxAnimCurveBase(obj, writer);

            if (obj is FbxAnimCurve)
                PrintFbxAnimCurve((FbxAnimCurve)obj, writer);
        }

        protected void PrintFbxAnimCurve(FbxAnimCurve obj, TextWriter writer)
        {
            _PrintFbxAnimCurve(obj, writer);
        }

        protected void PrintFbxAnimCurveNode(FbxAnimCurveNode obj, TextWriter writer)
        {
            _PrintFbxAnimCurveNode(obj, writer);
        }

        protected void PrintFbxAnimEvaluator(FbxAnimEvaluator obj, TextWriter writer)
        {
            _PrintFbxAnimEvaluator(obj, writer);

            if (obj is FbxAnimEvalClassic)
                PrintFbxAnimEvalClassic((FbxAnimEvalClassic)obj, writer);
        }

        protected void PrintFbxAnimEvalClassic(FbxAnimEvalClassic obj, TextWriter writer)
        {
            _PrintFbxAnimEvalClassic(obj, writer);
        }

        protected void PrintFbxCollection(FbxCollection obj, TextWriter writer)
        {
            _PrintFbxCollection(obj, writer);

            if (obj is FbxAnimLayer)
                PrintFbxAnimLayer((FbxAnimLayer)obj, writer);
            if (obj is FbxAnimStack)
                PrintFbxAnimStack((FbxAnimStack)obj, writer);
            if (obj is FbxDocument)
                PrintFbxDocument((FbxDocument)obj, writer);
        }

        protected void PrintFbxAnimLayer(FbxAnimLayer obj, TextWriter writer)
        {
            _PrintFbxAnimLayer(obj, writer);
        }

        protected void PrintFbxAnimStack(FbxAnimStack obj, TextWriter writer)
        {
            _PrintFbxAnimStack(obj, writer);
        }

        protected void PrintFbxDocument(FbxDocument obj, TextWriter writer)
        {
            _PrintFbxDocument(obj, writer);

            if (obj is FbxScene)
                PrintFbxScene((FbxScene)obj, writer);
        }

        protected void PrintFbxScene(FbxScene obj, TextWriter writer)
        {
            _PrintFbxScene(obj, writer);
        }

        protected void PrintFbxDeformer(FbxDeformer obj, TextWriter writer)
        {
            _PrintFbxDeformer(obj, writer);

            if (obj is FbxSkin)
                PrintFbxSkin((FbxSkin)obj, writer);
        }

        protected void PrintFbxSkin(FbxSkin obj, TextWriter writer)
        {
            _PrintFbxSkin(obj, writer);
        }

        protected void PrintFbxGlobalSettings(FbxGlobalSettings obj, TextWriter writer)
        {
            _PrintFbxGlobalSettings(obj, writer);
        }

        protected void PrintFbxIOBase(FbxIOBase obj, TextWriter writer)
        {
            _PrintFbxIOBase(obj, writer);

            if (obj is FbxImporter)
                PrintFbxImporter((FbxImporter)obj, writer);
        }

        protected void PrintFbxImporter(FbxImporter obj, TextWriter writer)
        {
            _PrintFbxImporter(obj, writer);
        }

        protected void PrintFbxNode(FbxNode obj, TextWriter writer)
        {
            _PrintFbxNode(obj, writer);
        }

        protected void PrintFbxNodeAttribute(FbxNodeAttribute obj, TextWriter writer)
        {
            _PrintFbxNodeAttribute(obj, writer);

            if (obj is FbxCamera)
                PrintFbxCamera((FbxCamera)obj, writer);
            if (obj is FbxLayerContainer)
                PrintFbxLayerContainer((FbxLayerContainer)obj, writer);
            if (obj is FbxLight)
                PrintFbxLight((FbxLight)obj, writer);
            if (obj is FbxNull)
                PrintFbxNull((FbxNull)obj, writer);
            if (obj is FbxSkeleton)
                PrintFbxSkeleton((FbxSkeleton)obj, writer);
        }

        protected void PrintFbxCamera(FbxCamera obj, TextWriter writer)
        {
            _PrintFbxCamera(obj, writer);
        }

        protected void PrintFbxLayerContainer(FbxLayerContainer obj, TextWriter writer)
        {
            _PrintFbxLayerContainer(obj, writer);

            if (obj is FbxGeometryBase)
                PrintFbxGeometryBase((FbxGeometryBase)obj, writer);
        }

        protected void PrintFbxGeometryBase(FbxGeometryBase obj, TextWriter writer)
        {
            _PrintFbxGeometryBase(obj, writer);

            if (obj is FbxGeometry)
                PrintFbxGeometry((FbxGeometry)obj, writer);
        }

        protected void PrintFbxGeometry(FbxGeometry obj, TextWriter writer)
        {
            _PrintFbxGeometry(obj, writer);

            if (obj is FbxMesh)
                PrintFbxMesh((FbxMesh)obj, writer);
        }

        protected void PrintFbxMesh(FbxMesh obj, TextWriter writer)
        {
            _PrintFbxMesh(obj, writer);
        }

        protected void PrintFbxLight(FbxLight obj, TextWriter writer)
        {
            _PrintFbxLight(obj, writer);
        }

        protected void PrintFbxNull(FbxNull obj, TextWriter writer)
        {
            _PrintFbxNull(obj, writer);
        }

        protected void PrintFbxSkeleton(FbxSkeleton obj, TextWriter writer)
        {
            _PrintFbxSkeleton(obj, writer);
        }

        protected void PrintFbxPose(FbxPose obj, TextWriter writer)
        {
            _PrintFbxPose(obj, writer);
        }

        protected void PrintFbxSubDeformer(FbxSubDeformer obj, TextWriter writer)
        {
            _PrintFbxSubDeformer(obj, writer);

            if (obj is FbxCluster)
                PrintFbxCluster((FbxCluster)obj, writer);
        }

        protected void PrintFbxCluster(FbxCluster obj, TextWriter writer)
        {
            _PrintFbxCluster(obj, writer);
        }

        protected void PrintFbxSurfaceMaterial(FbxSurfaceMaterial obj, TextWriter writer)
        {
            _PrintFbxSurfaceMaterial(obj, writer);

            if (obj is FbxSurfaceLambert)
                PrintFbxSurfaceLambert((FbxSurfaceLambert)obj, writer);
        }

        protected void PrintFbxSurfaceLambert(FbxSurfaceLambert obj, TextWriter writer)
        {
            _PrintFbxSurfaceLambert(obj, writer);

            if (obj is FbxSurfacePhong)
                PrintFbxSurfacePhong((FbxSurfacePhong)obj, writer);
        }

        protected void PrintFbxSurfacePhong(FbxSurfacePhong obj, TextWriter writer)
        {
            _PrintFbxSurfacePhong(obj, writer);
        }

        protected void PrintFbxTexture(FbxTexture obj, TextWriter writer)
        {
            _PrintFbxTexture(obj, writer);
        }

        protected void PrintFbxVideo(FbxVideo obj, TextWriter writer)
        {
            _PrintFbxVideo(obj, writer);
        }
    }
}
