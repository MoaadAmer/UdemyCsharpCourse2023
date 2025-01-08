using _08_AdvancedTypes.Model;
using _08_AdvancedTypes.UserInteraction;

namespace _08_AdvancedTypes.App;

public class PlanetStatisticsAnalyzer(IPlanetsStatsUserInteractor planetsStatsUserInteractor) : IPlanetStatisticsAnalyzer
{
    private readonly IPlanetsStatsUserInteractor _planetsStatsUserInteractor = planetsStatsUserInteractor;

    public void Analyze(IEnumerable<Planet> planets)
    {
        var propertyNameToSelectorsMapping = new Dictionary<string, Func<Planet, long?>>()
        {
            ["population"] = planet => planet.Population,
            ["diameter"] = planet => planet.Diameter,
            ["surface water"] = planet => planet.SurfaceWater,

        };
        string? desiredStat = _planetsStatsUserInteractor.ChooseStatisticsToBeShown(propertyNameToSelectorsMapping.Keys);
        desiredStat = desiredStat?.ToLower();
        if (desiredStat == null || !propertyNameToSelectorsMapping.TryGetValue(desiredStat, out Func<Planet, long?>? propertySelector))
        {
            _planetsStatsUserInteractor.ShowMessage("Invalid choice");
        }
        else
        {
            ShowStats("Max",
                  planets.MaxBy(propertySelector)
                , propertySelector
                , desiredStat);


            ShowStats("Min",
                planets.MinBy(propertySelector)
                , propertySelector
                , desiredStat);
        }
    }


    private void ShowStats(string descriptor, Planet planet, Func<Planet, long?> propertySelector, string propertyName)
    {
        _planetsStatsUserInteractor.ShowMessage($"{descriptor} {propertyName} is {propertySelector(planet)} ({propertyName}:{planet.Name})");
    }

}