using _08_AdvancedTypes.Model;

namespace _08_AdvancedTypes.App;

public interface IPlanetStatisticsAnalyzer
{
    void Analyze(IEnumerable<Planet> planets);
}