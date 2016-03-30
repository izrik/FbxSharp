using System;
using FbxSharp;
using System.Collections.Generic;

namespace FbxSharp
{
    public class Collector : FbxVisitor
    {
        public readonly List<FbxObject> Objects = new List<FbxObject>();

        public void Visit(FbxObject obj)
        {

            if (obj == null) return;

            if (Objects.Contains(obj)) return;

            if (!(obj is Scene) &&
                !(obj is AnimLayer) &&
                !(obj is AnimStack) &&
                !(obj is AnimCurve) &&
                !(obj is AnimCurveNode) &&
                !(obj is Skin) &&
                !(obj is Node) &&
                !(obj is Mesh) &&
                !(obj is Pose) &&
                !(obj is Cluster) &&
                !(obj is SurfaceMaterial) &&
                !(obj is Texture) &&
//                !(obj is Camera) &&
//                !(obj is Light) &&
                !(obj is Null) &&
                !(obj is Skeleton) &&
                !(obj is Video))
            {
                Console.WriteLine("Unknown object class: {0}", obj.GetType().Name); //obj.GetRuntimeClassId().GetName());
                return;
            }

            Objects.Add(obj);

            //Console.WriteLine("adding object {0}", MainClass.PrintObjectID(obj));

//            Visit(obj.GetDocument());
//            Visit(obj.GetRootDocument());
            Visit(obj.GetScene());

            int i;
            for (i = 0; i < obj.GetSrcObjectCount(); i++)
            {
                Visit(obj.GetSrcObject(i));
            }
            for (i = 0; i < obj.GetDstObjectCount(); i++)
            {
                Visit(obj.GetDstObject(i));
            }


            Property prop = obj.GetFirstProperty();
            while (prop != null && prop.IsValid())
            {
                for (i = 0; i < prop.GetSrcObjectCount(); i++)
                {
                    var srcObj = prop.GetSrcObject(i);
                    Visit(srcObj);
                }
                for (i = 0; i < prop.GetDstObjectCount(); i++)
                {
                    var dstObj = prop.GetDstObject(i);
                    Visit(dstObj);
                }

                // TODO: object references in properties
                // TODO: object references in src and dst properties

                prop = obj.GetNextProperty(prop);
            }

            prop = obj.RootProperty;
            for (i = 0; i < prop.GetSrcObjectCount(); i++)
            {
                var srcObj = prop.GetSrcObject(i);
                Visit(srcObj);
            }
            for (i = 0; i < prop.GetDstObjectCount(); i++)
            {
                var dstObj = prop.GetDstObject(i);
                Visit(dstObj);
            }

            //Console.WriteLine("branching object {0}", MainClass.PrintObjectID(obj));

            if ((obj is Collection))
                VisitCollection(obj as Collection);
            else if ((obj is AnimCurve))
                VisitAnimCurve(obj as AnimCurve);
            else if ((obj is AnimCurveNode))
                VisitAnimCurveNode(obj as AnimCurveNode);
            else if ((obj is Deformer))
                VisitDeformer(obj as Deformer);
            else if ((obj is Node))
                VisitNode(obj as Node);
            else if ((obj is NodeAttribute))
                VisitNodeAttribute(obj as NodeAttribute);
            else if ((obj is Pose))
                VisitPose(obj as Pose);
            else if ((obj is SubDeformer))
                VisitSubDeformer(obj as SubDeformer);
            else if ((obj is SurfaceMaterial))
                VisitSurfaceMaterial(obj as SurfaceMaterial);
            else if ((obj is Texture))
                VisitTexture(obj as Texture);
            else if ((obj is Video))
                VisitVideo(obj as Video);

            //Console.WriteLine("added object {0}", MainClass.PrintObjectID(obj));
        }

