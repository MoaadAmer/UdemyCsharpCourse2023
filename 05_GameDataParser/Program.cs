﻿using System.Text.Json;


var app = new GameDataParserApp();
var logger = new Logger("log.txt");

try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Sorry! the application has experienced an unexpected error" +
        "and will have to be closed.");
    logger.Log(ex);
}
Console.WriteLine("press any key to close.");
Console.ReadKey();

public class GameDataParserApp
{
    public void Run()
    {
        bool isFileRead = false;
        string fileContent = "";
        string fileName = "";

        do
        {
            try
            {
                Console.WriteLine("Enter the name of the file you want to read:");
                fileName = Console.ReadLine();
                fileContent = File.ReadAllText(Path.Combine("Resources", fileName));
                isFileRead = true;
            }

            catch (FileNotFoundException ex)
            {
                Console.WriteLine("The file does not exist.");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("The file does not exist.");
            }

            catch (ArgumentNullException ex)
            {
                Console.WriteLine("The file name cannot be null.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("The file name cannot be empty.");
            }




        } while (!isFileRead);
        List<VideoGame> videoGames = new();
        try
        {
            videoGames = JsonSerializer.Deserialize<List<VideoGame>>(fileContent);
        }
        catch (JsonException ex)
        {
            var orginalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"JSON in {fileName} file was not" +
                $"in a valid format. JSON body:");
            Console.WriteLine(fileContent);
            Console.ForegroundColor = orginalColor;

            throw new JsonException($"{ex.Message} the file is :{fileName}", ex);
        }

        if (videoGames.Count > 0)
        {
            Console.WriteLine();
            Console.WriteLine("Loaded games are:");
            foreach (VideoGame game in videoGames)
            {
                Console.WriteLine(game);
            }
        }
        else
        {
            Console.WriteLine("No games are present in the input file.");
        }
    }
}

public class VideoGame
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public decimal Rating { get; set; }

    public override string ToString()
    {
        return $"{Title}, released in {ReleaseYear}, rating: {Rating}";
    }
}
