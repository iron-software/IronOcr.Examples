using IronOcr;
namespace IronOcr.Examples.HowTo.ImageOrientationCorrection
{
    public static class Section4
    {
        public static void Run()
        {
            // Apply scale
            using var imageInput = new IronOcr.OcrImageInput("sample.jpg");
            imageInput.Scale(70);
        }
    }
}