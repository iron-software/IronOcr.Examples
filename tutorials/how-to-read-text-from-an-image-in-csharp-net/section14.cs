using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section14
    {
        public static void Run()
        {
            var ocr = new IronTesseract();
            
            using (var input = new OcrInput())
            {
                // Set HTML title
                input.Title = "Document Archive";
            
                // Process multiple document types
                input.AddImage("image2.jpeg");
                input.AddPdf("example.pdf", "password");
            
                // Add TIFF pages
                var pageIndices = new int[] { 1, 2 };
                input.AddTiff("example.tiff", pageIndices);
            
                // Export as HOCR with position data
                OcrResult result = ocr.Read(input);
                result.SaveAsHocrFile("hocr.html");
            }
        }
    }
}