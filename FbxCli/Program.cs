using NCommander;

namespace FbxCli
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var commander = new Commander("fbxcli", "0.1");
            commander.Commands.Add(PrintCommand.Value.Name,
                PrintCommand.Value);
            commander.Commands.Add(ExploreCommand.Value.Name,
                ExploreCommand.Value);
            if (args == null || args.Length < 1)
            {
                commander.ProcessArgs("help");
                return;
            }
            commander.ProcessArgs(args);
        }
    }
}
