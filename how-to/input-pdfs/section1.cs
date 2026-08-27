using IronOcr;
namespace IronOcr.Examples.HowTo.InputPdfs
{
    public static class Section1
    {
        public static void Run()
        {
            using var result = new IronOcr.IronTesseract().Read(new IronOcr.OcrPdfInput("document.pdf", PdfContents.TextAndImages));
        }
    }
}