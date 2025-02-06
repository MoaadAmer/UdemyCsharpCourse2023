namespace _10_Strings.PDF
{
    public interface IPdfFile
    {
        string ReadPage(string filePath, int pageNumber);
    }
}