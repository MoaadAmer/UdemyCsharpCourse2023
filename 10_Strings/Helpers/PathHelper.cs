namespace _10_Strings.Helpers;

public class PathHelper
{
    public static string GetBinFolderPath()
    {
        return Path.GetDirectoryName(
              System.Reflection.Assembly.GetExecutingAssembly().Location);
    }

}