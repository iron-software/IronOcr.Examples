using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.FilterWizard
{
    public static class Section3
    {
        public static void Run()
        {
            // Initialize the Tesseract engine
            var ocrTesseract = new IronTesseract();
            
            // Load the image into an OcrInput object
            using (var input = new OcrImageInput("noise.png"))
            {
                // Apply the exact filter chain recommended by the Wizard's output
                input.Invert();
                input.DeNoise();
                input.Contrast();
                input.AdaptiveThreshold();
            
                // Run OCR on the pre-processed image
                OcrResult result = ocrTesseract.Read(input);
            
                // Print the final result and confidence
                Console.WriteLine($"Result: {result.Text}");
                Console.WriteLine($"Confidence: {result.Confidence}");
            }
        }
    }
}