using System.Linq;
using System.Text.RegularExpressions;

namespace DevCon
{
    public class CommandInput
    {
        public string CmdLine { get; set; }

        public string multiStepCmd { get; set; }        // The name of the current multi-step cmd we're in the middle of, if any
        public string[] multiStepCmdArgs { get; set; }  // The accumulated args for any multi-step cmd we may be in the middle of

        public string[] GetArgs()
        {
            // Matches (1 or more chars that are NOT space or ") or (" any # of chars not a " followed by a ")
            var tokenEx = new Regex(@"[^\s""]+|""[^""]*""");

            return tokenEx.Matches(CmdLine)
                                 .Cast<Match>()
                                 .Select(m => m.Value.Replace("\"", ""))    // Remove " from the arg
                                 .ToArray();
        }
    }
}