        public void VisitScene(Scene scene)
        {
            // GenericNodeCount
            // CharacterCount
            // CharacterPoseCount

            int i;
            for (i = 0; i < scene.GetPoseCount(); i++)
            {
                Visit(scene.GetPose(i));
            }
            for (i = 0; i < scene.GetMaterialCount(); i++)
            {
                Visit(scene.GetMaterial(i));
            }
            for (i = 0; i < scene.GetTextureCount(); i++)
            {
                Visit(scene.GetTexture(i));
            }
            for (i = 0; i < scene.GetNodeCount(); i++)
            {
                Visit(scene.GetNode(i));
            }
            //for (i = 0; i < scene.GetGeometryCount(); i++)
            //{
            //    Visit(scene.GetGeometry(i));
            //}
            //for (i = 0; i < scene.GetVideoCount(); i++)
            //{
            //    Visit(scene.GetVideo(i));
            //}

            if (scene.GetRootNode() != null)
            {
                Visit(scene.GetRootNode());
            }

            // other stuff
        }

        public void VisitNode(Node node)
        {
            Visit(node.GetParent());

            int i;
            for (i = 0; i < node.GetChildCount(); i++)
            {
                Visit(node.GetChild(i));
            }

            //if (node.GetTarget() != null)
            //{
            //    Visit(node.GetTarget());
            //}
            //if (node.GetTargetUp() != null)
            //{
            //    Visit(node.GetTargetUp());
            //}

            for (i = 0; i < node.GetNodeAttributeCount(); i++)
            {
                Visit(node.GetNodeAttributeByIndex(i));
            }

            for (i = 0; i < node.GetMaterialCount(); i++)
            {
                Visit(node.GetMaterial(i));
            }
        }

        public void VisitNodeAttribute(NodeAttribute obj)
        {
            Visit(obj.GetNode());

//            if ((obj is Camera))
//                VisitCamera(obj as Camera);
//            else if ((obj is Light))
//                VisitLight(obj as Light);
//            else
            if ((obj is LayerContainer))
                VisitLayerContainer(obj as LayerContainer);
            else if ((obj is Null))
                VisitNull(obj as Null);
            else if ((obj is Skeleton))
                VisitSkeleton(obj as Skeleton);
        }

        public void VisitSurfaceMaterial(SurfaceMaterial obj)
        {
            // nothing to do
        }

        public void VisitSurfaceLambert(SurfaceLambert obj)
        {
            // nothing to do
        }

        public void VisitSurfacePhong(SurfacePhong obj)
        {
            // nothing to do
        }

        public void VisitMesh(Mesh obj)
        {
            // nothing to do
        }

        public void VisitGeometry(Geometry obj)
        {
            // nothing to do
            int i;
            for (i = 0; i < obj.GetDeformerCount(); i++)
            {
                Visit(obj.GetDeformer(i));
            }

            // geometry weighted map
            // shape

            if ((obj is Mesh))
                VisitMesh(obj as Mesh);
        }

        public void VisitGeometryBase(GeometryBase obj)
        {
            // TODO: geometry elements

            if ((obj is Geometry))
                VisitGeometry(obj as Geometry);
        }

        public void VisitLayerElementTexture(Collector c, LayerElementTexture tex)
        {
            if (tex == null) return;

            //LayerElementArrayT<Texture> tarray = tex.GetDirectArray();
            //
            //int i;
            //for (i = 0; i < tarray.GetCount(); i++)
            //{
            //    c.Visit(tarray.GetAt(i));
            //}
        }

        public void VisitLayerContainer(LayerContainer layerContainer)
        {
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
                    //    Visit(marray.GetAt(i));
                    //}
                }

