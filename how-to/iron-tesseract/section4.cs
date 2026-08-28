using IronOcr;
namespace IronOcr.Examples.HowTo.IronTesseract
{
    public static class Section4
    {
        public static void Run()
        {
            global::IronOcr.IronTesseract ocr = new global::IronOcr.IronTesseract();
            
            using OcrInput input = new OcrInput();
            input.LoadImage("attachment.png");
            OcrResult result = ocr.Read(input);
            string text = result.Text;
        }
    }
}