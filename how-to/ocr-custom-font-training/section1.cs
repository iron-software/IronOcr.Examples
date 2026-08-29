using IronOcr;
namespace IronOcr.Examples.HowTo.OcrCustomFontTraining
{
    public static class Section1
    {
        public static void Run()
        {
            var ocr = new IronOcr.IronTesseract();
            ocr.UseCustomTesseractLanguageFile("path/to/YourCustomFont.traineddata");
            string text = ocr.Read(new IronOcr.OcrInput("image-with-special-font.png")).Text;
        }
    }
}