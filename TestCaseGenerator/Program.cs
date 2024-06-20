using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Reflection;
using NCommander;

namespace TestCaseGenerator
{
    class MainClass
    {
        public static void Main(string [] args)
        {
            var commander = new Commander("TestCaseGenerator", GetVersionStringFromAssembly());

            var forceOption = new Option()
            {
                Name = "force",
                Description =
                    "Generate a test file even if it already exists and is " +
                    "newer than the source .tc file",
                Type = ParameterType.Flag,
            };
            var verboseOption = new Option()
            {
                Name = "verbose",
                Description =
                    "Print additional information during execution",
                Type = ParameterType.Flag,
            };

            var csCmd = CreateCommand(
                "cs", "Generate C# tests", GenerateCs,
                options: new[] { forceOption, verboseOption });
            commander.Commands.Add("cs", csCmd);

            var cppCmd = CreateCommand(
                "cpp", "Generate C++ tests", GenerateCpp,
                options: new[] { forceOption, verboseOption });
            commander.Commands.Add("cpp", cppCmd);

            try
            {
                if (args.Length < 1)
                {
                    commander.ShowUsage();
                }
                else if (args.Length > 0 && args[0] == "--version")
                {
                    commander.ShowVersion();
                }
                else
                {
                    try
                    {
                        commander.ProcessArgs(args);
                    }
                    catch (NCommanderException ex)
                    {
                        Console.WriteLine("Error: {0}", ex.Message);
                    }
                    catch(System.UnauthorizedAccessException ex)
                    {
                        Console.WriteLine("Error: {0}", ex.Message);
                    }
                    catch (System.IO.IOException ex)
                    {
                        Console.WriteLine("Error: {0}", ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write("There was an internal error:");
                Console.WriteLine(ex.ToString());
            }
        }

        public static string GetVersionStringFromAssembly()
        {
            var version = Assembly.GetCallingAssembly().GetName().Version;
            return version.ToString(version.Major == 0 ? 2 : 3);
        }

        static Command CreateCommand(string name, string description,
            Action<TestFile, TextWriter> generator,
            IEnumerable<Parameter> extraParams = null,
            IEnumerable<Option> options = null)
        {
            var paramlist = new List<Parameter> {
                new Parameter {
                    Name = "input-filename",
                    ParameterType = ParameterType.String,
                },
                new Parameter {
                    Name = "output-filename",
                    ParameterType = ParameterType.String,
                    IsOptional = true,
                }
            };
            if (extraParams != null)
                paramlist.AddRange(extraParams);
            var optionArray = Array.Empty<Option>();
            if (options != null)
                optionArray = options.ToArray();

            var cmd = new Command {
                Name = name,
                Description = description,
                Params = paramlist.ToArray(),
                Options = optionArray,
                ExecuteDelegate = args => {
                    ExecuteDelegate(args, generator, name);
                },
            };

            return cmd;
        }

        static void ExecuteDelegate(Dictionary<string, object> args,
            Action<TestFile, TextWriter> generator, string language)
        {
            var input = (string)args["input-filename"];
            var testFile = new TestFile();
            bool force = args.ContainsKey("force") && (bool)args["force"];
            bool verbose = args.ContainsKey("verbose") &&
                           (bool)args["verbose"];
            bool isStdout = !args.ContainsKey("output-filename") ||
                            args["output-filename"] == null;
            string outputFilename = null;
            if (!isStdout)
                outputFilename = (string)args["output-filename"];

            if (!isStdout)
            {
                var inmod = File.GetLastWriteTime(input);
                var outmod = File.GetLastWriteTime(outputFilename);
                if (outmod > inmod)
                {
                    if (force)
                    {
                        if (verbose)
                            Console.WriteLine(
                                $"Forced overwrite even though " +
                                $"{outputFilename} is newer than {input}");
                    }
                    else
                    {
                        if (verbose)
                            Console.WriteLine(
                                $"{outputFilename} is newer than {input}, " +
                                $"skipping...");
                        return;
                    }
                }
            }

            using (var reader = new StreamReader(input))
            {
                TestFixture currentFixture = null;
                TestCase currentTest = null;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        if (currentTest != null)
                            currentTest.Statements.Add(string.Empty);
                        continue;
                    }

                    var trimmed = line.Trim();
                    if (trimmed == "#use constraints")
                    {
                        if (currentTest != null)
                            currentTest.UseConstraints = true;
                        else if (currentFixture != null)
                            currentFixture.UseConstraints = true;
                        else
                            testFile.UseConstraints = true;
                        continue;
                    }

                    var parts = trimmed.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts[0].StartsWith("#"))
                    {
                        var targets = parts[0].Substring(1).Split(',');
                        if (!targets.Contains(language))
                        {
                            continue;
                        }

                        trimmed = trimmed.Replace(parts[0], string.Empty).Trim();
                        parts = trimmed.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    }
                    else if (parts[0].StartsWith("//"))
                    {
                        continue;
                    }

                    string name;
                    switch (parts[0].ToLower())
                    {
                        case "fixture":
                            name = parts[1];
                            currentFixture = new TestFixture { Name = name };
                            testFile.TestFixtures.Add(currentFixture);
                            break;
                        case "test":
                            name = parts[1];
                            if (currentFixture == null)
                                throw new InvalidOperationException(
                                    "Test defined outside of a fixture");
                            currentTest = new TestCase(name);
                            currentFixture.TestCases.Add(currentTest);
                            break;
                        case "given":
                        case "require":
                        case "when":
                        case "then":
                        case "expect":
                            if (currentTest!=null)
                                currentTest.Statements.Add(parts[0].ToLower());
                            break;
                        default:
                            if (currentTest != null)
                                currentTest.Statements.Add(trimmed);
                            else if (currentFixture != null)
                                currentFixture.Epilogue.Add(trimmed);
                            else
                                testFile.Prologue.Add(trimmed);
                            break;
                    }
                }
            }

            using (var writer = 
                   (isStdout ?
                       Console.Out :
                       new StreamWriter(outputFilename)))
            {
                generator(testFile, writer);
            }
        }

