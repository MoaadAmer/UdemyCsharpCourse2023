using UglyToad.PdfPig.Content;
using UglyToad.PdfPig;

namespace _10_Strings.PDF;

public class PigPdfFile : IPdfFile
{

    public string ReadPage(string filePath, int pageNumber)
    {
        using PdfDocument document = PdfDocument.Open(filePath);
        Page page = document.GetPage(1);
        return page.Text;
    }
}