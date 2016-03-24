using System;
using FbxSharp;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace ObjectPrinter
{
    class MainClass
    {
        public static void Main(string [] args)
        {
            if (args == null || args.Length < 1)
            {
                Console.Error.WriteLine("Usage: ObjectPrinter.exe FILENAME [ FILENAME ... ]");
                return;
            }

            foreach (var filename in args)
            {
                var importer = new Importer(filename);
                var scene = importer.Import(filename);

                var acs1 = scene.SrcObjects.Where(x => x is AnimCurve).ToList();
                var acs2 = acs1.Cast<AnimCurve>().ToList();
                var ordered = acs2.OrderBy(x => x.GetUniqueID()).ToList();
                var acs = ordered.ToList();
                foreach (var srcobj in acs)
                {
                    var ac = srcobj as AnimCurve;
                    if (ac != null)
                    {
    //                    PrintObject(ac);
    //                    Console.WriteLine(PrintObjectID(ac));
                        PrintAnimCurve(ac);
                        Console.WriteLine();
     //                    break;
                    }
                }

    //            PrintObjectGraph(scene);
            }
        }


        public static string quote(string s)
        {
            // TODO: hex escape sequences
            return "\"" + s.Replace("\r", "\\r").Replace("\n", "\\n").Replace("\t", "\\t") + "\"";
        }

        public static string PrintPropertyID(Property prop)
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

        public static void PrintObject(FbxObject obj)
        {
            Console.WriteLine("${0}", PrintObjectID(obj));  // extra $ for easy text search
            Console.WriteLine("    Name = {0}", quote(obj.GetName()));
            Console.WriteLine("    ClassId = {0}", obj.GetType().Name/*obj.GetRuntimeClassId().GetName()*/);
            Console.WriteLine("    UniqueId = {0}", obj.GetUniqueID());
            Console.WriteLine("    GetScene() = {0}", PrintObjectID(obj.GetScene()));
//            Console.Write("    GetDocument() = {0}", PrintObjectID(obj.GetDocument()));
//            Console.Write("    GetRootDocument() = {0}", PrintObjectID(obj.GetRootDocument()));
            Console.WriteLine("    SrcObjectCount = {0}", obj.GetSrcObjectCount());

            int i;
            for (i = 0; i < obj.GetSrcObjectCount(); i++)
            {
                FbxObject srcObj = obj.GetSrcObject(i);
                Console.WriteLine("        #{0} {1}", i, PrintObjectID(srcObj));
            }
            Console.Write("    DstObjectCount = {0}", obj.GetDstObjectCount());
            for (i = 0; i < obj.GetDstObjectCount(); i++)
            {
                FbxObject dstObj = obj.GetDstObject(i);
                Console.WriteLine("        #{0} {1}", i, PrintObjectID(dstObj));
            }

            var prop = obj.GetFirstProperty();
            int n = 0;
            while (prop != null && prop.IsValid())
            {
                n++;
                prop = obj.GetNextProperty(prop);
            }
            Console.WriteLine("    Properties {0}", n);

            prop = obj.GetFirstProperty();
            n = 0;
            while (prop != null && prop.IsValid())
            {
                Console.WriteLine("        #{0} {1}", n, PrintPropertyID(prop));
                PrintProperty(prop, true);
                n++;
                prop = obj.GetNextProperty(prop);
            }

            Console.WriteLine("    SrcPropertyCount = {0}", obj.GetSrcPropertyCount());
            for (i = 0; i < obj.GetSrcPropertyCount(); i++)
            {
                prop = obj.GetSrcProperty(i);
                Console.Write("        #{0} ", i);
                PrintPropertyID(prop);
                Console.WriteLine();
            }
            Console.WriteLine("    DstPropertyCount = {0}", obj.GetDstPropertyCount());
            for (i = 0; i < obj.GetDstPropertyCount(); i++)
            {
                prop = obj.GetDstProperty(i);
                Console.Write("        #{0} ", i);
                PrintPropertyID(prop);
                Console.WriteLine();
            }
            if (obj.RootProperty.IsValid())
            {
                Console.Write("    RootProperty ");
                PrintPropertyID(obj.RootProperty);
                Console.WriteLine();
                PrintProperty(obj.RootProperty);
            }


//            if (obj is Collection)
//                PrintCollection(obj as Collection);
//            else
            if (obj is AnimCurve)
                PrintAnimCurve(obj as AnimCurve);
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
                Console.WriteLine("Unknown object class: {0}", obj.GetType().Name/*obj.GetRuntimeClassId().GetName()*/);

            Console.WriteLine();
        }

        public static int sort_by_id(FbxObject a, FbxObject b)
        {
            if (a == null) throw new ArgumentNullException("a");
            if (b == null) throw new ArgumentNullException("b");

            var aid = a.GetUniqueID();
            var bid = b.GetUniqueID();

            if (aid < bid) return -1;
            if (aid == bid) return 0;
            return 1;
        }

        public static void PrintObjectGraph(FbxObject obj)
        {
            var c = new Collector();

            c.Visit(obj);

            Console.WriteLine();

            var objs = c.Objects;
            objs.Sort(sort_by_id);

            foreach (var o in objs)
            {
                PrintObject(o);
            }
        }


        //public static string GetTypeName(EFbxType tid)
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

        public static string GetTypeName(Type tid)
        {
            return tid.Name;
        }

        public static void PrintProperty(Property prop, bool indent=false)
        {
            string prefix = indent ? "            " : "        ";

            Console.WriteLine("{0}Name = {1}", prefix, prop.GetName());
            var type = prop.GetPropertyDataType();
            Console.WriteLine("{0}Type = {1} ({2})", prefix, type.GetName(), GetTypeName(type.GetType()));
//            Console.WriteLine("{0}HierName = {1}", prefix, prop.GetHierarchicalName());
//            Console.WriteLine("{0}Label = {1}", prefix, prop.GetLabel());

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
            Vector2 v2;
            Vector3 v3;
            Vector4 v4;
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
            if (type == typeof(Vector2))
            {
                v2 = prop.Get<Vector2>();
                sb.AppendFormat("{0}, {1}", v2.X, v2.Y);
            }
//                break;
//            case eFbxDouble3:
            if (type == typeof(sbyte))
            {
                v3 = prop.Get<Vector3>();
                sb.AppendFormat("{0}, {1}, {2}", v3.X, v3.Y, v3.Z);
            }
//                break;
//            case eFbxDouble4:
            if (type == typeof(sbyte))
            {
                v4 = prop.Get<Vector4>();
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
                Console.WriteLine("{0}Value = {1}", prefix, sb.ToString());
            }


            Console.WriteLine("{0}{1}{2}", prefix , "SrcObjectCount = " , prop.GetSrcObjectCount() );
            for (i = 0; i < prop.GetSrcObjectCount(); i++)
            {
                FbxObject srcObj = prop.GetSrcObject(i);
                Console.Write("{0}{1}{2}", prefix , "    #" , i , " ");
                PrintObjectID(srcObj);
                Console.WriteLine();
            }
            Console.WriteLine("{0}{1}{2}", prefix , "DstObjectCount = " , prop.GetDstObjectCount() );
            for (i = 0; i < prop.GetDstObjectCount(); i++)
            {
                FbxObject dstObj = prop.GetDstObject(i);
                Console.Write("{0}{1}{2}", prefix , "    #" , i , " ");
                PrintObjectID(dstObj);
                Console.WriteLine();
            }
//            Console.WriteLine("{0}{1}{2}", prefix , "SrcPropertyCount = " , prop.GetSrcPropertyCount() );
//            for (i = 0; i < prop.GetSrcPropertyCount(); i++)
//            {
//                Property prop2 = prop.GetSrcProperty(i);
//                Console.Write("{0}{1}{2}", prefix , "    #" , i , " ");
//                PrintPropertyID(prop2);
//                Console.WriteLine();
//            }
//            Console.WriteLine("{0}{1}{2}", prefix , "DstPropertyCount = " , prop.GetDstPropertyCount() );
//            for (i = 0; i < prop.GetDstPropertyCount(); i++)
//            {
//                Property prop2 = prop.GetDstProperty(i);
//                Console.Write("{0}{1}{2}", prefix , "    #" , i , " ");
//                PrintPropertyID(prop2);
//                Console.WriteLine();
//            }
        }



        public static void PrintAnimCurve(AnimCurve ac)
        {
            Console.Write("    KeyGetCount() = ");
            Console.Write(ac.KeyGetCount());
            Console.WriteLine();
            int k;
            for (k = 0; k < ac.KeyGetCount(); k++)
            {
                var key = ac.KeyGet(k);

                Console.Write("        #{0}: {1}, ", k, key.GetTime().Print());

                Console.Write("{0:g5}", key.GetValue());
                Console.Write(", ");
                Console.Write((int)key.GetInterpolation());
                Console.Write(":");
                Console.Write(key.GetInterpolation());
                Console.Write(", ");
                Console.Write((int)key.GetTangentMode());
                Console.Write(":");
                Console.Write(key.GetTangentMode());
                Console.Write(", ");
                Console.Write((int)key.GetTangentWeightMode());
                Console.Write(":");
                Console.Write(key.GetTangentWeightMode());
                Console.Write(", ");
                Console.Write((int)key.GetTangentVelocityMode());
                Console.Write(":");
                Console.Write(key.GetTangentVelocityMode());
                Console.Write(", ");
                Console.Write((int)key.GetConstantMode());
                Console.Write(":");
                Console.Write(key.GetConstantMode());
                Console.Write(", ");
                Console.Write((int)key.GetTangentVisibility());
                Console.Write(":");
                Console.Write(key.GetTangentVisibility());
                Console.Write(", ");
                Console.Write("Break: ");
                Console.Write(key.GetBreak() ? "1" : "0");
                Console.Write(", ");
                Console.Write("DataFloat: ");
                Console.Write("{0:G5}", key.GetDataFloat((AnimCurveDef.EDataIndex)0));
                Console.Write(", ");
                Console.Write("{0:G5}", key.GetDataFloat((AnimCurveDef.EDataIndex)1));
                Console.Write(", ");
                Console.Write("{0:G5}", key.GetDataFloat((AnimCurveDef.EDataIndex)2));
                Console.Write(", ");
                Console.Write("{0:G5}", key.GetDataFloat((AnimCurveDef.EDataIndex)3));
                Console.Write(", ");
                Console.Write("{0:G5}", key.GetDataFloat((AnimCurveDef.EDataIndex)4));
                Console.Write(", ");
                Console.Write("{0:G5}", key.GetDataFloat((AnimCurveDef.EDataIndex)5));

                Console.WriteLine();
            }
        }
    }
}
