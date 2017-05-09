using System;
using FbxSharp;
using System.Collections.Generic;

namespace FbxSharp
{
    public class Visitor
    {
        public virtual void Visit(FbxObject obj) { }
        public virtual void Visit(Scene scene) { }
        public virtual void Visit(Node node) { }
        public virtual void Visit(NodeAttribute obj) { }
        public virtual void Visit(SurfaceMaterial obj) { }
        public virtual void Visit(SurfaceLambert obj) { }
        public virtual void Visit(SurfacePhong obj) { }
        public virtual void Visit(Mesh obj) { }
        public virtual void Visit(Geometry obj) { }
        public virtual void Visit(GeometryBase obj) { }
        public virtual void Visit(LayerElementTexture tex) { }
        public virtual void Visit(LayerContainer layerContainer) { }
        public virtual void Visit(Document obj) { }
        public virtual void Visit(FbxCollection obj) { }
        public virtual void Visit(FbxAnimLayer obj) { }
        public virtual void Visit(FbxAnimStack obj) { }
        public virtual void Visit(FbxAnimCurve obj) { }
        public virtual void Visit(FbxAnimCurveNode obj) { }
        public virtual void Visit(Deformer obj) { }
        public virtual void Visit(Pose pose) { }
        public virtual void Visit(SubDeformer obj) { }
        public virtual void Visit(Texture obj) { }
        public virtual void Visit(Video obj) { }
        public virtual void Visit(FbxCamera obj) { }
        public virtual void Visit(Light obj) { }
        public virtual void Visit(Null obj) { }
        public virtual void Visit(Skeleton obj) { }

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
            else if (type == typeof(Scene))
                AcceptScene((Scene)obj, visitedObjects);
            else if (type == typeof(Node))
                AcceptNode((Node)obj, visitedObjects);
            else if (type == typeof(NodeAttribute))
                AcceptNodeAttribute((NodeAttribute)obj, visitedObjects);
            else if (type == typeof(SurfaceMaterial))
                AcceptSurfaceMaterial((SurfaceMaterial)obj, visitedObjects);
            else if (type == typeof(SurfaceLambert))
                AcceptSurfaceLambert((SurfaceLambert)obj, visitedObjects);
            else if (type == typeof(SurfacePhong))
                AcceptSurfacePhong((SurfacePhong)obj, visitedObjects);
            else if (type == typeof(Mesh))
                AcceptMesh((Mesh)obj, visitedObjects);
            else if (type == typeof(Geometry))
                AcceptGeometry((Geometry)obj, visitedObjects);
            else if (type == typeof(GeometryBase))
                AcceptGeometryBase((GeometryBase)obj, visitedObjects);
            else if (type == typeof(LayerElementTexture))
                AcceptLayerElementTexture((LayerElementTexture)obj, visitedObjects);
            else if (type == typeof(LayerContainer))
                AcceptLayerContainer((LayerContainer)obj, visitedObjects);
            else if (type == typeof(Document))
                AcceptDocument((Document)obj, visitedObjects);
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
            else if (type == typeof(Deformer))
                AcceptDeformer((Deformer)obj, visitedObjects);
            else if (type == typeof(Pose))
                AcceptPose((Pose)obj, visitedObjects);
            else if (type == typeof(SubDeformer))
                AcceptSubDeformer((SubDeformer)obj, visitedObjects);
            else if (type == typeof(Texture))
                AcceptTexture((Texture)obj, visitedObjects);
            else if (type == typeof(Video))
                AcceptVideo((Video)obj, visitedObjects);
            else if (type == typeof(FbxCamera))
                AcceptCamera((FbxCamera)obj, visitedObjects);
            else if (type == typeof(Light))
                AcceptLight((Light)obj, visitedObjects);
            else if (type == typeof(Null))
                AcceptNull((Null)obj, visitedObjects);
            else if (type == typeof(Skeleton))
                AcceptSkeleton((Skeleton)obj, visitedObjects);
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


            Property prop = obj.GetFirstProperty();
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

