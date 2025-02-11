namespace _10_Strings.FilesAccess;

public class FileWriter : IFileWriter
    {
        public void Write(string content, params string[] pathParts)
        {
            File.WriteAllText(Path.Combine(pathParts), content);
        }
    }