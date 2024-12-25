using System.Reflection;
using System.Text;

public class UniversalTablePrinter
{
    private readonly IEnumerable<object> _data;
    private const int _columnLength = 20;

    public UniversalTablePrinter(IEnumerable<object> data)
    {
        _data = data;
    }
    public void PrintToConsole()
    {
        object firstElement = _data.First();
        if (firstElement is not null)
        {
            Type type = firstElement.GetType();
            PropertyInfo[] props = type.GetProperties();

            //get table columns name
            StringBuilder columns = new StringBuilder();
            foreach (PropertyInfo prop in props)
            {
                columns.Append($"{prop.Name,-_columnLength}|");
            }
            columns.AppendLine();
            columns.Append(new string('-', (_columnLength + 1) * props.Length));
            Console.WriteLine(columns);

            //get table data
            StringBuilder rows = new StringBuilder();

            foreach (var item in _data)
            {
                foreach (PropertyInfo prop in props)
                {
                    rows.Append($"{prop.GetValue(item),-20}|");
                }
                rows.AppendLine();
            }
            Console.WriteLine(rows);
        }


    }
}