namespace DevCon
{
    public interface IMultiStepConsoleCommand
    {
        ConsoleResult RunStep(int stepNum, string[] args);
    }
}
