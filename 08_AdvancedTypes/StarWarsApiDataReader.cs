using AdvancedTypes;

public class StarWarsApiDataReader : IApiDataReader
{
    private HttpClient _httpClient;

    public StarWarsApiDataReader()
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

