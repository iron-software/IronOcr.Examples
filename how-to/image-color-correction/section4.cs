using IronOcr;
namespace IronOcr.Examples.HowTo.ImageColorCorrection
{
    public static class Section4
    {
        public static void Run()
        {
            // Apply invert affect
            using var imageInput = new IronOcr.OcrImageInput("sample.jpg");
            imageInput.Invert();
        }
    }
}