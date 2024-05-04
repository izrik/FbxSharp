using System;
using System.Collections.Generic;

namespace FbxSharp
{
    public partial class Visitor
    {
        public virtual void Visit(FbxAnimCurveBase obj) { }
        public virtual void Visit(FbxImporter obj) { }
        public virtual void Visit(FbxAnimCurve obj) { }
        public virtual void Visit(FbxVideo obj) { }
        public virtual void Visit(FbxNode obj) { }
        public virtual void Visit(FbxSurfaceLambert obj) { }
        public virtual void Visit(FbxNodeAttribute obj) { }
        public virtual void Visit(FbxAnimCurveNode obj) { }
        public virtual void Visit(FbxCamera obj) { }
        public virtual void Visit(FbxSurfacePhong obj) { }
        public virtual void Visit(FbxAnimEvaluator obj) { }
        public virtual void Visit(FbxLayerContainer obj) { }
        public virtual void Visit(FbxAnimEvalClassic obj) { }
        public virtual void Visit(FbxGeometryBase obj) { }
        public virtual void Visit(FbxCollection obj) { }
        public virtual void Visit(FbxSurfaceMaterial obj) { }
        public virtual void Visit(FbxGeometry obj) { }
        public virtual void Visit(FbxAnimLayer obj) { }
        public virtual void Visit(FbxMesh obj) { }
        public virtual void Visit(FbxAnimStack obj) { }
        public virtual void Visit(FbxLight obj) { }
        public virtual void Visit(FbxDocument obj) { }
        public virtual void Visit(FbxNull obj) { }
        public virtual void Visit(FbxTexture obj) { }
        public virtual void Visit(FbxScene obj) { }
        public virtual void Visit(FbxSkeleton obj) { }
        public virtual void Visit(FbxDeformer obj) { }
        public virtual void Visit(FbxPose obj) { }
        public virtual void Visit(FbxSkin obj) { }
        public virtual void Visit(FbxObject obj) { }
        public virtual void Visit(FbxSubDeformer obj) { }
        public virtual void Visit(FbxGlobalSettings obj) { }
        public virtual void Visit(FbxCluster obj) { }
        public virtual void Visit(FbxIOBase obj) { }

        /*********************************/

        public void Accept(object obj, ISet<object> visitedObjects=null)
        {
            if (obj == null) return;
            if (visitedObjects == null) visitedObjects = new HashSet<object>();
            if (visitedObjects.Contains(obj)) return;
            visitedObjects.Add(obj);

            if (obj is FbxObject)
                AcceptFbxObject((FbxObject)obj, visitedObjects);
        }

        protected void AcceptFbxObject(FbxObject obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxObject(obj, visitedObjects);

            if (obj is FbxAnimCurveBase)
                AcceptFbxAnimCurveBase((FbxAnimCurveBase)obj, visitedObjects);
            if (obj is FbxAnimCurveNode)
                AcceptFbxAnimCurveNode((FbxAnimCurveNode)obj, visitedObjects);
            if (obj is FbxAnimEvaluator)
                AcceptFbxAnimEvaluator((FbxAnimEvaluator)obj, visitedObjects);
            if (obj is FbxCollection)
                AcceptFbxCollection((FbxCollection)obj, visitedObjects);
            if (obj is FbxDeformer)
                AcceptFbxDeformer((FbxDeformer)obj, visitedObjects);
            if (obj is FbxGlobalSettings)
                AcceptFbxGlobalSettings((FbxGlobalSettings)obj, visitedObjects);
            if (obj is FbxIOBase)
                AcceptFbxIOBase((FbxIOBase)obj, visitedObjects);
            if (obj is FbxNode)
                AcceptFbxNode((FbxNode)obj, visitedObjects);
            if (obj is FbxNodeAttribute)
                AcceptFbxNodeAttribute((FbxNodeAttribute)obj, visitedObjects);
            if (obj is FbxPose)
                AcceptFbxPose((FbxPose)obj, visitedObjects);
            if (obj is FbxSubDeformer)
                AcceptFbxSubDeformer((FbxSubDeformer)obj, visitedObjects);
            if (obj is FbxSurfaceMaterial)
                AcceptFbxSurfaceMaterial((FbxSurfaceMaterial)obj, visitedObjects);
            if (obj is FbxTexture)
                AcceptFbxTexture((FbxTexture)obj, visitedObjects);
            if (obj is FbxVideo)
                AcceptFbxVideo((FbxVideo)obj, visitedObjects);
        }

        protected void AcceptFbxAnimCurveBase(FbxAnimCurveBase obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxAnimCurveBase(obj, visitedObjects);

            if (obj is FbxAnimCurve)
                AcceptFbxAnimCurve((FbxAnimCurve)obj, visitedObjects);
        }

        protected void AcceptFbxAnimCurve(FbxAnimCurve obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxAnimCurve(obj, visitedObjects);

        }

        protected void AcceptFbxAnimCurveNode(FbxAnimCurveNode obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxAnimCurveNode(obj, visitedObjects);

        }

        protected void AcceptFbxAnimEvaluator(FbxAnimEvaluator obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxAnimEvaluator(obj, visitedObjects);

            if (obj is FbxAnimEvalClassic)
                AcceptFbxAnimEvalClassic((FbxAnimEvalClassic)obj, visitedObjects);
        }

        protected void AcceptFbxAnimEvalClassic(FbxAnimEvalClassic obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxAnimEvalClassic(obj, visitedObjects);

        }

