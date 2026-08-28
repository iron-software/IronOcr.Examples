using IronOcr;
namespace IronOcr.Examples.HowTo.ComputerVision
{
    public static class Section3
    {
        public static void Run()
        {
            var ocr = new IronTesseract();
            using var input = new OcrInput();
            input.LoadImage("/path/file.png");
            
            input.FindTextRegion();
            OcrResult result = ocr.Read(input);
            string resultText = result.Text;
        }
    }
}