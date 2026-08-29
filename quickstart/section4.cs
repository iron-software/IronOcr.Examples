using IronOcr;
namespace IronOcr.Examples.Overview.Quickstart
{
    public static class Section4
    {
        public static void Run()
        {
            IronTesseract ocr = new IronTesseract();
            using OcrInput input = new OcrInput();
            input.Title = "Quarterly Report";
            input.LoadImage("image1.jpeg");
            input.LoadImage("image2.png");
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames("image3.gif", pageindices);
            
            OcrResult result = ocr.Read(input);
            result.SaveAsSearchablePdf("searchable.pdf");
        }
    }
}