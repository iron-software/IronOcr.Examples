using IronOcr;
namespace IronOcr.Examples.HowTo.InputImages
{
    public static class Section1
    {
        public static void Run()
        {
            var result = new IronTesseract().Read(new OcrImageInput("Potter.png"));
        }
    }
}