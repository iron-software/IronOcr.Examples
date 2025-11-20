using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.DetectPageRotation
{
    public static class Section3
    {
        public static void Run()
        {
            using var input = new OcrInput();
            
            // Load PDF document
            input.LoadPdf("Clockwise90.pdf");
            
            // Detect page rotation with Fast mode
            var results = input.DetectPageOrientation(OrientationDetectionMode.Fast);
            
            // Ouput result
            foreach(var result in results)
            {
                Console.WriteLine(result.PageNumber);
                Console.WriteLine(result.HighConfidence);
                Console.WriteLine(result.RotationAngle);
            }
        }
    }
}