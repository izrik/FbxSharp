using System;
using System.Collections.Generic;
using FbxSharp;
using NCommander;

namespace FbxCli
{
    public class Print2Command : Command
    {
        public Print2Command(CliState cliState)
        {
            Name = "print";
            Description = "Print the object graph starting at the current " +
                          "object";
            Options = new[]
            {
                new Option
                {
                    Name = "current-only",
                    Description = "Only print the current object, not any " +
                                  "connected objects within the object graph",
                    Type = ParameterType.Flag
                }
            };
            _cliState = cliState;
        }

        private readonly CliState _cliState;

        protected override void InternalExecute(Dictionary<string, object> args)
        {
            var printer = new ObjectPrinter();
            var currentOnly = args.GetBoolOrNull("current-only");
            if (currentOnly.HasValue && currentOnly.Value)
                printer.Print(_cliState.Current);
            else
                printer.PrintObjectGraph(_cliState.Current);
        }
    }
}
