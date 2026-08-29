using IronOcr;
namespace IronOcr.Examples.HowTo.ProgressTracking
{
    public static class Section1
    {
        public static void Run()
        {
            using var input = new OcrInput();
            input.LoadPdf("file.pdf");
                        var ocr = new IronOcr.IronTesseract();
            ocr.OcrProgress += (s, e) => Console.WriteLine(e.ProgressPercent + "% (" + e.PagesComplete + "/" + e.TotalPages + ")");
            var result = ocr.Read(input);
        }
    }
}