                //VisitLayerElementTexture(this, layer.GetTextures(LayerElement.EType.eTextureEmissive));
                //VisitLayerElementTexture(this, layer.GetTextures(LayerElement.EType.eTextureEmissiveFactor));
                //VisitLayerElementTexture(this, layer.GetTextures(LayerElement.EType.eTextureAmbient));
                //VisitLayerElementTexture(this, layer.GetTextures(LayerElement.EType.eTextureAmbientFactor));
                //VisitLayerElementTexture(this, layer.GetTextures(LayerElement.EType.eTextureDiffuseFactor));
                //VisitLayerElementTexture(this, layer.GetTextures(LayerElement.EType.eTextureSpecular));
                //VisitLayerElementTexture(this, layer.GetTextures(LayerElement.EType.eTextureNormalMap));
                //VisitLayerElementTexture(this, layer.GetTextures(LayerElement.EType.eTextureSpecularFactor));
                //VisitLayerElementTexture(this, layer.GetTextures(LayerElement.EType.eTextureShininess));
                //VisitLayerElementTexture(this, layer.GetTextures(LayerElement.EType.eTextureBump));
                //VisitLayerElementTexture(this, layer.GetTextures(LayerElement.EType.eTextureTransparency));
                //VisitLayerElementTexture(this, layer.GetTextures(LayerElement.EType.eTextureTransparencyFactor));
                //VisitLayerElementTexture(this, layer.GetTextures(LayerElement.EType.eTextureReflection));
                //VisitLayerElementTexture(this, layer.GetTextures(LayerElement.EType.eTextureReflectionFactor));
                //VisitLayerElementTexture(this, layer.GetTextures(LayerElement.EType.eTextureDisplacement));
            }

            if ((layerContainer is GeometryBase))
                VisitGeometryBase(layerContainer as GeometryBase);
        }

        public void VisitDocument(Document obj)
        {
            int i;
            //for (i = 0; i < obj.GetRootMemberCount(); i++)
            //{
            //    Visit(obj.GetRootMember(i));
            //}
            //
            //if (obj.GetDocumentInfo() != null)
            //{
            //    Visit(obj.GetDocumentInfo());
            //}

            if ((obj is Scene))
                VisitScene(obj as Scene);
        }

        public void VisitCollection(Collection obj)
        {
            int i;
            //for (i = 0; i < obj.GetMemberCount(); i++)
            //{
            //    Visit(obj.GetMember(i));
            //}


            if ((obj is Document))
                VisitDocument(obj as Document);
            else if ((obj is AnimStack))
                VisitAnimStack(obj as AnimStack);
            else if ((obj is AnimLayer))
                VisitAnimLayer(obj as AnimLayer);
        }

        public void VisitAnimLayer(AnimLayer obj)
        {
            // nothing to do
        }

        public void VisitAnimStack(AnimStack obj)
        {
            // nothing to do
        }

        public void VisitAnimCurve(AnimCurve obj)
        {
            // nothing to do
        }

        public void VisitAnimCurveNode(AnimCurveNode obj)
        {
            int i;
            int j;

            //for (i = 0; i < obj.GetChannelsCount(); i++)
            //{
            //    for (j = 0; j < obj.GetCurveCount((uint)i); j++)
            //    {
            //        AnimCurve curve = obj.GetCurve((uint)i, (uint)j);
            //        Visit(curve);
            //    }
            //}
        }

        public void VisitDeformer(Deformer obj)
        {
            Console.WriteLine("VisitDeformer: Not Implemented");
        }

        public void VisitPose(Pose pose)
        {
            int i;
            for (i = 0; i < pose.GetCount(); i++)
            {
                Visit(pose.GetNode(i));
            }
        }

        public void VisitSubDeformer(SubDeformer obj)
        {
            Console.WriteLine("VisitSubDeformer: Not Implemented");
        }

        public void VisitTexture(Texture obj)
        {
            // nothing to do
        }

        public void VisitVideo(Video obj)
        {
            Console.WriteLine("VisitVideo: Not Implemented");
        }

        //public void VisitCamera(Camera obj)
        //{
        //    Console.WriteLine("VisitCamera: Not Implemented");
        //}

        //public void VisitLight(Light obj)
        //{
        //    Console.WriteLine("VisitLight: Not Implemented");
        //}

        public void VisitNull(Null obj)
        {
            // nothing to do
        }

        public void VisitSkeleton(Skeleton obj)
        {
            Console.WriteLine("VisitSkeleton: Not Implemented");
        }
    }
}

