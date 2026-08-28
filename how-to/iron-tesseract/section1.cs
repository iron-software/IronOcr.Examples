using IronOcr;
namespace IronOcr.Examples.HowTo.IronTesseract
{
    public static class Section1
    {
        public static void Run()
        {
            var result = new global::IronOcr.IronTesseract { Language = global::IronOcr.OcrLanguage.English, Configuration = new global::IronOcr.TesseractConfiguration { ReadBarCodes = false, RenderSearchablePdf = true, WhiteListCharacters = "ABCabc123" } }.Read(new global::IronOcr.OcrInput("image.png"));
        }
    }
}