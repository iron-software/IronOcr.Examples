using IronOcr;
namespace IronOcr.Examples.Tutorial.CSharpTesseractOcr
{
    public static class Section1
    {
        public static void Run()
        {
            string text = new IronTesseract().Read(new OcrInput("image.png")).Text;
        }
    }
}