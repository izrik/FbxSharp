using System;
using System.Linq;
using System.Collections.Generic;
using ChamberLib;

namespace FbxSharp
{
    public class Converter
    {
        public Scene ConvertScene(List<ParseObject> parsedObjects)
        {
            var parsed = new ParseObject {
                Name = "Parsed Scene",
                Properties = parsedObjects,
            };
            var docs = parsed.FindPropertyByName("Documents");
            CheckDocuments(docs);

            foreach (var doc in docs.Properties.Skip(1))
            {
                CheckDocument(doc);
            }


            var defs = parsed.FindPropertyByName("Definitions");
            CheckDefinitions(defs);

            var objs = parsed.FindPropertyByName("Objects");
            var fbxObjects = new List<FbxObject>();
            var fbxObjectsById = new Dictionary<ulong, FbxObject>();
            foreach (var obj in objs.Properties)
            {
                var fobj = ConvertObject(obj, fbxObjectsById);
                fbxObjects.Add(fobj);
                fbxObjectsById[fobj.UniqueId] = fobj;
            }

            var conns = parsed.FindPropertyByName("Connections");
            CheckConnections(conns);
            foreach (var conn in conns.Properties)
            {
                CheckConnection(conn);
                long fromId;
                long toId;
                var connType = ((string)conn.Values[0]);
                fromId = ((Number)conn.Values[1]).AsLong.Value;
                toId = ((Number)conn.Values[2]).AsLong.Value;
                switch (connType)
                {
                case "OO":
//                    fbxObjectsById[fromId].AddConnectionTo(fbxObjectsById[toId]);
                    throw new NotImplementedException();
                    break;
                case "OP":
                    string propertyName = ((string)conn.Values[3]);
//                    fbxObjectsById[fromId].AddConnectionTo(fbxObjectsById[toId].GetPropertyByName(propertyName));
                    throw new NotImplementedException();
                    break;
                default:
                    throw new InvalidOperationException(string.Format("Unknown connection type: {0}", connType));
                }
            }

            var takes = parsed.FindPropertyByName("Takes");
            CheckTakes(takes);

            throw new NotImplementedException();
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

        public FbxObject ConvertObject(ParseObject obj, Dictionary<ulong, FbxObject> fbxObjectsById)
        {
            if (ConvertersByObjectName.ContainsKey(obj.Name))
            {
                return ConvertersByObjectName[obj.Name](obj);
            }

            if (obj.Name == "Pose")
            {
                return ConvertPose(obj, fbxObjectsById);
            }

            throw new InvalidOperationException(
                string.Format(
                    "Unknown object type: {0}",
                    obj.Name));
        }

        public static NodeAttribute ConvertNodeAttribute(ParseObject obj)
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

            throw new NotImplementedException();
        }

