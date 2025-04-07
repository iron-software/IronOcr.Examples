using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.ReadLicensePlate
{
    public static class Section1
    {
        public static void Run()
        {
            var ocr = new IronTesseract();
            ocr.Configuration.WhiteListCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";
            
            using var inputLicensePlate = new OcrInput();
            inputLicensePlate.LoadImage("plate.jpeg");
            
            // Read license plate
            OcrLicensePlateResult result = ocr.ReadLicensePlate(inputLicensePlate);
            
            // Retrieve license plate number and confidence value
            string output = $"{result.Text}\nResult Confidence: {result.Confidence}";
            
            Console.WriteLine(output);
        }
    }
}