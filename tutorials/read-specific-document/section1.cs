using IronOcr;
namespace IronOcr.Examples.Tutorial.ReadSpecificDocument
{
    public static class Section1
    {
        public static void Run()
        {
            using var input = new OcrInput();
            input.LoadImage("passport.jpg");
            var result = new IronTesseract().ReadPassport(input);
        }
    }
}