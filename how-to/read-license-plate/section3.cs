using IronSoftware.Drawing;
using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.ReadLicensePlate
{
    public static class Section3
    {
        public static void Run()
        {
            var ocr = new IronTesseract();
            using var inputLicensePlate = new OcrInput();
            inputLicensePlate.LoadImage("car_license.jpg");
            
            // Read license plate
            OcrLicensePlateResult result = ocr.ReadLicensePlate(inputLicensePlate);
            
            // Retrieve license plate coordinates
            RectangleF rectangle = result.Licenseplate;
            
            // Write license plate value and coordinates in a string
            string output = $"License Plate Number:\n{result.Text}\n\n"
                          + $"License Plate Area_\n"
                          + $"Starting X: {rectangle.X}\n"
                          + $"Starting Y: {rectangle.Y}\n"
                          + $"Width: {rectangle.Width}\n"
                          + $"Height: {rectangle.Height}";
            
            Console.WriteLine(output);
        }
    }
}