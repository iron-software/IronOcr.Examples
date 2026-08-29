using IronOcr;
namespace IronOcr.Examples.HowTo.InputPdfs
{
    public static class Section2
    {
        public static void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Add PDF
            using var pdfInput = new OcrPdfInput("Potter.pdf");
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(pdfInput);
        }
    }
}