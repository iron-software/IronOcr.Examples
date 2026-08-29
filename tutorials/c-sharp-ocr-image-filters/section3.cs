using System;
using IronOcr;
namespace IronOcr.Examples.Tutorial.CSharpOcrImageFilters
{
    public static class Section3
    {
        public static void Run()
        {
            var file = "skewed_image.tiff";
            var ocr = new IronTesseract();
            using var input = new OcrInput();
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames(file, pageindices);
            // Here we apply the filter: Deskew
            input.Deskew();
            
            // Save the input with filter(s) applied
            input.SaveAsImages("my_deskewed");
            
            // We read, then print the text to the console
            var result = ocr.Read(input);
            Console.WriteLine(result.Text);
        }
    }
}