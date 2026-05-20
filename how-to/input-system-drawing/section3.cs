using IronOcr;
namespace IronOcr.Examples.HowTo.InputSystemDrawing
{
    public static class Section3
    {
        public static void Run()
        {
            using Image = System.Drawing.Image;
            
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