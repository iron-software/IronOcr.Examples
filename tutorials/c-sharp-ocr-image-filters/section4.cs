using System;
using IronOcr;
namespace IronOcr.Examples.Tutorial.CSharpOcrImageFilters
{
    public static class Section4
    {
        public static void Run()
        {
            var image = "screenshot.png";
            var ocr = new IronTesseract();
            using var input = new OcrInput();
            // Load at least one image
            input.LoadImage(image);
            
            // Rotate 180 degrees because image is upside-down
            input.Rotate(180);
            
            // Read image into variable: result
            var result = ocr.Read(input);
            
            // Example print to console
            Console.WriteLine(result.Text);
        }
    }
}