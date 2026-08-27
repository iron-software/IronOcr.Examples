using IronOcr;
namespace IronOcr.Examples.HowTo.InputSystemDrawing
{
    public static class Section1
    {
        public static void Run()
        {
            var result = new IronOcr.IronTesseract().Read(new IronOcr.OcrImageInput(new System.Drawing.Bitmap("image.png")));
        }
    }
}