using IronOcr.Extension.AdvancedScan;
using IronOcr;
namespace IronOcr.Examples.HowTo.ReadTableInDocument
{
    public static class Section1
    {
        public static void Run()
        {
            var cells = new IronTesseract().ReadDocumentAdvanced(new OcrInput().LoadPdf("invoiceTable.pdf")).Tables.First().CellInfos;
        }
    }
}