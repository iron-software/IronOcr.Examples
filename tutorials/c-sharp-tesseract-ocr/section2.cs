using System;
using IronOcr;
namespace IronOcr.Examples.Tutorial.CSharpTesseractOcr
{
    public static class Section2
    {
        public static void Run()
        {
            // Initialize IronTesseract for performing OCR (Optical Character Recognition)
            var ocr = new IronTesseract
            {
            // Set the language for the OCR process to English
            Language = OcrLanguage.English
            };
            
            // Create a new OCR input that can hold the images to be processed
            using var input = new OcrInput();
            
            // Specify the page indices to be processed from the TIFF image
            var pageIndices = new int[] { 1, 2 };
            
            // Load specific pages of the TIFF image into the OCR input object
            // Perfect for processing large multi-page documents efficiently
            input.LoadImageFrames(@"img\example.tiff", pageIndices);
            
            // Optional pre-processing steps (uncomment as needed)
            // input.DeNoise();  // Remove digital noise from scanned documents
            // input.Deskew();   // Automatically straighten tilted scans
            
            // Perform OCR on the provided input
            OcrResult result = ocr.Read(input);
            
            // Output the recognized text to the console
            Console.WriteLine(result.Text);
            
            // Note: The OcrResult object contains detailed information including:
            // - Individual words with confidence scores
            // - Character positions and bounding boxes
            // - Paragraph and line structure
        }
    }
}