using System;
using System.IO;
using FbxSharp;
using NUnit.Framework;

namespace FbxSharpTests
{
    public class TestBase
    {
        public static int CountProperties(FbxObject obj)
        {
            return obj.Properties.Count;
        }

        public static string GetRootFolder()
        {
            var folder = TestContext.CurrentContext.TestDirectory;
            int i;
            for (i = 0; i < 100; i++)
            {
                if (Path.GetFileName(folder) == "FbxSharp") return folder;
                if (folder.Length < 3) return null;
                if (folder[1..] == ":\\") return null;
                if (folder == "/") return null;
                folder = Path.GetDirectoryName(folder);
            }

            throw new NotImplementedException();
        }

        public static string GetSamplesFolder()
        {
            var root = GetRootFolder();
            if (root == null)
                throw new NotImplementedException();
            return Path.Combine(root, "samples");
        }

        public static string GetSample(string name) =>
            Path.Combine(GetSamplesFolder(), name);
    }
}
