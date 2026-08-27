using IronOcr;
namespace IronOcr.Examples.HowTo.TesseractResultConfidence
{
    public static class Section1
    {
        public static void Run()
        {
            double confidence = new IronOcr.IronTesseract().Read("input.png").Confidence;
        }
    }
}