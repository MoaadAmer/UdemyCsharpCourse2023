using _08_AdvancedTypes.API;
using _08_AdvancedTypes.App;
using _08_AdvancedTypes.DataAccess;
using _08_AdvancedTypes.UserInteraction;

IUserInteractor consoleUserInteractor = new ConsoleUserInteractor();

try
{
    IPlanetsStatsUserInteractor planetsStatsUserInteractor = new PlanetsStatsUserInteractor(consoleUserInteractor);
    await new StarWarsPlanetsStatsApp(
          new APIPlanetReader(new APIDataReader(), new MockStarWarsApiDataReader(), consoleUserInteractor)
          , new PlanetStatisticsAnalyzer(planetsStatsUserInteractor)
          , planetsStatsUserInteractor)
          .RunAsync();
}
catch (Exception ex)
{
    consoleUserInteractor.ShowMessage($"""
                     Unexpected error occurred.
                     Exception Message : {ex.Message}   
                     """);

}

consoleUserInteractor.ShowMessage("Press any key to close.");
consoleUserInteractor.ReadInput();
