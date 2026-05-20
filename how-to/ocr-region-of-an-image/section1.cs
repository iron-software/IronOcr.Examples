using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.OcrRegionOfAnImage
{
    public static class Section1
    {
        public static void Run()
        {
            var ocrTesseract = new IronTesseract();
            using var ocrInput = new OcrInput();
            
            // Define the specific region as a Rectangle
            // (x, y) is the top-left corner.
            var ContentArea = new Rectangle(x: 215, y: 1250, width: 1335, height: 280);
            
            ocrInput.LoadImage("region-input.png", ContentArea);
            
            var ocrResult = ocrTesseract.Read(ocrInput);
            
            // Print the extracted text
            Console.WriteLine(ocrResult.Text);
        }
    }
}