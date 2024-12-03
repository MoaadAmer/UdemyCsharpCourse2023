using AdvancedTypes;
using AdvancedTypes.DTO;
using System.Text.Json;

IApiDataReader starWarsAPI = new StarWarsApiDataReader();

string responseContent = await starWarsAPI.ReadAsync("https://swapi.dev/api/", "planets");


PlanetsDTO planetsData = JsonSerializer.Deserialize<PlanetsDTO>(responseContent);


IEnumerable<Planet> planets =
     planetsData
    .results.Select(p =>
         new Planet()
         {
             Name = p.name,
             Diameter = int.TryParse(p.diameter, out int diameter) ? diameter + "" : "",
             SurfaceWater = int.TryParse(p.surface_water, out int surfaceWater) ? surfaceWater + "" : "",
             Population = long.TryParse(p.population, out long population) ? population + "" : ""
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
        Planet pMin = planets.First();
        Planet pMax = planets.First();
        foreach (Planet planet in planets)
        {
            if (int.TryParse(planet.Population, out int currentValue))
            {
                int.TryParse(pMin.Population, out int min);
                if (currentValue < min)
                {
                    pMin = planet;
                }
                int.TryParse(pMax.Population, out int max);
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
        pMin = planets.First();
        pMax = planets.First();
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
        pMin = planets.First();
        pMax = planets.First();
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

Console.WriteLine("Press any key to close.");
Console.ReadLine();

public class Planet
{
    public string Name { get; set; }
    public string Diameter { get; set; }
    public string SurfaceWater { get; set; }
    public string Population { get; set; }
}