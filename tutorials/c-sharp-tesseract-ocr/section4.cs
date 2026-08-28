using System;
using IronOcr;
namespace IronOcr.Examples.Tutorial.CSharpTesseractOcr
{
    public static class Section4
    {
        public static void Run()
        {
            // Initialize IronTesseract for OCR operations
            var ocr = new IronTesseract();
            
            // Create an OcrInput container for multiple sources
            using var input = new OcrInput();
            
            // Load password-protected PDFs seamlessly
            // IronOCR handles PDF rendering internally
            input.LoadPdf("example.pdf", Password: "password");
            
            // Process specific pages from multi-page TIFFs
            // Perfect for batch document processing
            var pageIndices = new int[] { 1, 2 };
            input.LoadImageFrames("multi-frame.tiff", pageIndices);
            
            // Add individual images in any common format
            // Automatic format detection and conversion
            input.LoadImage("image1.png");
            input.LoadImage("image2.jpeg");
            
            // Process all loaded content in a single operation
            // Results maintain document structure and ordering
            var result = ocr.Read(input);
            
            // Extract text while preserving document layout
            Console.WriteLine(result.Text);
            
            // Advanced features for complex documents:
            // - Extract images from specific PDF pages
            // - Process only certain regions of images
            // - Maintain reading order across mixed formats
        }
    }
}