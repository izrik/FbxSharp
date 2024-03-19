using System;
using System.Collections.Generic;
using FbxSharp;
using NCommander;

namespace FbxCli
{
    public class LsCommand : Command
    {
        public LsCommand(CliState cliState)
        {
            Name = "ls";
            Description = "List connections of the current object";
            Params = new[]
            {
                new Parameter()
                {
                    Name = "target",
                    Description = "The set of object connections to list",
                    IsOptional = true,
                    ParameterType = ParameterType.String // TODO: ParameterType.Choice
                }
            };
            Options = new[]
            {
                new Option
                {
                    Name = "from",
                    Description = "Starting index for listing a subset of " +
                                  "entries",
                    Type = ParameterType.Integer
                },
                new Option
                {
                    Name = "to",
                    Description = "Ending index (inclusive) for listing a " +
                                  "subset of entries",
                    Type = ParameterType.Integer
                },
                new Option
                {
                    Name = "count",
                    Description = "Number of entries to list",
                    Type = ParameterType.Integer
                },
                new Option
                {
                    Name = "type",
                    Description = "Type of objects to list, e.g. 'FbxNode', " +
                                  "'FbxGeometry'",
                    Type = ParameterType.String
                }
            };

            _cliState=cliState;
        }

        private readonly CliState _cliState;

        private static readonly Dictionary<string, Type> _typesByName =
            new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
        {
            {"FbxObject", typeof(FbxObject)},
            {"FbxAnimCurveBase", typeof(FbxAnimCurveBase)},
            {"FbxAnimCurve", typeof(FbxAnimCurve)},
            {"FbxAnimCurveNode", typeof(FbxAnimCurveNode)},
            {"FbxAnimEvaluator", typeof(FbxAnimEvaluator)},
            {"FbxAnimEvalClassic", typeof(FbxAnimEvalClassic)},
            {"FbxCollection", typeof(FbxCollection)},
            {"FbxAnimLayer", typeof(FbxAnimLayer)},
            {"FbxAnimStack", typeof(FbxAnimStack)},
            {"FbxDocument", typeof(FbxDocument)},
            {"FbxScene", typeof(FbxScene)},
            {"FbxDeformer", typeof(FbxDeformer)},
            {"FbxSkin", typeof(FbxSkin)},
            {"FbxGlobalSettings", typeof(FbxGlobalSettings)},
            {"FbxIOBase", typeof(FbxIOBase)},
            {"FbxImporter", typeof(FbxImporter)},
            {"FbxNode", typeof(FbxNode)},
            {"FbxNodeAttribute", typeof(FbxNodeAttribute)},
            {"FbxCamera", typeof(FbxCamera)},
            {"FbxLayerContainer", typeof(FbxLayerContainer)},
            {"FbxGeometryBase", typeof(FbxGeometryBase)},
            {"FbxGeometry", typeof(FbxGeometry)},
            {"FbxMesh", typeof(FbxMesh)},
            {"FbxLight", typeof(FbxLight)},
            {"FbxNull", typeof(FbxNull)},
            {"FbxSkeleton", typeof(FbxSkeleton)},
            {"FbxPose", typeof(FbxPose)},
            {"FbxSubDeformer", typeof(FbxSubDeformer)},
            {"FbxCluster", typeof(FbxCluster)},
            {"FbxSurfaceMaterial", typeof(FbxSurfaceMaterial)},
            {"FbxSurfaceLambert", typeof(FbxSurfaceLambert)},
            {"FbxSurfacePhong", typeof(FbxSurfacePhong)},
            {"FbxTexture", typeof(FbxTexture)},
            {"FbxVideo", typeof(FbxVideo)},
        };

        private static Type GetTypeByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
            if (_typesByName.ContainsKey(name))
                return _typesByName[name];
            if (_typesByName.ContainsKey("Fbx" + name))
                return _typesByName["Fbx" + name];
            return null;
        }

