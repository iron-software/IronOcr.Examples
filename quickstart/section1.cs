using IronOcr;
namespace IronOcr.Examples.Overview.Quickstart
{
    public static class Section1
    {
        public static void Run()
        {
            IronTesseract ocr = new IronTesseract();
            ocr.Configuration.ReadBarCodes = true;
            
            using OcrInput input = new OcrInput();
            input.LoadImage("img/Barcode.png");
            
            OcrResult Result = ocr.Read(input);
            foreach (var Barcode in Result.Barcodes)
            {
                // type and location properties also exposed
                Console.WriteLine(Barcode.Value);
            }
        }
    }
}