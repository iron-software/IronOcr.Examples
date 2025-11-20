using IronOcr;
namespace IronOcr.Examples.HowTo.ReadLicensePlate
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Read License Plate in One Line—Try IronOCR
            OcrLicensePlateResult result = new IronTesseract().ReadLicensePlate(new OcrInput("plate.jpg"));
        }
    }
}