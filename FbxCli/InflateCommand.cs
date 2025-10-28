using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using NCommander;

namespace FbxCli;

public class InflateCommand : Command
{
    public static readonly InflateCommand Value = new();

    private InflateCommand()
    {
        Name = "inflate";
        Description = "Decompress a sequence of bytes";
        Params =
        [
            new Parameter
            {
                Name = "filename",
                Description = "File to get the bytes from",
                ParameterType = ParameterType.String,
                IsOptional = true,
            }
        ];
        Options =
        [
            new Option
            {
                Name = "hex-out",
                Description = "Display the output as a space-separated sequence of hexadecimal bytes",
                Type = ParameterType.Flag,
            }
        ];
    }

    protected override void InternalExecute(Dictionary<string, object> args)
    {
        var filename = string.Empty;
        if (args.ContainsKey("filename"))
            filename = (string)args["filename"];

        var hexOut = false;
        if (args.ContainsKey("hex-out"))
            hexOut = (bool)args["hex-out"];

        using var stream = (
            string.IsNullOrWhiteSpace(filename) || filename == "-"
                ? System.Console.OpenStandardInput()
                : File.Open(filename, FileMode.Open));
        using var zs = new ZLibStream(stream, CompressionMode.Decompress,
            true);
        using var stdout = System.Console.OpenStandardOutput();
        using var writer = System.Console.Out;

        var total = 0;
        var buffer = new byte[4096];
        while (true)
        {
            var numBytesRead = zs.Read(buffer, 0, 4096);
            if (numBytesRead < 1)
                break;
            total += numBytesRead;
            if (hexOut)
            {
                int i;
                for (i = 0; i < numBytesRead; i++)
                {
                    writer.Write("{0:x2} ", buffer[i]);
                    if (i % 16 == 7)
                        writer.Write(" ");
                    if (i % 16 == 15)
                        writer.WriteLine();
                }

                if (i % 16 != 0)
                    writer.WriteLine();
            }
            else
                stdout.Write(buffer, 0, numBytesRead);
        }
    }
}
