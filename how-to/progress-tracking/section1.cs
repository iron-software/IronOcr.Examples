using IronOcr;
namespace IronOcr.Examples.HowTo.ProgressTracking
{
    public static class Section1
    {
        public static void Run()
        {
            var ocr = new IronOcr.IronTesseract();
            ocr.OcrProgress += (s, e) => Console.WriteLine(e.ProgressPercent + "% (" + e.PagesComplete + "/" + e.TotalPages + ")");
            var result = ocr.Read(new IronOcr.OcrInput().LoadPdf("file.pdf"));
        }
    }
}