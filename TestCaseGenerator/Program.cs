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
            string type = string.Empty;

            if (args.Length > 0)
            {
                type = args[0];
            }
            else
            {
                //Console.Write("What output type? [cs]");
                //type = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(type))
                {
                    type = "cs";
                }
            }

            if (type != "cs" && type != "cpp")
            {
                Console.WriteLine("Unrecognized output type: {0}", type);
                return;
            }

            var fixtures = new List<TestFixture>();

            using (var reader = new StreamReader("test_cases.txt"))
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

            Console.WriteLine("using System;");
            Console.WriteLine("using NUnit.Framework;");
            Console.WriteLine("using FbxSharp;");
            Console.WriteLine();
            Console.WriteLine("namespace FbxSharpTests");
            Console.WriteLine("{");
            var fixturesStarted = false;
            foreach (var fixture in fixtures)
            {
                if (fixturesStarted) Console.WriteLine();
                Console.WriteLine("    [TestFixture]");
                Console.WriteLine("    public class {0}", fixture.Name);
                Console.WriteLine("    {");

                var casesStarted = false;
                foreach (var testcase in fixture.TestCases)
                {
                    if (casesStarted) Console.WriteLine();
                    Console.WriteLine("        [Test]");
                    Console.WriteLine("        public void {0}()", testcase.Name);
                    Console.WriteLine("        {");
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
                            for (; blanks > 0; blanks--) Console.WriteLine();
                        }
                        switch (stmt)
                        {
                        case "given":
                        case "require":
                        case "when":
                        case "then":
                            Console.WriteLine("            // {0}:", stmt);
                            break;
                        default:
                            var outline = stmt.Replace("AssertEqual", "Assert.AreEqual");
                            if (Regex.IsMatch(outline, @"\bnew\b"))
                            {
                                parts = outline.Split(new[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                                parts[3] = parts[3].Replace("new", "new " + parts[0]);
                                outline = string.Join(" ", parts);
                            }
                            parts = outline.Split(new[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                            if (parts.Count > 3 && parts[2] == "=")
                            {
                                parts[0] = "var";
                                outline = string.Join(" ", parts);
                            }
                            if (!string.IsNullOrWhiteSpace(outline))
                            {
                                Console.Write("            {0};", outline);
                                Console.WriteLine();
                            }
                            break;
                        }
                    }

                    Console.WriteLine("        }");
                    casesStarted = true;
                }

                Console.WriteLine("    }");
                fixturesStarted = true;
            }
            Console.WriteLine("}");

        }
    }
}
