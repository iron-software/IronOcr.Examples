using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section13
    {
        public static void Run()
        {
            var ocr = new IronTesseract();
            
            using (var input = new OcrInput())
            {
                // Configure document properties
                input.Title = "Scanned Archive Document";
            
                // Select pages to process
                var pageIndices = new int[] { 1, 2 };
                input.LoadImageFrames("example.tiff", pageIndices);
            
                // Create searchable PDF from TIFF
                OcrResult result = ocr.Read(input);
                result.SaveAsSearchablePdf("searchable.pdf");
            }
        }
    }
}