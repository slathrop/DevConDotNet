﻿using System;

namespace DevCon
{
    [ConsoleCommand("cls", "Clears the console")]
    public class CLS : IConsoleCommand
    {
        public ConsoleResult Run(string[] args)
        {
            // Implemented on client. This server-side code exists solely to provide the documentation
            // in the "ConsoleCommand" attribute above
            throw new NotImplementedException();
        }
    }
}