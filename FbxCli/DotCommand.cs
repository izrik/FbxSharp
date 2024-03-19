using System;
using System.Collections.Generic;
using FbxSharp;
using NCommander;

namespace FbxCli
{
    public class DotCommand : Command
    {
        public DotCommand(CliState state)
        {
            Name = ".";
            Description = "Print the ID of the current object";
            _state = state;
        }

        private readonly CliState _state;

        protected override void InternalExecute(Dictionary<string, object> args)
        {
            Console.WriteLine(ObjectPrinter.PrintObjectID(_state.Current));
        }
    }
}
