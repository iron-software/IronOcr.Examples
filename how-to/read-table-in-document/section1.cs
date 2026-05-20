using IronOcr;
namespace IronOcr.Examples.HowTo.ReadTableInDocument
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Start Extracting Tables Fast with IronOCR
            var cells = new IronTesseract().ReadDocumentAdvanced(new OcrInput().LoadPdf("invoiceTable.pdf")).Tables.First().CellInfos;
        }
    }
}