namespace DevCon
{
    [ConsoleCommand("echo", "Echos back the first arg received")]
    public class Echo : IConsoleCommand
    {
        public ConsoleResult Run(string[] args)
        {
            if (args.Length > 1)
            {
                return new ConsoleResult(args[1]);
            }
            return new ConsoleErrorResult("I didn't hear anything!");
        }
    }
}