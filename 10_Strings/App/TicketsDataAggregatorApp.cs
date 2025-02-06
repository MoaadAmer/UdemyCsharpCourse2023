using _10_Strings.Format;
using _10_Strings.Helpers;
using _10_Strings.PDF;
using System.Text;

namespace _10_Strings.App;
public class TicketsDataAggregatorApp(IPdfFile pdfFile, ITicketFormatter ticketFormatter)
{
    public void Run()
    {

        string? binFolder = PathHelper.GetBinFolderPath();

        IEnumerable<string> ticketsFilesAsPdf = Directory.EnumerateFiles(Path.Combine(binFolder, "AssignmentFiles", "Tickets"), "*.pdf");
        var tickets = new StringBuilder();
        foreach (string file in ticketsFilesAsPdf)
        {
            string pageText = pdfFile.ReadPage(file, 1);
            tickets.Append(ticketFormatter.FormatTicket(pageText));
        }
        string resultFilePath = Path.Combine(binFolder, "AssignmentFiles", "Tickets", "aggregatedTickets.txt");
        File.WriteAllText(resultFilePath, tickets.ToString());
    }

}