using _08_AdvancedTypes.Model;

namespace _08_AdvancedTypes.DataAccess;

public interface IPlanetsReader
{
    Task<IEnumerable<Planet>> ReadAsync();
}