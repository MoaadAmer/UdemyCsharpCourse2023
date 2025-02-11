using _10_Strings.App;
using _10_Strings.FilesAccess;
using _10_Strings.Helpers;
using _10_Strings.PDF;

try
{


    string ticketsFolder = Path.Combine(PathHelper.GetBinFolderPath(), "AssignmentFiles", "Tickets");
    IPdfFile pdfFile = new PigPdfFile();
    var app = new TicketsDataAggregatorApp(ticketsFolder,pdfFile);
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"UnExpected error -> {ex.Message}");
}
