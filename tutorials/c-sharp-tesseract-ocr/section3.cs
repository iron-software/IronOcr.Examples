using System;
using IronOcr;
namespace IronOcr.Examples.Tutorial.CSharpTesseractOcr
{
    public static class Section3
    {
        public static void Run()
        {
            // Create an instance of the IronTesseract class for OCR processing
            var ocr = new IronTesseract();
            
            // Create an OcrInput object to load and preprocess images
            using var input = new OcrInput();
            
            // Specify which pages to extract from multi-page documents
            var pageIndices = new int[] { 1, 2 };
            
            // Load specific frames from a TIFF file
            // IronOCR automatically detects and handles various image formats
            input.LoadImageFrames(@"img\example.tiff", pageIndices);
            
            // Apply automatic image enhancement filters
            // These filters dramatically improve accuracy on imperfect scans
            input.DeNoise();    // Removes digital artifacts and speckles
            input.Deskew();     // Corrects rotation up to 15 degrees
            
            // Perform OCR with enhanced accuracy algorithms
            OcrResult result = ocr.Read(input);
            
            // Access the extracted text with confidence metrics
            Console.WriteLine(result.Text);
            
            // Additional accuracy features available:
            // - result.Confidence: Overall accuracy percentage
            // - result.Pages[0].Words: Word-level confidence scores
            // - result.Blocks: Structured document layout analysis
        }
    }
}