        public static Skeleton ConvertSkeleton(ParseObject obj)
        {
            var skeleton = new Skeleton();
            skeleton.UniqueId = (ulong)((Number)obj.Values[0]).AsLong.Value;
            skeleton.Name = ((string)obj.Values[1]);
            skeleton.SkeletonType = (Skeleton.EType)Enum.Parse(typeof(Skeleton.EType), ((string)obj.Values[2]));

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

        public static Null ConvertNull(ParseObject obj)
        {
            var n = new Null();
            n.UniqueId = (ulong)((Number)obj.Values[0]).AsLong.Value;
            n.Name = ((string)obj.Values[1]);

            return n;
        }

        public static Geometry ConvertGeometry(ParseObject obj)
        {
            var geometryType = ((string)obj.Values[2]);

            switch (geometryType)
            {
            case "Mesh":
                return ConvertMesh(obj);
                break;
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

        public static Mesh ConvertMesh(ParseObject obj)
        {
            var normals = new List<LayerElementNormal>();
            var uvs = new List<LayerElementUV>();
            var visibility = new List<LayerElementVisibility>();
            var materials = new List<LayerElementMaterial>();

            var mesh = new Mesh();
            mesh.UniqueId = (ulong)((Number)obj.Values[0]).AsLong.Value;
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
                    mesh.VertexPositions = ConvertVertices(prop);
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
                    mesh.Layers.Add(ConvertLayer(prop, normals, uvs, visibility, materials));
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return mesh;
        }

        static Layer ConvertLayer(ParseObject obj, List<LayerElementNormal> normals, List<LayerElementUV> uvs, List<LayerElementVisibility> visibility, List<LayerElementMaterial> materials)
        {
            var layer = new Layer();

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
                    LayerElement layerElement;
                    switch ((string)type.Values[0])
                    {
                    case "LayerElementNormal":
                        layerElement = normals[indexValue];
                        break;
                    case "LayerElementMaterial":
                        layerElement = materials[indexValue];
                        break;
                    case "LayerElementVisibility":
                        layerElement = visibility[indexValue];
                        break;
                    case "LayerElementUV":
                        layerElement = uvs[indexValue];
                        break;
                    default:
                        throw new NotImplementedException();
                    }
                    layer.LayerElements.Add(layerElement);
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return layer;
        }

        public static LayerElementNormal ConvertLayerElementNormal(ParseObject obj)
        {
            var normals = new LayerElementNormal();

            foreach (var prop in obj.Properties)
            {
                switch (prop.Name)
                {
                case "Version":
                    if (((Number)prop.Values[0]).AsLong.Value != 101)
                        throw new NotImplementedException();
                    break;
                case "Name":
                    normals.Name = ((string)prop.Values[0]);
                    break;
                case "MappingInformationType":
                    normals.MappingMode = ConvertMappingInformationType(prop);
                    break;
                case "ReferenceInformationType":
                    normals.ReferenceMode = ConvertReferenceInformationType(prop);
                    break;
                case "Normals":
                    normals.Values = prop.Properties[0].Values.Select(n => ((Number)n).AsDouble.Value).ToList();
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return normals;
        }

        public static LayerElementUV ConvertLayerElementUV(ParseObject obj)
        {
            var uvs = new LayerElementUV();

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
                    uvs.Values = prop.Properties[0].Values.Select(n => ((Number)n).AsDouble.Value).ToList();
                    break;
                case "UVIndex":
                    uvs.UVIndex = prop.Properties[0].Values.Select(n => ((Number)n).AsLong.Value).ToList();
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return uvs;
        }

        public static LayerElementVisibility ConvertLayerElementVisibility(ParseObject obj)
        {
            var visibility = new LayerElementVisibility();

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
                    visibility.Values = prop.Properties[0].Values.Select(n => (((Number)n).AsLong.Value == 1)).ToList();
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return visibility;
        }

        public static LayerElementMaterial ConvertLayerElementMaterial(ParseObject obj)
        {
            var material = new LayerElementMaterial();

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
                    //material.Values = prop.Properties[0].Values.Select(n => (((Number)n).AsLong.Value == 1)).ToList();
                    material.MaterialIndexes = prop.Properties[0].Values.Select(n => ((Number)n).AsLong.Value).ToList();
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            return material;
        }

        public static LayerElement.EMappingMode ConvertMappingInformationType(ParseObject obj)
        {
            if (obj.Values.Count < 1)
                throw new NotImplementedException();
            switch ((string)obj.Values[0])
            {
            case "ByPolygonVertex":
                return LayerElement.EMappingMode.ByPolygonVertex;
            case "ByPolygon":
                return LayerElement.EMappingMode.ByPolygon;
            case "ByVertex":
                return LayerElement.EMappingMode.ByPolygonVertex;
            case "ByEdge":
                return LayerElement.EMappingMode.ByEdge;
            case "AllSame":
                return LayerElement.EMappingMode.AllSame;
            default:
                throw new NotImplementedException();
            }
        }

        public static LayerElement.EReferenceMode ConvertReferenceInformationType(ParseObject obj)
        {
            if (obj.Values.Count < 1)
                throw new NotImplementedException();
            switch ((string)obj.Values[0])
            {
            case "Direct":
                return LayerElement.EReferenceMode.Direct;
            case "IndexToDirect":
                return LayerElement.EReferenceMode.IndexToDirect;
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
                    var r = ((Number)p.Values[4]).AsDouble.Value;
                    var g = ((Number)p.Values[5]).AsDouble.Value;
                    var b = ((Number)p.Values[6]).AsDouble.Value;
                    propType = typeof(Color);
                    propValue = new Color(new Vector3((float)r, (float)g, (float)b));
                    break;
                case "bool":
                    propType = typeof(bool);
                    propValue = (((Number)p.Values[4]).AsLong.Value != 0);
                    break;
                case "enum":
                    propType = typeof(long);
                    propValue = ((Number)p.Values[4]).AsLong.Value;
                    break;
                case "Vector3D":
                    propType = typeof(Vector3);
                    var x = ((Number)p.Values[4]).AsDouble.Value;
                    var y = ((Number)p.Values[5]).AsDouble.Value;
                    var z = ((Number)p.Values[6]).AsDouble.Value;
                    propValue = new Vector3((float)x, (float)y, (float)z);
                    break;
                case "int":
                    propType = typeof(int);
                    propValue = (int)((Number)p.Values[4]).AsLong.Value;
                    break;
                case "Lcl Translation":
                case "Lcl Rotation":
                case "Lcl Scaling":
                    propType = typeof(Vector3);
                    x = ((Number)p.Values[4]).AsDouble.Value;
                    y = ((Number)p.Values[5]).AsDouble.Value;
                    z = ((Number)p.Values[6]).AsDouble.Value;
                    if (comment != "A+" && comment != "A")
                        throw new NotImplementedException();
                    propValue = new Vector3((float)x, (float)y, (float)z);
                    break;
                case "KString":
                    propType = typeof(string);
                    propValue = (string)p.Values[4];
                    break;
                case "double":
                    propType = typeof(double);
                    propValue = ((Number)p.Values[4]).AsDouble.Value;
                    break;
                default:
                    throw new NotImplementedException();
                }

                propNamesTypesValues.Add(
                    new Tuple<string, Type, object>(
                        propName, propType, propValue));
            }

            return propNamesTypesValues;
        }

        public static List<Vector3> ConvertVertices(ParseObject obj)
        {
            int i;
            var vectors = new List<Vector3>();
            for (i = 0; i+2 < obj.Values.Count; i+=3)
            {
                vectors.Add(
                    new Vector3(
                        (float)((Number)obj.Values[i]).AsDouble.Value,
                        (float)((Number)obj.Values[i+1]).AsDouble.Value,
                        (float)((Number)obj.Values[i+2]).AsDouble.Value));
            }
            return vectors;
        }

        public static List<List<long>> ConvertPolygonVertexIndex(ParseObject obj)
        {
            int i;
            var polygons = new List<List<long>>();
            var current = new List<long>();
            foreach (var v in obj.Values)
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

        public static Node ConvertNode(ParseObject obj)
        {
            var node = new Node();

            if (obj.Values.Count < 3)
                throw new InvalidOperationException();
            if (obj.Values.Count > 3)
                throw new NotImplementedException();
            node.UniqueId = (ulong)((Number)obj.Values[0]).AsLong.Value;
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

        public static Pose ConvertPose(ParseObject obj, Dictionary<ulong, FbxObject> fbxObjectsById)
        {
            var pose = new Pose();

            if (obj.Values.Count < 3)
                throw new InvalidOperationException();
            if (obj.Values.Count > 3)
                throw new NotImplementedException();
            pose.UniqueId = (ulong)((Number)obj.Values[0]).AsLong.Value;
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
                        pose.IsBindPose = true;
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
                    var posenode = ConvertPoseNode(prop, fbxObjectsById);
                    pose.PoseNodes.Add(posenode);
                    break;
                default:
                    throw new NotImplementedException();
                }
            }

            if (numPoseNodes != pose.PoseNodes.Count)
                throw new InvalidOperationException();

            return pose;
        }

        public static Pose.PoseNode ConvertPoseNode(ParseObject obj, Dictionary<ulong, FbxObject> fbxObjectsById)
        {
            if (obj.Properties.Count != 2)
                throw new NotImplementedException();

            var nodeIdProp = obj.FindPropertyByName("Node");
            if (nodeIdProp == null)
                throw new InvalidOperationException();
            var nodeId = ((Number)nodeIdProp.Values[0]).AsLong.Value;
            var node = (Node)fbxObjectsById[(ulong)nodeId];

            var matrixProp = obj.FindPropertyByName("Matrix");
            if (matrixProp == null)
                throw new InvalidOperationException();
            var matrix = ConvertMatrix(matrixProp);

            return new Pose.PoseNode(node, matrix);
        }

        public static Matrix ConvertMatrix(ParseObject obj)
        {
            if (obj.Properties.Count != 1)
                throw new InvalidOperationException();
            var values = obj.Properties[0].Values;
            if (values.Count != 16)
                throw new InvalidOperationException();

            var v = values.Select(n => (float)(((Number)n).AsDouble.Value)).ToArray();

            var m = new Matrix(
                        v[0], v[1], v[2], v[3],
                        v[4], v[5], v[6], v[7],
                        v[8], v[9], v[10], v[11],
                        v[12], v[13], v[14], v[15]);
            return m;
        }

        public static SurfaceMaterial ConvertMaterial(ParseObject obj)
        {
            var shadingModelProp = obj.FindPropertyByName("ShadingModel");
            if (shadingModelProp == null)
                throw new InvalidOperationException();

            var shadingModel = (string)shadingModelProp.Values[0];
            if (shadingModel != "phong")
                throw new NotImplementedException();

            return ConvertPhongMaterial(obj);
        }

        public static SurfacePhong ConvertPhongMaterial(ParseObject obj)
        {
            var material = new SurfacePhong();

            if (obj.Values.Count < 3)
                throw new InvalidOperationException();
            if (obj.Values.Count > 3)
                throw new NotImplementedException();
            material.UniqueId = (ulong)((Number)obj.Values[0]).AsLong.Value;
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

        public static Skin ConvertSkin(ParseObject obj)
        {
            var skin = new Skin();

            if (obj.Values.Count < 3)
                throw new InvalidOperationException();
            if (obj.Values.Count > 3)
                throw new NotImplementedException();
            skin.UniqueId = (ulong)((Number)obj.Values[0]).AsLong.Value;
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

        public static Cluster ConvertCluster(ParseObject obj)
        {
            var cluster = new Cluster();

            if (obj.Values.Count < 3)
                throw new InvalidOperationException();
            if (obj.Values.Count > 3)
                throw new NotImplementedException();
            cluster.UniqueId = (ulong)((Number)obj.Values[0]).AsLong.Value;
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
                    cluster.Indexes = prop.Properties[0].Values.Select(n => ((Number)n).AsLong.Value).ToList();
                    hasIndexes = true;
                    break;
                case "Weights":
                    cluster.Weights = prop.Properties[0].Values.Select(n => ((Number)n).AsDouble.Value).ToList();
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

            if (!hasIndexes ||
                !hasWeights ||
                !hasTransform ||
                !hasTransformLink)
            {
                throw new InvalidOperationException();
            }

            return cluster;
        }

        public static Video ConvertVideo(ParseObject obj)
        {
            var video = new Video();

            if (obj.Values.Count < 3)
                throw new InvalidOperationException();
            if (obj.Values.Count > 3)
                throw new NotImplementedException();
            video.UniqueId = (ulong)((Number)obj.Values[0]).AsLong.Value;
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

        public static Texture ConvertTexture(ParseObject obj)
        {
            var texture = new Texture();

            if (obj.Values.Count < 3)
                throw new InvalidOperationException();
            if (obj.Values.Count > 3)
                throw new NotImplementedException();
            texture.UniqueId = (ulong)((Number)obj.Values[0]).AsLong.Value;
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
                    texture.AlphaSource = (Texture.EAlphaSource)Enum.Parse(typeof(Texture.EAlphaSource), (string)prop.Values[0]);
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

        public static Vector2 ConvertVector2(List<object> values, int startIndex=0)
        {
            return
                new Vector2(
                    (float)((Number)values[startIndex]).AsDouble.Value,
                    (float)((Number)values[startIndex + 1]).AsDouble.Value);
        }

        public static Vector3 ConvertVector3(List<object> values, int startIndex=0)
        {
            return
                new Vector3(
                    (float)((Number)values[startIndex]).AsDouble.Value,
                    (float)((Number)values[startIndex + 1]).AsDouble.Value,
                    (float)((Number)values[startIndex + 2]).AsDouble.Value);
        }

        public static Vector4 ConvertVector4(List<object> values, int startIndex=0)
        {
            return
                new Vector4(
                    (float)((Number)values[startIndex]).AsDouble.Value,
                    (float)((Number)values[startIndex + 1]).AsDouble.Value,
                    (float)((Number)values[startIndex + 2]).AsDouble.Value,
                    (float)((Number)values[startIndex + 3]).AsDouble.Value);
        }

        public static NodeAttribute ConvertAnimationStack(ParseObject obj)
        {
            throw new NotImplementedException();
        }

        public static NodeAttribute ConvertAnimationLayer(ParseObject obj)
        {
            throw new NotImplementedException();
        }

        public static NodeAttribute ConvertAnimationCurveNode(ParseObject obj)
        {
            throw new NotImplementedException();
        }

        public static NodeAttribute ConvertAnimationCurve(ParseObject obj)
        {
            throw new NotImplementedException();
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

