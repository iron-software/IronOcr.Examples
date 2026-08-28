using IronOcr;
namespace IronOcr.Examples.HowTo.DetectPageRotation
{
    public static class Section1
    {
        public static void Run()
        {
            using var input = new OcrInput();
            input.LoadPdf("doc.pdf");
            input.DetectPageOrientation();
                        var rotationResults = input;
            Console.WriteLine(rotationResults.First().RotationAngle);
        }
    }
}