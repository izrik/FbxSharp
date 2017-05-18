using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace FbxSharp
{
    public partial class ObjectPrinter
    {
        public static string quote(string s)
        {
            // TODO: hex escape sequences
            return "\"" + s.Replace("\r", "\\r").Replace("\n", "\\n").Replace("\t", "\\t") + "\"";
        }

        public static string PrintPropertyID(FbxProperty prop)
        {
            if (prop == null)
                return "<<null>>";

            var pobj = prop.GetFbxObject();
            return
                string.Format("{0} . {1} : {2}",
                    PrintObjectID(pobj),
                    quote(prop.GetName()),
                    prop.PropertyDataType.FullName);
        }

        public static string PrintObjectID(FbxObject obj)
        {
            if (obj == null)
                return "<<null>>";

            return string.Format("${0}, {1}, {2}",
                obj.GetUniqueID(),
                obj.GetType().Name/*obj.GetRuntimeClassId().GetName()*/,
                quote(obj.GetName()));
        }

        public void _PrintFbxObject(FbxObject obj, TextWriter writer)
        {
            writer.WriteLine("${0}", PrintObjectID(obj));  // extra $ for easy text search
            writer.WriteLine("    Name = {0}", quote(obj.GetName()));
            writer.WriteLine("    ClassId = {0}", obj.GetType().Name/*obj.GetRuntimeClassId().GetName()*/);
            writer.WriteLine("    UniqueId = {0}", obj.GetUniqueID());
            writer.WriteLine("    GetScene() = {0}", PrintObjectID(obj.GetScene()));
//            writer.Write("    GetDocument() = {0}", PrintObjectID(obj.GetDocument()));
//            writer.Write("    GetRootDocument() = {0}", PrintObjectID(obj.GetRootDocument()));
            writer.WriteLine("    SrcObjectCount = {0}", obj.GetSrcObjectCount());

            int i;
            for (i = 0; i < obj.GetSrcObjectCount(); i++)
            {
                FbxObject srcObj = obj.GetSrcObject(i);
                writer.WriteLine("        #{0} {1}", i, PrintObjectID(srcObj));
            }
            writer.WriteLine("    DstObjectCount = {0}", obj.GetDstObjectCount());
            for (i = 0; i < obj.GetDstObjectCount(); i++)
            {
                FbxObject dstObj = obj.GetDstObject(i);
                writer.WriteLine("        #{0} {1}", i, PrintObjectID(dstObj));
            }

            var prop = obj.GetFirstProperty();
            int n = 0;
            while (prop != null && prop.IsValid())
            {
                n++;
                prop = obj.GetNextProperty(prop);
            }
            writer.WriteLine("    Properties {0}", n);

            prop = obj.GetFirstProperty();
            n = 0;
            while (prop != null && prop.IsValid())
            {
                writer.WriteLine("        #{0} {1}", n, PrintPropertyID(prop));
                PrintProperty(prop, writer, true);
                n++;
                prop = obj.GetNextProperty(prop);
            }

            writer.WriteLine("    SrcPropertyCount = {0}", obj.GetSrcPropertyCount());
            for (i = 0; i < obj.GetSrcPropertyCount(); i++)
            {
                prop = obj.GetSrcProperty(i);
                writer.WriteLine("        #{0} {1}", i, PrintPropertyID(prop));
            }
            writer.WriteLine("    DstPropertyCount = {0}", obj.GetDstPropertyCount());
            for (i = 0; i < obj.GetDstPropertyCount(); i++)
            {
                prop = obj.GetDstProperty(i);
                writer.WriteLine("        #{0} {1}", i, PrintPropertyID(prop));
            }
            if (obj.RootProperty.IsValid())
            {
                writer.WriteLine("    RootProperty = {0}", PrintPropertyID(obj.RootProperty));
                PrintProperty(obj.RootProperty, writer);
            }
        }

        public int sort_by_id(FbxObject a, FbxObject b)
        {
            if (a == null) throw new ArgumentNullException("a");
            if (b == null) throw new ArgumentNullException("b");

            var aid = a.GetUniqueID();
            var bid = b.GetUniqueID();

            if (aid < bid) return -1;
            if (aid == bid) return 0;
            return 1;
        }

        public void PrintObjectGraph(FbxObject obj)
        {
            PrintObjectGraph(obj, Console.Out);
        }
        public void PrintObjectGraph(FbxObject obj, TextWriter writer)
        {
            var c = new Collector();

            var collected = c.Collect(obj);
            var objs = new List<FbxObject>(collected);

            writer.WriteLine();

            objs.Sort(sort_by_id);

            foreach (var o in objs)
            {
                PrintFbxObject(o, writer);
            }
        }


        //public string GetTypeName(EFbxType tid)
        //{
        //    switch (tid)
        //    {
        //    case eFbxUndefined: return "eFbxUndefined";
        //    case eFbxChar:      return "eFbxChar";
        //    case eFbxUChar:     return "eFbxUChar";
        //    case eFbxShort:     return "eFbxShort";
        //    case eFbxUShort:    return "eFbxUShort";
        //    case eFbxUInt:      return "eFbxUInt";
        //    case eFbxLongLong:  return "eFbxLongLong";
        //    case eFbxULongLong: return "eFbxULongLong";
        //    case eFbxHalfFloat: return "eFbxHalfFloat";
        //    case eFbxBool:      return "eFbxBool";
        //    case eFbxInt:       return "eFbxInt";
        //    case eFbxFloat:     return "eFbxFloat";
        //    case eFbxDouble:    return "eFbxDouble";
        //    case eFbxDouble2:   return "eFbxDouble2";
        //    case eFbxDouble3:   return "eFbxDouble3";
        //    case eFbxDouble4:   return "eFbxDouble4";
        //    case eFbxDouble4x4: return "eFbxDouble4x4";
        //    case eFbxEnum:      return "eFbxEnum";
        //    case eFbxString:    return "eFbxString";
        //    case eFbxTime:      return "eFbxTime";
        //    case eFbxReference: return "eFbxReference";
        //    case eFbxBlob:      return "eFbxBlob";
        //    case eFbxDistance:  return "eFbxDistance";
        //    case eFbxDateTime:  return "eFbxDateTime";
        //    case eFbxTypeCount: return "eFbxTypeCount";
        //    }
        //
        //    return "<<unknown>>";
        //}

        public string GetTypeName(Type tid)
        {
            return tid.Name;
        }

        public void PrintProperty(FbxProperty prop, TextWriter writer, bool indent=false)
        {
            string prefix = indent ? "            " : "        ";

            writer.WriteLine("{0}Name = {1}", prefix, prop.GetName());
            var type = prop.GetPropertyDataType();
            writer.WriteLine("{0}Type = {1}", prefix, type.GetName());
//            writer.WriteLine("{0}HierName = {1}", prefix, prop.GetHierarchicalName());
//            writer.WriteLine("{0}Label = {1}", prefix, prop.GetLabel());

//            char n[1024];
            int i;
//            for (i = 0; i < 1024; i++)
//            {
//                n[i] = 0;
//            }
            sbyte ch;
            byte uch;
            uint ui;
            short sh;
            ushort ush;
            long ll;
            ulong ull;
            bool b;
            float f;
            double d;
            string fstr;
            FbxVector2 v2;
            FbxVector3 v3;
            FbxVector4 v4;
            string s;
            FbxTime t;
            var sb = new StringBuilder();

            bool printValue = true;

//            switch (type.GetType())
//            {
//            case eFbxUndefined:
//                printValue = false;
//                break;
//            case eFbxChar:
            if (type == typeof(sbyte))
            {
                ch = prop.Get<sbyte>();
                sb.AppendFormat("%i ('%c')", (int)ch, ch);
            }
//                break;
//            case eFbxUChar:
            if (type == typeof(byte))
            {
                uch = prop.Get<byte>();
                sb.AppendFormat("%i ('%c')", (uint)uch, uch);
            }
//                break;
//            case eFbxShort:
            if (type == typeof(short))
            {
                sh = prop.Get<short>();
                sb.AppendFormat("%i", (int)sh);
            }
//                break;
//            case eFbxUShort:
            if (type == typeof(ushort))
            {
                ush = prop.Get<ushort>();
                sb.AppendFormat("%ui", (uint)ush);
            }
//                break;
//            case eFbxUInt:
            if (type == typeof(uint))
            {
                ui = prop.Get<uint>();
                sb.AppendFormat("%ui", ui);
            }
//                break;
//            case eFbxLongLong:
            if (type == typeof(long))
            {
                ll = prop.Get<long>();
                sb.AppendFormat("%lli", ll);
            }
//                break;
//            case eFbxULongLong:
            if (type == typeof(ulong))
            {
                ull = prop.Get<ulong>();
                sb.AppendFormat("%llu", ull);
            }
//                break;
//            case eFbxHalfFloat:
//                printValue = false;
//                break;
//            case eFbxBool:
            if (type == typeof(bool))
            {
                b = prop.Get<bool>();
                if (b)
                    sb.AppendFormat("true");
                else
                    sb.AppendFormat("false");
            }
//                break;
//            case eFbxInt:
            if (type == typeof(int))
            {
                i = prop.Get<int>();
                sb.AppendFormat("%i", i);
            }
//                break;
//            case eFbxFloat:
            if (type == typeof(float))
            {
                f = prop.Get<float>();
                sb.AppendFormat("%f", f);
            }
//                break;
//            case eFbxDouble:
            if (type == typeof(double))
            {
                d = prop.Get<double>();
                sb.AppendFormat("{0}", d);
            }
//                break;
//            case eFbxDouble2:
            if (type == typeof(FbxVector2))
            {
                v2 = prop.Get<FbxVector2>();
                sb.AppendFormat("{0}, {1}", v2.X, v2.Y);
            }
//                break;
//            case eFbxDouble3:
            if (type == typeof(sbyte))
            {
                v3 = prop.Get<FbxVector3>();
                sb.AppendFormat("{0}, {1}, {2}", v3.X, v3.Y, v3.Z);
            }
//                break;
//            case eFbxDouble4:
            if (type == typeof(sbyte))
            {
                v4 = prop.Get<FbxVector4>();
                sb.AppendFormat("{0}, {1}, {2}, {3}", v4.X, v4.Y, v4.Z, v4.W);
            }
//                break;
//            case eFbxDouble4x4:
//            case eFbxEnum:
//                printValue = false;
//                break;
//            case eFbxString:
            if (type == typeof(sbyte))
            {
                fstr = prop.Get<string>();
                sb.Append(quote(fstr));
            }
//                break;
//            case eFbxTime:
            if (type == typeof(sbyte))
            {
                t = prop.Get<FbxTime>();
                sb.AppendFormat("{0}", t);
            }
//                break;
//            case eFbxReference:
                //            FbxObject* obj;
                //            obj = prop.Get<FbxObject*>();
                //            cout << prefix << ".Value = " << obj.GetRuntimeClassId().GetName() << ", uid=" << obj.GetUniqueID() << endl;
                //            break;
//            case eFbxBlob:
//            case eFbxDistance:
//            case eFbxDateTime:
//            case eFbxTypeCount:
//                printValue = false;
//                break;

            if (printValue)
            {
                writer.WriteLine("{0}Value = {1}", prefix, sb.ToString());
            }


            writer.WriteLine("{0}{1}{2}", prefix , "SrcObjectCount = " , prop.GetSrcObjectCount() );
            for (i = 0; i < prop.GetSrcObjectCount(); i++)
            {
                FbxObject srcObj = prop.GetSrcObject(i);
                writer.WriteLine("{0}    #{1} {2}", prefix , i, PrintObjectID(srcObj));
            }
            writer.WriteLine("{0}{1}{2}", prefix , "DstObjectCount = " , prop.GetDstObjectCount() );
            for (i = 0; i < prop.GetDstObjectCount(); i++)
            {
                FbxObject dstObj = prop.GetDstObject(i);
                writer.WriteLine("{0}    #{1} {2}", prefix , i, PrintObjectID(dstObj));
            }
//            writer.WriteLine("{0}{1}{2}", prefix , "SrcPropertyCount = " , prop.GetSrcPropertyCount() );
//            for (i = 0; i < prop.GetSrcPropertyCount(); i++)
//            {
//                Property prop2 = prop.GetSrcProperty(i);
//                writer.Write("{0}{1}{2}", prefix , "    #" , i , " ");
//                PrintPropertyID(prop2);
//                writer.WriteLine();
//            }
//            writer.WriteLine("{0}{1}{2}", prefix , "DstPropertyCount = " , prop.GetDstPropertyCount() );
//            for (i = 0; i < prop.GetDstPropertyCount(); i++)
//            {
//                Property prop2 = prop.GetDstProperty(i);
//                writer.Write("{0}{1}{2}", prefix , "    #" , i , " ");
//                PrintPropertyID(prop2);
//                writer.WriteLine();
//            }
        }



        public void _PrintFbxAnimCurve(FbxAnimCurve obj, TextWriter writer)
        {
            writer.WriteLine("    KeyGetCount() = {0}", obj.KeyGetCount());
            int k;
            for (k = 0; k < obj.KeyGetCount(); k++)
            {
                var key = obj.KeyGet(k);

                writer.Write("        #{0}: {1}, ", k, key.GetTime().Print());

                writer.Write("{0:g5}", key.GetValue());
                writer.Write(", ");
                writer.Write((int)key.GetInterpolation());
                writer.Write(":");
                writer.Write(key.GetInterpolation());
                writer.Write(", ");
                writer.Write((int)key.GetTangentMode());
                writer.Write(":");
                writer.Write(key.GetTangentMode());
                writer.Write(", ");
                writer.Write((int)key.GetTangentWeightMode());
                writer.Write(":");
                writer.Write(key.GetTangentWeightMode());
                writer.Write(", ");
                writer.Write((int)key.GetTangentVelocityMode());
                writer.Write(":");
                writer.Write(key.GetTangentVelocityMode());
                writer.Write(", ");
                writer.Write((int)key.GetConstantMode());
                writer.Write(":");
                writer.Write(key.GetConstantMode());
                writer.Write(", ");
                writer.Write((int)key.GetTangentVisibility());
                writer.Write(":");
                writer.Write(key.GetTangentVisibility());
                writer.Write(", ");
                writer.Write("Break: ");
                writer.Write(key.GetBreak() ? "1" : "0");
                writer.Write(", ");
                writer.Write("DataFloat: ");
                writer.Write("{0:G5}", key.GetDataFloat((FbxAnimCurveDef.EDataIndex)0));
                writer.Write(", ");
                writer.Write("{0:G5}", key.GetDataFloat((FbxAnimCurveDef.EDataIndex)1));
                writer.Write(", ");
                writer.Write("{0:G5}", key.GetDataFloat((FbxAnimCurveDef.EDataIndex)2));
                writer.Write(", ");
                writer.Write("{0:G5}", key.GetDataFloat((FbxAnimCurveDef.EDataIndex)3));
                writer.Write(", ");
                writer.Write("{0:G5}", key.GetDataFloat((FbxAnimCurveDef.EDataIndex)4));
                writer.Write(", ");
                writer.Write("{0:G5}", key.GetDataFloat((FbxAnimCurveDef.EDataIndex)5));

                writer.WriteLine();
            }
            // TODO: Evaluation and Analysis?
            // TODO: GetTimeInterval?
        }

        protected void _PrintFbxAnimCurveBase(FbxAnimCurveBase obj, TextWriter writer)
        {
            // TODO: Extrapolation
            // TODO: Evaluate?
            // TODO: GetTimeInterval?
        }

        protected void _PrintFbxAnimCurveNode(FbxAnimCurveNode obj, TextWriter writer)
        {
            // TODO: GetAnimationInterval?
            // TODO: writer.WriteLine("    IsAnimated = {0}", obj.IsAnimated());
            // TODO: IsAnimated(recurse: true)
            // TODO: writer.WriteLine("    IsComposite = {0}", obj.IsComposite());
            int i;
            writer.WriteLine("    ChannelsCount = {0}", obj.GetChannelsCount());
            for (i = 0; i < obj.GetChannelsCount(); i++)
            {
                int curveCount = obj.GetCurveCount((uint)i);
                writer.WriteLine("        #{0} {1}, {2} curves",
                                 i,
                                 obj.GetChannelName(i),
                                 curveCount);
                int j;
                for (j = 0; j < curveCount; j++)
                {
                    writer.WriteLine("            #{0} {1}",
                                     j,
                                     PrintObjectID(obj.GetCurve((uint)i, (uint)j)));
                }
            }
        }

        protected void _PrintFbxAnimEvaluator(FbxAnimEvaluator obj, TextWriter writer)
        {
        }

        protected void _PrintFbxAnimEvalClassic(FbxAnimEvalClassic obj, TextWriter writer)
        {
            throw new NotImplementedException();
        }

        protected void _PrintFbxCollection(FbxCollection obj, TextWriter writer)
        {
        }

        protected void _PrintFbxAnimLayer(FbxAnimLayer obj, TextWriter writer)
        {
            // TODO
        }

        protected void _PrintFbxAnimStack(FbxAnimStack obj, TextWriter writer)
        {
            // TODO: GetLocalTimeSpan
            // TODO: GetReferenceTimeSpan
        }

        protected void _PrintFbxDocument(FbxDocument obj, TextWriter writer)
        {
        }

        protected void _PrintFbxScene(FbxScene obj, TextWriter writer)
        {
            writer.WriteLine("    RootNode = {0}", PrintObjectID(obj.GetRootNode()));
            writer.WriteLine("    AnimationEvaluator = {0}", PrintObjectID(obj.GetAnimationEvaluator()));
            writer.WriteLine("    CurrentAnimationStack = {0}", PrintObjectID(obj.GetCurrentAnimationStack()));
            writer.WriteLine("    Global Settings = {0}", PrintObjectID(obj.GetGlobalSettings()));

            int i;
            writer.WriteLine("    MaterialCount = {0}", obj.GetMaterialCount());
            for (i = 0; i < obj.GetMaterialCount(); i++)
            {
                FbxSurfaceMaterial mat = obj.GetMaterial(i);
                writer.WriteLine("        #{0} {1}", i, PrintObjectID(mat));
            }
            writer.WriteLine("    PoseCount = {0}", obj.GetPoseCount());
            for (i = 0; i < obj.GetPoseCount(); i++)
            {
                FbxPose pose = obj.GetPose(i);
                writer.WriteLine("        #{0} {1}", i, PrintObjectID(pose));
            }
            writer.WriteLine("    TextureCount = {0}", obj.GetTextureCount());
            for (i = 0; i < obj.GetTextureCount(); i++)
            {
                FbxTexture texture = obj.GetTexture(i);
                writer.WriteLine("        #{0} {1}", i, PrintObjectID(texture));
            }
            writer.WriteLine("    NodeCount = {0}", obj.GetNodeCount());
            for (i = 0; i < obj.GetNodeCount(); i++)
            {
                FbxNode node = obj.GetNode(i);
                writer.WriteLine("        #{0} {1}", i, PrintObjectID(node));
            }
        }

        protected void _PrintFbxDeformer(FbxDeformer obj, TextWriter writer)
        {
            writer.WriteLine("    DeformerType = {0}", obj.GetDeformerType());
        }

        protected void _PrintFbxSkin(FbxSkin obj, TextWriter writer)
        {
            writer.WriteLine("    DeformAccuracy = {0}", obj.GetDeformAccuracy());
            writer.WriteLine("    Geometry = {0}", PrintObjectID(obj.GetGeometry()));
            // TODO: GetSkinningType
            int i;
            writer.WriteLine("    ClusterCount = {0}", obj.GetClusterCount());
            for (i = 0; i < obj.GetClusterCount(); i++)
            {
                FbxCluster cluster = obj.GetCluster(i);
                writer.WriteLine("        #{0} {1}", i, PrintObjectID(cluster));
            }
            // TODO: Control Points
        }

        protected void _PrintFbxGlobalSettings(FbxGlobalSettings obj, TextWriter writer)
        {
        }

        protected void _PrintFbxIOBase(FbxIOBase obj, TextWriter writer)
        {
            throw new NotImplementedException();
        }

        protected void _PrintFbxImporter(FbxImporter obj, TextWriter writer)
        {
            throw new NotImplementedException();
        }

        protected void _PrintFbxNode(FbxNode obj, TextWriter writer)
        {
            writer.WriteLine("    Parent = {0}", PrintObjectID(obj.GetParent()));
            writer.WriteLine("    MultiLayer = {0}", obj.MultiLayer);
            writer.WriteLine("    MultiTake = {0}", obj.MultiTake);
            writer.WriteLine("    Shading = {0}", obj.Shading);
            writer.WriteLine("    Culling = {0}", obj.Culling);

            writer.WriteLine("    ChildCount = {0}", obj.GetChildCount());
            int i;
            for (i = 0; i < obj.GetChildCount(); i++)
            {
                FbxNode child = obj.GetChild(i);
                writer.WriteLine("        #{0} {1}", i, PrintObjectID(child));
            }
            writer.WriteLine("    NodeAttribute = {0}", PrintObjectID(obj.GetNodeAttribute()));
            writer.WriteLine("    NodeAttributeCount = {0}", obj.GetNodeAttributeCount());
            for (i = 0; i < obj.GetNodeAttributeCount(); i++)
            {
                FbxNodeAttribute attr = obj.GetNodeAttributeByIndex(i);
                writer.WriteLine("        #{0} {1}", i, PrintObjectID(attr));
            }
            // TODO: Node Evaluation Functions
            writer.WriteLine("    MaterialCount = {0}", obj.GetMaterialCount());
            for (i = 0; i < obj.GetMaterialCount(); i++)
            {
                FbxSurfaceMaterial mat = obj.GetMaterial(i);
                writer.WriteLine("        #{0} {1}", i, PrintObjectID(mat));
            }
        }

        protected void _PrintFbxNodeAttribute(FbxNodeAttribute obj, TextWriter writer)
        {
            writer.WriteLine("    AttributeType = {0}", obj.GetAttributeType());
            int i;
            writer.WriteLine("    NodeCount = {0}", obj.GetNodeCount());
            for (i = 0; i < obj.GetNodeCount(); i++)
            {
                FbxNode node = obj.GetNode(i);
                writer.WriteLine("        #{0} {1}", i, PrintObjectID(node));
            }
        }

        protected void _PrintFbxCamera(FbxCamera obj, TextWriter writer)
        {
            // TODO: Functions to handle the viewing area
            // TODO: Aperture and Film Functions
            // TODO: Functions to handle BackPlane/FrontPlane and Plate
            // TODO: Camera View Functions
            // TODO: Render Functions
            // TODO: Utility Functions
        }

        protected void _PrintFbxLayerContainer(FbxLayerContainer obj, TextWriter writer)
        {
            int i;
            writer.WriteLine("    LayerCount = {0}", obj.GetLayerCount());
            for (i = 0; i < obj.GetLayerCount(); i++)
            {
                FbxLayer layer = obj.GetLayer(i);
                writer.WriteLine("        #{0}", i);
                _PrintFbxLayer(layer, writer);
            }
        }

        protected void _PrintFbxLayer(FbxLayer obj, TextWriter writer)
        {
            // TODO
        }

        protected void _PrintFbxGeometryBase(FbxGeometryBase obj, TextWriter writer)
        {
            int i;
            writer.WriteLine("    ControlPointsCount = {0}", obj.GetControlPointsCount());
            for (i = 0; i < obj.GetControlPointsCount(); i++)
            {
                FbxVector4 cp = obj.GetControlPointAt(i);
                writer.WriteLine("        #{0} {1}, {2}, {3}, {4}", i, cp.X, cp.Y, cp.Z, cp.W);
            }
        }

        protected void _PrintFbxGeometry(FbxGeometry obj, TextWriter writer)
        {
            int i;
            writer.WriteLine("    DeformerCount = {0}", obj.GetDeformerCount());
            for (i = 0; i < obj.GetDeformerCount(); i++)
            {
                FbxDeformer deformer = obj.GetDeformer(i);
                writer.WriteLine("        #{0} {1}", i, PrintObjectID(deformer));
            }
        }

        protected void _PrintFbxMesh(FbxMesh obj, TextWriter writer)
        {
            int i;
            writer.WriteLine("    PolygonIndexes = {0}", obj.PolygonIndexes.Count);
            for (i = 0; i < obj.PolygonIndexes.Count; i++)
            {
                writer.Write("        #{0} ({1}):", i, obj.PolygonIndexes[i].Count);
                int j;
                for (j = 0; j < obj.PolygonIndexes[i].Count; j++)
                {
                    writer.Write(" ");
                    writer.Write(obj.PolygonIndexes[i][j]);
                }
                writer.WriteLine();
            }
        }

        protected void _PrintFbxLight(FbxLight obj, TextWriter writer)
        {
            // TODO: writer.WriteLine("    ShadowTexture = {0}", obj.GetShadowTexture());
        }

        protected void _PrintFbxNull(FbxNull obj, TextWriter writer)
        {
            throw new NotImplementedException();
        }

        protected void _PrintFbxSkeleton(FbxSkeleton obj, TextWriter writer)
        {
            writer.WriteLine("    SkeletonType = {0}", obj.SkeletonType);
            writer.WriteLine("    IsSkeletonRoot = {0}", obj.IsSkeletonRoot);
            writer.WriteLine("    IsLimbNodeColorSet = {0}", obj.IsLimbNodeColorSet);
            writer.WriteLine("    LimbNodeColor = {0}", obj.LimbNodeColor);
        }

        protected void _PrintFbxPose(FbxPose obj, TextWriter writer)
        {
            writer.WriteLine("    IsBindPose = {0}", obj.IsBindPose());
            writer.WriteLine("    GetCount = {0}", obj.GetCount());
            int i;
            for (i = 0; i < obj.GetCount(); i++)
            {
                FbxPoseInfo pi = obj.PoseInfos[i];
                writer.WriteLine("        #{0} {1}", i, RenderPoseInfo(pi));
            }
        }

        protected string RenderPoseInfo(FbxPoseInfo pi)
        {
            return string.Format("Node={0} IsLocal={1} Matrix={2}",
                                 PrintObjectID(pi.Node),
                                 pi.MatrixIsLocal,
                                 pi.Matrix.ToString());
        }

        protected void _PrintFbxSubDeformer(FbxSubDeformer obj, TextWriter writer)
        {
            writer.WriteLine("    IsMultiLayer = {0}", obj.GetMultiLayer());
            writer.WriteLine("    SubDeformerType = {0}", obj.GetSubDeformerType());
        }

        protected void _PrintFbxCluster(FbxCluster obj, TextWriter writer)
        {
            // TODO: Public Member Functions
            // TODO: General Functions
            // TODO: Link Mode, Link Node, Associate Model
            // TODO: Control Points
            // TODO: Transformation Matrices
        }

        protected void _PrintFbxSurfaceMaterial(FbxSurfaceMaterial obj, TextWriter writer)
        {
        }

        protected void _PrintFbxSurfaceLambert(FbxSurfaceLambert obj, TextWriter writer)
        {
        }

        protected void _PrintFbxSurfacePhong(FbxSurfacePhong obj, TextWriter writer)
        {
        }

        protected void _PrintFbxTexture(FbxTexture obj, TextWriter writer)
        {
            writer.WriteLine("    Type = {0}", obj.Type);
            writer.WriteLine("    Media = {0}", obj.Media);
            writer.WriteLine("    Filename = {0}", obj.Filename);
            writer.WriteLine("    RelativeFilename = {0}", obj.RelativeFilename);
            writer.WriteLine("    ModelUVTranslation = {0}", obj.ModelUVTranslation);
            writer.WriteLine("    ModelUVScaling = {0}", obj.ModelUVScaling);
            writer.WriteLine("    AlphaSource = {0}", obj.AlphaSource);
            writer.WriteLine("    Cropping = {0}", obj.Cropping);
        }

        protected void _PrintFbxVideo(FbxVideo obj, TextWriter writer)
        {
            writer.WriteLine("    Type = {0}", obj.Type);
            writer.WriteLine("    UseMipMap = {0}", obj.UseMipMap);
            writer.WriteLine("    Filename = {0}", obj.Filename);
            writer.WriteLine("    RelativeFilename = {0}", obj.RelativeFilename);
        }
    }
}
