using IronOcr;
namespace IronOcr.Examples.Overview.Quickstart
{
    public static class Section2
    {
        public static void Run()
        {
            IronTesseract ocr = new IronTesseract();
            using OcrInput input = new OcrInput();
            
            // Dimensions are in pixel
            var contentArea = new System.Drawing.Rectangle() { X = 215, Y = 1250, Height = 280, Width = 1335 };
            
            input.LoadImage("document.png", contentArea);
            
            OcrResult result = ocr.Read(input);
            Console.WriteLine(result.Text);
        }
    }
}