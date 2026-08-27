using IronOcr;
namespace IronOcr.Examples.HowTo.ComputerVision
{
    public static class Section1
    {
        public static void Run()
        {
            using var result = new IronTesseract().Read(new OcrInput().LoadImage("image.png").FindTextRegion());
        }
    }
}