        protected override void InternalExecute(Dictionary<string, object> args)
        {
            var obj = _cliState.Current;
            if (obj == null)
            {
                Console.WriteLine("Current object is <<null>>");
                return;
            }

            var target = (string) args.GetOrNull("target");

            /*
             * From | To | Count | result
             * ---------------------------
             *  N     N     N       0..N
             *  Y     N     N       F..N
             *  N     Y     N       0..T+1
             *  Y     Y     N       F..T+1
             *  N     N     Y       0..C
             *  Y     N     Y       F..F+C
             *  N     Y     Y       T-C+1..T+1
             *  Y     Y     Y       Must match, or ignore C
             *
             * Start Index
             *      !F    F
             *    +-----+---+
             * !T |  0  | F | !C
             *    +-----+---+
             * !T |  0  | F |  C
             *    +-----+---+
             *  T |T-C+1| * |  C
             *    +-----+---+
             *  T |  0  | F | !C
             *    +-----+---+
             *
             * End Index
             *     !F   F
             *    +---+---+
             * !T | N | N | !C
             *    +---+---+
             * !T | C |F+C|  C
             *    +---+---+
             *  T |T+1| * |  C
             *    +---+---+
             *  T |T+1|T+1| !C
             *    +---+---+
             */
            int? fromIndex = null;
            int? toIndex = null;
            int? indexCount = null;
            if (args.ContainsKey("from") && args["from"] != null)
                fromIndex = (int) args["from"];
            if (args.ContainsKey("to") && args["to"] != null)
                toIndex = (int) args["to"];
            if (args.ContainsKey("count") && args["count"] != null)
                indexCount = (int) args["count"];

            var typeName = (string) args.GetOrNull("type");
            if (typeName != null && GetTypeByName(typeName) == null)
                throw new ArgumentException($"Unknown type, {typeName}");

            int startIndex = 0;
            int endIndex = 0;

            void SetIndexes(int n)
            {
                if (fromIndex.HasValue)
                    startIndex = fromIndex.Value;
                else if (toIndex.HasValue && indexCount.HasValue)
                    startIndex = toIndex.Value - indexCount.Value + 1;

                if (startIndex < 0) startIndex = 0;
                if (startIndex > n) startIndex = n;

                if (toIndex.HasValue)
                    endIndex = toIndex.Value + 1;
                else if (!indexCount.HasValue)
                    endIndex = n;
                else if (fromIndex.HasValue)
                    endIndex = fromIndex.Value + indexCount.Value;
                else
                    endIndex = indexCount.Value;

                if (endIndex < 0) endIndex = 0;
                if (endIndex > n) endIndex = n;
            }

            var filterType = GetTypeByName(typeName);
            int N;
            int i;
            FbxProperty prop = null;
            switch (target)
            {
                case null:
                case "":
                    break;
                case "src":
                    N = obj.GetSrcObjectCount();
                    SetIndexes(N);
                    for (i = startIndex; i < endIndex; i++)
                    {
                        var srcObj = obj.GetSrcObject(i);
                        if (filterType != null &&
                            !filterType.IsInstanceOfType(srcObj))
                            continue;
                        var id = ObjectPrinter.PrintObjectID(srcObj);
                        Console.WriteLine($"        #{i} {id}");
                    }
                    break;
                case "dst":
                    N = obj.GetDstObjectCount();
                    SetIndexes(N);
                    for (i = startIndex; i < endIndex; i++)
                    {
                        var dstObj = obj.GetDstObject(i);
                        if (filterType != null &&
                            !filterType.IsInstanceOfType(dstObj))
                            continue;
                        var id = ObjectPrinter.PrintObjectID(dstObj);
                        Console.WriteLine($"        #{i} {id}");
                    }
                    break;
                case "prop":
                    N = CountProperties(obj);
                    SetIndexes(N);
                    for (i = startIndex; i < endIndex; i++)
                    {
                        prop = obj.GetPropertyByIndex(i);
                        var id = ObjectPrinter.PrintPropertyID(prop);
                        Console.WriteLine($"        #{i} {id}");
                    }
                    break;
                case "time":
                    var op = new ObjectPrinter();
                    prop = GetPropertyByIndex(obj, 4);
                    op.PrintProperty(prop, Console.Out, false);
                    var t = prop.Get<FbxTime>();
                    Console.WriteLine($"    Raw value:           {t.Get()}");
                    Console.WriteLine($"    Seconds:             {t.GetSecondDouble()}");
                    Console.WriteLine($"    Second count:        {t.GetSecondCount()}");
                    Console.WriteLine($"    Milliseconds:        {t.GetMilliSeconds()}");
                    Console.WriteLine($"    Frame count:         {t.GetFrameCount()}");
                    Console.WriteLine($"    Frame count precise: {t.GetFrameCountPrecise()}");
                    Console.WriteLine($"    Field count:         {t.GetFieldCount()}");
                    Console.WriteLine($"  Global time mode:      {FbxTime.GetGlobalTimeMode()}");
                    Console.WriteLine($"  FBXSDK_TC_MILLISECOND: {FbxTime.FBXSDK_TC_MILLISECOND}");
                    Console.WriteLine($"  FBXSDK_TC_SECOND:      {FbxTime.FBXSDK_TC_SECOND}");
                    break;
                case "sprop":
                    N = obj.GetSrcPropertyCount();
                    SetIndexes(N);
                    for (i = startIndex; i < endIndex; i++)
                    {
                        var sprop = obj.GetSrcProperty(i);
                        var id = ObjectPrinter.PrintPropertyID(sprop);
                        Console.WriteLine($"        #{i} {id}");
                    }
                    break;
                case "dprop":
                    N = obj.GetDstPropertyCount();
                    SetIndexes(N);
                    for (i = startIndex; i < endIndex; i++)
                    {
                        var sprop = obj.GetDstProperty(i);
                        var id = ObjectPrinter.PrintPropertyID(sprop);
                        Console.WriteLine($"        #{i} {id}");
                    }
                    break;
                default:
                    Console.WriteLine($"Unknown target \"{target}\"");
                    break;
            }

            Console.WriteLine($"SrcObjects: {obj.GetSrcObjectCount()} (src)");
            Console.WriteLine($"DstObjects: {obj.GetDstObjectCount()} (dst)");
            Console.WriteLine($"Properties: {CountProperties(obj)} (prop)");
            Console.WriteLine(
                $"SrcProperties: {obj.GetSrcPropertyCount()} (sprop)");
            Console.WriteLine(
                $"DstProperties: {obj.GetDstPropertyCount()} (dprop)");
        }

        public static int CountProperties(FbxObject obj)
        {
            var prop = obj.GetFirstProperty();
            int n = 0;
            while (prop != null && prop.IsValid())
            {
                n++;
                prop = obj.GetNextProperty(prop);
            }
            return n;
        }

        public static FbxProperty GetPropertyByIndex(FbxObject obj, int index)
        {
            var prop = obj.GetFirstProperty();
            var n = 0;
            while (prop != null && prop.IsValid())
            {
                if (n == index) return prop;
                n++;
                prop = obj.GetNextProperty(prop);
            }
            return null;  // TODO: empty prop struct, like C++ SDK ?
        }
    }
}