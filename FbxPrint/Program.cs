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

//                var acs1 = scene.SrcObjects.Where(x => x is AnimCurve).ToList();
//                var acs2 = acs1.Cast<AnimCurve>().ToList();
//                var ordered = acs2.OrderBy(x => x.GetUniqueID()).ToList();
//                var acs = ordered.ToList();
//                foreach (var srcobj in acs)
//                {
//                    var ac = srcobj as AnimCurve;
//                    if (ac != null)
//                    {
//    //                    ObjectPrinter.PrintObject(ac);
//    //                    Console.WriteLine(ObjectPrinter.PrintObjectID(ac));
//                        ObjectPrinter.PrintAnimCurve(ac);
//                        Console.WriteLine();
//     //                    break;
//                    }
//                }

                var printer = new FbxSharp.ObjectPrinter();
                printer.PrintObjectGraph(scene);
            }
        }
    }
}
