using System;

namespace DevCon
{
    [ConsoleCommand("add", "Adds 2 numbers together")]
    public class Add : IConsoleCommand
    {
        public ConsoleResult Run(string[] args)
        {
            if (args.Length != 3) { return new ConsoleErrorResult("Exactly 2 operands required"); }

            double x = double.Parse(args[1]);
            double y = double.Parse(args[2]);

            return new ConsoleResult((x + y).ToString());
        }
    }
}