using IronOcr;
namespace IronOcr.Examples.HowTo.DetectPageRotation
{
    public static class Section1
    {
        public static void Run()
        {
            using var input = new OcrInput();
            input.LoadPdf("doc.pdf");
            var rotationResults = input.DetectPageOrientation();
            Console.WriteLine(rotationResults.First().RotationAngle);
        }
    }
}