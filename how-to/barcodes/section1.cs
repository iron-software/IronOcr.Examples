using IronOcr;
namespace IronOcr.Examples.HowTo.Barcodes
{
    public static class Section1
    {
        public static void Run()
        {
            var result = new IronOcr.IronTesseract() { Configuration = new IronOcr.TesseractConfiguration { ReadBarCodes = true } }.Read(new IronOcr.OcrPdfInput("document.pdf"));
            foreach(var bc in result.Barcodes) Console.WriteLine(bc.Value);
        }
    }
}