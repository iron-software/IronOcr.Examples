using IronOcr;
namespace IronOcr.Examples.HowTo.InputImages
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Try IronOCR Image Text Extraction – It’s Easy!
            var result = new IronTesseract().Read(new OcrImageInput("Potter.png"));
        }
    }
}