using IronOcr;
namespace IronOcr.Examples.HowTo.InputStreams
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Quick & Easy Stream OCR in C#
            using var input = new IronOcr.OcrInput(stream);
            var result = new IronOcr.IronTesseract().Read(input);
        }
    }
}