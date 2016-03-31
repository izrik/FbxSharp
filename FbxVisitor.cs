using System;
using FbxSharp;
using System.Collections.Generic;

namespace FbxSharp
{
    public class FbxVisitor
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
        public virtual void Visit(Collection obj) { }
        public virtual void Visit(AnimLayer obj) { }
        public virtual void Visit(AnimStack obj) { }
        public virtual void Visit(AnimCurve obj) { }
        public virtual void Visit(AnimCurveNode obj) { }
        public virtual void Visit(Deformer obj) { }
        public virtual void Visit(Pose pose) { }
        public virtual void Visit(SubDeformer obj) { }
        public virtual void Visit(Texture obj) { }
        public virtual void Visit(Video obj) { }
        public virtual void Visit(Camera obj) { }
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
            if (visitedObjects.Contains(obj)) return;
            visitedObjects.Add(obj);

            var type = obj.GetType();

//            var prop = obj as Property;
//            if (prop != null)
//            {
//                Accept(prop, visitedObjects);
//                return;
//            }

            if (type == typeof(FbxObject)) Accept((FbxObject)obj, visitedObjects);
            else if (type == typeof(Scene)) Accept((Scene)obj, visitedObjects);
            else if (type == typeof(Node)) Accept((Node)obj, visitedObjects);
            else if (type == typeof(NodeAttribute)) Accept((NodeAttribute)obj, visitedObjects);
            else if (type == typeof(SurfaceMaterial)) Accept((SurfaceMaterial)obj, visitedObjects);
            else if (type == typeof(SurfaceLambert)) Accept((SurfaceLambert)obj, visitedObjects);
            else if (type == typeof(SurfacePhong)) Accept((SurfacePhong)obj, visitedObjects);
            else if (type == typeof(Mesh)) Accept((Mesh)obj, visitedObjects);
            else if (type == typeof(Geometry)) Accept((Geometry)obj, visitedObjects);
            else if (type == typeof(GeometryBase)) Accept((GeometryBase)obj, visitedObjects);
            else if (type == typeof(LayerElementTexture)) Accept((LayerElementTexture)obj, visitedObjects);
            else if (type == typeof(LayerContainer)) Accept((LayerContainer)obj, visitedObjects);
            else if (type == typeof(Document)) Accept((Document)obj, visitedObjects);
            else if (type == typeof(Collection)) Accept((Collection)obj, visitedObjects);
            else if (type == typeof(AnimLayer)) Accept((AnimLayer)obj, visitedObjects);
            else if (type == typeof(AnimStack)) Accept((AnimStack)obj, visitedObjects);
            else if (type == typeof(AnimCurve)) Accept((AnimCurve)obj, visitedObjects);
            else if (type == typeof(AnimCurveNode)) Accept((AnimCurveNode)obj, visitedObjects);
            else if (type == typeof(Deformer)) Accept((Deformer)obj, visitedObjects);
            else if (type == typeof(Pose)) Accept((Pose)obj, visitedObjects);
            else if (type == typeof(SubDeformer)) Accept((SubDeformer)obj, visitedObjects);
            else if (type == typeof(Texture)) Accept((Texture)obj, visitedObjects);
            else if (type == typeof(Video)) Accept((Video)obj, visitedObjects);
            else if (type == typeof(Camera)) Accept((Camera)obj, visitedObjects);
            else if (type == typeof(Light)) Accept((Light)obj, visitedObjects);
            else if (type == typeof(Null)) Accept((Null)obj, visitedObjects);
            else if (type == typeof(Skeleton)) Accept((Skeleton)obj, visitedObjects);
        }

        protected void Accept(FbxObject obj, ISet<object> visitedObjects)
        {
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

        protected void Accept(Scene scene, ISet<object> visitedObjects)
        {
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

        protected void Accept(Node node, ISet<object> visitedObjects)
        {
            Visit(node);

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

        protected void Accept(NodeAttribute obj, ISet<object> visitedObjects)
        {
            Visit(obj);

            Accept(obj.GetNode(), visitedObjects);
        }

        protected void Accept(SurfaceMaterial obj, ISet<object> visitedObjects)
        {
            Visit(obj);
        }

        protected void Accept(SurfaceLambert obj, ISet<object> visitedObjects)
        {
            Visit(obj);
        }

        protected void Accept(SurfacePhong obj, ISet<object> visitedObjects)
        {
            Visit(obj);
        }

        protected void Accept(Mesh obj, ISet<object> visitedObjects)
        {
            Visit(obj);
        }

        protected void Accept(Geometry obj, ISet<object> visitedObjects)
        {
            Visit(obj);

            int i;
            for (i = 0; i < obj.GetDeformerCount(); i++)
            {
                Accept(obj.GetDeformer(i), visitedObjects);
            }

            // geometry weighted map
            // shape
        }

        protected void Accept(GeometryBase obj, ISet<object> visitedObjects)
        {
            Visit(obj);

            // TODO: geometry elements
        }

        public void Accept(LayerElementTexture tex, ISet<object> visitedObjects)
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

        protected void Accept(LayerContainer layerContainer, ISet<object> visitedObjects)
        {
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

        protected void Accept(Document obj, ISet<object> visitedObjects)
        {
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

        protected void Accept(Collection obj, ISet<object> visitedObjects)
        {
            Visit(obj);

            int i;
            //for (i = 0; i < obj.GetMemberCount(); i++)
            //{
            //    Accept(obj.GetMember(i));
            //}
        }

        protected void Accept(AnimLayer obj, ISet<object> visitedObjects)
        {
            Visit(obj);
        }

        protected void Accept(AnimStack obj, ISet<object> visitedObjects)
        {
            Visit(obj);
        }

        protected void Accept(AnimCurve obj, ISet<object> visitedObjects)
        {
            Visit(obj);
        }

        protected void Accept(AnimCurveNode obj, ISet<object> visitedObjects)
        {
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

        protected void Accept(Deformer obj, ISet<object> visitedObjects)
        {
            throw new NotImplementedException();
        }

        protected void Accept(Pose pose, ISet<object> visitedObjects)
        {
            Visit(pose);

            int i;
            for (i = 0; i < pose.GetCount(); i++)
            {
                Accept(pose.GetNode(i), visitedObjects);
            }
        }

        protected void Accept(SubDeformer obj, ISet<object> visitedObjects)
        {
            throw new NotImplementedException();
        }

        protected void Accept(Texture obj, ISet<object> visitedObjects)
        {
            Visit(obj);
        }

        protected void Accept(Video obj, ISet<object> visitedObjects)
        {
            throw new NotImplementedException();
        }

        protected void Accept(Camera obj, ISet<object> visitedObjects)
        {
            throw new NotImplementedException();
        }

        protected void Accept(Light obj, ISet<object> visitedObjects)
        {
            throw new NotImplementedException();
        }

        protected void Accept(Null obj, ISet<object> visitedObjects)
        {
            Visit(obj);
        }

        protected void Accept(Skeleton obj, ISet<object> visitedObjects)
        {
            throw new NotImplementedException();
        }

    }
}

