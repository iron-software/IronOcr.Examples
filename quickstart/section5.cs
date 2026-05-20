using IronOcr;
namespace IronOcr.Examples.Overview.Quickstart
{
    public static class Section5
    {
        public static void Run()
        {
            IronTesseract ocr = new IronTesseract();
            using OcrInput input = new OcrInput();
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames("example.tiff", pageindices);
            ocr.Read(input).SaveAsSearchablePdf("searchable.pdf");
        }
    }
}