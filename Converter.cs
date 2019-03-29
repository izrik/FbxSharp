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
                        if (version.Value == 7300) converter = new Converter7300();
                        if (version.Value == 6100) converter = new Converter6100();

                        if (converter != null)
                        {
                            return converter.ConvertScene(parsedObjects);
                        }
                    }
                }
            }

            return new Converter7300().ConvertScene(parsedObjects);
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

