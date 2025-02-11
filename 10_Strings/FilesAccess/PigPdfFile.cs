using UglyToad.PdfPig.Content;
using UglyToad.PdfPig;

namespace _10_Strings.FilesAccess;

public class PigPdfFile : IPdfFile
{

    public string ReadPage(string filePath, int pageNumber)
    {
        using PdfDocument document = PdfDocument.Open(filePath);
        Page page = document.GetPage(pageNumber);
        return page.Text;
    }
}