        static void GenerateCs(TestFile testFile, TextWriter writer)
        {
            foreach (var line in testFile.Prologue)
                writer.WriteLine(line);
            writer.WriteLine("using System;");
            writer.WriteLine("using NUnit.Framework;");
            writer.WriteLine("using FbxSharp;");
            writer.WriteLine();
            writer.WriteLine("namespace FbxSharpTests");
            writer.WriteLine("{");
            var fixturesStarted = false;
            foreach (var fixture in testFile.TestFixtures)
            {
                if (fixturesStarted)
                    writer.WriteLine();
                writer.WriteLine("    [TestFixture]");
                writer.WriteLine("    public class {0} : TestBase", fixture.Name);
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
                    var lineno = 0;
                    foreach (var stmt in testcase.Statements)
                    {
                        lineno++;
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
                        case "expect":
                            writer.WriteLine("            // {0}:", stmt);
                            break;
                        default:
                            var outline = stmt;
                            if ((testFile.UseConstraints ||
                                 fixture.UseConstraints ||
                                 testcase.UseConstraints) &&
                                outline.StartsWith("Assert"))
                            {
                                var outline2 = outline[12..^1];
                                var parts1 = outline2.Split(",");
                                var new_rhs = string.Join(",", parts1[..^1]).Trim();
                                var new_lhs = parts1[^1].Trim();
                                if (outline.StartsWith("AssertEqual"))
                                {
                                    outline = string.Format(
                                        "Assert.That({0}, Is.EqualTo({1}))",
                                        new_lhs, new_rhs);
                                }
                                else if (outline.StartsWith("AssertNotEqual"))
                                {
                                    outline = string.Format(
                                        "Assert.That({0}, Is.Not.EqualTo({1}))",
                                        new_lhs, new_rhs);
                                }
                                else if (outline.StartsWith("AssertSame"))
                                {
                                    outline = string.Format(
                                        "Assert.That({0}, Is.SameAs({1}))",
                                        new_lhs, new_rhs);
                                }
                                else
                                {
                                    outline = Regex.Replace(outline,
                                        @"Assert(\w)",
                                        m => "Assert." + m.Groups[1].Value);
                                }
                            }
                            else
                            {
                                outline = outline.Replace("AssertEqual", "Assert.AreEqual");
                                outline = outline.Replace("AssertNotEqual", "Assert.AreNotEqual");
                                outline = outline.Replace("AssertSame", "Assert.AreSame");
                                outline = Regex.Replace(outline, @"Assert(\w)", m => "Assert." + m.Groups[1].Value);
                            }

                            outline = outline.Replace("&", "");
                            outline =
                                Regex.Replace(
                                    outline,
                                    @"([\w])\*(\s)",
                                    m => m.Groups[1].Value + m.Groups[2].Value);
                            outline =
                                Regex.Replace(
                                    outline,
                                    @"(\s)\*([\w>])",
                                    m => m.Groups[1].Value + m.Groups[2].Value);
                            outline =
                                Regex.Replace(
                                    outline,
                                    @"([\w()])\*([\w>])",
                                    m => m.Groups[1].Value + m.Groups[2].Value);
                            outline = outline.Replace("::", ".");
                            outline = outline.Replace(":\\:", "::");

                            outline = Regex.Replace(outline, @"\bFbx\$", "");

                            outline = Regex.Replace(outline, @"\b(\d+L)L\b", m => m.Groups[1].Value);

                            if (Regex.IsMatch(outline, @"^\w+\s*\*\s*\w+$"))
                            {
                                outline = outline.Replace('*', ' ');
                            }

                            if (Regex.IsMatch(outline, @"new&"))
                            {
                                outline = outline.Replace("new&", "new");
                            }
                            else if (Regex.IsMatch(outline, @"\bnew\b"))
                            {
                                parts = outline.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                                parts[0] = parts[0].Replace("!", "");
                                var targetTypeName = parts[0];
                                if (targetTypeName == "FbxLayerContainer" ||
                                    targetTypeName == "FbxGeometryBase" ||
                                    targetTypeName == "FbxGeometry")
                                {
                                    targetTypeName = "FbxMesh";
                                }
                                if (targetTypeName == "FbxAMatrix" ||
                                    targetTypeName == "FbxMatrix" ||
                                    targetTypeName == "FbxAMatrix")
                                {
                                    targetTypeName = "FbxMatrix";
                                }

                                if (parts.Count > 3)
                                    parts[3] = parts[3].Replace("new",
                                        "new " + targetTypeName);
                                outline = string.Join(" ", parts);
                            }

                            parts = outline.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                            if (parts.Count == 2)
                            {
                                var targetTypeName = parts[0];
                                if (targetTypeName == "FbxAMatrix" ||
                                    targetTypeName == "FbxMatrix" ||
                                    targetTypeName == "FbxAMatrix")
                                {
                                    targetTypeName = "FbxMatrix";
                                }
                                if (targetTypeName == "FbxArray<FbxString*>" ||
                                    targetTypeName == "FbxArray<FbxString>")
                                {
                                    targetTypeName = "string[]";
                                }

                                parts[0] = targetTypeName;
                                outline = string.Join(" ", parts);
                            }
                            else if (parts.Count > 3 && parts[2] == "=")
                            {
                                parts[0] = "var";
                                outline = string.Join(" ", parts);
                            }

                            if (Regex.IsMatch(outline, @"\bFbxVector(\d)\("))
                            {
                                outline =
                                    Regex.Replace(
                                        outline,
                                        @"\bFbxVector(\d)\(",
                                        m => "new FbxVector" + m.Groups[1].Value + "(");
                            }

                            outline = outline.Replace("Get<FbxString>()",
                                "Get<string>()");

                            outline = outline.Replace("GetType()",
                                "GetFbxType()");

                            if (Regex.IsMatch(outline, @"\bNULL\b"))
                            {
                                outline = Regex.Replace(outline, @"\bNULL\b", "null");
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
                foreach (var line in fixture.Epilogue)
                    writer.WriteLine(line);
                writer.WriteLine("    }");
                fixturesStarted = true;
            }
            writer.WriteLine("}");
            writer.Flush();
        }

        static void GenerateCpp(TestFile testFile, TextWriter writer)
        {
            foreach (var line in testFile.Prologue)
                writer.WriteLine(line);
            writer.WriteLine();
            writer.WriteLine("#include \"Tests.h\"");
            writer.WriteLine();
            writer.WriteLine("using namespace std;");
            foreach (var fixture in testFile.TestFixtures)
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
                        case "expect":
                            writer.WriteLine("    // {0}:", stmt);
                            break;
                        default:
                            var outline = stmt;

                            outline = outline.Replace("AssertSame", "AssertEqual");
                            outline = outline.Replace(":\\:", "::");

                            parts = outline.Split(' ').ToList();
                            if ((parts.Count > 3 && parts[2] == "=" && !parts[0].StartsWith("Fbx")) ||
                                (parts.Count == 2 && Regex.IsMatch(parts[0], @"^\w+$") && Regex.IsMatch(parts[1], @"^\w+$") && !parts[0].StartsWith("Fbx")))
                            {
                                if (char.IsUpper(parts[0][0]))
                                {
                                    parts[0] = "Fbx" + parts[0];
                                    outline = string.Join(" ", parts);
                                }
                            }

                            if (Regex.IsMatch(outline, @"\bnew\b"))
                            {
                                parts = outline.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                                var isStackValue = parts[0].EndsWith("!");
                                var equalsIndex = parts.IndexOf("=");
                                string type;
                                if (equalsIndex == 1)
                                {
                                    // var = new...
                                    var m = Regex.Match(parts[3], @"^(\w+)");
                                    type = m.Captures[0].Value;
                                }
                                else if (equalsIndex == 2)
                                {
                                    // Type var = new...
                                    type = parts[0].Replace("!", "");
                                }
                                else
                                {
                                    type = "";
                                }


                                if (type == "AnimCurveKey" ||
                                    type == "Vector2" ||
                                    type == "Vector3" ||
                                    type == "Vector4" ||
                                    type == "Double2" ||
                                    type == "Double3" ||
                                    type == "Double4")
                                {
                                    type = "Fbx" + type;
                                }

                                if (type == "FbxVector3")
                                {
                                    type = "FbxDouble3";
                                }

                                if (equalsIndex == 2)
                                {
                                    parts[0] = type + (isStackValue ? "!" : "");
                                }

                                if (type == "FbxTime" ||
                                    type == "FbxMatrix" ||
                                    type == "FbxAMatrix" ||
                                    type == "FbxVector2" ||
                                    type == "FbxVector3" ||
                                    type == "FbxVector4" ||
                                    type == "FbxDouble2" ||
                                    type == "FbxDouble3" ||
                                    type == "FbxDouble4" ||
                                    type == "FbxAnimCurveKey")
                                {
                                    if (isStackValue)
                                    {
                                        parts[3] = parts[3].Replace("new(", type + "(");
                                    }
                                    else
                                    {
                                        parts[3] = parts[3].Replace("new(", "new " + type + "(");
                                    }
                                }
                                else if (type == "FbxLayerElementVisibility")
                                {
                                    parts[3] = parts[3].Replace("new(", type + "::Create(NULL, ");
                                }
                                else
                                {
                                    parts[3] = parts[3].Replace("new(", type + "::Create(manager, ");
                                }
                                outline = string.Join(" ", parts);
                            }

                            outline = Regex.Replace(outline, @"\bAnimCurveDef\.(\w+)\.", "FbxAnimCurveDef::");
                            outline = Regex.Replace(outline, @"\bFbxAnimCurveDef\.(\w+)\.", "FbxAnimCurveDef::");
                            outline = Regex.Replace(outline, @"\bAnimCurveDef\.s", "FbxAnimCurveDef::s");
                            outline = Regex.Replace(outline, @"\bFbxAnimCurveDef\.s", "FbxAnimCurveDef::s");

                            outline = Regex.Replace(outline, @"\bFbx\$", "Fbx");
                            outline = Regex.Replace(outline,
                                @"\bFbxIOSettingsPath.\b", "");

                            outline = outline.Replace(
                                "GetPropertyDataType()&.GetFbxType()",
                                "GetPropertyDataType()&.GetType()");

                            parts = outline.Split(' ').ToList();
                            if (parts.Count == 2)
                            {
                                if (parts[0].EndsWith("!"))
                                {
                                    parts[0] = parts[0].Replace("!", "");
                                }

                                if (Regex.IsMatch(parts[0], "^\\w+$") &&
                                    !parts[0].StartsWith("Fbx") &&
                                    char.IsUpper(parts[0][0]))
                                {
                                    parts[0] = "Fbx" + parts[0];
                                }

                                outline = string.Join(" ", parts);
                            }
                            else if (parts.Count > 3 && parts[2] == "=")
                            {
                                if (char.IsLower(parts[0][0]) || parts[0].EndsWith("!"))
                                {
                                    parts[0] = parts[0].Replace("!", "");
                                }
                                else
                                {
                                    parts[0] += "*";
                                }
                                outline = string.Join(" ", parts);
                            }

                            if (Regex.IsMatch(outline, @"[\w)]\.[a-zA-Z_]"))
                            {
                                outline = 
                                    Regex.Replace(
                                        outline,
                                        @"([\w\)])\.([a-zA-Z_])",
                                        m => m.Groups[1].Value + "->" + m.Groups[2].Value);
                            }

                            if (Regex.IsMatch(outline, @"[\w)]&\.[a-zA-Z_]"))
                            {
                                outline =
                                    Regex.Replace(
                                        outline,
                                        @"([\w\)])&\.([a-zA-Z_])",
                                        m => m.Groups[1].Value + "." + m.Groups[2].Value);
                            }

                            if (Regex.IsMatch(outline, @"\bVector(\d)\("))
                            {
                                outline =
                                    Regex.Replace(
                                        outline,
                                        @"\bVector(\d)\(",
                                        m => "FbxVector" + m.Groups[1].Value + "(");
                            }

                            if (Regex.IsMatch(outline, @"\bnull\b"))
                            {
                                outline = Regex.Replace(outline, @"\bnull\b", "NULL");
                            }

                            outline = Regex.Replace(outline,
                                @"\b(GetSample\(""[^""]+""\))\)",
                                "$1.c_str())");

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

                foreach (var line in fixture.Epilogue)
                    writer.WriteLine(line);
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
