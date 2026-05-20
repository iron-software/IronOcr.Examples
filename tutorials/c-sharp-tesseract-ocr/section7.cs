using IronOcr;
namespace IronOcr.Examples.Tutorial.CSharpTesseractOcr
{
    public static class Section7
    {
        public static void Run()
        {
            // Install language packs via NuGet:
            // PM> Install-Package IronOcr.Languages.ChineseSimplified
            
            // Configure multi-language OCR
            var ocr = new IronTesseract();
            
            // Set primary language for majority content
            ocr.Language = OcrLanguage.ChineseSimplified;
            
            // Add secondary language for mixed content
            // Perfect for documents with Chinese text and English metadata
            ocr.AddSecondaryLanguage(OcrLanguage.English);
            
            // Process multi-language PDFs efficiently
            using var input = new OcrInput();
            input.LoadPdf("multi-language.pdf");
            
            // IronOCR automatically detects and switches between languages
            // Maintains high accuracy across language boundaries
            var result = ocr.Read(input);
            
            // Export preserves all languages correctly
            result.SaveAsTextFile("results.txt");
            
            // Supported scenarios:
            // - Technical documents with English terms in foreign text
            // - Multilingual forms and applications  
            // - International business documents
            // - Mixed-script content (Latin, CJK, Arabic, etc.)
        }
    }
}