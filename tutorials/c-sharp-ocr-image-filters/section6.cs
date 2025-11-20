using System;
using IronOcr;
namespace IronOcr.Examples.Tutorial.CSharpOcrImageFilters
{
    public static class Section6
    {
        public static void Run()
        {
            var image = @"small_barcode.png";
            var ocr = new IronTesseract();
            
            // Optional: This example uses a barcode
            ocr.Configuration.ReadBarCodes = true;
            
            using var input = new OcrInput();
            // Load at least one image
            input.LoadImage(image);
            
            // Apply scale
            input.Scale(400); // 400% is 4 times larger
            
            // Read image into variable: result
            var result = ocr.Read(input);
            
            // Example print to console
            Console.WriteLine(result.Text);
        }
    }
}