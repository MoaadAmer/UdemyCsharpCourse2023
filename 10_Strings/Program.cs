using UglyToad.PdfPig.Content;
using UglyToad.PdfPig;
using System.Text;
using System.Globalization;
using _10_Strings.Helpers;
try
{
    string? binFolder = PathHelper.GetBinFolderPath();

    IEnumerable<string> ticketsFilesAsPdf = Directory.EnumerateFiles(Path.Combine(binFolder, "AssignmentFiles", "Tickets"), "*.pdf");

    StringBuilder stringBuilder = new StringBuilder();
    var cultures = new Dictionary<string, string>()
{
    { "fr" ,"fr-FR" },
    { "com" ,"en-US" },
    { "jp" ,"jp-JP" },
};

    foreach (string file in ticketsFilesAsPdf)
    {
        using (PdfDocument document = PdfDocument.Open(file))
        {
            Page page = document.GetPage(1);
            string pageText = page.Text;

            pageText = pageText.Replace("Title", $"{Environment.NewLine}Title");
            pageText = pageText.Replace("Date", $"{Environment.NewLine}Date");
            pageText = pageText.Replace("Time", $"{Environment.NewLine}Time");
            pageText = pageText.Replace("Visit us", $"{Environment.NewLine}Visit us");
            pageText = pageText.Trim();


            List<string> lines =
                 pageText.Split(Environment.NewLine)
                .Skip(1)
                .Select(line => line.Trim())
                .ToList();

            var arr = lines[lines.Count - 1].Replace("Visit us:", "").Trim().Split(".");

            CultureInfo culture = new CultureInfo(cultures[arr[arr.Length - 1]]);

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
        }
    }

    File.WriteAllText(Path.Combine(binFolder, "AssignmentFiles", "Tickets", "aggregatedTickets.txt"), stringBuilder.ToString());
}
catch (Exception ex)
{
    Console.WriteLine($"UnExpected error -> {ex.Message}");
}