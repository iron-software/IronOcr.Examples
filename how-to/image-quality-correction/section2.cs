using IronOcr;
namespace IronOcr.Examples.HowTo.ImageQualityCorrection
{
    public static class Section2
    {
        public static void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Add image
            using var imageInput = new OcrImageInput("sample.jpg");
            // Apply sharpen filter
            imageInput.Sharpen();
            
            // Export filtered image
            imageInput.SaveAsImages("sharpen.jpg");
        }
    }
}