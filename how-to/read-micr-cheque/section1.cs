using IronOcr;
namespace IronOcr.Examples.HowTo.ReadMicrCheque
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Read MICR in One Line with IronOCR
            string micrText = new IronOcr.IronTesseract { Language = IronOcr.OcrLanguage.MICR }.Read(new IronOcr.OcrInput().LoadImage("micr.png", new System.Drawing.Rectangle(125, 240, 310, 15))).Text;
        }
    }
}