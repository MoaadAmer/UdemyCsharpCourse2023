using _10_Strings.Extensions;
using _10_Strings.FilesAccess;
using System.Globalization;
using System.Text;

namespace _10_Strings.App;
public partial class TicketsDataAggregatorApp
{
    private readonly string ticketsFolder;
    private readonly IPdfFile pdfFile;
    private readonly IFileWriter fileWriter;
    private readonly Dictionary<string, CultureInfo> domainToCulture;

    public TicketsDataAggregatorApp(string ticketsFolder, IPdfFile pdfFile, IFileWriter fileWriter)
    {
        this.ticketsFolder = ticketsFolder;
        this.pdfFile = pdfFile;
        this.fileWriter = fileWriter;
        domainToCulture = new()
                            {
                                { ".fr" ,new CultureInfo("fr-FR") },
                                { ".com" ,new CultureInfo("en-US") },
                                { ".jp" ,new CultureInfo("jp-JP") },
                            };
    }

    public void Run()
    {
        var ticketsData = new StringBuilder();
        foreach (string file in Directory.EnumerateFiles(ticketsFolder, "*.pdf"))
        {
            foreach (var ticket in ProcessFile(file))
            {
                ticketsData.AppendLine(ticket);
            }
        }
        SaveTicketsData(ticketsData, ticketsFolder);
    }


    private void SaveTicketsData(StringBuilder result, string ticketsFolder)
    {
        fileWriter.Write(result.ToString(), ticketsFolder, "aggregatedTickets.txt");
    }
    private IEnumerable<string> ProcessFile(string pathToFile)
    {
        string pageText = pdfFile.ReadPage(pathToFile, 1);
        string[] formattedPageText = pageText.Split(["Title:", "Date:", "Time:", "Visit us:"], StringSplitOptions.TrimEntries);
        return FormatResult(formattedPageText);
    }
    private IEnumerable<string> FormatResult(string[] lines)
    {
        CultureInfo culture = domainToCulture[lines[^1].ExtractDomain()];
        for (int i = 1; i < lines.Length - 3; i += 3)
        {
            string title = lines[i];
            string date = DateOnly.Parse(lines[i + 1], culture).ToString(CultureInfo.InvariantCulture);
            string time = TimeOnly.Parse(lines[i + 2], culture).ToString(CultureInfo.InvariantCulture);
            yield return ($"{title,-40}| {date,-11}| {time,-6}");
        }
    }
}