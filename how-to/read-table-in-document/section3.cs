using IronOcr.Extension.AdvancedScan;
using System.Linq;
using IronOcr;
namespace IronOcr.Examples.HowTo.ReadTableInDocument
{
    public static class Section3
    {
        public static void Run()
        {
            // Instantiate OCR engine
            var ocr = new IronTesseract();
            
            using var input = new OcrInput();
            input.LoadPdf("invoiceTable.pdf");
            
            // Perform OCR
            var result = ocr.ReadDocumentAdvanced(input);
            
            var cellList = result.Tables.First().CellInfos;
        }
    }
}