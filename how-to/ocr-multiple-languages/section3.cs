using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.OcrMultipleLanguages
{
    public static class Section3
    {
        public static void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Set primary language to Hindi
            ocrTesseract.Language = OcrLanguage.Russian;
            ocrTesseract.AddSecondaryLanguage(OcrLanguage.Japanese);
            
            // Add image
            using var imageInput = new OcrImageInput(@"example.png");
            // Perform OCR
            OcrResult result = ocrTesseract.Read(imageInput);
            
            // Output extracted text to console
            Console.WriteLine(result.Text);
        }
    }
}