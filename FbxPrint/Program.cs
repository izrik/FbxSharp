using System;
using FbxSharp;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace FbxPrint
{
    class MainClass
    {
        public static void Main(string [] args)
        {
            if (args == null || args.Length < 1)
            {
                Console.Error.WriteLine("Usage: FbxPrint.exe FILENAME [ FILENAME ... ]");
                return;
            }

            foreach (var filename in args)
            {
                var importer = new FbxImporter(filename);
                var scene = importer.Import(filename);

                var printer = new FbxSharp.ObjectPrinter();
                printer.PrintObjectGraph(scene);
            }
        }
    }
}
