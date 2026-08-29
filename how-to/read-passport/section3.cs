using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.ReadPassport
{
    public static class Section3
    {
        public static void Run()
        {
            // Instantiate OCR engine
            var ocr = new IronTesseract();
            
            using var inputPassport = new OcrInput();
            
            inputPassport.LoadImage("passport.jpg");
            
            // Perform OCR
            OcrPassportResult result = ocr.ReadPassport(inputPassport);
            
            // Output Confidence level and raw extracted text
            Console.WriteLine(result.Confidence);
            Console.WriteLine(result.Text);
        }
    }
}