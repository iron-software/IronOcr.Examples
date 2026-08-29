using IronOcr;
namespace IronOcr.Examples.HowTo.OcrMultipleLanguages
{
    public static class Section1
    {
        public static void Run()
        {
            var ocr = new IronTesseract { Language = OcrLanguage.Spanish };

            // AddSecondaryLanguage returns void, so it cannot be chained
            ocr.AddSecondaryLanguage(OcrLanguage.French);

            string text = ocr.Read("doc_or_image_path").Text;
        }
    }
}