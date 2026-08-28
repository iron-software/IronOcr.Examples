using IronOcr;
namespace IronOcr.Examples.HowTo.ImageOrientationCorrection
{
    public static class Section3
    {
        public static void Run()
        {
            // Apply deskew
            using var imageInput = new IronOcr.OcrImageInput("sample.jpg");
            imageInput.Deskew();
        }
    }
}