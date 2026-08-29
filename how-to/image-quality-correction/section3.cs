using IronOcr;
namespace IronOcr.Examples.HowTo.ImageQualityCorrection
{
    public static class Section3
    {
        public static void Run()
        {
            // Apply enhance resolution filter
            using var imageInput = new IronOcr.OcrImageInput("sample.jpg");
            imageInput.EnhanceResolution();
        }
    }
}