using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section3
    {
        public static void Run()
        {
            // Initialize IronTesseract for advanced OCR operations
            IronTesseract ocr = new IronTesseract();
            
            // Create input container for processing multiple images
            using (OcrInput input = new OcrInput())
            {
                // Process specific pages from multi-page TIFF files
                int[] pageIndices = new int[] { 1, 2 };
            
                // Load TIFF frames - perfect for scanned documents
                input.LoadImageFrames(@"img\Potter.tiff", pageIndices);
            
                // Execute OCR to read text from image using IronOCR
                OcrResult result = ocr.Read(input);
            
                // Output the extracted text
                Console.WriteLine(result.Text);
            }
        }
    }
}