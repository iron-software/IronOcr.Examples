using IronOcr;
namespace IronOcr.Examples.HowTo.ReadScannedDocument
{
    public static class Section1
    {
        public static void Run()
        {
            using var input = new OcrInput();
            input.LoadPdf("scanned.pdf");
            var text = new IronOcr.IronTesseract().ReadDocument(input).Text;
        }
    }
}