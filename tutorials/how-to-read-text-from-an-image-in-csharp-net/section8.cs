using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section8
    {
        public static void Run()
        {
            // Multi-source document processing
            using IronOcr;
            
            IronTesseract ocr = new IronTesseract();
            
            using (OcrInput input = new OcrInput())
            {
                // Add various image formats
                input.AddImage("image1.jpeg");
                input.AddImage("image2.png");
            
                // Process specific frames from multi-frame images
                int[] frameNumbers = { 1, 2 };
                input.AddImageFrames("image3.gif", frameNumbers);
            
                // Process all sources together
                OcrResult result = ocr.Read(input);
            
                // Verify page count
                Console.WriteLine($"{result.Pages.Count} Pages processed.");
            }
        }
    }
}