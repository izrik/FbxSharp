using System;
using System.Linq;
using System.Collections.Generic;

namespace FbxSharp
{
    public class Converter
    {
        public FbxScene ConvertScene(List<ParseObject> parsedObjects)
        {
            var parsed = new ParseObject {
                Name = "Parsed Scene",
                Properties = parsedObjects,
            };

            var scene = new FbxScene();

            var docs = parsed.FindPropertyByName("Documents");
            CheckDocuments(docs);

            foreach (var doc in docs.Properties.Skip(1))
            {
                CheckDocument(doc);
            }


            var defs = parsed.FindPropertyByName("Definitions");
            CheckDefinitions(defs);

            // read and convert objects
            var objs = parsed.FindPropertyByName("Objects");
            var fbxObjects = new List<FbxObject>();
            var fbxObjectsById = new Dictionary<ulong, FbxObject>();
            var actualIdsByInFileIds = new Dictionary<ulong, ulong>();
            foreach (var obj in objs.Properties)
            {
                var fobj = ConvertObject(obj, fbxObjectsById, actualIdsByInFileIds);
                fbxObjects.Add(fobj);
                fbxObjectsById[fobj.UniqueId] = fobj;
            }

            // connect objects
            var conns = parsed.FindPropertyByName("Connections");
            CheckConnections(conns);
            foreach (var conn in conns.Properties)
            {
                CheckConnection(conn);
                var connType = ((string)conn.Values[0]);
                var inFileSrcId = (ulong)((Number)conn.Values[1]).AsLong.Value;
                var srcId = actualIdsByInFileIds[inFileSrcId];
                var inFileDstId = (ulong)((Number)conn.Values[2]).AsLong.Value;
                var dstId = (inFileDstId == 0 ? 0 : actualIdsByInFileIds[inFileDstId]);
                FbxObject dstObj;
                switch (connType)
                {
                case "OO":
                    dstObj = (dstId == 0 ? scene.RootNode : fbxObjectsById[dstId]);
                    dstObj.ConnectSrcObject(fbxObjectsById[srcId]);
                    break;
                case "OP":
                    string propertyName = ((string)conn.Values[3]);
                    dstObj = (dstId == 0 ? scene.RootNode : fbxObjectsById[dstId]);
                    var dstProp = dstObj.FindProperty(propertyName);
                    dstProp.ConnectSrcObject(fbxObjectsById[srcId]);
                    break;
                default:
                    throw new InvalidOperationException(string.Format("Unknown connection type: {0}", connType));
                }
            }

            // fix-up material layer elements
            foreach (var node in scene.Nodes)
            {
                if ((node.GetNodeAttribute() as FbxLayerContainer) == null) continue;

                var lc = (FbxLayerContainer)node.GetNodeAttribute();
                foreach (var layer in lc.Layers)
                {
                    var matelem = layer.GetMaterials();
                    if (matelem == null) continue;

                    foreach (var mi in matelem.MaterialIndexes.List)
                    {
                        var mat = node.Materials[mi];
                        matelem.GetDirectArray().Add(mat);
                    }
                }
            }

            // connect animation stacks
            foreach (var stack in fbxObjects)
            {
                scene.ConnectSrcObject(stack);
            }

            var takes = parsed.FindPropertyByName("Takes");
            CheckTakes(takes);

//            var notConnected = fbxObjects.Except(scene.SrcObjects).ToList();

            return scene;
        }

        void CheckDocuments(ParseObject docs)
        {
            if (docs.Properties[0].Name != "Count")
                throw new NotImplementedException();
            if (docs.Properties[0].Values.Count < 1)
                throw new NotImplementedException();
            var count = ((Number)docs.Properties[0].Values[0]).AsLong.Value;
            if (docs.Properties.Count != count + 1)
                throw new NotImplementedException();
        }

        void CheckDocument(ParseObject doc)
        {
        }

        void CheckDefinitions(ParseObject defs)
        {
            if (defs.Properties[0].Name != "Version")
                throw new NotImplementedException();
            if (defs.Properties[0].Values.Count < 1)
                throw new NotImplementedException();
            var version = ((Number)defs.Properties[0].Values[0]).AsLong.Value;

            if (defs.Properties[1].Name != "Count")
                throw new NotImplementedException();
            if (defs.Properties[1].Values.Count < 1)
                throw new NotImplementedException();
            var count = ((Number)defs.Properties[1].Values[0]).AsLong.Value;

//            if (defs.Properties.Count != count + 2)
//                throw new NotImplementedException();
        }

        Dictionary<string, Func<ParseObject, FbxObject>> ConvertersByObjectName =
            new Dictionary<string, Func<ParseObject, FbxObject>> {
                { "NodeAttribute", ConvertNodeAttribute },
                { "Geometry", ConvertGeometry },
                { "Model", ConvertNode }, // Node?
                { "Material", ConvertMaterial },
                { "Deformer", ConvertDeformer },
                { "Video", ConvertVideo },
                { "Texture", ConvertTexture },
                { "AnimationStack", ConvertAnimationStack },
                { "AnimationLayer", ConvertAnimationLayer },
                { "AnimationCurveNode", ConvertAnimationCurveNode },
                { "AnimationCurve", ConvertAnimationCurve },
            };

