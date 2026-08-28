using static IronOcr.OcrResult;
using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.ReadResults
{
    public static class Section3
    {
        public static void Run()
        {
            
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Enable barcodes detection
            ocrTesseract.Configuration.ReadBarCodes = true;
            
            // Add image
            using OcrInput ocrInput = new OcrInput();
            ocrInput.LoadPdf("sample.pdf");
            
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(ocrInput);
            
            // Output information to console
            foreach(var barcode in ocrResult.Barcodes)
            {
                Console.WriteLine("Format = " + barcode.Format);
                Console.WriteLine("Value = " + barcode.Value);
                Console.WriteLine("X = " + barcode.X);
                Console.WriteLine("Y = " + barcode.Y);
            }
            Console.WriteLine(ocrResult.Text);
        }
    }
}