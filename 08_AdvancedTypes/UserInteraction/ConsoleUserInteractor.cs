namespace _08_AdvancedTypes.UserInteraction;

public class ConsoleUserInteractor : IUserInteractor
{
    public ConsoleUserInteractor()
    {
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