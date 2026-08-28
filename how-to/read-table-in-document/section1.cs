using IronOcr.Extension.AdvancedScan;
using IronOcr;
namespace IronOcr.Examples.HowTo.ReadTableInDocument
{
    public static class Section1
    {
        public static void Run()
        {
            using var input = new OcrInput();
            input.LoadPdf("invoiceTable.pdf");
            var cells = new IronTesseract().ReadDocumentAdvanced(input).Tables.First().CellInfos;
        }
    }
}