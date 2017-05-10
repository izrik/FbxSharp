using System;
using FbxSharp;
using System.Collections.Generic;

namespace FbxSharp
{
    public class Visitor
    {
        public virtual void Visit(FbxObject obj) { }
        public virtual void Visit(FbxScene scene) { }
        public virtual void Visit(FbxNode node) { }
        public virtual void Visit(FbxNodeAttribute obj) { }
        public virtual void Visit(FbxSurfaceMaterial obj) { }
        public virtual void Visit(FbxSurfaceLambert obj) { }
        public virtual void Visit(FbxSurfacePhong obj) { }
        public virtual void Visit(FbxMesh obj) { }
        public virtual void Visit(FbxGeometry obj) { }
        public virtual void Visit(FbxGeometryBase obj) { }
        public virtual void Visit(FbxLayerElementTexture tex) { }
        public virtual void Visit(FbxLayerContainer layerContainer) { }
        public virtual void Visit(FbxDocument obj) { }
        public virtual void Visit(FbxCollection obj) { }
        public virtual void Visit(FbxAnimLayer obj) { }
        public virtual void Visit(FbxAnimStack obj) { }
        public virtual void Visit(FbxAnimCurve obj) { }
        public virtual void Visit(FbxAnimCurveNode obj) { }
        public virtual void Visit(FbxDeformer obj) { }
        public virtual void Visit(FbxPose pose) { }
        public virtual void Visit(FbxSubDeformer obj) { }
        public virtual void Visit(FbxTexture obj) { }
        public virtual void Visit(FbxVideo obj) { }
        public virtual void Visit(FbxCamera obj) { }
        public virtual void Visit(FbxLight obj) { }
        public virtual void Visit(FbxNull obj) { }
        public virtual void Visit(FbxSkeleton obj) { }

        /*********************************/


        public void Accept(object obj)
        {
            Accept(obj, new HashSet<object>());
        }

        protected void Accept(object obj, ISet<object> visitedObjects)
        {
            if (obj == null) return;
            if (visitedObjects.Contains(obj)) return;
            visitedObjects.Add(obj);

            var type = obj.GetType();

            //            var prop = obj as Property;
            //            if (prop != null)
            //            {
            //                Accept(prop, visitedObjects);
            //                return;
            //            }

            if (type == typeof(FbxObject))
                AcceptFbxObject((FbxObject)obj, visitedObjects);
            else if (type == typeof(FbxScene))
                AcceptScene((FbxScene)obj, visitedObjects);
            else if (type == typeof(FbxNode))
                AcceptNode((FbxNode)obj, visitedObjects);
            else if (type == typeof(FbxNodeAttribute))
                AcceptNodeAttribute((FbxNodeAttribute)obj, visitedObjects);
            else if (type == typeof(FbxSurfaceMaterial))
                AcceptSurfaceMaterial((FbxSurfaceMaterial)obj, visitedObjects);
            else if (type == typeof(FbxSurfaceLambert))
                AcceptSurfaceLambert((FbxSurfaceLambert)obj, visitedObjects);
            else if (type == typeof(FbxSurfacePhong))
                AcceptSurfacePhong((FbxSurfacePhong)obj, visitedObjects);
            else if (type == typeof(FbxMesh))
                AcceptMesh((FbxMesh)obj, visitedObjects);
            else if (type == typeof(FbxGeometry))
                AcceptGeometry((FbxGeometry)obj, visitedObjects);
            else if (type == typeof(FbxGeometryBase))
                AcceptGeometryBase((FbxGeometryBase)obj, visitedObjects);
            else if (type == typeof(FbxLayerElementTexture))
                AcceptLayerElementTexture((FbxLayerElementTexture)obj, visitedObjects);
            else if (type == typeof(FbxLayerContainer))
                AcceptLayerContainer((FbxLayerContainer)obj, visitedObjects);
            else if (type == typeof(FbxDocument))
                AcceptDocument((FbxDocument)obj, visitedObjects);
            else if (type == typeof(FbxCollection))
                AcceptCollection((FbxCollection)obj, visitedObjects);
            else if (type == typeof(FbxAnimLayer))
                AcceptAnimLayer((FbxAnimLayer)obj, visitedObjects);
            else if (type == typeof(FbxAnimStack))
                AcceptAnimStack((FbxAnimStack)obj, visitedObjects);
            else if (type == typeof(FbxAnimCurve))
                AcceptAnimCurve((FbxAnimCurve)obj, visitedObjects);
            else if (type == typeof(FbxAnimCurveNode))
                AcceptAnimCurveNode((FbxAnimCurveNode)obj, visitedObjects);
            else if (type == typeof(FbxDeformer))
                AcceptDeformer((FbxDeformer)obj, visitedObjects);
            else if (type == typeof(FbxPose))
                AcceptPose((FbxPose)obj, visitedObjects);
            else if (type == typeof(FbxSubDeformer))
                AcceptSubDeformer((FbxSubDeformer)obj, visitedObjects);
            else if (type == typeof(FbxTexture))
                AcceptTexture((FbxTexture)obj, visitedObjects);
            else if (type == typeof(FbxVideo))
                AcceptVideo((FbxVideo)obj, visitedObjects);
            else if (type == typeof(FbxCamera))
                AcceptCamera((FbxCamera)obj, visitedObjects);
            else if (type == typeof(FbxLight))
                AcceptLight((FbxLight)obj, visitedObjects);
            else if (type == typeof(FbxNull))
                AcceptNull((FbxNull)obj, visitedObjects);
            else if (type == typeof(FbxSkeleton))
                AcceptSkeleton((FbxSkeleton)obj, visitedObjects);
        }

