namespace DevCon
{
    public class ConsoleResult
    {
        public string output { get; set; } = "";            // Holds the success or error output
        public bool isError { get; set; } = false;          // Is the output a text string or an HTML string?
        public bool isHTML { get; set; } = false;           // True if output is an error message

        public string multiStepCmdName { get; set; } = "";  // Holds the name of the multi-step command we're in the middle of, if any
        public int multiStepCmdStepNum { get; set; } = 0;   // Holds the step number of the multi-step command we're in the middle of, if any

        public ConsoleResult() { }

        public ConsoleResult(string output)
        {
            this.output = output;
        }
    }

    public class ConsoleErrorResult : ConsoleResult
    {
        public ConsoleErrorResult()
        {
            isError = true;
            output = "Invalid syntax";
        }

        public ConsoleErrorResult(string message)
        {
            isError = true;
            output = message;
        }
    }

    public class ConsoleMultiStepResult : ConsoleResult
    {
        public ConsoleMultiStepResult(string output, string[] args)
        {
            this.output = output;

            if ((args != null) && (args.Length > 0))
            {
                this.multiStepCmdName = args[0];
                this.multiStepCmdStepNum = args.Length;
            }
        }
    }
}