namespace _08_AdvancedTypes.API;

public interface IApiDataReader
{
    Task<string> ReadAsync(string baseAddress, string requestUri);

}

