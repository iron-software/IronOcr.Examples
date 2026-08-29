using IronOcr;
namespace IronOcr.Examples.HowTo.ImageColorCorrection
{
    public static class Section3
    {
        public static void Run()
        {
            // Apply grayscale affect
            using var imageInput = new IronOcr.OcrImageInput("sample.jpg");
            imageInput.ToGrayScale();
        }
    }
}