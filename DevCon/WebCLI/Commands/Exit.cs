using System;

namespace DevCon
{
    [ConsoleCommand("exit", "Exits the console")]
    public class Exit : IConsoleCommand
    {
        public ConsoleResult Run(string[] args)
        {
            // Implemented on client. This server-side code exists solely to provide the documentation
            // in the "ConsoleCommand" attribute above
            throw new NotImplementedException();
        }
    }
}