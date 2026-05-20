using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section9
    {
        public static void Run()
        {
            IronTesseract ocr = new IronTesseract();
            
            using (OcrInput input = new OcrInput())
            {
                // Define pages to process (0-based indexing)
                int[] pageIndices = new int[] { 0, 1 };
            
                // Load specific TIFF frames
                input.LoadImageFrames("MultiFrame.Tiff", pageIndices);
            
                // Extract text from all frames
                OcrResult result = ocr.Read(input);
            
                Console.WriteLine(result.Text);
                Console.WriteLine($"{result.Pages.Count} Pages processed");
            }
        }
    }
}