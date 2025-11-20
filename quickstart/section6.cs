using IronOcr;
namespace IronOcr.Examples.Overview.Quickstart
{
    public static class Section6
    {
        public static void Run()
        {
            IronTesseract ocr = new IronTesseract();
            using OcrInput input = new OcrInput();
            input.Title = "Html Title";
            input.LoadImage("image1.jpeg");
            
            OcrResult Result = ocr.Read(input);
            Result.SaveAsHocrFile("results.html");
        }
    }
}