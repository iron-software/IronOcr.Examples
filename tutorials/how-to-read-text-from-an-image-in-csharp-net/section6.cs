using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section6
    {
        public static void Run()
        {
            // Install-Package IronOcr.Languages.Arabic
            
            // Configure for Arabic language OCR
            var ocr = new IronTesseract();
            ocr.Language = OcrLanguage.Arabic;
            
            using (var input = new OcrInput())
            {
                // Load Arabic text image
                input.AddImage("img/arabic.gif");
                
                // IronOCR handles low-quality Arabic text that standard Tesseract cannot
                var result = ocr.Read(input);
            
                // Save to file (console may not display Arabic correctly)
                result.SaveAsTextFile("arabic.txt");
            }
        }
    }
}