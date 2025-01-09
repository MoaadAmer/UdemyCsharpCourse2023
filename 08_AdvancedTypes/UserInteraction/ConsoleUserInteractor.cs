
using _08_AdvancedTypes.Utilities;

namespace _08_AdvancedTypes.UserInteraction;

public class ConsoleUserInteractor : IUserInteractor
{
    public ConsoleUserInteractor()
    {
    }

    public void PrintTable<T>(IEnumerable<T> items)
    {
       UniversalTablePrinter.PrintToConsole(items);
    }

    public string? ReadInput()
    {
        return Console.ReadLine();
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}