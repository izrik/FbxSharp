using System;
using FbxSharp;
using System.Collections.Generic;

namespace FbxSharp
{
    public partial class Visitor
    {
//        public virtual void Visit(FbxObject obj) { }
//        public virtual void Visit(FbxScene scene) { }
//        public virtual void Visit(FbxNode node) { }
//        public virtual void Visit(FbxNodeAttribute obj) { }
//        public virtual void Visit(FbxSurfaceMaterial obj) { }
//        public virtual void Visit(FbxSurfaceLambert obj) { }
//        public virtual void Visit(FbxSurfacePhong obj) { }
//        public virtual void Visit(FbxMesh obj) { }
//        public virtual void Visit(FbxGeometry obj) { }
//        public virtual void Visit(FbxGeometryBase obj) { }
//        public virtual void Visit(FbxLayerElementTexture tex) { }
//        public virtual void Visit(FbxLayerContainer layerContainer) { }
//        public virtual void Visit(FbxDocument obj) { }
//        public virtual void Visit(FbxCollection obj) { }
//        public virtual void Visit(FbxAnimLayer obj) { }
//        public virtual void Visit(FbxAnimStack obj) { }
//        public virtual void Visit(FbxAnimCurve obj) { }
//        public virtual void Visit(FbxAnimCurveNode obj) { }
//        public virtual void Visit(FbxDeformer obj) { }
//        public virtual void Visit(FbxPose pose) { }
//        public virtual void Visit(FbxSubDeformer obj) { }
//        public virtual void Visit(FbxTexture obj) { }
//        public virtual void Visit(FbxVideo obj) { }
//        public virtual void Visit(FbxCamera obj) { }
//        public virtual void Visit(FbxLight obj) { }
//        public virtual void Visit(FbxNull obj) { }
//        public virtual void Visit(FbxSkeleton obj) { }

        /*********************************/


//        public void Accept(object obj)
//        {
//            Accept(obj, new HashSet<object>());
//        }
//
//        protected void Accept(object obj, ISet<object> visitedObjects)
//        {
//            if (obj == null) return;
//            if (visitedObjects.Contains(obj)) return;
//            visitedObjects.Add(obj);
//
//            var type = obj.GetType();
//
//            //            var prop = obj as Property;
//            //            if (prop != null)
//            //            {
//            //                Accept(prop, visitedObjects);
//            //                return;
//            //            }
//
//            if (type == typeof(FbxObject))
//                _AcceptFbxObject((FbxObject)obj, visitedObjects);
//            else if (type == typeof(FbxScene))
//                _AcceptFbxScene((FbxScene)obj, visitedObjects);
//            else if (type == typeof(FbxNode))
//                _AcceptFbxNode((FbxNode)obj, visitedObjects);
//            else if (type == typeof(FbxNodeAttribute))
//                _AcceptFbxNodeAttribute((FbxNodeAttribute)obj, visitedObjects);
//            else if (type == typeof(FbxSurfaceMaterial))
//                _AcceptFbxSurfaceMaterial((FbxSurfaceMaterial)obj, visitedObjects);
//            else if (type == typeof(FbxSurfaceLambert))
//                _AcceptFbxSurfaceLambert((FbxSurfaceLambert)obj, visitedObjects);
//            else if (type == typeof(FbxSurfacePhong))
//                _AcceptFbxSurfacePhong((FbxSurfacePhong)obj, visitedObjects);
//            else if (type == typeof(FbxMesh))
//                _AcceptFbxMesh((FbxMesh)obj, visitedObjects);
//            else if (type == typeof(FbxGeometry))
//                _AcceptFbxGeometry((FbxGeometry)obj, visitedObjects);
//            else if (type == typeof(FbxGeometryBase))
//                _AcceptFbxGeometryBase((FbxGeometryBase)obj, visitedObjects);
//            else if (type == typeof(FbxLayerElementTexture))
//                _AcceptFbxLayerElementTexture((FbxLayerElementTexture)obj, visitedObjects);
//            else if (type == typeof(FbxLayerContainer))
//                _AcceptFbxLayerContainer((FbxLayerContainer)obj, visitedObjects);
//            else if (type == typeof(FbxDocument))
//                _AcceptFbxDocument((FbxDocument)obj, visitedObjects);
//            else if (type == typeof(FbxCollection))
//                _AcceptFbxCollection((FbxCollection)obj, visitedObjects);
//            else if (type == typeof(FbxAnimLayer))
//                _AcceptFbxAnimLayer((FbxAnimLayer)obj, visitedObjects);
//            else if (type == typeof(FbxAnimStack))
//                _AcceptFbxAnimStack((FbxAnimStack)obj, visitedObjects);
//            else if (type == typeof(FbxAnimCurve))
//                _AcceptFbxAnimCurve((FbxAnimCurve)obj, visitedObjects);
//            else if (type == typeof(FbxAnimCurveNode))
//                _AcceptFbxAnimCurveNode((FbxAnimCurveNode)obj, visitedObjects);
//            else if (type == typeof(FbxDeformer))
//                _AcceptFbxDeformer((FbxDeformer)obj, visitedObjects);
//            else if (type == typeof(FbxPose))
//                _AcceptFbxPose((FbxPose)obj, visitedObjects);
//            else if (type == typeof(FbxSubDeformer))
//                _AcceptFbxSubDeformer((FbxSubDeformer)obj, visitedObjects);
//            else if (type == typeof(FbxTexture))
//                _AcceptFbxTexture((FbxTexture)obj, visitedObjects);
//            else if (type == typeof(FbxVideo))
//                _AcceptFbxVideo((FbxVideo)obj, visitedObjects);
//            else if (type == typeof(FbxCamera))
//                Camera((FbxCamera)obj, visitedObjects);
//            else if (type == typeof(FbxLight))
//                _AcceptFbxLight((FbxLight)obj, visitedObjects);
//            else if (type == typeof(FbxNull))
//                _AcceptFbxNull((FbxNull)obj, visitedObjects);
//            else if (type == typeof(FbxSkeleton))
//                _AcceptFbxSkeleton((FbxSkeleton)obj, visitedObjects);
//        }

