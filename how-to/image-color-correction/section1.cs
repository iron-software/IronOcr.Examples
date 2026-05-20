using IronOcr;
namespace IronOcr.Examples.HowTo.ImageColorCorrection
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Fix Text Color Fast with IronOCR
            new IronTesseract().Read(new IronOcr.OcrImageInput("sample.jpg").SelectTextColor(new IronSoftware.Drawing.Color("#DB645C"), 60));
        }
    }
}