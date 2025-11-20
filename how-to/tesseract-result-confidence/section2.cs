using IronOcr;
namespace IronOcr.Examples.HowTo.TesseractResultConfidence
{
    public static class Section2
    {
        public static void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Add image
            using var imageInput = new OcrImageInput("sample.tiff");
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
            
            // Get confidence level
            double confidence = ocrResult.Confidence;
        }
    }
}