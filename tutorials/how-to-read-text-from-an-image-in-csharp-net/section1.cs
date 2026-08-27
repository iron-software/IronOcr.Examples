using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section1
    {
        public static void Run()
        {
            string text = new IronTesseract().Read("image.png").Text;
        }
    }
}