        protected void AcceptFbxObject(FbxObject obj, ISet<object> visitedObjects)
        {
            //AcceptEmitter(obj, visitedObjects);
            Visit(obj);

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

        protected void AcceptScene(FbxScene scene, ISet<object> visitedObjects)
        {
            AcceptDocument(scene, visitedObjects);
            Visit(scene);

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

        protected void AcceptNode(FbxNode node, ISet<object> visitedObjects)
        {
            AcceptFbxObject(node, visitedObjects);
            Visit(node);

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

        protected void AcceptNodeAttribute(FbxNodeAttribute obj, ISet<object> visitedObjects)
        {
            AcceptFbxObject(obj, visitedObjects);
            Visit(obj);

            Accept(obj.GetNode(), visitedObjects);
        }

        protected void AcceptSurfaceMaterial(FbxSurfaceMaterial obj, ISet<object> visitedObjects)
        {
            AcceptFbxObject(obj, visitedObjects);
            Visit(obj);
        }

        protected void AcceptSurfaceLambert(FbxSurfaceLambert obj, ISet<object> visitedObjects)
        {
            AcceptSurfaceMaterial(obj, visitedObjects);
            Visit(obj);
        }

        protected void AcceptSurfacePhong(FbxSurfacePhong obj, ISet<object> visitedObjects)
        {
            AcceptSurfaceLambert(obj, visitedObjects);
            Visit(obj);
        }

        protected void AcceptMesh(FbxMesh obj, ISet<object> visitedObjects)
        {
            AcceptGeometry(obj, visitedObjects);
            Visit(obj);
        }

        protected void AcceptGeometry(FbxGeometry obj, ISet<object> visitedObjects)
        {
            AcceptGeometryBase(obj, visitedObjects);
            Visit(obj);

            int i;
            for (i = 0; i < obj.GetDeformerCount(); i++)
            {
                Accept(obj.GetDeformer(i), visitedObjects);
            }

            // geometry weighted map
            // shape
        }

        protected void AcceptGeometryBase(FbxGeometryBase obj, ISet<object> visitedObjects)
        {
            AcceptLayerContainer(obj, visitedObjects);
            Visit(obj);

            // TODO: geometry elements
        }

        protected void AcceptLayerElementTexture(FbxLayerElementTexture tex, ISet<object> visitedObjects)
        {
            Visit(tex);

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

        protected void AcceptLayerContainer(FbxLayerContainer layerContainer, ISet<object> visitedObjects)
        {
            AcceptNodeAttribute(layerContainer, visitedObjects);
            Visit(layerContainer);

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

        protected void AcceptDocument(FbxDocument obj, ISet<object> visitedObjects)
        {
            AcceptCollection(obj, visitedObjects);
            Visit(obj);

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

        protected void AcceptCollection(FbxCollection obj, ISet<object> visitedObjects)
        {
            AcceptFbxObject(obj, visitedObjects);
            Visit(obj);

            int i;
            //for (i = 0; i < obj.GetMemberCount(); i++)
            //{
            //    Accept(obj.GetMember(i));
            //}
        }

        protected void AcceptAnimLayer(FbxAnimLayer obj, ISet<object> visitedObjects)
        {
            AcceptCollection(obj, visitedObjects);
            Visit(obj);
        }

        protected void AcceptAnimStack(FbxAnimStack obj, ISet<object> visitedObjects)
        {
            AcceptCollection(obj, visitedObjects);
            Visit(obj);
        }

        protected void AcceptAnimCurve(FbxAnimCurve obj, ISet<object> visitedObjects)
        {
            //AcceptAnimCurveBase(obj, visitedObjects);
            AcceptFbxObject(obj, visitedObjects);
            Visit(obj);
        }

        protected void AcceptAnimCurveNode(FbxAnimCurveNode obj, ISet<object> visitedObjects)
        {
            AcceptFbxObject(obj, visitedObjects);
            Visit(obj);

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

        protected void AcceptDeformer(FbxDeformer obj, ISet<object> visitedObjects)
        {
            AcceptFbxObject(obj, visitedObjects);
            Visit(obj);

            throw new NotImplementedException();
        }

        protected void AcceptPose(FbxPose pose, ISet<object> visitedObjects)
        {
            AcceptFbxObject(pose, visitedObjects);
            Visit(pose);

            int i;
            for (i = 0; i < pose.GetCount(); i++)
            {
                Accept(pose.GetNode(i), visitedObjects);
            }
        }

        protected void AcceptSubDeformer(FbxSubDeformer obj, ISet<object> visitedObjects)
        {
            AcceptFbxObject(obj, visitedObjects);
            Visit(obj);
            throw new NotImplementedException();
        }

        protected void AcceptTexture(FbxTexture obj, ISet<object> visitedObjects)
        {
            AcceptFbxObject(obj, visitedObjects);
            Visit(obj);
        }

        protected void AcceptVideo(FbxVideo obj, ISet<object> visitedObjects)
        {
            AcceptFbxObject(obj, visitedObjects);
            Visit(obj);
            throw new NotImplementedException();
        }

        protected void AcceptCamera(FbxCamera obj, ISet<object> visitedObjects)
        {
            AcceptNodeAttribute(obj, visitedObjects);
            Visit(obj);
            throw new NotImplementedException();
        }

        protected void AcceptLight(FbxLight obj, ISet<object> visitedObjects)
        {
            AcceptNodeAttribute(obj, visitedObjects);
            Visit(obj);
            throw new NotImplementedException();
        }

        protected void AcceptNull(FbxNull obj, ISet<object> visitedObjects)
        {
            AcceptNodeAttribute(obj, visitedObjects);
            Visit(obj);
        }

        protected void AcceptSkeleton(FbxSkeleton obj, ISet<object> visitedObjects)
        {
            AcceptNodeAttribute(obj, visitedObjects);
            Visit(obj);
            throw new NotImplementedException();
        }
    }
}