        public FbxObject ConvertObject(
            ParseObject obj,
            Dictionary<ulong, FbxObject> fbxObjectsById,
            Dictionary<ulong, ulong> actualIdsByInFileIds)
        {
            if (ConvertersByObjectName.ContainsKey(obj.Name))
            {
                var fbxobj = ConvertersByObjectName[obj.Name](obj);
                if (obj != null &&
                    obj.Values.Count > 0)
                {
                    var inFileId = (ulong)((Number)obj.Values[0]).AsLong.Value;
                    actualIdsByInFileIds[inFileId] = fbxobj.GetUniqueID();
                }
                return fbxobj;
            }

            if (obj.Name == "Pose")
            {
                var fbxobj = ConvertPose(obj, fbxObjectsById, actualIdsByInFileIds);
                if (obj != null &&
                    obj.Values.Count > 0)
                {
                    var inFileId = (ulong)((Number)obj.Values[0]).AsLong.Value;
                    actualIdsByInFileIds[inFileId] = fbxobj.GetUniqueID();
                }
                return fbxobj;
            }

            throw new InvalidOperationException(
                string.Format(
                    "Unknown object type: {0}",
                    obj.Name));
        }

        public static FbxNodeAttribute ConvertNodeAttribute(ParseObject obj)
        {
            var typeFlagsProp = obj.FindPropertyByName("TypeFlags");
            var typeFlags = new HashSet<string>(typeFlagsProp.Values.Select(x => (string)x));
            // null
            // root
            // skeleton
            if (typeFlags.Contains("Skeleton"))
            {
                return ConvertSkeleton(obj);
            }

            if (typeFlags.Contains("Null"))
            {
                return ConvertNull(obj);
            }

            if (typeFlags.Contains("Light"))
            {
                return ConvertLight(obj);
            }

            if (typeFlags.Contains("Camera"))
            {
                return ConvertCamera(obj);
            }

            throw new NotImplementedException();
        }

        public static FbxSkeleton ConvertSkeleton(ParseObject obj)
        {
            var skeleton = new FbxSkeleton();
            skeleton.Name = ((string)obj.Values[1]);
            skeleton.SkeletonType = (FbxSkeleton.EType)Enum.Parse(typeof(FbxSkeleton.EType), ((string)obj.Values[2]));

            var props70 = obj.FindPropertyByName("Properties70");
            if (props70 != null)
            {
                foreach (var p in props70.Properties)
                {
                    if (p.Name != "P") 
                        throw new NotImplementedException();

                    //P: "Size", "double", "Number", "",0.988142713904381
                    var propName = ((string)p.Values[0]);
                    var type1 = ((string)p.Values[1]);
                    var type2 = ((string)p.Values[2]);
                    var comment = ((string)p.Values[3]); // ???
                    object value;
                    if (type1 == "double")
                    {
                        value = ((Number)p.Values[4]).AsDouble.Value;
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }

                    switch (propName)
                    {
                    case "Size":
                        skeleton.Size.Value = (double)value;
                        break;
                    default:
                        throw new NotImplementedException();
                    }
                }
            }

            return skeleton;
        }

        public static FbxNull ConvertNull(ParseObject obj)
        {
            var n = new FbxNull();
            n.Name = ((string)obj.Values[1]);

            return n;
        }

