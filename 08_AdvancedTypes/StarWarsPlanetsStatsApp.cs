
using _08_AdvancedTypes.API;
using AdvancedTypes.DTO;
using System.Text.Json;

public class StarWarsPlanetsStatsApp
{
    private readonly IApiDataReader _apiReader;
    private readonly IApiDataReader _mockReader;

    public StarWarsPlanetsStatsApp(IApiDataReader apiReader,IApiDataReader mockReader)
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


        IEnumerable<Planet> planets =
             planetsData
            .results.Select(p =>
                 new Planet()
                 {
                     Name = p.name,
                     Diameter = int.TryParse(p.diameter, out int diameter) ? diameter.ToString() : "",
                     SurfaceWater = int.TryParse(p.surface_water, out int surfaceWater) ? surfaceWater.ToString() : "",
                     Population = long.TryParse(p.population, out long population) ? population.ToString() : ""
                 });





        var tablePrinter = new UniversalTablePrinter(planets);
        tablePrinter.PrintToConsole();

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
                Planet pMin = planets.First(p => long.TryParse(p.Population, out long value));
                Planet pMax = planets.First(p => long.TryParse(p.Population, out long value));
                foreach (Planet planet in planets)
                {
                    if (long.TryParse(planet.Population, out long currentValue))
                    {
                        long.TryParse(pMin.Population, out long min);
                        if (currentValue < min)
                        {
                            pMin = planet;
                        }
                        long.TryParse(pMax.Population, out long max);
                        if (currentValue > max)
                        {
                            pMax = planet;
                        }
                    }

                }
                Console.WriteLine($"Max population is {pMax.Population} (planet:{pMax.Name})");
                Console.WriteLine($"Min population is {pMin.Population} (planet:{pMin.Name})");
                break;
            case "diameter":
                pMin = planets.First(p => int.TryParse(p.Diameter, out int value));
                pMax = planets.First(p => int.TryParse(p.Diameter, out int value));
                foreach (Planet planet in planets)
                {
                    if (int.TryParse(planet.Diameter, out int currentValue))
                    {
                        int.TryParse(pMin.Diameter, out int min);
                        if (currentValue < min)
                        {
                            pMin = planet;
                        }
                        int.TryParse(pMax.Diameter, out int max);
                        if (currentValue > max)
                        {
                            pMax = planet;
                        }
                    }
                }
                Console.WriteLine($"Max diameter is {pMax.Diameter} (diameter:{pMax.Name})");
                Console.WriteLine($"Min diameter is {pMin.Diameter} (diameter:{pMin.Name})");
                break;
            case "surface water":
                pMin = planets.First(p => int.TryParse(p.SurfaceWater, out int value));
                pMax = planets.First(p => int.TryParse(p.SurfaceWater, out int value));
                foreach (Planet planet in planets)
                {
                    if (int.TryParse(planet.SurfaceWater, out int currentValue))
                    {
                        int.TryParse(pMin.SurfaceWater, out int min);
                        if (currentValue < min)
                        {
                            pMin = planet;
                        }
                        int.TryParse(pMax.SurfaceWater, out int max);
                        if (currentValue > max)
                        {
                            pMax = planet;
                        }
                    }
                }
                Console.WriteLine($"Max surface water is {pMax.SurfaceWater} (surface water:{pMax.Name})");
                Console.WriteLine($"Min surface water is {pMin.SurfaceWater} (surface water:{pMin.Name})");
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}