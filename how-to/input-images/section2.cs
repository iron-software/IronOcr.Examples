using IronOcr;
namespace IronOcr.Examples.HowTo.InputImages
{
    public static class Section2
    {
        public static void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Add image
            using var imageInput = new OcrImageInput("Potter.png");
            
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
        }
    }
}