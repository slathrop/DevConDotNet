using System;

namespace DevCon
{
    [ConsoleCommand("add", "Adds 2 numbers together")]
    public class Add : IConsoleCommand, IMultiStepConsoleCommand
    {
        public ConsoleResult Run(string[] args)
        {
            if (args.Length == 1) { return RunStep(args); }
            if (args.Length != 3) { return new ConsoleErrorResult("Exactly 2 operands required, or no operands to be prompted"); }

            double x = double.Parse(args[1]);
            double y = double.Parse(args[2]);

            return new ConsoleResult($"Result: {x} + {y} = {(x + y)}");
        }

        public ConsoleResult RunStep(string[] args)
        {
            ConsoleResult res = null;
            int stepNum = args.Length;

            switch (stepNum)
            {
                case 1:
                    res = new ConsoleMultiStepResult("Enter the first operand", args);
                    break;
                case 2:
                    res = new ConsoleMultiStepResult("Enter the second operand", args);
                    break;
                case 3:
                    res = Run(args);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return res;
        }
    }
}