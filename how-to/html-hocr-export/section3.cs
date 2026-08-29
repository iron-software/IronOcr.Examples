using IronOcr;
namespace IronOcr.Examples.HowTo.HtmlHocrExport
{
    public static class Section3
    {
        public static void Run()
        {
            // Export as HTML string
            using var input = new IronOcr.OcrInput("image.png");
            var ocrResult = new IronOcr.IronTesseract().Read(input);
            string hocr = ocrResult.SaveAsHocrString();
        }
    }
}