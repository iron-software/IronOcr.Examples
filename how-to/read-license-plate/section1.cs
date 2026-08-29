using IronOcr;
namespace IronOcr.Examples.HowTo.ReadLicensePlate
{
    public static class Section1
    {
        public static void Run()
        {
            OcrLicensePlateResult result = new IronTesseract().ReadLicensePlate(new OcrInput("plate.jpg"));
        }
    }
}