        protected void _AcceptFbxObject(FbxObject obj, ISet<object> visitedObjects)
        {
            //Accept(obj.GetDocument());
            //Accept(obj.GetRootDocument());
            Accept(obj.GetScene(), visitedObjects);

            int i;
            for (i = 0; i < obj.GetSrcObjectCount(); i++)
            {
                Accept(obj.GetSrcObject(i), visitedObjects);
            }
            for (i = 0; i < obj.GetDstObjectCount(); i++)
            {
                Accept(obj.GetDstObject(i), visitedObjects);
            }


            FbxProperty prop = obj.GetFirstProperty();
            while (prop != null && prop.IsValid())
            {
                for (i = 0; i < prop.GetSrcObjectCount(); i++)
                {
                    var srcObj = prop.GetSrcObject(i);
                    Accept(srcObj, visitedObjects);
                }
                for (i = 0; i < prop.GetDstObjectCount(); i++)
                {
                    var dstObj = prop.GetDstObject(i);
                    Accept(dstObj, visitedObjects);
                }

                // TODO: object references in properties
                // TODO: object references in src and dst properties

                prop = obj.GetNextProperty(prop);
            }

            prop = obj.RootProperty;
            for (i = 0; i < prop.GetSrcObjectCount(); i++)
            {
                var srcObj = prop.GetSrcObject(i);
                Accept(srcObj, visitedObjects);
            }
            for (i = 0; i < prop.GetDstObjectCount(); i++)
            {
                var dstObj = prop.GetDstObject(i);
                Accept(dstObj, visitedObjects);
            }
        }

        protected void _AcceptFbxScene(FbxScene scene, ISet<object> visitedObjects)
        {
            // GenericNodeCount
            // CharacterCount
            // CharacterPoseCount

            int i;
            for (i = 0; i < scene.GetPoseCount(); i++)
            {
                Accept(scene.GetPose(i), visitedObjects);
            }
            for (i = 0; i < scene.GetMaterialCount(); i++)
            {
                Accept(scene.GetMaterial(i), visitedObjects);
            }
            for (i = 0; i < scene.GetTextureCount(); i++)
            {
                Accept(scene.GetTexture(i), visitedObjects);
            }
            for (i = 0; i < scene.GetNodeCount(); i++)
            {
                Accept(scene.GetNode(i), visitedObjects);
            }
            //for (i = 0; i < scene.GetGeometryCount(); i++)
            //{
            //    Accept(scene.GetGeometry(i));
            //}
            //for (i = 0; i < scene.GetVideoCount(); i++)
            //{
            //    Accept(scene.GetVideo(i));
            //}

            if (scene.GetRootNode() != null)
            {
                Accept(scene.GetRootNode(), visitedObjects);
            }

            // other stuff
        }

