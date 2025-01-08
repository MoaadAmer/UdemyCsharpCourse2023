using _08_AdvancedTypes.Model;

namespace _08_AdvancedTypes.UserInteraction;

public interface IPlanetsStatsUserInteractor
{
    void ShowPlanets(IEnumerable<Planet> planets);
    string? ChooseStatisticsToBeShown(IEnumerable<string> stats);
    void ShowMessage(string message);
}