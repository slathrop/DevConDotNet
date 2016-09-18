using System;

namespace DevCon
{
    [ConsoleCommand("youtube", "Plays a Pluralsight video")]
    public class YouTube : IConsoleCommand
    {
        public ConsoleResult Run(string[] args)
        {
            // Implemented on client. This server-side code exists solely to provide the documentation
            // in the "ConsoleCommand" attribute above
            throw new NotImplementedException();
        }
    }
}