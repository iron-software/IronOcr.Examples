using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.OcrMultipleLanguages
{
    public static class Section2
    {
        public static void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Set secondary language to Russian
            ocrTesseract.AddSecondaryLanguage(OcrLanguage.Russian);
            
            // Add PDF
            using var pdfInput = new OcrPdfInput(@"example.pdf");
            // Perform OCR
            OcrResult result = ocrTesseract.Read(pdfInput);
            
            // Output extracted text to console
            Console.WriteLine(result.Text);
        }
    }
}