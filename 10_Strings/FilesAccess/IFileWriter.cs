namespace _10_Strings.App;
public partial class TicketsDataAggregatorApp
{
    public interface IFileWriter
    {
        void Write(string filePath, string content);
    }
}