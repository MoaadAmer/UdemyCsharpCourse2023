using _10_Strings;
using _10_Strings.PDF;

try
{
    IPdfFile pdfFile = new PigPdfFile();
    ITicketFormatter ticketFormatter = new TicketFormatter();
    var app = new TicketsDataAggregatorApp(pdfFile,ticketFormatter);
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"UnExpected error -> {ex.Message}");
}
