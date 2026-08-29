using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section10
    {
        public static void Run()
        {
            IronTesseract ocr = new IronTesseract();
            
            using (OcrInput input = new OcrInput())
            {
                try
                {
                    // Load password-protected PDF if needed
                    input.LoadPdf("example.pdf", Password: "password");
            
                    // Process entire document
                    OcrResult result = ocr.Read(input);
            
                    Console.WriteLine(result.Text);
                    Console.WriteLine($"{result.Pages.Count} Pages recognized");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing PDF: {ex.Message}");
                }
            }
        }
    }
}