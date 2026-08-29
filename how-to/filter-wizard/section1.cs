using IronOcr;
namespace IronOcr.Examples.HowTo.FilterWizard
{
    public static class Section1
    {
        public static void Run()
        {
            string code = OcrInputFilterWizard.Run("image.png", out double confidence, new IronTesseract());
        }
    }
}