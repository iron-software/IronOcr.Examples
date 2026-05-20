using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.ReadMicrCheque
{
    public static class Section2
    {
        public static void Run()
        {
            // Create a new instance of IronTesseract for performing OCR operations
            IronTesseract ocr = new IronTesseract();
            
            // Set the OCR language to MICR to recognize magnetic ink characters
            // Must have MICR (IronOcr.Languages.MICR) installed beforehand
            ocr.Language = OcrLanguage.MICR;
            
            // Specify the file path of the input image containing MICR text
            using (var input = new OcrInput())
            {
                // Specify the MICR of the image to focus on for OCR (coordinates in pixels)
                var contentArea = new Rectangle(x: 215, y: 482, width: 520, height: 20);
                input.LoadImage("micr.png", contentArea);
            
                // Optional: Save the cropped area for verification
                input.StampCropRectangleAndSaveAs(contentArea, Color.Aqua, "cropped.png");
            
                // Run the OCR engine to read the MICR text from the input image
                var result = ocr.Read(input);
                // Output the recognized text to the console
                Console.WriteLine(result.Text);
            
                // Transit number is the first 7 characters of the MICR string
                string transitNum = result.Text.Substring(0, 7);
                // Routing number starts from the 8th character and is 11 characters long
                string routingNum = result.Text.Substring(7, 11);
                // Account number starts from the 22nd character to the end of the string
                string accountNum = result.Text.Substring(22);
            }
        }
    }
}