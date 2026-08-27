using IronOcr;
namespace IronOcr.Examples.HowTo.ReadPhoto
{
    public static class Section1
    {
        public static void Run()
        {
            var result = new IronTesseract().ReadPhoto(new OcrInput().LoadImageFrame("photo.tiff", 0));
        }
    }
}