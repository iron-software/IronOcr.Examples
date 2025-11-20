using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section15
    {
        public static void Run()
        {
            // Enable combined text and barcode recognition
            using IronOcr;
            
            var ocr = new IronTesseract();
            
            // Enable barcode detection
            ocr.Configuration.ReadBarCodes = true;
            
            using (var input = new OcrInput())
            {
                // Load image containing both text and barcodes
                input.AddImage("img/Barcode.png");
            
                // Process both text and barcodes
                var result = ocr.Read(input);
            
                // Extract barcode data
                foreach (var barcode in result.Barcodes)
                {
                    Console.WriteLine($"Barcode Value: {barcode.Value}");
                    Console.WriteLine($"Type: {barcode.Type}, Location: {barcode.Location}");
                }
            }
        }
    }
}