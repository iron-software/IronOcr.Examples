using IronOcr;
namespace IronOcr.Examples.HowTo.ImageQualityCorrection
{
    public static class Section4
    {
        public static void Run()
        {
            // Apply denoise filter
            using var imageInput = new IronOcr.OcrImageInput("sample.jpg");
            imageInput.DeNoise();
        }
    }
}