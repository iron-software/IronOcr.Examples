using IronOcr;
namespace IronOcr.Examples.HowTo.ImageOrientationCorrection
{
    public static class Section1
    {
        public static void Run()
        {
            using var input = new OcrInput();
            input.LoadImage("skewed.png");
            input.Rotate(90);
            input.Deskew(45);
            input.Scale(150);
            var result = new IronOcr.IronTesseract().Read(input);
        }
    }
}