using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section2
    {
        public static void Run()
        {
            // Basic C# OCR image to text conversion using IronOCR
            // This example shows how to extract text from images without complex setup
            
            using IronOcr;
            using System;
            
            try
            {
                // Initialize IronTesseract for OCR operations
                var ocrEngine = new IronTesseract();
            
                // Path to your image file - supports PNG, JPG, TIFF, BMP, and more
                var imagePath = @"img\Screenshot.png";
            
                // Create input and perform OCR to convert image to text
                using (var input = new OcrInput(imagePath))
                {
                    // Read text from image and get results
                    OcrResult result = ocrEngine.Read(input);
            
                    // Display extracted text
                    Console.WriteLine(result.Text);
                }
            }
            catch (OcrException ex)
            {
                // Handle OCR-specific errors
                Console.WriteLine($"OCR Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle general errors
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}