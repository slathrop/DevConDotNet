using System;

namespace DevCon
{
    [ConsoleCommand("img", "Displays an image")]
    public class Img: IConsoleCommand
    {
        public ConsoleResult Run(string[] args)
        {
            throw new NotImplementedException();   //Implemented on client
        }
    }
}