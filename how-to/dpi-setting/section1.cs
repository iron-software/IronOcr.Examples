using IronOcr;
namespace IronOcr.Examples.HowTo.DpiSetting
{
    public static class Section1
    {
        public static void Run()
        {
            using var input = new IronOcr.OcrInput { TargetDPI = 300 };
            input.LoadImage("low-res.png");

            var result = new IronOcr.IronTesseract().Read(input);
        }
    }
}