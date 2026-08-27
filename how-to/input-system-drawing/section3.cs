using IronOcr;
using Image = System.Drawing.Image;
namespace IronOcr.Examples.HowTo.InputSystemDrawing
{
    public static class Section3
    {
        public static void Run()
        {
            
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Open image file as Image
            Image image = Image.FromFile("Potter.tiff");
            
            // Import System.Drawing.Image
            using var imageInput = new OcrImageInput(image);
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
        }
    }
}