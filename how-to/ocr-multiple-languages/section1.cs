using IronOcr;
namespace IronOcr.Examples.HowTo.OcrMultipleLanguages
{
    public static class Section1
    {
        public static void Run()
        {
            string text = new IronTesseract { Language = OcrLanguage.Spanish }.AddSecondaryLanguage(OcrLanguage.French).Read("doc_or_image_path").Text;
        }
    }
}