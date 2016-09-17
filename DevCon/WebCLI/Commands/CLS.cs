using System;

namespace DevCon
{
    [ConsoleCommand("cls", "Clears the console")]
    public class CLS : IConsoleCommand
    {
        public ConsoleResult Run(string[] args)
        {
            throw new NotImplementedException();   //Implemented on client
        }
    }
}