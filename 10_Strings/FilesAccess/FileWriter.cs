namespace _10_Strings.App;
public partial class TicketsDataAggregatorApp
{
    public class FileWriter : IFileWriter
    {
        public void Write(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }
    }
}