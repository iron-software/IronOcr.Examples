using IronOcr;
namespace IronOcr.Examples.HowTo.ImageQualityCorrection
{
    public static class Section1
    {
        public static void Run()
        {
            new IronOcr.OcrImageInput("sample.png").Sharpen().SaveAsImages("output.png");
        }
    }
}