using System.Globalization;
using System.Text;

namespace _10_Strings.Format;

public class TicketFormatter : ITicketFormatter
{
    public string FormatTicket(string ticket)
    {
        string[] tickets = SplitText(ticket);
        return FormatTickets(tickets.ToList());
    }

    private static string[] SplitText(string pageText) =>
        pageText.Split(["Title:", "Date:", "Time:", "Visit us:"], StringSplitOptions.TrimEntries);

    private static string FormatTickets(List<string> lines)
    {
        var stringBuilder = new StringBuilder();
        CultureInfo culture = GetCulture(lines[^1]);
        //Skip First and last lines
        for (int i = 1; i < lines.Count - 3; i += 3)
        {
            string title = lines[i];
            string date = DateOnly.Parse(lines[i + 1], culture).ToString(CultureInfo.InvariantCulture);
            string time = TimeOnly.Parse(lines[i + 2], culture).ToString(CultureInfo.InvariantCulture);
               stringBuilder.AppendLine($"{title,-40}| {date,-11}| {time,-6}");
        }
        return stringBuilder.ToString();
    }

    private static CultureInfo GetCulture(string webAddress)
    {
        var domainToCulture = new Dictionary<string, string>()
                            {
                                { ".fr" ,"fr-FR" },
                                { ".com" ,"en-US" },
                                { ".jp" ,"jp-JP" },
                            };
        int index = webAddress.LastIndexOf('.');
        string domain = webAddress.Substring(index);

        return new CultureInfo(domainToCulture[domain]);
    }
}
