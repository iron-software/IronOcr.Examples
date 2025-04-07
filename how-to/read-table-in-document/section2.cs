using System.Linq;
using IronOcr;
namespace IronOcr.Examples.HowTo.ReadTableInDocument
{
    public static class Section2
    {
        public static void Run()
        {
            // Instantiate OCR engine
            var ocr = new IronTesseract();
            
            using var input = new OcrInput();
            input.LoadPdf("table.pdf");
            
            // Perform OCR
            var result = ocr.ReadDocumentAdvanced(input);
            
            var cellList = result.Tables.First().CellInfos;
        }
    }
}