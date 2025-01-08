using _08_AdvancedTypes.API;
using _08_AdvancedTypes.Model;
using _08_AdvancedTypes.DTO;
using System.Text.Json;
using _08_AdvancedTypes.UserInteraction;

namespace _08_AdvancedTypes.DataAccess;

public class APIPlanetReader(IApiDataReader apiReader, IApiDataReader mockReader, IUserInteractor userInteractor) : IPlanetsReader
{
    public async Task<IEnumerable<Planet>> ReadAsync()
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
            userInteractor.ShowMessage($"""
                  API Request was unsuccessful.
                  Switching to mock data.
                  Exception Message : {ex.Message}

                  """);

            responseContent = await mockReader.ReadAsync(baseAddress, endPoint);
        }

        PlanetsDTO? planetsData = JsonSerializer.Deserialize<PlanetsDTO>(responseContent);
        return ToPlanets(planetsData);
    }

    private static IEnumerable<Planet> ToPlanets(PlanetsDTO? planetsData)
    {
        ArgumentNullException.ThrowIfNull(planetsData);
        return planetsData.results.Select(planet => (Planet)planet);
    }
}