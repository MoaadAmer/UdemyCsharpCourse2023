namespace _08_AdvancedTypes;

public interface IApiDataReader
{
    Task<string> ReadAsync(string baseAddress, string requestUri);
}

