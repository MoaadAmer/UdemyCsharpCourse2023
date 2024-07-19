namespace _08_AdvancedTypes.DTO;

public readonly struct PlanetsDTO
{
    public readonly int count { get; init; }
    public readonly string next { get; init; }
    public readonly object previous { get; init; }
    public readonly Result[] results { get; init; }

}

public readonly struct Result
{
    public readonly string name { get; init; }
    public readonly string rotation_period { get; init; }
    public readonly string orbital_period { get; init; }
    public readonly string diameter { get; init; }
    public readonly string climate { get; init; }
    public readonly string gravity { get; init; }
    public readonly string terrain { get; init; }
    public readonly string surface_water { get; init; }
    public readonly string population { get; init; }
    public readonly string[] residents { get; init; }
    public readonly string[] films { get; init; }
    public readonly DateTime created { get; init; }
    public readonly DateTime edited { get; init; }
    public readonly string url { get; init; }
}

