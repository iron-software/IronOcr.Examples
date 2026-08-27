using IronOcr;
namespace IronOcr.Examples.HowTo.Async
{
    public static class Section1
    {
        public static void Run()
        {
            var result = await new IronOcr.IronTesseract().ReadAsync("image.png");
        }
    }
}