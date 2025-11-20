using IronOcr;
namespace IronOcr.Examples.HowTo.SearchablePdf
{
    public static class Section2
    {
        public static void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Enable render as searchable PDF
            ocrTesseract.Configuration.RenderSearchablePdf = true;
            
            // Add image
            using var imageInput = new OcrImageInput("Potter.tiff");
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
            
            // Export as searchable PDF
            ocrResult.SaveAsSearchablePdf("searchablePdf.pdf");
        }
    }
}