using IronOcr;
namespace IronOcr.Examples.HowTo.InputTiffGif
{
    public static class Section3
    {
        public static void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Import GIF
            using var imageInput = new OcrImageInput("Potter.gif");
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
        }
    }
}