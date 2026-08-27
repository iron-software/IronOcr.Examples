using IronOcr;
namespace IronOcr.Examples.HowTo.IronTesseract
{
    public static class Section1
    {
        public static void Run()
        {
            var result = new IronOcr.IronTesseract { Language = IronOcr.OcrLanguage.English, Configuration = new IronOcr.TesseractConfiguration { ReadBarCodes = false, RenderSearchablePdf = true, WhiteListCharacters = "ABCabc123" } }.Read(new IronOcr.OcrInput("image.png"));
        }
    }
}