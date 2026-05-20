using IronSoftware.Drawing;
using IronOcr;
namespace IronOcr.Examples.HowTo.OcrRegionOfAnImage
{
    public static class Section2
    {
        public static void Run()
        {
            var ocrTesseract = new IronTesseract();
            using var ocrInput = new OcrInput();
            
            // Define the specific rectangular area to scan within the image.
            // The coordinates are in pixels: (x, y) is the top-left corner of the rectangle.
            var ContentArea = new Rectangle(x: 4, y: 59, width: 365, height: 26);
            
            ocrInput.LoadImage("region-input.png", ContentArea);
            
            var ocrResult = ocrTesseract.Read(ocrInput);
            
            // Draws the rectangle from above in a blue bounding box on the image for visualization.
            ocrInput.StampCropRectangleAndSaveAs(ContentArea, Color.Aqua, "region-input.png");
        }
    }
}