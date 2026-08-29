using System.Threading.Tasks;
using IronOcr;
namespace IronOcr.Examples.HowTo.Async
{
    public static class Section1
    {
        public static async Task Run()
        {
            var result = await new IronOcr.IronTesseract().ReadAsync("image.png");
        }
    }
}