        protected void _AcceptFbxNode(FbxNode node, ISet<object> visitedObjects)
        {
            if (node.GetParent() != null)
                Accept(node.GetParent(), visitedObjects);

            int i;
            for (i = 0; i < node.GetChildCount(); i++)
            {
                Accept(node.GetChild(i), visitedObjects);
            }

            //if (node.GetTarget() != null)
            //{
            //    Accept(node.GetTarget());
            //}
            //if (node.GetTargetUp() != null)
            //{
            //    Accept(node.GetTargetUp());
            //}

            for (i = 0; i < node.GetNodeAttributeCount(); i++)
            {
                Accept(node.GetNodeAttributeByIndex(i), visitedObjects);
            }

            for (i = 0; i < node.GetMaterialCount(); i++)
            {
                Accept(node.GetMaterial(i), visitedObjects);
            }
        }

        protected void _AcceptFbxNodeAttribute(FbxNodeAttribute obj, ISet<object> visitedObjects)
        {
            Accept(obj.GetNode(), visitedObjects);
        }

        protected void _AcceptFbxSurfaceMaterial(FbxSurfaceMaterial obj, ISet<object> visitedObjects)
        {
        }

        protected void _AcceptFbxSurfaceLambert(FbxSurfaceLambert obj, ISet<object> visitedObjects)
        {
        }

        protected void _AcceptFbxSurfacePhong(FbxSurfacePhong obj, ISet<object> visitedObjects)
        {
        }

        protected void _AcceptFbxMesh(FbxMesh obj, ISet<object> visitedObjects)
        {
        }

        protected void _AcceptFbxGeometry(FbxGeometry obj, ISet<object> visitedObjects)
        {
            int i;
            for (i = 0; i < obj.GetDeformerCount(); i++)
            {
                Accept(obj.GetDeformer(i), visitedObjects);
            }

            // geometry weighted map
            // shape
        }

        protected void _AcceptFbxGeometryBase(FbxGeometryBase obj, ISet<object> visitedObjects)
        {
            // TODO: geometry elements
        }

        protected void _AcceptFbxLayerElementTexture(FbxLayerElementTexture tex, ISet<object> visitedObjects)
        {
            throw new NotImplementedException();
            //if (tex == null) return;
            //
            //LayerElementArrayT<Texture> tarray = tex.GetDirectArray();
            //
            //int i;
            //for (i = 0; i < tarray.List.Count; i++)
            //{
            //    Accept(tarray.GetAt(i));
            //}
        }

        protected void _AcceptFbxLayerContainer(FbxLayerContainer layerContainer, ISet<object> visitedObjects)
        {
            int j;
            for (j = 0; j < layerContainer.GetLayerCount(); j++)
            {
                FbxLayer layer = layerContainer.GetLayer(j);

                int i;
                FbxLayerElementMaterial mats = layer.GetMaterials();
                if (mats != null)
                {
                    FbxLayerElementTemplate<FbxSurfaceMaterial> _mats = mats;
                    LayerElementArrayT<FbxSurfaceMaterial> marray = _mats.GetDirectArray();
                    //for (i = 0; i < marray.GetCount(); i++)
                    //{
                    //    Accept(marray.GetAt(i));
                    //}
                }

                //Accept(this, layer.GetTextures(LayerElement.EType.eTextureEmissive));
                //Accept(this, layer.GetTextures(LayerElement.EType.eTextureEmissiveFactor));
                //Accept(this, layer.GetTextures(LayerElement.EType.eTextureAmbient));
                //Accept(this, layer.GetTextures(LayerElement.EType.eTextureAmbientFactor));
                //Accept(this, layer.GetTextures(LayerElement.EType.eTextureDiffuseFactor));
                //Accept(this, layer.GetTextures(LayerElement.EType.eTextureSpecular));
                //Accept(this, layer.GetTextures(LayerElement.EType.eTextureNormalMap));
                //Accept(this, layer.GetTextures(LayerElement.EType.eTextureSpecularFactor));
                //Accept(this, layer.GetTextures(LayerElement.EType.eTextureShininess));
                //Accept(this, layer.GetTextures(LayerElement.EType.eTextureBump));
                //Accept(this, layer.GetTextures(LayerElement.EType.eTextureTransparency));
                //Accept(this, layer.GetTextures(LayerElement.EType.eTextureTransparencyFactor));
                //Accept(this, layer.GetTextures(LayerElement.EType.eTextureReflection));
                //Accept(this, layer.GetTextures(LayerElement.EType.eTextureReflectionFactor));
                //Accept(this, layer.GetTextures(LayerElement.EType.eTextureDisplacement));
            }
        }

