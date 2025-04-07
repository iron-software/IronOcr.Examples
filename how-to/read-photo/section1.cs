using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.ReadPhoto
{
    public static class Section1
    {
        public static void Run()
        {
            // Instantiate OCR engine
            var ocr = new IronTesseract();
            
            using var inputPhoto = new OcrInput();
            inputPhoto.LoadImageFrame("ocr.tiff", 0);
            
            // Read photo
            OcrPhotoResult result = ocr.ReadPhoto(inputPhoto);
            
            // Index number refer to region order in the page
            int number = result.TextRegions[0].FrameNumber;
            
            // Extract the text in the first region
            string textinregion = result.TextRegions[0].TextInRegion;
            
            //Extract the co_ordinates of the first text region
            Rectangle region = result.TextRegions[0].Region;
            
            var output = $"Text in First Region: {textinregion}\n"
                         + $"Text Region:\n"
                         + $"Starting X: {region.X}\n"
                         + $"Starting Y: {region.Y}\n"
                         + $"Region Width: {region.Width}\n"
                         + $"Region Height: {region.Height}\n"
                         + $"Result Confidence: {result.Confidence}\n\n"
                         + $"Full Scnned Photo Text: {result.Text}";
            
            Console.WriteLine(output);
        }
    }
}