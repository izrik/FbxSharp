using System;
using FbxSharp;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace FbxSharp
{
    public class ObjectPrinter
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

        public void PrintObject(FbxObject obj)
        {
            PrintObject(obj, Console.Out);
        }
        public void PrintObject(FbxObject obj, TextWriter writer)
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
            writer.Write("    DstObjectCount = {0}", obj.GetDstObjectCount());
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
                PrintProperty(prop, true);
                n++;
                prop = obj.GetNextProperty(prop);
            }

            writer.WriteLine("    SrcPropertyCount = {0}", obj.GetSrcPropertyCount());
            for (i = 0; i < obj.GetSrcPropertyCount(); i++)
            {
                prop = obj.GetSrcProperty(i);
                writer.Write("        #{0} ", i);
                PrintPropertyID(prop);
                writer.WriteLine();
            }
            writer.WriteLine("    DstPropertyCount = {0}", obj.GetDstPropertyCount());
            for (i = 0; i < obj.GetDstPropertyCount(); i++)
            {
                prop = obj.GetDstProperty(i);
                writer.Write("        #{0} ", i);
                PrintPropertyID(prop);
                writer.WriteLine();
            }
            if (obj.RootProperty.IsValid())
            {
                writer.Write("    RootProperty ");
                PrintPropertyID(obj.RootProperty);
                writer.WriteLine();
                PrintProperty(obj.RootProperty);
            }


//            if (obj is Collection)
//                PrintCollection(obj as Collection);
//            else
            if (obj is FbxAnimCurve)
                PrintAnimCurve(obj as FbxAnimCurve);
//            else if (obj is AnimCurveNode)
//                PrintAnimCurveNode(obj as AnimCurveNode);
//            else if (obj is Deformer)
//                PrintDeformer(obj as Deformer);
//            else if (obj is Node)
//                PrintNode(obj as Node);
//            else if (obj is NodeAttribute)
//                PrintNodeAttribute(obj as NodeAttribute);
//            else if (obj is Pose)
//                PrintPose(obj as Pose);
//            else if (obj is SubDeformer)
//                PrintSubDeformer(obj as SubDeformer);
//            else if (obj is SurfaceMaterial)
//                PrintSurfaceMaterial(obj as SurfaceMaterial);
//            else if (obj is Texture)
//                PrintTexture(obj as Texture);
//            else if (obj is Video)
//                PrintVideo(obj as Video);
            else
                writer.WriteLine("Unknown object class: {0}", obj.GetType().Name/*obj.GetRuntimeClassId().GetName()*/);

            writer.WriteLine();
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
                PrintObject(o);
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

        public void PrintProperty(FbxProperty prop, bool indent=false)
        {
            PrintProperty(prop, Console.Out, indent);
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
                writer.Write("{0}{1}{2}", prefix , "    #" , i , " ");
                PrintObjectID(srcObj);
                writer.WriteLine();
            }
            writer.WriteLine("{0}{1}{2}", prefix , "DstObjectCount = " , prop.GetDstObjectCount() );
            for (i = 0; i < prop.GetDstObjectCount(); i++)
            {
                FbxObject dstObj = prop.GetDstObject(i);
                writer.Write("{0}{1}{2}", prefix , "    #" , i , " ");
                PrintObjectID(dstObj);
                writer.WriteLine();
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



        public void PrintAnimCurve(FbxAnimCurve ac)
        {
            PrintAnimCurve(ac, Console.Out);
        }
        public void PrintAnimCurve(FbxAnimCurve ac, TextWriter writer)
        {
            writer.Write("    KeyGetCount() = ");
            writer.Write(ac.KeyGetCount());
            writer.WriteLine();
            int k;
            for (k = 0; k < ac.KeyGetCount(); k++)
            {
                var key = ac.KeyGet(k);

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
        }
    }
}
