using IronOcr;
namespace IronOcr.Examples.HowTo.FilterWizard
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Get Best OCR Filters Instantly
            string code = OcrInputFilterWizard.Run("image.png", out double confidence, new IronTesseract());
        }
    }
}