using IronOcr;
namespace IronOcr.Examples.HowTo.ReadResults
{
    public static class Section1
    {
        public static void Run()
        {
            :title=Read OCR Results Instantly
            string wordText = new IronTesseract().Read("file.jpg").Words[0].Text;
        }
    }
}