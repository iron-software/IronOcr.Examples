using IronOcr;
namespace IronOcr.Examples.HowTo.ReadPhoto
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Quickly Extract Text from Photos with ReadPhoto
            var result = new IronTesseract().ReadPhoto(new OcrInput().LoadImageFrame("photo.tiff", 0));
        }
    }
}