using IronOcr;
namespace IronOcr.Examples.HowTo.ReadPhoto
{
    public static class Section1
    {
        public static void Run()
        {
            using var input = new OcrInput();
            input.LoadImageFrame("photo.tiff", 0);
            var result = new IronTesseract().ReadPhoto(input);
        }
    }
}