using IronOcr;
namespace IronOcr.Examples.HowTo.ImageQualityCorrection
{
    public static class Section6
    {
        public static void Run()
        {
            // Apply erode filter
            using var imageInput = new IronOcr.OcrImageInput("sample.jpg");
            imageInput.Erode();
        }
    }
}