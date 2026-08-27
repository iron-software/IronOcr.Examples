using IronOcr;
namespace IronOcr.Examples.HowTo.DetectPageRotation
{
    public static class Section1
    {
        public static void Run()
        {
            var rotationResults = new IronOcr.OcrInput().LoadPdf("doc.pdf").DetectPageOrientation();
            Console.WriteLine(rotationResults.First().RotationAngle);
        }
    }
}