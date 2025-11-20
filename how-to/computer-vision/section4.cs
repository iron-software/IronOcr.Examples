using System.Linq;
using IronOcr;
namespace IronOcr.Examples.HowTo.ComputerVision
{
    public static class Section4
    {
        public static void Run()
        {
            var ocr = new IronTesseract();
            using var input = new OcrInput();
            input.LoadImage("wh-words-sign.jpg");
            
            // Find the text region using Computer Vision
            Rectangle textCropArea = input.GetPages().First().FindTextRegion();
            
            // For debugging and demonstration purposes, lets see what region it found:
            input.StampCropRectangleAndSaveAs(textCropArea, Color.Red, "image_text_area", AnyBitmap.ImageFormat.Png);
            
            // Looks good, so let us apply this region to hasten the read:
            var ocrResult = ocr.Read("wh-words-sign.jpg", textCropArea);
            Console.WriteLine(ocrResult.Text);
        }
    }
}