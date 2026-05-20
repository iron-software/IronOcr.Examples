using System;
using IronOcr;
namespace IronOcr.Examples.Tutorial.CSharpOcrImageFilters
{
    public static class Section8
    {
        public static void Run()
        {
            var image = @"before-invert.png";
            var ocr = new IronTesseract();
            
            using var input = new OcrInput();
            // Load at least one image
            input.LoadImage(image);
            
            // Apply Invert
            input.Invert(true);
            
            // Read image into variable: result
            var result = ocr.Read(input);
            
            // Example print to console
            Console.WriteLine(result.Text);
        }
    }
}