using System.Collections.Generic;
using IronOcr;
namespace IronOcr.Examples.HowTo.InputPdfs
{
    public static class Section3
    {
        public static void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Create page indices list
            List<int> pageIndices = new List<int>() { 0, 2 };
            
            // Add PDF
            using var pdfInput = new OcrPdfInput("Potter.pdf", PageIndices: pageIndices);
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(pdfInput);
        }
    }
}