        public static FbxLight ConvertLight(ParseObject obj)
        {
            var name = ((string)obj.Values[1]);
            var light = new FbxLight(name);

            foreach (var prop in obj.Properties)
            {
                switch (prop.Name)
                {
                case "Properties70":
                    ImportProperties(light, ConvertProperties70(prop));
                    break;
                case "TypeFlags":
                    if (((string)prop.Values[0]) != "Light")
                        throw new NotImplementedException();
                    break;
                case "GeometryVersion":
                    if (((Number)prop.Values[0]).AsLong.Value != 124)
                        throw new NotImplementedException();
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return light;
        }

        public static FbxCamera ConvertCamera(ParseObject obj)
        {
            var name = ((string)obj.Values[1]);
            var camera = new FbxCamera(name);

            FbxVector3 position;
            FbxVector3 up;
            FbxVector3 lookAt;
            bool showInfoOnMoving;
            bool showAudio;
            FbxVector3 audioColor;
            double cameraOrthoZoom;

            foreach (var prop in obj.Properties)
            {
                switch (prop.Name)
                {
                case "Properties70":
                    ImportProperties(camera, ConvertProperties70(prop));
                    break;
                case "TypeFlags":
                    if (((string)prop.Values[0]) != "Camera")
                        throw new NotImplementedException();
                    break;
                case "GeometryVersion":
                    if (((Number)prop.Values[0]).AsLong.Value != 124)
                        throw new NotImplementedException();
                    break;
                case "Position":
                    position = new FbxVector3(
                        ((Number)prop.Values[0]).AsDouble.Value,
                        ((Number)prop.Values[1]).AsDouble.Value,
                        ((Number)prop.Values[2]).AsDouble.Value);
                    break;
                case "Up":
                    up = new FbxVector3(
                        ((Number)prop.Values[0]).AsDouble.Value,
                        ((Number)prop.Values[1]).AsDouble.Value,
                        ((Number)prop.Values[2]).AsDouble.Value);
                    break;
                case "LookAt":
                    lookAt = new FbxVector3(
                        ((Number)prop.Values[0]).AsDouble.Value,
                        ((Number)prop.Values[1]).AsDouble.Value,
                        ((Number)prop.Values[2]).AsDouble.Value);
                    break;
                case "ShowInfoOnMoving":
                    showInfoOnMoving = (((Number)prop.Values[0]).AsLong.Value != 0);
                    break;
                case "ShowAudio":
                    showAudio = (((Number)prop.Values[0]).AsLong.Value != 0);
                    break;
                case "AudioColor":
                    audioColor = new FbxVector3(
                        ((Number)prop.Values[0]).AsDouble.Value,
                        ((Number)prop.Values[1]).AsDouble.Value,
                        ((Number)prop.Values[2]).AsDouble.Value);
                    break;
                case "CameraOrthoZoom":
                    cameraOrthoZoom = ((Number)prop.Values[0]).AsDouble.Value;
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return camera;
        }

        public static FbxGeometry ConvertGeometry(ParseObject obj)
        {
            var geometryType = ((string)obj.Values[2]);

            switch (geometryType)
            {
            case "Mesh":
                return ConvertMesh(obj);
            default:
                throw new NotImplementedException();
            }
        }

        static void ExpandListToMinimum<T>(List<T> list, int minIndex)
        {
            while (list.Count <= minIndex)
            {
                list.Add(default(T));
            }
        }

        public static FbxMesh ConvertMesh(ParseObject obj)
        {
            var normals = new List<FbxLayerElementNormal>();
            var uvs = new List<FbxLayerElementUV>();
            var visibility = new List<FbxLayerElementVisibility>();
            var materials = new List<FbxLayerElementMaterial>();

            var mesh = new FbxMesh();
            mesh.Name = ((string)obj.Values[1]);

            foreach (var prop in obj.Properties)
            {
                int index;
                switch (prop.Name)
                {
                case "Properties70":
                    ImportProperties(mesh, ConvertProperties70(prop));
                    break;
                case "Vertices":
                    ConvertVertices(mesh, prop);
                    break;
                case "PolygonVertexIndex":
                    mesh.PolygonIndexes = ConvertPolygonVertexIndex(prop);
                    break;
                case "Edges":
                    // skip for now
                    break;
                case "GeometryVersion":
                    if (((Number)prop.Values[0]).AsLong.Value != 124)
                        throw new NotImplementedException();
                    break;
                case "LayerElementNormal":
                    index = (int)(prop.Values.Count > 0 ? ((Number)prop.Values[0]).AsLong.Value : 0);
                    ExpandListToMinimum(normals, index);
                    normals[index] = ConvertLayerElementNormal(prop);
                    break;
                case "LayerElementUV":
                    index = (int)(prop.Values.Count > 0 ? ((Number)prop.Values[0]).AsLong.Value : 0);
                    ExpandListToMinimum(uvs, index);
                    uvs[index] = ConvertLayerElementUV(prop);
                    break;
                case "LayerElementVisibility":
                    index = (int)(prop.Values.Count > 0 ? ((Number)prop.Values[0]).AsLong.Value : 0);
                    ExpandListToMinimum(visibility, index);
                    visibility[index] = ConvertLayerElementVisibility(prop);
                    break;
                case "LayerElementMaterial":
                    index = (int)(prop.Values.Count > 0 ? ((Number)prop.Values[0]).AsLong.Value : 0);
                    ExpandListToMinimum(materials, index);
                    materials[index] = ConvertLayerElementMaterial(prop);
                    break;
                case "Layer":
                    var layer = mesh.GetLayer(mesh.CreateLayer());
                    ConvertLayer(layer, prop, normals, uvs, visibility, materials);
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return mesh;
        }

        static void ConvertLayer(FbxLayer layer, ParseObject obj, List<FbxLayerElementNormal> normals, List<FbxLayerElementUV> uvs, List<FbxLayerElementVisibility> visibility, List<FbxLayerElementMaterial> materials)
        {
            foreach (var prop in obj.Properties)
            {
                switch (prop.Name)
                {
                case "Version":
                    if (prop.Values.Count < 0)
                        throw new NotImplementedException();
                    if (((Number)prop.Values[0]).AsLong.Value != 100)
                        throw new NotImplementedException();
                    break;
                case "LayerElement":
                    var type = prop.FindPropertyByName("Type");
                    if (type == null)
                        throw new NotImplementedException();
                    var index = prop.FindPropertyByName("TypedIndex");
                    if (index == null)
                        throw new NotImplementedException();
                    var indexValue = (int)((Number)index.Values[0]).AsLong.Value;
                    switch ((string)type.Values[0])
                    {
                    case "LayerElementNormal":
                        layer.SetNormals(normals[indexValue]);
                        break;
                    case "LayerElementMaterial":
                        layer.SetMaterials(materials[indexValue]);
                        break;
                    case "LayerElementVisibility":
                        layer.SetVisibility(visibility[indexValue]);
                        break;
                    case "LayerElementUV":
                        layer.SetUVs(uvs[indexValue]);
                        break;
                    default:
                        throw new NotImplementedException();
                    }
                    break;
                default:
                    throw new NotImplementedException();
                }
            }
        }

        public static FbxLayerElementNormal ConvertLayerElementNormal(ParseObject obj)
        {
            var normals = new FbxLayerElementNormal();

            foreach (var prop in obj.Properties)
            {
                switch (prop.Name)
                {
                case "Version":
                    if (((Number)prop.Values[0]).AsLong.Value != 101)
                        throw new NotImplementedException();
                    break;
                case "Name":
                    normals.SetName((string)prop.Values[0]);
                    break;
                case "MappingInformationType":
                    normals.SetMappingMode(ConvertMappingInformationType(prop));
                    break;
                case "ReferenceInformationType":
                    normals.SetReferenceMode(ConvertReferenceInformationType(prop));
                    break;
                case "Normals":
                    normals.GetDirectArray().List.AddRange(
                        prop.Properties[0].Values
                        .Select(n => ((Number)n).AsDouble.Value)
                        .ToVector3List()
                        .Select(v => v.ToVector4()));
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return normals;
        }

        public static FbxLayerElementUV ConvertLayerElementUV(ParseObject obj)
        {
            var uvs = new FbxLayerElementUV();

            foreach (var prop in obj.Properties)
            {
                switch (prop.Name)
                {
                case "Version":
                    if (((Number)prop.Values[0]).AsLong.Value != 101)
                        throw new NotImplementedException();
                    break;
                case "Name":
                    uvs.Name = ((string)prop.Values[0]);
                    break;
                case "MappingInformationType":
                    uvs.MappingMode = ConvertMappingInformationType(prop);
                    break;
                case "ReferenceInformationType":
                    uvs.ReferenceMode = ConvertReferenceInformationType(prop);
                    break;
                case "UV":
                    uvs.GetDirectArray().List.AddRange(
                        prop.Properties[0].Values
                        .Select(n => ((Number)n).AsDouble.Value)
                        .ToVector2List());
                    break;
                case "UVIndex":
                    uvs.GetIndexArray().List.AddRange(
                        prop.Properties[0].Values
                        .Select(n => (int)((Number)n).AsLong.Value));
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return uvs;
        }

        public static FbxLayerElementVisibility ConvertLayerElementVisibility(ParseObject obj)
        {
            var visibility = new FbxLayerElementVisibility();

            foreach (var prop in obj.Properties)
            {
                switch (prop.Name)
                {
                case "Version":
                    if (((Number)prop.Values[0]).AsLong.Value != 101)
                        throw new NotImplementedException();
                    break;
                case "Name":
                    visibility.Name = ((string)prop.Values[0]);
                    break;
                case "MappingInformationType":
                    visibility.MappingMode = ConvertMappingInformationType(prop);
                    break;
                case "ReferenceInformationType":
                    visibility.ReferenceMode = ConvertReferenceInformationType(prop);
                    break;
                case "Visibility":
                    visibility.GetDirectArray().List.AddRange(prop.Properties[0].Values.Select(n => (((Number)n).AsLong.Value == 1)));
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return visibility;
        }

        public static FbxLayerElementMaterial ConvertLayerElementMaterial(ParseObject obj)
        {
            var material = new FbxLayerElementMaterial();

            foreach (var prop in obj.Properties)
            {
                switch (prop.Name)
                {
                case "Version":
                    if (((Number)prop.Values[0]).AsLong.Value != 101)
                        throw new NotImplementedException();
                    break;
                case "Name":
                    material.Name = ((string)prop.Values[0]);
                    break;
                case "MappingInformationType":
                    material.MappingMode = ConvertMappingInformationType(prop);
                    break;
                case "ReferenceInformationType":
                    material.ReferenceMode = ConvertReferenceInformationType(prop);
                    break;
                case "Materials":
                    material.MaterialIndexes.List.AddRange(
                        prop.Properties[0].Values.Select(n => (int)((Number)n).AsLong.Value));
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return material;
        }

        public static FbxLayerElement.EMappingMode ConvertMappingInformationType(ParseObject obj)
        {
            if (obj.Values.Count < 1)
                throw new NotImplementedException();
            switch ((string)obj.Values[0])
            {
            case "ByPolygonVertex":
                return FbxLayerElement.EMappingMode.ByPolygonVertex;
            case "ByPolygon":
                return FbxLayerElement.EMappingMode.ByPolygon;
            case "ByVertex":
                return FbxLayerElement.EMappingMode.ByPolygonVertex;
            case "ByEdge":
                return FbxLayerElement.EMappingMode.ByEdge;
            case "AllSame":
                return FbxLayerElement.EMappingMode.AllSame;
            default:
                throw new NotImplementedException();
            }
        }

        public static FbxLayerElement.EReferenceMode ConvertReferenceInformationType(ParseObject obj)
        {
            if (obj.Values.Count < 1)
                throw new NotImplementedException();
            switch ((string)obj.Values[0])
            {
            case "Direct":
                return FbxLayerElement.EReferenceMode.Direct;
            case "IndexToDirect":
                return FbxLayerElement.EReferenceMode.IndexToDirect;
            default:
                throw new NotImplementedException();
            }
        }

        public static List<Tuple<string, Type, object>> ConvertProperties70(ParseObject props70)
        {
            var propNamesTypesValues = new List<Tuple<string, Type, object>>();

            foreach (var p in props70.Properties)
            {
                if (p.Name != "P")
                    throw new NotImplementedException();

                // P: "Color", "ColorRGB", "Color", "",0.0313725490196078,0.0313725490196078,0.0313725490196078
                var propName = ((string)p.Values[0]);
                var type1 = ((string)p.Values[1]);
                var type2 = ((string)p.Values[2]);
                var comment = ((string)p.Values[3]); // ???

                Type propType;
                object propValue;

                switch (type1)
                {
                case "ColorRGB":
                case "Color":
                    var r = ((Number)p.Values[4]).AsDouble.Value;
                    var g = ((Number)p.Values[5]).AsDouble.Value;
                    var b = ((Number)p.Values[6]).AsDouble.Value;
                    propType = typeof(FbxColor);
                    propValue = new FbxColor(r, g, b);
                    break;
                case "Visibility":
                case "bool":
                    propType = typeof(bool);
                    propValue = (((Number)p.Values[4]).AsLong.Value != 0);
                    break;
                case "enum":
                    propType = typeof(long);
                    propValue = ((Number)p.Values[4]).AsLong.Value;
                    break;
                case "Vector":
                case "Vector3":
                case "Vector3D":
                    propType = typeof(FbxVector3);
                    var x = ((Number)p.Values[4]).AsDouble.Value;
                    var y = ((Number)p.Values[5]).AsDouble.Value;
                    var z = ((Number)p.Values[6]).AsDouble.Value;
                    propValue = new FbxVector3(x, y, z);
                    break;
                case "int":
                    propType = typeof(int);
                    propValue = (int)((Number)p.Values[4]).AsLong.Value;
                    break;
                case "Lcl Translation":
                case "Lcl Rotation":
                case "Lcl Scaling":
                    propType = typeof(FbxVector3);
                    x = ((Number)p.Values[4]).AsDouble.Value;
                    y = ((Number)p.Values[5]).AsDouble.Value;
                    z = ((Number)p.Values[6]).AsDouble.Value;
                    if (comment != "A+" && comment != "A")
                        throw new NotImplementedException();
                    propValue = new FbxVector3(x, y, z);
                    break;
                case "KString":
                    propType = typeof(string);
                    propValue = (string)p.Values[4];
                    break;
                case "FieldOfView":
                case "FieldOfViewX":
                case "FieldOfViewY":
                case "double":
                    propType = typeof(double);
                    propValue = ((Number)p.Values[4]).AsDouble.Value;
                    break;
                case "KTime":
                    propType = typeof(FbxTime);
                    propValue = new FbxTime(((Number)p.Values[4]).AsLong.Value);
                    break;
                case "Compound":
                    propType = typeof(string);
                    propValue = "";
                    break;
                case "Number":
                    if ((string)p.Values[3] != "A")
                        throw new InvalidOperationException();
                    propType = typeof(double);
                    propValue = ((Number)p.Values[4]).AsDouble.Value;
                    break;
                default:
                    throw new NotImplementedException("Unknown property type: " + type1);
                }

                propNamesTypesValues.Add(
                    new Tuple<string, Type, object>(
                        propName, propType, propValue));
            }

            return propNamesTypesValues;
        }

        public static void ConvertVertices(FbxMesh mesh, ParseObject obj)
        {
            var values = obj.Properties[0].Values;
            mesh.InitControlPoints(values.Count / 3);
            int i;
            for (i = 0; i+2 < values.Count; i+=3)
            {
                var v = new FbxVector4(
                        ((Number)values[i]).AsDouble.Value,
                        ((Number)values[i+1]).AsDouble.Value,
                        ((Number)values[i+2]).AsDouble.Value,
                        0);
                mesh.SetControlPointAt(v, i/3);
            }
        }

        public static List<List<long>> ConvertPolygonVertexIndex(ParseObject obj)
        {
            var values = obj.Properties[0].Values;
            int i;
            var polygons = new List<List<long>>();
            var current = new List<long>();
            foreach (var v in values)
            {
                var n = ((Number)v).AsLong.Value;
                current.Add(n < 0 ? -n - 1 : n);
                if (n < 0)
                {
                    polygons.Add(current);
                    current = new List<long>();
                }
            }
            if (current.Count > 0)
            {
                polygons.Add(current);
            }
            return polygons;
        }

        public static FbxNode ConvertNode(ParseObject obj)
        {
            var node = new FbxNode();

            if (obj.Values.Count < 3)
                throw new InvalidOperationException();
            if (obj.Values.Count > 3)
                throw new NotImplementedException();
            node.Name = ((string)obj.Values[1]);
            var type = ((string)obj.Values[2]);

            foreach (var prop in obj.Properties)
            {
                switch (prop.Name)
                {
                case "Version":
                    if (((Number)prop.Values[0]).AsLong.Value != 232)
                        throw new NotImplementedException();
                    break;
                case "Properties70":
                    ImportProperties(node, ConvertProperties70(prop));
                    break;
                case "MultiLayer":
                    node.MultiLayer = (((Number)prop.Values[0]).AsLong.Value != 0);
                    break;
                case "MultiTake":
                    node.MultiTake = (((Number)prop.Values[0]).AsLong.Value != 0);
                    break;
                case "Shading":
                    node.MultiTake = ((string)prop.Values[0] == "T");
                    break;
                case "Culling":
                    node.Culling = (string)prop.Values[0];
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return node;
        }

        public static void ImportProperty(FbxObject obj, string name, Type type, object value)
        {
            var pprop = obj.FindProperty(name, type);

            if (pprop == null)
            {
                pprop = obj.CreateProperty(name, type);
            }
            pprop.Set(value);
        }

        public static void ImportProperties(FbxObject obj, IEnumerable<Tuple<string, Type, object>> propinfos)
        {
            foreach (var propinfo in propinfos)
            {
                var pname = propinfo.Item1;
                var ptype = propinfo.Item2;
                var pvalue = propinfo.Item3;

                ImportProperty(obj, pname, ptype, pvalue);
            }
        }

        public static FbxPose ConvertPose(
            ParseObject obj,
            Dictionary<ulong, FbxObject> fbxObjectsById,
            Dictionary<ulong, ulong> actualIdsByInFileIds)
        {
            var pose = new FbxPose();

            if (obj.Values.Count < 3)
                throw new InvalidOperationException();
            if (obj.Values.Count > 3)
                throw new NotImplementedException();
            pose.Name = ((string)obj.Values[1]);
            var type = ((string)obj.Values[2]);

            long numPoseNodes = 0;

            foreach (var prop in obj.Properties)
            {
                switch (prop.Name)
                {
                case "Type":
                    if ((string)prop.Values[0] == "BindPose")
                    {
                        pose.SetIsBindPose(true);
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                    break;
                case "Version":
                    if (((Number)prop.Values[0]).AsLong.Value != 100)
                        throw new NotImplementedException();
                    break;
                case "NbPoseNodes":
                    numPoseNodes = ((Number)prop.Values[0]).AsLong.Value;
                    break;
                case "PoseNode":
                    var posenode = ConvertPoseNode(prop, fbxObjectsById, actualIdsByInFileIds);
                    pose.Add(posenode.Item1, posenode.Item2, posenode.Item3);
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            if (numPoseNodes != pose.GetCount())
                throw new InvalidOperationException();

            return pose;
        }

        public static Tuple<FbxNode, FbxMatrix, bool> ConvertPoseNode(
            ParseObject obj,
            Dictionary<ulong, FbxObject> fbxObjectsById,
            Dictionary<ulong, ulong> actualIdsByInFileIds)
        {
            if (obj.Properties.Count != 2)
                throw new NotImplementedException();

            var nodeIdProp = obj.FindPropertyByName("Node");
            if (nodeIdProp == null)
                throw new InvalidOperationException();
            var inFileNodeId = (ulong)((Number)nodeIdProp.Values[0]).AsLong.Value;
            var nodeId = actualIdsByInFileIds[inFileNodeId];
            var node = (FbxNode)fbxObjectsById[(ulong)nodeId];

            var matrixProp = obj.FindPropertyByName("Matrix");
            if (matrixProp == null)
                throw new InvalidOperationException();
            var matrix = ConvertMatrix(matrixProp);

            return new Tuple<FbxNode, FbxMatrix, bool>(node, matrix, false);
        }

        public static FbxMatrix ConvertMatrix(ParseObject obj)
        {
            if (obj.Properties.Count != 1)
                throw new InvalidOperationException();
            var values = obj.Properties[0].Values;
            if (values.Count != 16)
                throw new InvalidOperationException();

            var v = values.Select(n => ((Number)n).AsDouble.Value).ToArray();

            var m = new FbxMatrix(
                        v[0], v[1], v[2], v[3],
                        v[4], v[5], v[6], v[7],
                        v[8], v[9], v[10], v[11],
                        v[12], v[13], v[14], v[15]);
            return m;
        }

        public static FbxSurfaceMaterial ConvertMaterial(ParseObject obj)
        {
            var shadingModelProp = obj.FindPropertyByName("ShadingModel");
            if (shadingModelProp == null)
                throw new InvalidOperationException();

            var shadingModel = (string)shadingModelProp.Values[0];
            if (shadingModel != "phong")
                throw new NotImplementedException();

            return ConvertPhongMaterial(obj);
        }

        public static FbxSurfacePhong ConvertPhongMaterial(ParseObject obj)
        {
            var material = new FbxSurfacePhong();

            if (obj.Values.Count < 3)
                throw new InvalidOperationException();
            if (obj.Values.Count > 3)
                throw new NotImplementedException();
            material.Name = ((string)obj.Values[1]);
            var type = ((string)obj.Values[2]);

            foreach (var prop in obj.Properties)
            {
                switch (prop.Name)
                {
                case "Version":
                    if (((Number)prop.Values[0]).AsLong.Value != 102)
                        throw new NotImplementedException();
                    break;
                case "ShadingModel":
                    break;
                case "MultiLayer":
                    var multilayer = (((Number)prop.Values[0]).AsLong.Value != 0);
                    ImportProperty(material, "MultiLayer", typeof(bool), multilayer);
                    break;
                case "Properties70":
                    ImportProperties(material, ConvertProperties70(prop));
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return material;
        }

        public static FbxObject ConvertDeformer(ParseObject obj)
        {
            if (obj.Values.Count < 3)
                throw new InvalidOperationException();
            if (obj.Values.Count > 3)
                throw new NotImplementedException();
            var type = ((string)obj.Values[2]);

            switch (type)
            {
            case "Skin":
                return ConvertSkin(obj);
            case "Cluster":
                return ConvertCluster(obj);
            default:
                throw new NotImplementedException();
            }
        }

        public static FbxSkin ConvertSkin(ParseObject obj)
        {
            var skin = new FbxSkin();

            if (obj.Values.Count < 3)
                throw new InvalidOperationException();
            if (obj.Values.Count > 3)
                throw new NotImplementedException();
            skin.Name = ((string)obj.Values[1]);

            foreach (var prop in obj.Properties)
            {
                switch (prop.Name)
                {
                case "Version":
                    if (((Number)prop.Values[0]).AsLong.Value != 101)
                        throw new NotImplementedException();
                    break;
                case "Link_DeformAcuracy":
                    var accuracy = ((Number)prop.Values[0]).AsDouble.Value;
                    skin.DeformAccuracy = accuracy;
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return skin;
        }

        public static FbxCluster ConvertCluster(ParseObject obj)
        {
            var cluster = new FbxCluster();

            if (obj.Values.Count < 3)
                throw new InvalidOperationException();
            if (obj.Values.Count > 3)
                throw new NotImplementedException();
            cluster.Name = ((string)obj.Values[1]);

            bool hasIndexes = false;
            bool hasWeights = false;
            bool hasTransform = false;
            bool hasTransformLink = false;

            foreach (var prop in obj.Properties)
            {
                switch (prop.Name)
                {
                case "Version":
                    if (((Number)prop.Values[0]).AsLong.Value != 100)
                        throw new NotImplementedException();
                    break;
                case "UserData":
                    break;
                case "Indexes":
                    cluster.ControlPointIndices.AddRange(
                        prop.Properties[0].Values.Select(n => (int)((Number)n).AsLong.Value));
                    hasIndexes = true;
                    break;
                case "Weights":
                    cluster.ControlPointWeights.AddRange(
                        prop.Properties[0].Values.Select(n => ((Number)n).AsDouble.Value));
                    hasWeights = true;
                    break;
                case "Transform":
                    cluster.Transform = ConvertMatrix(prop);
                    hasTransform = true;
                    break;
                case "TransformLink":
                    cluster.TransformLink = ConvertMatrix(prop);
                    hasTransformLink = true;
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return cluster;
        }

        public static FbxVideo ConvertVideo(ParseObject obj)
        {
            var video = new FbxVideo();

            if (obj.Values.Count < 3)
                throw new InvalidOperationException();
            if (obj.Values.Count > 3)
                throw new NotImplementedException();
            video.Name = ((string)obj.Values[1]);
            var type = ((string)obj.Values[2]);

            foreach (var prop in obj.Properties)
            {
                switch (prop.Name)
                {
                case "Type":
                    video.Type = (string)prop.Values[0];
                    break;
                case "Properties70":
                    ImportProperties(video, ConvertProperties70(prop));
                    break;
                case "UseMipMap":
                    video.UseMipMap = (((Number)prop.Values[0]).AsLong.Value != 0);
                    break;
                case "Filename":
                    video.Filename = (string)prop.Values[0];
                    break;
                case "RelativeFilename":
                    video.RelativeFilename = (string)prop.Values[0];
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return video;
        }

        public static FbxTexture ConvertTexture(ParseObject obj)
        {
            var texture = new FbxTexture();

            if (obj.Values.Count < 3)
                throw new InvalidOperationException();
            if (obj.Values.Count > 3)
                throw new NotImplementedException();
            texture.Name = ((string)obj.Values[1]);
            var type = ((string)obj.Values[2]);

            foreach (var prop in obj.Properties)
            {
                switch (prop.Name)
                {
                case "Type":
                    texture.Type = (string)prop.Values[0];
                    break;
                case "Version":
                    if (((Number)prop.Values[0]).AsLong.Value != 202)
                        throw new NotImplementedException();
                    break;
                case "TextureName":
                    var name = (string)prop.Values[0];
                    if (name != texture.Name)
                        throw new InvalidOperationException();
                    break;
                case "Properties70":
                    ImportProperties(texture, ConvertProperties70(prop));
                    break;
                case "Media":
                    texture.Media = (string)prop.Values[0];
                    break;
                case "Filename":
                case "FileName":
                    texture.Filename = (string)prop.Values[0];
                    break;
                case "RelativeFilename":
                    texture.RelativeFilename = (string)prop.Values[0];
                    break;
                case "ModelUVTranslation":
                    texture.ModelUVTranslation = ConvertVector2(prop.Values);
                    break;
                case "ModelUVScaling":
                    texture.ModelUVScaling = ConvertVector2(prop.Values);
                    break;
                case "Texture_Alpha_Source":
                    texture.AlphaSource = (FbxTexture.EAlphaSource)Enum.Parse(typeof(FbxTexture.EAlphaSource), (string)prop.Values[0]);
                    break;
                case "Cropping":
                    texture.Cropping = ConvertVector4(prop.Values);
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return texture;
        }

        public static FbxVector2 ConvertVector2(List<object> values, int startIndex=0)
        {
            return
                new FbxVector2(
                    ((Number)values[startIndex]).AsDouble.Value,
                    ((Number)values[startIndex + 1]).AsDouble.Value);
        }

        public static FbxVector3 ConvertVector3(List<object> values, int startIndex=0)
        {
            return
                new FbxVector3(
                    ((Number)values[startIndex]).AsDouble.Value,
                    ((Number)values[startIndex + 1]).AsDouble.Value,
                    ((Number)values[startIndex + 2]).AsDouble.Value);
        }

        public static FbxVector4 ConvertVector4(List<object> values, int startIndex=0)
        {
            return
                new FbxVector4(
                    ((Number)values[startIndex]).AsDouble.Value,
                    ((Number)values[startIndex + 1]).AsDouble.Value,
                    ((Number)values[startIndex + 2]).AsDouble.Value,
                    ((Number)values[startIndex + 3]).AsDouble.Value);
        }

        public static FbxAnimStack ConvertAnimationStack(ParseObject obj)
        {
            var animstack = new FbxAnimStack();

            if (obj.Values.Count < 3)
                throw new InvalidOperationException();
            if (obj.Values.Count > 3)
                throw new NotImplementedException();
            animstack.Name = ((string)obj.Values[1]);
            var type = ((string)obj.Values[2]);

            foreach (var prop in obj.Properties)
            {
                switch (prop.Name)
                {
                case "Properties70":
                    ImportProperties(animstack, ConvertProperties70(prop));
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return animstack;
        }

        public static FbxAnimLayer ConvertAnimationLayer(ParseObject obj)
        {
            var animlayer = new FbxAnimLayer();

            if (obj.Values.Count < 3)
                throw new InvalidOperationException();
            if (obj.Values.Count > 3)
                throw new NotImplementedException();
            animlayer.Name = ((string)obj.Values[1]);
            var type = ((string)obj.Values[2]);

            if (obj.Properties.Count > 0)
                throw new NotImplementedException();

            return animlayer;
        }

        public static FbxAnimCurveNode ConvertAnimationCurveNode(ParseObject obj)
        {
            var animCurveNode = new FbxAnimCurveNode();

            if (obj.Values.Count < 3)
                throw new InvalidOperationException();
            if (obj.Values.Count > 3)
                throw new NotImplementedException();
            animCurveNode.Name = ((string)obj.Values[1]);
            var type = ((string)obj.Values[2]);

            foreach (var prop in obj.Properties)
            {
                switch (prop.Name)
                {
                case "Properties70":
                    var propinfos = ConvertProperties70(prop);
                    foreach (var propinfo in propinfos)
                    {
                        var pname = propinfo.Item1;
                        var ptype = propinfo.Item2;
                        var pvalue = propinfo.Item3;

                        if (pname == "d")
                        {
                        }
                        else if (pname.StartsWith("d|"))
                        {
                            var genMethod = typeof(FbxAnimCurveNode).GetMethod("AddChannel");
                            var typedMethod = genMethod.MakeGenericMethod(ptype);
                            typedMethod.Invoke(animCurveNode, new object[]{pname, pvalue});
                            //animCurveNode.AddChannel<ptype>(pname, pvalue)
                        }
                        else
                        {
                            ImportProperty(animCurveNode, pname, ptype, pvalue);
                        }
                    }
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return animCurveNode;
        }

        public static FbxAnimCurve ConvertAnimationCurve(ParseObject obj)
        {
            var curve = new FbxAnimCurve();

            if (obj.Values.Count < 3)
                throw new InvalidOperationException();
            if (obj.Values.Count > 3)
                throw new NotImplementedException();
            curve.Name = ((string)obj.Values[1]);
            var type = ((string)obj.Values[2]);

            long[] keyTimes = null;
            double[] keyValues = null;
            long[] attrFlags = null;
            long[] attrData = null;
            long[] attrRefCounts = null;

            foreach (var prop in obj.Properties)
            {
                switch (prop.Name)
                {
                case "Default":
                    var defaultValue = ((Number)prop.Values[0]).AsDouble.Value;
                    break;
                case "KeyVer":
                    long keyVersion = ((Number)prop.Values[0]).AsLong.Value;
                    if (keyVersion != 4008 && keyVersion != 4009)
                        throw new NotImplementedException();
                    break;
                case "KeyTime":
                    keyTimes = prop.Properties[0].Values.Select(n => ((Number)n).AsLong.Value).ToArray();
                    break;
                case "KeyValueFloat":
                    keyValues = prop.Properties[0].Values.Select(n => ((Number)n).AsDouble.Value).ToArray();
                    break;
                case "KeyAttrFlags":
                    attrFlags = prop.Properties[0].Values.Select(n => ((Number)n).AsLong.Value).ToArray();
                    break;
                case "KeyAttrDataFloat":
                    attrData = prop.Properties[0].Values.Select(n => ((Number)n).AsLong.Value).ToArray();
                    break;
                case "KeyAttrRefCount":
                    attrRefCounts = prop.Properties[0].Values.Select(n => ((Number)n).AsLong.Value).ToArray();
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            var keys = new FbxAnimCurveKey[Math.Min(keyTimes.Length, keyValues.Length)];
            int i;
            for (i = 0; i < Math.Min(keyTimes.Length, keyValues.Length); i++)
            {
                var time = new FbxTime(keyTimes[i]);
                keys[i] = new FbxAnimCurveKey(time, (float)keyValues[i]);
            }


            int k = 0;
            int m = 0;
            foreach (var attrCount in attrRefCounts)
            {
                long data0 = attrData[4 * m + 0];
                long data1 = attrData[4 * m + 1];
                long data2 = attrData[4 * m + 2];
                long data3 = attrData[4 * m + 3];
                long flags = attrFlags[m];

                var tangentMode = (FbxAnimCurveDef.ETangentMode)(flags & 0x00007f00);
                tangentMode = tangentMode & ~FbxAnimCurveDef.ETangentMode.eTangentGenericTimeIndependent;
                var interpolation = (FbxAnimCurveDef.EInterpolationType)(flags & 0x0000000e);
                var weight = (FbxAnimCurveDef.EWeightedMode)(flags & 0x03000000);
                var constant = (FbxAnimCurveDef.EConstantMode)(flags & 0x00000100);
                var velocity = (FbxAnimCurveDef.EVelocityMode)(flags & 0x30000000);
                var visibility = (FbxAnimCurveDef.ETangentVisibility)(flags & 0x00300000);

                for (i = 0; i < attrCount; i++, k++)
                {
                    var key = keys[k];
                    key.SetTangentMode(tangentMode);
                    key.SetInterpolation(interpolation);
                    key.SetTangentWeightMode(weight);
                    key.SetConstantMode(constant);
                    key.SetTangentVelocityMode(velocity);
                    key.SetTangentVisibility(visibility);
                    key.SetTangentWeightAndAdjustTangent(FbxAnimCurveDef.EDataIndex.eRightWeight, (data2 & 0x0000ffff) / 9999.0);
                    key.SetTangentWeightAndAdjustTangent(FbxAnimCurveDef.EDataIndex.eNextLeftWeight, ((data2 >> 16) & 0xffff) / 9999.0);
//                    key.SetDataFloat(AnimCurveDef.EDataIndex.eRightSlope, data0);
//                    key.SetDataFloat(AnimCurveDef.EDataIndex.eRightSlope, data1);
//                    key.SetDataFloat(AnimCurveDef.EDataIndex.eRightSlope, data2);
//                    key.SetDataFloat(AnimCurveDef.EDataIndex.eRightSlope, data3);
                }

                m++;
            }

            foreach (var key in keys)
            {
                curve.KeyAdd(key.GetTime(), key);
            }

            return curve;
        }

        void CheckConnections(ParseObject conns)
        {
        }

        void CheckConnection(ParseObject conn)
        {
        }

        void CheckTakes(ParseObject takes)
        {
        }
    }
}

