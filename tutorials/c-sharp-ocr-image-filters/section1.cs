using IronOcr;
namespace IronOcr.Examples.Tutorial.CSharpOcrImageFilters
{
    public static class Section1
    {
        public static void Run()
        {
            using var input = new IronOcr.OcrInput("scan.jpg"); input.DeNoise(true).Binarize().Deskew(45); var result = new IronOcr.IronTesseract().Read(input);
        }
    }
}