using IronOcr;
namespace IronOcr.Examples.HowTo.HighlightTextsAsImages
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Highlight PDF Text in One Line
            new IronOcr.OcrInput().LoadPdf("document.pdf").HighlightTextAndSaveAsImages(new IronOcr.IronTesseract(), "highlight_page_", IronOcr.ResultHighlightType.Word);
        }
    }
}