        protected void _AcceptFbxDocument(FbxDocument obj, ISet<object> visitedObjects)
        {
            int i;
            //for (i = 0; i < obj.GetRootMemberCount(); i++)
            //{
            //    Accept(obj.GetRootMember(i));
            //}
            //
            //if (obj.GetDocumentInfo() != null)
            //{
            //    Accept(obj.GetDocumentInfo());
            //}
        }

        protected void _AcceptFbxCollection(FbxCollection obj, ISet<object> visitedObjects)
        {
            int i;
            //for (i = 0; i < obj.GetMemberCount(); i++)
            //{
            //    Accept(obj.GetMember(i));
            //}
        }

        protected void _AcceptFbxAnimLayer(FbxAnimLayer obj, ISet<object> visitedObjects)
        {
        }

        protected void _AcceptFbxAnimStack(FbxAnimStack obj, ISet<object> visitedObjects)
        {
        }

        protected void _AcceptFbxAnimCurve(FbxAnimCurve obj, ISet<object> visitedObjects)
        {
        }

        protected void _AcceptFbxAnimCurveBase(FbxAnimCurveBase obj, ISet<object> visitedObjects)
        {
        }

        protected void _AcceptFbxAnimCurveNode(FbxAnimCurveNode obj, ISet<object> visitedObjects)
        {
            int i;
            int j;

            //for (i = 0; i < obj.GetChannelsCount(); i++)
            //{
            //    for (j = 0; j < obj.GetCurveCount((uint)i); j++)
            //    {
            //        AnimCurve curve = obj.GetCurve((uint)i, (uint)j);
            //        Accept(curve);
            //    }
            //}
        }

        protected void _AcceptFbxDeformer(FbxDeformer obj, ISet<object> visitedObjects)
        {
        }

        protected void _AcceptFbxPose(FbxPose pose, ISet<object> visitedObjects)
        {
            int i;
            for (i = 0; i < pose.GetCount(); i++)
            {
                Accept(pose.GetNode(i), visitedObjects);
            }
        }

        protected void _AcceptFbxSubDeformer(FbxSubDeformer obj, ISet<object> visitedObjects)
        {
        }

        protected void _AcceptFbxTexture(FbxTexture obj, ISet<object> visitedObjects)
        {
        }

        protected void _AcceptFbxVideo(FbxVideo obj, ISet<object> visitedObjects)
        {
        }

        protected void _AcceptFbxCamera(FbxCamera obj, ISet<object> visitedObjects)
        {
            throw new NotImplementedException();
        }

        protected void _AcceptFbxLight(FbxLight obj, ISet<object> visitedObjects)
        {
            //TODO: shadow texture
        }

        protected void _AcceptFbxNull(FbxNull obj, ISet<object> visitedObjects)
        {
        }

        protected void _AcceptFbxSkeleton(FbxSkeleton obj, ISet<object> visitedObjects)
        {
        }

        protected void _AcceptFbxAnimEvaluator(FbxAnimEvaluator obj, ISet<object> visitedObjects)
        {
            //TODO: GetPropertyCurveNode
        }

        protected void _AcceptFbxAnimEvalClassic(FbxAnimEvalClassic obj, ISet<object> visitedObjects)
        {
        }

        protected void _AcceptFbxSkin(FbxSkin obj, ISet<object> visitedObjects)
        {
            //TODO: GetGeometry
            //TODO: Clusters
        }

        protected void _AcceptFbxGlobalSettings(FbxGlobalSettings obj, ISet<object> visitedObjects)
        {
            // TODO: default camera
        }

        protected void _AcceptFbxIOBase(FbxIOBase obj, ISet<object> visitedObjects)
        {
            throw new NotImplementedException();
        }

        protected void _AcceptFbxImporter(FbxImporter obj, ISet<object> visitedObjects)
        {
            throw new NotImplementedException();
        }

        protected void _AcceptFbxCluster(FbxCluster obj, ISet<object> visitedObjects)
        {
            //TODO: link
            //TODO: associated model
        }
    }
}

