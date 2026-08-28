using IronOcr;
namespace IronOcr.Examples.HowTo.IronTesseract
{
    public static class Section3
    {
        public static void Run()
        {
            global::IronOcr.IronTesseract ocr = new global::IronOcr.IronTesseract
            {
                Configuration = new TesseractConfiguration
                {
                    ReadBarCodes = false,
                    RenderHocr = true,
                    TesseractVariables = null,
                    WhiteListCharacters = null,
                    BlackListCharacters = "`ë|^",
                },
                MultiThreaded = false,
                Language = OcrLanguage.English,
                EnableTesseractConsoleMessages = true, // False as default
            };
        }
    }
}