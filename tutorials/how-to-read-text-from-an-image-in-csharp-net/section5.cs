using IronSoftware.Drawing;
using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section5
    {
        public static void Run()
        {
            // Initialize OCR engine for targeted region processing
            var ocr = new IronTesseract();
            
            using (var input = new OcrInput())
            {
                // Define exact region for OCR - coordinates in pixels
                var contentArea = new System.Drawing.Rectangle(
                    x: 215, 
                    y: 1250, 
                    width: 1335, 
                    height: 280
                );
            
                // Load image with specific area - perfect for forms and invoices
                input.AddImage("img/ComSci.png", contentArea);
            
                // Process only the defined region
                OcrResult result = ocr.Read(input);
                Console.WriteLine(result.Text);
            }
        }
    }
}