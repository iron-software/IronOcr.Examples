using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section12
    {
        public static void Run()
        {
            var ocr = new IronTesseract();
            
            using (var input = new OcrInput())
            {
                // Set PDF metadata
                input.Title = "Annual Report 2024";
            
                // Process existing PDF
                input.LoadPdf("example.pdf", "password");
            
                // Generate searchable version
                var result = ocr.Read(input);
                result.SaveAsSearchablePdf("searchable.pdf");
            }
        }
    }
}