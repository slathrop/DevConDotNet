namespace DevCon
{
    public interface IMultiStepConsoleCommand
    {
        ConsoleResult RunStep(string[] args);
    }
}
