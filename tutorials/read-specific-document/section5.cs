using IronSoftware.Drawing;
using IronOcr;
namespace IronOcr.Examples.Tutorial.ReadSpecificDocument
{
    public static class Section5
    {
        public static void Run()
        {
            // Instantiate OCR engine
            var ocr = new IronTesseract();
            
            using var inputPhoto = new OcrInput();
            inputPhoto.LoadImageFrame("photo.tif", 2);
            
            // Perform OCR
            OcrPhotoResult result = ocr.ReadPhoto(inputPhoto);
            
            // index number refer to region order in the page
            int number = result.TextRegions[0].PageNumber;
            string textinregion = result.TextRegions[0].TextInRegion;
            Rectangle region = result.TextRegions[0].Region;
        }
    }
}