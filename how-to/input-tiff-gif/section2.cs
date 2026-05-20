using IronOcr;
namespace IronOcr.Examples.HowTo.InputTiffGif
{
    public static class Section2
    {
        public static void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Import TIFF/TIF
            using var imageInput = new OcrImageInput("Potter.tiff");
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
        }
    }
}