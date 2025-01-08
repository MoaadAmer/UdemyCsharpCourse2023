using _08_AdvancedTypes.DataAccess;
using _08_AdvancedTypes.Model;
using _08_AdvancedTypes.UserInteraction;

namespace _08_AdvancedTypes.App;

public class StarWarsPlanetsStatsApp(IPlanetsReader planetsReader,
    IPlanetStatisticsAnalyzer planetStatisticsAnalyzer,
    IPlanetsStatsUserInteractor planetsStatsUserInteractor)
{

    public async Task RunAsync()
    {
        IEnumerable<Planet> planets = await planetsReader.ReadAsync();

        //var tablePrinter = new UniversalTablePrinter(planets);
        //tablePrinter.PrintToConsole();
        planetsStatsUserInteractor.ShowPlanets(planets);

        planetStatisticsAnalyzer.Analyze(planets);
    }



}