namespace _08_AdvancedTypes.UserInteraction;

public interface IUserInteractor
{
    void ShowMessage(string message);
    string? ReadInput();
}