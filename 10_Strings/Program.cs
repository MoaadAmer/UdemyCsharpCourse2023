using _10_Strings.App;
using _10_Strings.FilesAccess;
using _10_Strings.Helpers;

try
{
    string ticketsFolder = Path.Combine(PathHelper.GetBinFolderPath(), "AssignmentFiles", "Tickets");
    IPdfFile pdfFile = new PigPdfFile();
    IFileWriter fileWriter = new FileWriter();
    var app = new TicketsDataAggregatorApp(ticketsFolder, pdfFile, fileWriter);
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"UnExpected error -> {ex.Message}");
}
