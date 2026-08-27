using IronSoftware.Drawing;
using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.InputPdfs
{
    public static class Section4
    {
        public static void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Specify crop regions
            Rectangle[] scanRegions = { new Rectangle(550, 100, 600, 300) };
            
            // Add PDF
            using (var pdfInput = new OcrPdfInput("Potter.pdf", ContentAreas: scanRegions))
            {
                // Perform OCR
                OcrResult ocrResult = ocrTesseract.Read(pdfInput);
            
                // Output the result to console
                Console.WriteLine(ocrResult.Text);
            }
        }
    }
}