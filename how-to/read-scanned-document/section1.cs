using IronOcr;
namespace IronOcr.Examples.HowTo.ReadScannedDocument
{
    public static class Section1
    {
        public static void Run()
        {
            var text = new IronOcr.IronTesseract().ReadDocument(new IronOcr.OcrInput().LoadPdf("scanned.pdf")).Text;
        }
    }
}