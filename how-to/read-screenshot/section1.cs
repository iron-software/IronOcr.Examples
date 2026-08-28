using IronOcr;
namespace IronOcr.Examples.HowTo.ReadScreenshot
{
    public static class Section1
    {
        public static void Run()
        {
            using var input = new OcrInput();
            input.LoadImage("screenshot.png");
            OcrPhotoResult result = new IronTesseract().ReadScreenShot(input);
        }
    }
}