using System;
using System.Linq;
using System.Collections.Generic;

namespace FbxSharp
{
    public class Converter
    {
        public FbxScene ConvertScene(List<ParseObject> parsedObjects)
        {
            var header = GetHeader(parsedObjects);
            if (header != null)
            {
                var headerVersion = GetHeaderVersion(header);
                if (headerVersion == 1003)
                {
                    var version = GetVersion(header);
                    if (version.HasValue)
                    {
                        IConverter converter = null;
                        if (version.Value == 2000) converter = new Converter2000();
                        if (version.Value == 2001) converter = new Converter2001();
                        if (version.Value == 3000) converter = new Converter3000();
                        if (version.Value == 3001) converter = new Converter3001();
                        if (version.Value == 4000) converter = new Converter4000();
                        if (version.Value == 4001) converter = new Converter4001();
                        if (version.Value == 4050) converter = new Converter4050();
                        if (version.Value == 5000) converter = new Converter5000();
                        if (version.Value == 5800) converter = new Converter5800();
                        if (version.Value == 6000) converter = new Converter6000();
                        if (version.Value == 6100) converter = new Converter6100();
                        if (version.Value == 7000) converter = new Converter7000();
                        if (version.Value == 7099) converter = new Converter7099();
                        if (version.Value == 7100) converter = new Converter7100();
                        if (version.Value == 7200) converter = new Converter7200();
                        if (version.Value == 7300) converter = new Converter7300();
                        if (version.Value == 7400) converter = new Converter7400();
                        if (version.Value == 7500) converter = new Converter7500();
                        if (version.Value == 7600) converter = new Converter7600();
                        if (version.Value == 7700) converter = new Converter7700();


                        if (converter != null)
                        {
                            return converter.ConvertScene(parsedObjects);
                        }
                    }
                }
            }

            return new Converter7700().ConvertScene(parsedObjects);
        }

        protected ParseObject GetHeader(List<ParseObject> parsedObjects)
        {
            return parsedObjects.First(h => h.Name == "FBXHeaderExtension");
        }

        protected long? GetHeaderVersion(ParseObject header)
        {
            var hv = header.FindPropertyByName("FBXHeaderVersion");
            if (hv == null) return null;
            if (hv.Values.Count < 1) return null;
            if (!(hv.Values[0] is Number)) return null;
            return ((Number)hv.Values[0]).AsLong;
        }

        protected long? GetVersion(ParseObject header)
        {
            var v = header.FindPropertyByName("FBXVersion");
            if (v == null) return null;
            if (v.Values.Count < 1) return null;
            if (!(v.Values[0] is Number)) return null;
            return ((Number)v.Values[0]).AsLong;
        }
    }
}

