using System.Reflection;
namespace _08_AdvancedTypes.Utilities;
public class UniversalTablePrinter
{
    private const int _columnWidth = 15;

    public static void PrintToConsole<T>(IEnumerable<T> data)
    {
        PropertyInfo[] properties = typeof(T).GetProperties();

        //Print table columns name
        foreach (PropertyInfo prop in properties)
        {
            Console.Write($"{prop.Name,-_columnWidth}|");
        }
        Console.WriteLine();
        Console.Write(new string('-', (_columnWidth + 1) * properties.Length));
        Console.WriteLine();

        //Print table data
        foreach (var item in data)
        {
            foreach (PropertyInfo property in properties)
            {
                Console.Write($"{property.GetValue(item),-_columnWidth}|");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}