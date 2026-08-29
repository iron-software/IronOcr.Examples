using System.IO;
using IronOcr;
namespace IronOcr.Examples.HowTo.OcrCustomLanguage
{
    public static class Section1
    {
        public static void Run()
        {
            var ocrTesseract = new IronTesseract();
            
            // Load the traineddata file for the custom language
            ocrTesseract.UseCustomTesseractLanguageFile("AMGDT.traineddata");
            
            using var ocrInput = new OcrInput();
            // Load the PDF containing text in the custom language
            ocrInput.LoadPdf("custom.pdf");
            
            var ocrResult = ocrTesseract.Read(ocrInput);
            
            // Print text to the console
            Console.WriteLine("--- OCR Result ---");
            Console.WriteLine(ocrResult.Text);
            Console.WriteLine("------------------");
            
            // Pipe text to a .txt file
            string outputFilePath = "ocr_output.txt";
            File.WriteAllText(outputFilePath, ocrResult.Text);
            
            Console.WriteLine($"\nSuccessfully saved text to {outputFilePath}");
        }
    }
}