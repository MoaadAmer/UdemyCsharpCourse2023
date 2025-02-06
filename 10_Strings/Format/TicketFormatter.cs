using System.Globalization;
using System.Text;

namespace _10_Strings.Format;

public class TicketFormatter : ITicketFormatter
{
    public string FormatTicket(string ticket)
    {
        string[] tickets = SplitText(ticket);
        return FormatTickets(tickets.ToList(), GetCulture(tickets.Last()));
    }

    private static string[] SplitText(string pageText) =>
        pageText.Split(["Title", "Date", "Time", "Visit us"], StringSplitOptions.TrimEntries);

    private static string FormatTickets(List<string> lines, CultureInfo culture)
    {
        var stringBuilder = new StringBuilder();

        //Skip First and last lines
        for (int i = 1; i < lines.Count - 1; i += 3)
        {
            stringBuilder.Append($"{lines[i],-40}| ");
            DateTime dateTime = DateTime.Parse($"{lines[i + 1]} {lines[i + 2]}", culture);
            stringBuilder.Append($"{dateTime.Date.ToString("dd/MM/yyyy"),-11}| ");
            stringBuilder.Append($"{dateTime.Hour}:{dateTime.Hour,-6}");
            stringBuilder.AppendLine();
        }
        return stringBuilder.ToString();
    }

    private static CultureInfo GetCulture(string visitUsLine)
    {
        var cultures = new Dictionary<string, string>()
                            {
                                { "fr" ,"fr-FR" },
                                { "com" ,"en-US" },
                                { "jp" ,"jp-JP" },
                            };

        var arr = visitUsLine.Replace("Visit us:", "").Trim().Split(".");
        return new CultureInfo(cultures[arr[^1]]);
    }
}
