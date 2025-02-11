namespace _10_Strings.Extensions;
public static class WebAddressExtensions
{
    public static string ExtractDomain(this string webAddress)
    {
        int index = webAddress.LastIndexOf('.');
        return webAddress.Substring(index);
    }
}