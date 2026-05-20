using IronOcr;
namespace IronOcr.Examples.HowTo.InputTiffGif
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Extract Text from TIFFs & GIFs in Seconds
            using IronOcr;
            var result = new IronTesseract().Read(new OcrImageInput("Potter.tiff"));
        }
    }
}