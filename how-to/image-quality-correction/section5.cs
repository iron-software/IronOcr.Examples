using IronOcr;
namespace IronOcr.Examples.HowTo.ImageQualityCorrection
{
    public static class Section5
    {
        public static void Run()
        {
            // Apply dilate filter
            using var imageInput = new IronOcr.OcrImageInput("sample.jpg");
            imageInput.Dilate();
        }
    }
}