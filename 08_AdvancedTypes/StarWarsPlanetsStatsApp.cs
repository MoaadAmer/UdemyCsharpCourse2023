
using _08_AdvancedTypes.API;
using AdvancedTypes.DTO;
using System.Text.Json;

public class StarWarsPlanetsStatsApp
{
    private readonly IApiDataReader _apiReader;
    private readonly IApiDataReader _mockReader;

    public StarWarsPlanetsStatsApp(IApiDataReader apiReader, IApiDataReader mockReader)
    {
        _apiReader = apiReader;
        _mockReader = mockReader;
    }
    public async Task RunAsync()
    {
        string baseAddress = "https://swapi.dev/";
        string endPoint = "api/planets";
        string responseContent;
        try
        {

            responseContent = await _apiReader.ReadAsync(baseAddress, endPoint);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"""
                      API Request was unsuccessful.
                      Switching to mock data.
                      Exception Message : {ex.Message}

                      """);

            responseContent = await _mockReader.ReadAsync(baseAddress, endPoint);
        }


        PlanetsDTO planetsData = JsonSerializer.Deserialize<PlanetsDTO>(responseContent);
        IEnumerable<Planet> planets = ToPlanets(planetsData);

        //var tablePrinter = new UniversalTablePrinter(planets);
        //tablePrinter.PrintToConsole();

        foreach (var item in planets)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine(
            """
    The statistics of which property would you like to see?
    population
    diameter
    surface water
    """
            );


        string desiredStat = Console.ReadLine().ToLower();
        switch (desiredStat)
        {
            case "population":
                Planet pMin = planets.MinBy(p => p.Population);
                Planet pMax = planets.MaxBy(p => p.Population);
                Console.WriteLine($"Max population is {pMax.Population} (planet:{pMax.Name})");
                Console.WriteLine($"Min population is {pMin.Population} (planet:{pMin.Name})");
                break;
            case "diameter":
                pMin = planets.MinBy(p => p.Diameter);
                pMax = planets.MaxBy(p => p.Diameter);
                Console.WriteLine($"Max diameter is {pMax.Diameter} (diameter:{pMax.Name})");
                Console.WriteLine($"Min diameter is {pMin.Diameter} (diameter:{pMin.Name})");
                break;
            case "surface water":
                pMin = planets.MinBy(p => p.SurfaceWater);
                pMax = planets.MaxBy(p => p.SurfaceWater);
                Console.WriteLine($"Max surface water is {pMax.SurfaceWater} (surface water:{pMax.Name})");
                Console.WriteLine($"Min surface water is {pMin.SurfaceWater} (surface water:{pMin.Name})");
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }


    private IEnumerable<Planet> ToPlanets(PlanetsDTO? planetsData)
    {
        if (planetsData == null)
        {
            throw new ArgumentNullException(nameof(planetsData));
        }
        var planets = new List<Planet>();
        foreach (var planetsDTO in planetsData.results)
        {
            var planet = (Planet)planetsDTO;
            planets.Add(planet);
        }
        return planets;

    }
}