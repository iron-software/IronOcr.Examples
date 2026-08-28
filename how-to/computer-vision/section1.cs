using IronOcr;
namespace IronOcr.Examples.HowTo.ComputerVision
{
    public static class Section1
    {
        public static void Run()
        {
            using var input = new OcrInput();
            input.LoadImage("image.png");
            input.FindTextRegion();
            var result = new IronTesseract().Read(input);
        }
    }
}