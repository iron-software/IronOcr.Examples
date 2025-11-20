using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section4
    {
        public static void Run()
        {
            // Advanced Iron Tesseract C# example for low-quality images
            using IronOcr;
            using System;
            
            var ocr = new IronTesseract();
            
            try
            {
                using (var input = new OcrInput())
                {
                    // Load specific pages from poor-quality TIFF
                    var pageIndices = new int[] { 0, 1 };
                    input.LoadImageFrames(@"img\Potter.LowQuality.tiff", pageIndices);
            
                    // Apply deskew filter to correct rotation and perspective
                    input.Deskew(); // Critical for improving accuracy on skewed scans
            
                    // Perform OCR with enhanced preprocessing
                    OcrResult result = ocr.Read(input);
            
                    // Display results
                    Console.WriteLine("Recognized Text:");
                    Console.WriteLine(result.Text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during OCR: {ex.Message}");
            }
        }
    }
}