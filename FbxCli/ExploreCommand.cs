using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using FbxSharp;
using NCommander;

namespace FbxCli
{
    public class ExploreCommand : Command
    {
        public static readonly ExploreCommand Value = new ExploreCommand();

        private ExploreCommand()
        {
            Name = "explore";
            Description = "Explore various parts of an FBX file using an " +
                          "interactive prompt";
            Params = new[]
            {
                new Parameter
                {
                    Name = "filename",
                    Description = "The path to the FBX file to open",
                    ParameterType = ParameterType.String
                }
            };
        }

        protected override void InternalExecute(Dictionary<string, object> args)
        {
            var filename = (string) args["filename"];
            FbxObject current;
            try
            {
                var importer = new FbxImporter(filename);
                current = importer.Import(filename);
            }
            catch (IOException ex)
            {
                Console.WriteLine(
                    $"There was an error while trying to read the file: " +
                    $"{ex.Message}");
                return;
            }

            var prompt = ">>> ";
            var state = new CliState(current);
            var commander = new Commander(prompt, "0.1");
            commander.Commands["print"] = new Print2Command(state);
            commander.Commands["."] = new DotCommand(state);
            commander.Commands["ls"] = new LsCommand(state);
            commander.Commands["cd"] = new CdCommand(state);
            while (true)
            {
                try
                {
                    // TODO: add ConsoleCancelEventHandler so we can Ctrl+C a
                    // long-running print

                    var line = GetInput(prompt);
                    if (line == null) // Ctrl + D
                        break;
                    if (string.IsNullOrWhiteSpace(line)) // possibly Ctrl + C
                        continue;

                    string[] args2;
                    try
                    {
                        args2 = Splitter.SplitArgs(line);
                    }
                    catch (UnmatchedQuoteException ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }

                    if (args.Count < 1) continue;

                    var command = args2[0];
                    if (command == "quit" || command == "exit") break;

                    commander.ProcessArgs(args2);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"There was an error: {ex.Message}");
                }
            }
        }

        protected string GetInput(string prompt)
        {
            Console.Write(prompt);
            var thread = Thread.CurrentThread;
            ConsoleCancelEventHandler handler =
                (sender, args) =>
                {
                    args.Cancel = true; // don't terminate the program
                    thread.Abort(); // stop the ReadLine
                };
            Console.CancelKeyPress += handler;
            try
            {
                return Console.ReadLine();
            }
            catch (ThreadAbortException) // Ctrl + C
            {
                Thread.ResetAbort(); // don't terminate the program
                Console.WriteLine();
                return "";
            }
            finally
            {
                Console.CancelKeyPress -= handler;
            }
        }
    }
}
