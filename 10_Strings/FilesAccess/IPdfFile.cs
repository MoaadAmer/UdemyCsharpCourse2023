namespace _10_Strings.FilesAccess
{
    public interface IPdfFile
    {
        string ReadPage(string filePath, int pageNumber);
    }
}