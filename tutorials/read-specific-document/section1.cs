using IronOcr;
namespace IronOcr.Examples.Tutorial.ReadSpecificDocument
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Quickly Read Any Document Type with IronOCR
            var result = new IronTesseract().ReadPassport(new OcrInput().LoadImage("passport.jpg"));
        }
    }
}