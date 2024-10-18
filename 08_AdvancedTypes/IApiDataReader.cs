namespace AdvancedTypes;

public interface IApiDataReader
{
    Task<string> ReadAsync(string baseAddress, string requestUri);
}

