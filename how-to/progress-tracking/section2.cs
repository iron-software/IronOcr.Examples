using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.ProgressTracking
{
    public static class Section2
    {
        public static void Run()
        {
            var ocrTesseract = new IronTesseract();
            
            // Subscribe to OcrProgress event
            ocrTesseract.OcrProgress += (_, ocrProgressEventsArgs) =>
            {
                Console.WriteLine("Start time: " + ocrProgressEventsArgs.StartTimeUTC.ToString());
                Console.WriteLine("Total pages number: " + ocrProgressEventsArgs.TotalPages);
                Console.WriteLine("Progress(%) | Duration");
                Console.WriteLine("    " + ocrProgressEventsArgs.ProgressPercent + "%     | " + ocrProgressEventsArgs.Duration.TotalSeconds + "s");
                Console.WriteLine("End time: " + ocrProgressEventsArgs.EndTimeUTC.ToString());
                Console.WriteLine("----------------------------------------------");
            };
            
            using var input = new OcrInput();
            input.LoadPdf("Experiences-in-Biodiversity-Research-A-Field-Course.pdf");
            
            // Progress events will fire during the read operation
            var result = ocrTesseract.Read(input);
        }
    }
}