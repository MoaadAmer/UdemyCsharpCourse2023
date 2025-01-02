
using _08_AdvancedTypes.API;
using AdvancedTypes.DTO;
using System.Text.Json;

public class StarWarsPlanetsStatsApp(IApiDataReader apiReader, IApiDataReader mockReader)
{

    public async Task RunAsync()
    {
        string baseAddress = "https://swapi.dev/";
        string endPoint = "api/planets";
        string responseContent;
        try
        {

            responseContent = await apiReader.ReadAsync(baseAddress, endPoint);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"""
                      API Request was unsuccessful.
                      Switching to mock data.
                      Exception Message : {ex.Message}

                      """);

            responseContent = await mockReader.ReadAsync(baseAddress, endPoint);
        }

        PlanetsDTO? planetsData = JsonSerializer.Deserialize<PlanetsDTO>(responseContent);
        IEnumerable<Planet> planets = ToPlanets(planetsData);

        //var tablePrinter = new UniversalTablePrinter(planets);
        //tablePrinter.PrintToConsole();

        foreach (var item in planets)
        {
            Console.WriteLine(item);
        }

        var propertyNameToSelectorsMapping = new Dictionary<string, Func<Planet, long?>>()
        {
            ["population"] = planet => planet.Population,
            ["diameter"] = planet => planet.Diameter,
            ["surface water"] = planet => planet.SurfaceWater,

        };

        Console.WriteLine("The statistics of which property would you like to see ?");
        Console.WriteLine(string.Join(Environment.NewLine, propertyNameToSelectorsMapping.Keys));

        string? desiredStat = Console.ReadLine();
        desiredStat = desiredStat?.ToLower();
        if (desiredStat == null || !propertyNameToSelectorsMapping.TryGetValue(desiredStat, out Func<Planet, long?>? propertySelector))
        {
            Console.WriteLine("Invalid choice");
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

    private static void ShowStats(string descriptor, Planet planet, Func<Planet, long?> propertySelector, string propertyName)
    {
        Console.WriteLine($"{descriptor} {propertyName} is {propertySelector(planet)} ({propertyName}:{planet.Name})");
    }

    private static IEnumerable<Planet> ToPlanets(PlanetsDTO? planetsData)
    {
        ArgumentNullException.ThrowIfNull(planetsData);
        return planetsData.results.Select(planet => (Planet)planet);
    }
}