using IronOcr;
namespace IronOcr.Examples.HowTo.DpiSetting
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Easily Boost OCR Clarity with TargetDPI
            var result = new IronOcr.IronTesseract().Read(new IronOcr.OcrInput { TargetDPI = 300 }.LoadImage("low-res.png"));
        }
    }
}