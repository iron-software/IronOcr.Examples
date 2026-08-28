using IronOcr;
namespace IronOcr.Examples.HowTo.ReadMicrCheque
{
    public static class Section1
    {
        public static void Run()
        {
            using var input = new OcrInput();
            input.LoadImage("micr.png", new System.Drawing.Rectangle(125, 240, 310, 15));
            string micrText = new IronOcr.IronTesseract { Language = IronOcr.OcrLanguage.MICR }.Read(input).Text;
        }
    }
}