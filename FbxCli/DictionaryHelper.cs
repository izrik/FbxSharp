using System;
using System.Collections.Generic;

namespace FbxCli
{
    public static class DictionaryHelper
    {
        public static T GetOrNull<T>(this Dictionary<string, T> dict,
            string key)
            where T : class
        {
            if (!dict.ContainsKey(key)) return null;
            return dict[key];
        }

        public static int? GetIntOrNull(
            this Dictionary<string, object> dict, string key)
        {
            if (!dict.ContainsKey(key)) return null;
            return (int) dict[key];
        }

        public static bool? GetBoolOrNull(
            this Dictionary<string, object> dict, string key)
        {
            if (!dict.ContainsKey(key)) return null;
            return (bool) dict[key];
        }
    }
}
