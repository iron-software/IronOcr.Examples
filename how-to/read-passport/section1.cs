using IronOcr;
namespace IronOcr.Examples.HowTo.ReadPassport
{
    public static class Section1
    {
        public static void Run()
        {
            var passportInfo = new IronOcr.IronTesseract().ReadPassport(new IronOcr.OcrInput("passport.jpg")).PassportInfo;
        }
    }
}