        protected void AcceptFbxCollection(FbxCollection obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxCollection(obj, visitedObjects);

            if (obj is FbxAnimLayer)
                AcceptFbxAnimLayer((FbxAnimLayer)obj, visitedObjects);
            if (obj is FbxAnimStack)
                AcceptFbxAnimStack((FbxAnimStack)obj, visitedObjects);
            if (obj is FbxDocument)
                AcceptFbxDocument((FbxDocument)obj, visitedObjects);
        }

        protected void AcceptFbxAnimLayer(FbxAnimLayer obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxAnimLayer(obj, visitedObjects);

        }

        protected void AcceptFbxAnimStack(FbxAnimStack obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxAnimStack(obj, visitedObjects);

        }

        protected void AcceptFbxDocument(FbxDocument obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxDocument(obj, visitedObjects);

            if (obj is FbxScene)
                AcceptFbxScene((FbxScene)obj, visitedObjects);
        }

        protected void AcceptFbxScene(FbxScene obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxScene(obj, visitedObjects);

        }

        protected void AcceptFbxDeformer(FbxDeformer obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxDeformer(obj, visitedObjects);

            if (obj is FbxSkin)
                AcceptFbxSkin((FbxSkin)obj, visitedObjects);
        }

        protected void AcceptFbxSkin(FbxSkin obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxSkin(obj, visitedObjects);

        }

        protected void AcceptFbxGlobalSettings(FbxGlobalSettings obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxGlobalSettings(obj, visitedObjects);

        }

        protected void AcceptFbxIOBase(FbxIOBase obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxIOBase(obj, visitedObjects);

            if (obj is FbxImporter)
                AcceptFbxImporter((FbxImporter)obj, visitedObjects);
        }

        protected void AcceptFbxImporter(FbxImporter obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxImporter(obj, visitedObjects);

        }

        protected void AcceptFbxNode(FbxNode obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxNode(obj, visitedObjects);

        }

        protected void AcceptFbxNodeAttribute(FbxNodeAttribute obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxNodeAttribute(obj, visitedObjects);

            if (obj is FbxCamera)
                AcceptFbxCamera((FbxCamera)obj, visitedObjects);
            if (obj is FbxLayerContainer)
                AcceptFbxLayerContainer((FbxLayerContainer)obj, visitedObjects);
            if (obj is FbxLight)
                AcceptFbxLight((FbxLight)obj, visitedObjects);
            if (obj is FbxNull)
                AcceptFbxNull((FbxNull)obj, visitedObjects);
            if (obj is FbxSkeleton)
                AcceptFbxSkeleton((FbxSkeleton)obj, visitedObjects);
        }

        protected void AcceptFbxCamera(FbxCamera obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxCamera(obj, visitedObjects);

        }

        protected void AcceptFbxLayerContainer(FbxLayerContainer obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxLayerContainer(obj, visitedObjects);

            if (obj is FbxGeometryBase)
                AcceptFbxGeometryBase((FbxGeometryBase)obj, visitedObjects);
        }

        protected void AcceptFbxGeometryBase(FbxGeometryBase obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxGeometryBase(obj, visitedObjects);

            if (obj is FbxGeometry)
                AcceptFbxGeometry((FbxGeometry)obj, visitedObjects);
        }

        protected void AcceptFbxGeometry(FbxGeometry obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxGeometry(obj, visitedObjects);

            if (obj is FbxMesh)
                AcceptFbxMesh((FbxMesh)obj, visitedObjects);
        }

        protected void AcceptFbxMesh(FbxMesh obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxMesh(obj, visitedObjects);

        }

        protected void AcceptFbxLight(FbxLight obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxLight(obj, visitedObjects);

        }

        protected void AcceptFbxNull(FbxNull obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxNull(obj, visitedObjects);

        }

        protected void AcceptFbxSkeleton(FbxSkeleton obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxSkeleton(obj, visitedObjects);

        }

        protected void AcceptFbxPose(FbxPose obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxPose(obj, visitedObjects);

        }

        protected void AcceptFbxSubDeformer(FbxSubDeformer obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxSubDeformer(obj, visitedObjects);

            if (obj is FbxCluster)
                AcceptFbxCluster((FbxCluster)obj, visitedObjects);
        }

        protected void AcceptFbxCluster(FbxCluster obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxCluster(obj, visitedObjects);

        }

        protected void AcceptFbxSurfaceMaterial(FbxSurfaceMaterial obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxSurfaceMaterial(obj, visitedObjects);

            if (obj is FbxSurfaceLambert)
                AcceptFbxSurfaceLambert((FbxSurfaceLambert)obj, visitedObjects);
        }

        protected void AcceptFbxSurfaceLambert(FbxSurfaceLambert obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxSurfaceLambert(obj, visitedObjects);

            if (obj is FbxSurfacePhong)
                AcceptFbxSurfacePhong((FbxSurfacePhong)obj, visitedObjects);
        }

        protected void AcceptFbxSurfacePhong(FbxSurfacePhong obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxSurfacePhong(obj, visitedObjects);

        }

        protected void AcceptFbxTexture(FbxTexture obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxTexture(obj, visitedObjects);

        }

        protected void AcceptFbxVideo(FbxVideo obj, ISet<object> visitedObjects=null)
        {
            Visit(obj);

            _AcceptFbxVideo(obj, visitedObjects);

        }
    }
}

