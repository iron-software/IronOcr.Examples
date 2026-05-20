using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.IronTesseract
{
    public static class Section5
    {
        public static void Run()
        {
            IronTesseract Ocr = new IronTesseract();
            
            Ocr.Language = OcrLanguage.English;
            Ocr.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.AutoOsd;
            
            // Configure Tesseract Engine
            Ocr.Configuration.TesseractVariables["tessedit_parallelize"] = false;
            
            using var input = new OcrInput();
            input.LoadImage("/path/file.png");
            
            OcrResult Result = Ocr.Read(input);
            Console.WriteLine(Result.Text);
        }
    }
}