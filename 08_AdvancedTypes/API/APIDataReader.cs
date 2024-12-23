using _08_AdvancedTypes.API;

public class APIDataReader : IApiDataReader
{
    private HttpClient _httpClient;

    public APIDataReader()
    {
        _httpClient = new HttpClient();
    }
    public async Task<string> ReadAsync(string baseAddress, string requestUri)
    {
        _httpClient.BaseAddress = new Uri(baseAddress);
        HttpResponseMessage httpResponse = await _httpClient.GetAsync(requestUri);
        httpResponse.EnsureSuccessStatusCode();
        return await httpResponse.Content.ReadAsStringAsync();
    }
}

