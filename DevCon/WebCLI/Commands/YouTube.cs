using System;

namespace DevCon
{
    [ConsoleCommand("youtube", "Plays a Pluralsight video")]
    public class YouTube : IConsoleCommand
    {
        public ConsoleResult Run(string[] args)
        {
            throw new NotImplementedException();   //Implemented on client
        }
    }
}