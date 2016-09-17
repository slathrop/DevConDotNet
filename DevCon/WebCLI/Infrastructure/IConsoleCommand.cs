namespace DevCon
{
    public interface IConsoleCommand
    {
        ConsoleResult Run(string[] args);
    }
}
