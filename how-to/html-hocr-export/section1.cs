using IronOcr;
namespace IronOcr.Examples.HowTo.HtmlHocrExport
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Export hOCR with One-Line IronOCR Setup
            var hocr = new IronTesseract { Configuration = { RenderHocr = true } }.Read(new OcrInput("image.png")).SaveAsHocrString();
        }
    }
}