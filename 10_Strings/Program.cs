using _10_Strings;

try
{
    var app = new TicketsDataAggregatorApp();
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"UnExpected error -> {ex.Message}");
}
