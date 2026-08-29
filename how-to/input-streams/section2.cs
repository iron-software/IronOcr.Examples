using IronSoftware.Drawing;
using IronOcr;
namespace IronOcr.Examples.HowTo.InputStreams
{
    public static class Section2
    {
        public static void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Read image file to AnyBitmap
            AnyBitmap anyBitmap = AnyBitmap.FromFile("Potter.tiff");
            
            // Import image stream
            using var imageInput = new OcrImageInput(anyBitmap.GetStream());
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
        }
    }
}