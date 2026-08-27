using IronOcr;
namespace IronOcr.Examples.HowTo.ReadScreenshot
{
    public static class Section1
    {
        public static void Run()
        {
            OcrPhotoResult result = new IronTesseract().ReadScreenShot(new OcrInput().LoadImage("screenshot.png"));
        }
    }
}