using IronOcr;
namespace IronOcr.Examples.HowTo.InputPdfs
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Try IronOCR PDF OCR in One Line
            using var result = new IronOcr.IronTesseract().Read(new IronOcr.OcrPdfInput("document.pdf", PdfContents.TextAndImages));
        }
    }
}