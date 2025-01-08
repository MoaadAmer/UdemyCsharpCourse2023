using _08_AdvancedTypes.Model;

namespace _08_AdvancedTypes.UserInteraction;

public class PlanetsStatsUserInteractor(IUserInteractor userInteractor) : IPlanetsStatsUserInteractor
{
    public void ShowPlanets(IEnumerable<Planet> planets)
    {
        foreach (var planet in planets)
        {
            ShowMessage(planet.ToString());
        }
    }

    public string? ChooseStatisticsToBeShown(IEnumerable<string> stats)
    {
        ShowMessage(Environment.NewLine);
        ShowMessage("The statistics of which property would you like to see ?");
        ShowMessage(string.Join(Environment.NewLine, stats));
        return userInteractor.ReadInput();
    }

    public void ShowMessage(string message)
    {
        userInteractor.ShowMessage(message);
    }
}