using System;
using FbxSharp;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;

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

            bool tokens = false;
            bool parse = false;
            foreach (var filename in args)
            {
                if (filename == "--tokens")
                {
                    tokens = true;
                    continue;
                }
                if (filename == "--parse")
                {
                    parse = true;
                    continue;
                }

                if (tokens)
                {
                    using (var reader = new StreamReader(filename))
                    {
                        var t = new Tokenizer(reader, filename: filename);
                        var token = t.GetNextToken();
                        while (token.HasValue)
                        {
                            var tt = token.Value;
                            Console.WriteLine("\"{0}\", {1}, {2}", tt.Value, tt.Type, tt.Location);
                            token = t.GetNextToken();
                        }
                    }
                    continue;
                }
                if (parse)
                {
                    using (var reader = new StreamReader(filename))
                    {
                        var p = new Parser(new Tokenizer(reader, filename:filename));
                        var objs = p.ReadFile();
                        foreach (var obj in objs)
                        {
                            PrintParseObject(obj);
                        }
                    }
                    continue;
                }
                var importer = new FbxImporter(filename);
                var scene = importer.Import(filename);

                var printer = new FbxSharp.ObjectPrinter();
                printer.PrintObjectGraph(scene);
            }
        }
        public static void PrintParseObject(ParseObject obj, string indent="")
        {
            if (obj == null)
            {
                Console.WriteLine("{0}null", indent);
                return;
            }
            Console.WriteLine("{2}\"{0}\" {1}", obj.Name, obj.Location, indent);
            Console.WriteLine("{0}Values:", indent);
            foreach (var value in obj.Values)
            {
                Console.WriteLine("{1}{0}", value, indent);
            }
            if (obj.Properties == null)
            {
                Console.WriteLine("{0}Properties: null", indent);
            }
            else
            {
                Console.WriteLine("{0}Properties:", indent);
                foreach (var prop in obj.Properties)
                {
                    PrintParseObject(prop, indent + "  ");
                }
                Console.WriteLine();
            }
        }
    }
}
