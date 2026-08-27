using IronSoftware.Drawing;
using IronOcr;
namespace IronOcr.Examples.HowTo.ImageColorCorrection
{
    public static class Section5
    {
        public static void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Add image
            using var imageInput = new OcrImageInput("sample.jpg");
            IronSoftware.Drawing.Color currentColor = new IronSoftware.Drawing.Color("#DB645C");
            IronSoftware.Drawing.Color newColor = IronSoftware.Drawing.Color.DarkCyan;
            
            // Replace color
            imageInput.ReplaceColor(currentColor, newColor, 80);
            
            // Export the modified image
            imageInput.SaveAsImages("replaceColor");
        }
    }
}