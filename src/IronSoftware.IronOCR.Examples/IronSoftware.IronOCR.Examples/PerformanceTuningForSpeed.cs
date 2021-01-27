using IronOcr;
using IronSoftware.IronOcrConsoleDotNetSamples.Infrastructure;


namespace IronSoftware.IronOcrConsoleDotNetSamples
{
    public class PerformanceTuningForSpeed : IExecuteApp
    {
        public OcrResult Run()
        {
            var Ocr = new IronTesseract();
            // Configure for speed
            Ocr.Configuration.BlackListCharacters = "~`$#^*_}{][|\\@";
            Ocr.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.Auto;
            Ocr.Configuration.TesseractVersion = TesseractVersion.Tesseract5;
            Ocr.Configuration.EngineMode = TesseractEngineMode.LstmOnly;
            Ocr.Language = OcrLanguage.EnglishFast;
            using (var Input = new OcrInput(@"Inputs\Potter.tiff"))
            {
                var Result = Ocr.Read(Input);
                return Result;
            }
        }
    }
}
