using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.FilterWizard
{
    public static class Section2
    {
        public static void Run()
        {
            // Initialize the Tesseract engine
            var ocr = new IronTesseract();
            
            // 1. Pass the image path ("noise.png").
            // 2. Pass an 'out' variable to store the best confidence score found.
            // 3. Pass the tesseract instance to be used for testing.
            string codeToRun = OcrInputFilterWizard.Run("noise.png", out double confidence, ocr);
            
            // The 'confidence' variable is now populated with the highest score achieved.
            Console.WriteLine($"Best Confidence Score: {confidence}");
            
            // 'codeToRun' holds the exact C# code snippet that achieved this score.
            // The returned string is the code you can use to filter similar images.
            Console.WriteLine("Recommended Filter Code:");
            Console.WriteLine(codeToRun);
        }
    }
}