using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section11
    {
        public static void Run()
        {
            IronTesseract ocr = new IronTesseract();
            
            using (OcrInput input = new OcrInput())
            {
                // Set document metadata
                input.Title = "Quarterly Report";
            
                // Combine multiple sources
                input.AddImage("image1.jpeg");
                input.AddImage("image2.png");
            
                // Add specific frames from animated images
                int[] gifFrames = new int[] { 1, 2 };
                input.AddImageFrames("image3.gif", gifFrames);
            
                // Create searchable PDF
                OcrResult result = ocr.Read(input);
                result.SaveAsSearchablePdf("searchable.pdf");
            }
        }
    }
}