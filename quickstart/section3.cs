using IronOcr;
namespace IronOcr.Examples.Overview.Quickstart
{
    public static class Section3
    {
        public static void Run()
        {
            IronTesseract ocr = new IronTesseract();
            using OcrInput input = new OcrInput();
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames(@"img\Potter.tiff", pageindices);
            
            // fixes digital noise and poor scanning
            input.DeNoise();
            
            // fixes rotation and perspective
            input.Deskew();
            
            OcrResult result = ocr.Read(input);
            Console.WriteLine(result.Text);
        }
    }
}