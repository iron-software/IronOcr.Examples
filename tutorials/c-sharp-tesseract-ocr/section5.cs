using IronOcr;
namespace IronOcr.Examples.Tutorial.CSharpTesseractOcr
{
    public static class Section5
    {
        public static void Run()
        {
            // Initialize the OCR engine with full IntelliSense support
            var ocr = new IronTesseract();
            
            // Process an image with automatic format detection
            // Handles JPEG, PNG, TIFF, PDF, and more
            var result = ocr.Read("img.png");
            
            // Extract text with confidence metrics
            string extractedText = result.Text;
            Console.WriteLine(extractedText);
            
            // Rich API provides detailed results:
            // - result.Confidence: Overall accuracy percentage
            // - result.Pages: Page-by-page breakdown
            // - result.Paragraphs: Document structure
            // - result.Words: Individual word details
            // - result.Barcodes: Detected barcode values
        }
    }
}