using IronOcr;
namespace IronOcr.Examples.HowTo.HighlightTextsAsImages
{
    public static class Section1
    {
        public static void Run()
        {
            using var input = new OcrInput();
            input.LoadPdf("document.pdf");
            input.HighlightTextAndSaveAsImages(new IronOcr.IronTesseract(), "highlight_page_", IronOcr.ResultHighlightType.Word);
            input;
        }
    }
}