using System.IO;
using IronOcr;
namespace IronOcr.Examples.HowTo.InputImages
{
    public static class Section3
    {
        public static void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Read byte from file
            byte[] data = File.ReadAllBytes("Potter.tiff");
            
            // Import image byte
            using var imageInput = new OcrImageInput(data);
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
        }
    }
}