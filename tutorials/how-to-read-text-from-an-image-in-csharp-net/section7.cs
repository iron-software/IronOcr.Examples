using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section7
    {
        public static void Run()
        {
            // Multi-language OCR configuration
            using IronOcr;
            
            var ocr = new IronTesseract();
            
            // Set primary language
            ocr.Language = OcrLanguage.ChineseSimplified;
            
            // Add secondary languages as needed
            ocr.AddSecondaryLanguage(OcrLanguage.English);
            
            // Custom .traineddata files can be added for specialized recognition
            // ocr.AddSecondaryLanguage("path/to/custom.traineddata");
            
            using (var input = new OcrInput())
            {
                // Process multi-language document
                input.AddImage("img/MultiLanguage.jpeg");
                
                var result = ocr.Read(input);
                result.SaveAsTextFile("MultiLanguage.txt");
            }
        }
    }
}