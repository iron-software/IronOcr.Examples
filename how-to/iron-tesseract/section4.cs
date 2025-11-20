using IronOcr;
namespace IronOcr.Examples.HowTo.IronTesseract
{
    public static class Section4
    {
        public static void Run()
        {
            IronTesseract ocr = new IronTesseract();
            
            using OcrInput input = new OcrInput();
            input.LoadImage("attachment.png");
            OcrResult result = ocr.Read(input);
            string text = result.Text;
        }
    }
}