




using _08_AdvancedTypes.API;
try
{

    await new StarWarsPlanetsStatsApp(
        new APIDataReader(), new MockStarWarsApiDataReader())
        .RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"""
                     Unexpected error occurred.
                     Exception Message : {ex.Message}   
                     """);
}

Console.WriteLine("Press any key to close.");
Console.ReadLine();
