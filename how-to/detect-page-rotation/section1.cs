using IronOcr;
namespace IronOcr.Examples.HowTo.DetectPageRotation
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Detect and Fix Page Rotation Instantly
            var rotationResults = new IronOcr.OcrInput().LoadPdf("doc.pdf").DetectPageOrientation();
            Console.WriteLine(rotationResults.First().RotationAngle);
        }
    }
}