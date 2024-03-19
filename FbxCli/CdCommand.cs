using System;
using System.Collections.Generic;
using FbxSharp;
using NCommander;

namespace FbxCli
{
    public class CdCommand : Command
    {
        public CdCommand(CliState state)
        {
            Name = "cd";
            Description = "Change to a different object";
            Params = new[]
            {
                new Parameter
                {
                    Name = "target",
                    Description = "The type of object to change to, either " +
                                  "'src' or 'dst'",
                    // TODO: prop, sprop, dprop?
                    ParameterType = ParameterType.String // TODO: ParameterType.Choice
                },
                new Parameter
                {
                    Name = "index",
                    Description = "The index of the object to change to",
                    ParameterType = ParameterType.Integer
                }
            };

            _state = state;
        }

        private readonly CliState _state;

        protected override void InternalExecute(Dictionary<string, object> args)
        {
            var obj = _state.Current;
            if (obj == null)
            {
                Console.WriteLine("Current object is <<null>>");
                return;
            }

            var target = (string) args.GetOrNull("target");
            var index = (int) args["index"];
            int n;
            FbxObject next = null;
            switch (target)
            {
                case null:
                case "":
                    break;
                case "src":
                    n = obj.GetSrcObjectCount();
                    if (index >= n)
                        throw new IndexOutOfRangeException(
                            "Index must be less than the number " +
                            "of src connections, {N}.");
                    next = obj.GetSrcObject(index);
                    break;
                case "dst":
                    n = obj.GetDstObjectCount();
                    if (index >= n)
                        throw new IndexOutOfRangeException(
                            "Index must be less than the number " +
                            "of dst connections, {N}.");
                    next = obj.GetDstObject(index);
                    break;
                case "prop":
                case "time":
                case "sprop":
                case "dprop":
                default:
                    Console.WriteLine($"Unknown target \"{target}\"");
                    break;
            }

            if (next != null)
                _state.Current = next;
        }
    }
}
