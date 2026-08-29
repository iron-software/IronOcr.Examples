using IronSoftware.Drawing;
using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.ImageColorCorrection
{
    public static class Section6
    {
        public static void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Add image
            using var imageInput = new OcrImageInput("sample.jpg");
            // Text color to focus on
            IronSoftware.Drawing.Color focusColor = new IronSoftware.Drawing.Color("#DB645C");
            
            // Specify which text color to read
            imageInput.SelectTextColor(focusColor, 60);
            
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
            
            // Output result to console
            Console.WriteLine(ocrResult.Text);
        }
    }
}