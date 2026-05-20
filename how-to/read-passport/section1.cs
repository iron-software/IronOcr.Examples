using IronOcr;
namespace IronOcr.Examples.HowTo.ReadPassport
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Grab Passport Data Instantly with IronOCR
            var passportInfo = new IronOcr.IronTesseract().ReadPassport(new IronOcr.OcrInput("passport.jpg")).PassportInfo;
        }
    }
}