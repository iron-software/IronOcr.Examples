using IronOcr;
namespace IronOcr.Examples.Tutorial.CSharpTesseractOcr
{
    public static class Section6
    {
        public static void Run()
        {
            // Configure IronTesseract for Arabic text recognition
            var ocr = new IronTesseract
            {
                // Set primary language to Arabic
                // Automatically handles right-to-left text
                Language = OcrLanguage.Arabic
            };
            
            // Load Arabic documents for processing
            using var input = new OcrInput();
            var pageIndices = new int[] { 1, 2 };
            input.LoadImageFrames("img/arabic.gif", pageIndices);
            
            // IronOCR includes specialized preprocessing for Arabic scripts
            // Handles cursive text and diacritical marks automatically
            
            // Perform OCR with language-specific optimizations
            var result = ocr.Read(input);
            
            // Save results with proper Unicode encoding
            // Preserves Arabic text formatting and direction
            result.SaveAsTextFile("arabic.txt");
            
            // Advanced Arabic features:
            // - Mixed Arabic/English document support
            // - Automatic number conversion (Eastern/Western Arabic)
            // - Font-specific optimization for common Arabic typefaces
        }
    }
}