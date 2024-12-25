using _08_AdvancedTypes;
using AdvancedTypes.DTO;

public readonly record struct Planet
{
    public string Name { get; }
    public int? Diameter { get; }
    public int? SurfaceWater { get; }
    public long? Population { get; }

    public Planet(string name, int? diameter, int? surfaceWater, long? population)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        Name = name;
        Diameter = diameter;
        SurfaceWater = surfaceWater;
        Population = population;
    }


    public static explicit operator Planet(PlanetsDataDTO planetDto)
    {
        string name = planetDto.name;
        int? diameter = planetDto.diameter.ToIntOrNull();
        int? surfaceWater = planetDto.surface_water.ToIntOrNull();
        long? population = planetDto.population.ToLongOrNull();

        return new Planet(name, diameter, surfaceWater, population);

    }
}
