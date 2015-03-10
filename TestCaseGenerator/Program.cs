using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace TestCaseGenerator
{
    class MainClass
    {
        public static void Main(string [] args)
        {
            string language = string.Empty;

            if (args.Length > 0)
            {
                language = args[0];
            }
            else
            {
                //Console.Write("What output type? [cs]");
                //type = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(language))
                {
                    language = "cs";
                }
            }

            if (language != "cs" && language != "cpp")
            {
                Console.WriteLine("Unrecognized output type: {0}", language);
                return;
            }

            string outputType = (args.Length > 1 ? args[1] : "-");

            var inputs = args.Skip(2).ToList();
            if (inputs.Count < 1) inputs.Add("test_cases.txt");

            foreach (var input in inputs)
            {
                var fixtures = new List<TestFixture>();


                using (var reader = new StreamReader(input))
                {
                    TestFixture currentFixture = null;
                    TestCase currentTest = null;


                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            currentTest.Statements.Add(string.Empty);
                            continue;
                        }

                        var trimmed = line.Trim();
                        var parts = trimmed.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        string name;
                        switch (parts[0].ToLower())
                        {
                        case "fixture":
                            name = parts[1];
                            currentFixture = new TestFixture { Name = name };
                            fixtures.Add(currentFixture);
                            break;
                        case "test":
                            name = parts[1];
                            currentTest = new TestCase { Name = name };
                            currentFixture.TestCases.Add(currentTest);
                            break;
                        case "given":
                        case "require":
                        case "when":
                        case "then":
                            currentTest.Statements.Add(parts[0].ToLower());
                            break;
                        default:
                            currentTest.Statements.Add(trimmed);
                            break;
                        }
                    }
                }

                using (var writer = 
                    outputType == "-" ? 
                        Console.Out :
                        new StreamWriter(input + "." + language))
                {
                    if (language == "cs")
                    {
                        GenerateCs(fixtures, writer);
                    }
                    else
                    {
                        GenerateCpp(fixtures, writer);
                    }
                }
            }
        }

        static void GenerateCs(List<TestFixture> fixtures, TextWriter writer)
        {
            writer.WriteLine("using System;");
            writer.WriteLine("using NUnit.Framework;");
            writer.WriteLine("using FbxSharp;");
            writer.WriteLine();
            writer.WriteLine("namespace FbxSharpTests");
            writer.WriteLine("{");
            var fixturesStarted = false;
            foreach (var fixture in fixtures)
            {
                if (fixturesStarted)
                    writer.WriteLine();
                writer.WriteLine("    [TestFixture]");
                writer.WriteLine("    public class {0}", fixture.Name);
                writer.WriteLine("    {");
                var casesStarted = false;
                foreach (var testcase in fixture.TestCases)
                {
                    if (casesStarted)
                        writer.WriteLine();
                    writer.WriteLine("        [Test]");
                    writer.WriteLine("        public void {0}()", testcase.Name);
                    writer.WriteLine("        {");
                    int blanks = 0;
                    List<String> parts;
                    foreach (var stmt in testcase.Statements)
                    {
                        if (string.IsNullOrWhiteSpace(stmt))
                        {
                            blanks++;
                        }
                        else
                        {
                            for (; blanks > 0; blanks--)
                                writer.WriteLine();
                        }
                        switch (stmt)
                        {
                        case "given":
                        case "require":
                        case "when":
                        case "then":
                            writer.WriteLine("            // {0}:", stmt);
                            break;
                        default:
                            var outline = stmt.Replace("AssertEqual", "Assert.AreEqual");

                            outline = outline.Replace("&", "");

                            if (Regex.IsMatch(outline, @"\bnew\b"))
                            {
                                parts = outline.Split(new[] {
                                    ' '
                                }, StringSplitOptions.RemoveEmptyEntries).ToList();
                                parts[3] = parts[3].Replace("new", "new " + parts[0]);
                                outline = string.Join(" ", parts);
                            }

                            parts = outline.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
                            if (parts.Count > 3 && parts[2] == "=")
                            {
                                parts[0] = "var";
                                outline = string.Join(" ", parts);
                            }

                            if (!string.IsNullOrWhiteSpace(outline))
                            {
                                writer.Write("            {0};", outline);
                                writer.WriteLine();
                            }
                            break;
                        }
                    }
                    writer.WriteLine("        }");
                    casesStarted = true;
                }
                writer.WriteLine("    }");
                fixturesStarted = true;
            }
            writer.WriteLine("}");
            writer.Flush();
        }

        static void GenerateCpp(List<TestFixture> fixtures, TextWriter writer)
        {
            writer.WriteLine();
            writer.WriteLine("#include \"common.h\"");
            writer.WriteLine();
            writer.WriteLine("using namespace std;");
            foreach (var fixture in fixtures)
            {
                foreach (var testcase in fixture.TestCases)
                {
                    writer.WriteLine();
                    writer.WriteLine("void {0}()", testcase.Name);
                    writer.WriteLine("{");
                    int blanks = 0;
                    List<String> parts;
                    foreach (var stmt in testcase.Statements)
                    {
                        if (string.IsNullOrWhiteSpace(stmt))
                        {
                            blanks++;
                        }
                        else
                        {
                            for (; blanks > 0; blanks--)
                                writer.WriteLine();
                        }
                        switch (stmt)
                        {
                        case "given":
                            writer.WriteLine("    // {0}:", stmt);
                            writer.WriteLine("    FbxManager* manager = FbxManager::Create();");
                            break;
                        case "require":
                        case "when":
                        case "then":
                            writer.WriteLine("    // {0}:", stmt);
                            break;
                        default:
                            var outline = stmt;

                            parts = outline.Split(' ').ToList();
                            if (parts.Count > 3 && 
                                parts[2] == "=" &&
                                !parts[0].StartsWith("Fbx"))
                            {
                                parts[0] = "Fbx" + parts[0];
                                outline = string.Join(" ", parts);
                            }

                            if (Regex.IsMatch(outline, @"\bnew\b"))
                            {
                                parts = outline.Split(new[] {
                                    ' '
                                }, StringSplitOptions.RemoveEmptyEntries).ToList();
                                parts[3] = parts[3].Replace("new(", parts[0] + "::Create(manager, ");
                                outline = string.Join(" ", parts);
                            }

                            parts = outline.Split(' ').ToList();
                            if (parts.Count > 3 && parts[2] == "=")
                            {
                                parts[0] += "*";
                                outline = string.Join(" ", parts);
                            }

                            if (Regex.IsMatch(outline, @"[\w)]\.\w"))
                            {
                                outline = 
                                    Regex.Replace(
                                        outline,
                                        @"([\w\)])\.(\w)",
                                        m => m.Groups[1].Value + "->" + m.Groups[2].Value);
                            }

                            if (Regex.IsMatch(outline, @"\bnull\b"))
                            {
                                outline = Regex.Replace(outline, @"\bnull\b", "NULL");
                            }

                            if (!string.IsNullOrWhiteSpace(outline))
                            {
                                writer.Write("    {0};", outline);
                                writer.WriteLine();
                            }
                            break;
                        }
                    }
                    writer.WriteLine("}");
                }

                writer.WriteLine();
                writer.WriteLine("void {0}::RegisterTestCases()", fixture.Name);
                writer.WriteLine("{");
                foreach (var testcase in fixture.TestCases)
                {
                    writer.WriteLine("    AddTestCase({0});", testcase.Name);
                }
                writer.WriteLine("}");
                writer.WriteLine();
            }
            writer.Flush();
        }
    }
}
