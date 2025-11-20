using IronOcr;
namespace IronOcr.Examples.HowTo.HighlightTextsAsImages
{
    public static class Section2
    {
        public static void Run()
        {
            IronTesseract ocrTesseract = new IronTesseract();
            
            using var ocrInput = new OcrInput();
            ocrInput.LoadPdf("document.pdf");
            ocrInput.HighlightTextAndSaveAsImages(ocrTesseract, "highlight_page_", ResultHighlightType.Paragraph);
        }
    }
}