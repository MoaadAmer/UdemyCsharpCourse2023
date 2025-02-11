namespace _10_Strings.FilesAccess;

public interface IFileWriter
{
    public void Write(string content, params string[] pathParts);

}