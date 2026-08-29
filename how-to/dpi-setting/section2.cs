using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.DpiSetting
{
    public static class Section2
    {
        public static void Run()
        {
            var ocrTesseract = new IronTesseract();
            
            using var ocrInput = new OcrInput();
            // Set the target DPI to 300 for better OCR accuracy
            ocrInput.TargetDPI = 300;
            
            ocrInput.LoadImage(@"images\image.png");
            
            // Perform OCR on the image with the specified DPI
            var ocrResult = ocrTesseract.Read(ocrInput);
            // Display the text extracted from the image
            Console.WriteLine(ocrResult.Text);
            // Display the confidence level of the OCR result
            Console.WriteLine(ocrResult.Confidence);
        }
    }
}