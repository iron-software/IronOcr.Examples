using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Start OCR in Seconds with IronOCR!
            string text = new IronTesseract().Read("image.png").Text;
        }
    }
}