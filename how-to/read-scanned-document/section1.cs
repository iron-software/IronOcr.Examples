using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.ReadScannedDocument
{
    public static class Section1
    {
        public static void Run()
        {
            // Instantiate OCR engine
            var ocr = new IronTesseract();
            
            // Configure OCR engine
            using var input = new OcrInput();
            input.LoadImage("potter.tiff");
            
            // Perform OCR
            OcrResult result = ocr.ReadDocument(input);
            
            Console.WriteLine(result.Text);
        }
    }
}