        protected void AcceptScene(Scene scene, ISet<object> visitedObjects)
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

        protected void AcceptNode(Node node, ISet<object> visitedObjects)
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

        protected void AcceptNodeAttribute(NodeAttribute obj, ISet<object> visitedObjects)
        {
            AcceptFbxObject(obj, visitedObjects);
            Visit(obj);

            Accept(obj.GetNode(), visitedObjects);
        }

        protected void AcceptSurfaceMaterial(SurfaceMaterial obj, ISet<object> visitedObjects)
        {
            AcceptFbxObject(obj, visitedObjects);
            Visit(obj);
        }

        protected void AcceptSurfaceLambert(SurfaceLambert obj, ISet<object> visitedObjects)
        {
            AcceptSurfaceMaterial(obj, visitedObjects);
            Visit(obj);
        }

        protected void AcceptSurfacePhong(SurfacePhong obj, ISet<object> visitedObjects)
        {
            AcceptSurfaceLambert(obj, visitedObjects);
            Visit(obj);
        }

        protected void AcceptMesh(Mesh obj, ISet<object> visitedObjects)
        {
            AcceptGeometry(obj, visitedObjects);
            Visit(obj);
        }

        protected void AcceptGeometry(Geometry obj, ISet<object> visitedObjects)
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

        protected void AcceptGeometryBase(GeometryBase obj, ISet<object> visitedObjects)
        {
            AcceptLayerContainer(obj, visitedObjects);
            Visit(obj);

            // TODO: geometry elements
        }

        protected void AcceptLayerElementTexture(LayerElementTexture tex, ISet<object> visitedObjects)
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

        protected void AcceptLayerContainer(LayerContainer layerContainer, ISet<object> visitedObjects)
        {
            AcceptNodeAttribute(layerContainer, visitedObjects);
            Visit(layerContainer);

            int j;
            for (j = 0; j < layerContainer.GetLayerCount(); j++)
            {
                Layer layer = layerContainer.GetLayer(j);

                int i;
                LayerElementMaterial mats = layer.GetMaterials();
                if (mats != null)
                {
                    LayerElementT<SurfaceMaterial> _mats = mats;
                    LayerElementArrayT<SurfaceMaterial> marray = _mats.GetDirectArray();
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

        protected void AcceptDocument(Document obj, ISet<object> visitedObjects)
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

        protected void AcceptDeformer(Deformer obj, ISet<object> visitedObjects)
        {
            AcceptFbxObject(obj, visitedObjects);
            Visit(obj);

            throw new NotImplementedException();
        }

        protected void AcceptPose(Pose pose, ISet<object> visitedObjects)
        {
            AcceptFbxObject(pose, visitedObjects);
            Visit(pose);

            int i;
            for (i = 0; i < pose.GetCount(); i++)
            {
                Accept(pose.GetNode(i), visitedObjects);
            }
        }

        protected void AcceptSubDeformer(SubDeformer obj, ISet<object> visitedObjects)
        {
            AcceptFbxObject(obj, visitedObjects);
            Visit(obj);
            throw new NotImplementedException();
        }

        protected void AcceptTexture(Texture obj, ISet<object> visitedObjects)
        {
            AcceptFbxObject(obj, visitedObjects);
            Visit(obj);
        }

        protected void AcceptVideo(Video obj, ISet<object> visitedObjects)
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

        protected void AcceptLight(Light obj, ISet<object> visitedObjects)
        {
            AcceptNodeAttribute(obj, visitedObjects);
            Visit(obj);
            throw new NotImplementedException();
        }

        protected void AcceptNull(Null obj, ISet<object> visitedObjects)
        {
            AcceptNodeAttribute(obj, visitedObjects);
            Visit(obj);
        }

        protected void AcceptSkeleton(Skeleton obj, ISet<object> visitedObjects)
        {
            AcceptNodeAttribute(obj, visitedObjects);
            Visit(obj);
            throw new NotImplementedException();
        }
    }
}

