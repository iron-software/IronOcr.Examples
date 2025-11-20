using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.InputImages
{
    public static class Section4
    {
        public static void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Specify crop region
            Rectangle scanRegion = new Rectangle(800, 200, 900, 400);
            
            // Add image
            using var imageInput = new OcrImageInput("Potter.tiff", ContentArea: scanRegion);
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
            
            // Output the result to console
            Console.WriteLine(ocrResult.Text);
        }
    }
}