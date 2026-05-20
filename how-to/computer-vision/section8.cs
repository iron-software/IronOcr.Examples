using System.Linq;
using IronOcr;
namespace IronOcr.Examples.HowTo.ComputerVision
{
    public static class Section8
    {
        public static void Run()
        {
            int pageIndex = 0;
            using var input = new OcrInput();
            input.LoadImage("/path/file.png");
            
            var selectedPage = input.GetPages().ElementAt(pageIndex);
            // List<Rectangle> regions = selectedPage.GetTextRegions();
        }
    }
}