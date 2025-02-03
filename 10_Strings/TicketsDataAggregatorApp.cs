
using _10_Strings.Helpers;
using System.Globalization;
using System.Text;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig;

namespace _10_Strings;
public class TicketsDataAggregatorApp
{
    public TicketsDataAggregatorApp()
    {
    }

    public void Run()
    {

        string? binFolder = PathHelper.GetBinFolderPath();

        IEnumerable<string> ticketsFilesAsPdf = Directory.EnumerateFiles(Path.Combine(binFolder, "AssignmentFiles", "Tickets"), "*.pdf");
        var tickets = new StringBuilder();
        foreach (string file in ticketsFilesAsPdf)
        {
            string pageText = ReadFileText(file);
            List<string> lines = GetTextAsLines(pageText);
            CultureInfo culture = GetCulture(lines.Last());
            tickets.Append(ReadTicketsData(lines, culture));
        }
        File.WriteAllText(Path.Combine(binFolder, "AssignmentFiles", "Tickets", "aggregatedTickets.txt"), tickets.ToString());
    }

    private CultureInfo GetCulture(string visitUsLine)
    {
        var cultures = new Dictionary<string, string>()
{
{ "fr" ,"fr-FR" },
{ "com" ,"en-US" },
{ "jp" ,"jp-JP" },
};


        var arr = visitUsLine.Replace("Visit us:", "").Trim().Split(".");
        return new CultureInfo(cultures[arr[arr.Length - 1]]);
    }

    private string ReadFileText(string filePath)
    {
        using (PdfDocument document = PdfDocument.Open(filePath))
        {
            Page page = document.GetPage(1);
            return page.Text;
        }
    }


    private List<string> GetTextAsLines(string pageText)
    {
        pageText = pageText.Replace("Title", $"{Environment.NewLine}Title");
        pageText = pageText.Replace("Date", $"{Environment.NewLine}Date");
        pageText = pageText.Replace("Time", $"{Environment.NewLine}Time");
        pageText = pageText.Replace("Visit us", $"{Environment.NewLine}Visit us");
        pageText = pageText.Trim();

        return
              pageText.Split(Environment.NewLine)
             .Skip(1)
             .Select(line => line.Trim())
             .ToList();
    }

    private static string ReadTicketsData(List<string> lines, CultureInfo culture)
    {
        var stringBuilder = new StringBuilder();

        //Skip the last line
        for (int i = 0; i < lines.Count() - 1; i += 3)
        {
            stringBuilder.Append($"{lines[i].Replace("Title:", "").Trim(),-40}| ");
            string date = lines[i + 1].Replace("Date:", "").Trim();
            string time = lines[i + 2].Replace("Time:", "").Trim();
            DateTime dateTime = DateTime.Parse($"{date} {time}", culture);
            stringBuilder.Append($"{dateTime.Date.ToString("dd/MM/yyyy"),-11}| ");
            stringBuilder.Append($"{dateTime.Hour}:{dateTime.Hour,-6}");
            stringBuilder.AppendLine();
        }
        return stringBuilder.ToString();
    }
}