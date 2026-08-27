using IronOcr;
namespace IronOcr.Examples.HowTo.ImageOrientationCorrection
{
    public static class Section1
    {
        public static void Run()
        {
            var result = new IronOcr.OcrInput().LoadImage("skewed.png").Rotate(90).Deskew(45).Scale(150).Let(input => new IronOcr.IronTesseract().Read(input));
        }
    }
}