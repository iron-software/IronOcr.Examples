using IronOcr;
namespace IronOcr.Examples.HowTo.SearchablePdf
{
    public static class Section1
    {
        public static void Run()
        {
            new IronOcr.IronTesseract { Configuration = { RenderSearchablePdf = true } } .Read(new IronOcr.OcrImageInput("file.jpg")).SaveAsSearchablePdf("searchable.pdf");
        }
    }
}