using System;
using System.Collections.Generic;
using System.IO;
using FbxSharp;
using NCommander;

namespace FbxCli
{
    internal class PrintCommand : Command
    {
        public static readonly PrintCommand Value = new PrintCommand();

        private PrintCommand()
        {
            Name = "print";
            Description = "Print the internal structure of one or more FBX " +
                          "files";
            Params = new[]
            {
                new Parameter
                {
                    Name = "filenames",
                    Description = "One or more files to print",
                    ParameterType = ParameterType.StringArray,
                }
            };
            Options = new[]
            {
                new Option
                {
                    Name = "tokens",
                    Description =
                        "Print the tokens in the file, instead of the " +
                        "FBX object graph",
                    Type = ParameterType.Flag
                },
                new Option
                {
                    Name = "parse",
                    Description = "Print the parse objects (key-value " +
                                  "pairs and other info, without FBX " +
                                  "type info), instead of the FBX " +
                                  "object graph",
                    Type = ParameterType.Flag
                }
            };
        }

        protected override void InternalExecute(Dictionary<string, object> args)
        {
            var tokens = (bool) args["tokens"];
            var parse = (bool) args["parse"];
            var filenames = (string[]) args["filenames"];
            foreach (var filename in filenames)
            {
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

        public static void PrintParseObject(ParseObject obj, string indent = "")
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
