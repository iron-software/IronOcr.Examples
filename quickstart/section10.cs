using IronOcr;
namespace IronOcr.Examples.Overview.Quickstart
{
    public static class Section10
    {
        public static void Run()
        {
            IronTesseract ocr = new IronTesseract();
            
            // Must be set to true to read barcode
            ocr.Configuration.ReadBarCodes = true;
            using OcrInput input = new OcrInput();
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames(@"img\sample.tiff", pageindices);
            
            OcrResult result = ocr.Read(input);
            var pages = result.Pages;
            var words = pages[0].Words;
            var barcodes = result.Barcodes;
            // Explore here to find a massive, detailed API:
            // - Pages, Blocks, Paraphaphs, Lines, Words, Chars
            // - Image Export, Fonts Coordinates, Statistical Data, Tables
        }
    }
}