using IronOcr;
using IronSoftware.IronOcrConsoleDotNetSamples.Infrastructure;


namespace IronSoftware.IronOcrConsoleDotNetSamples
{
    public class LowQualityScan : IExecuteApp
    {
        public OcrResult Run()
        {
            var Ocr = new IronTesseract();
            using (var Input = new OcrInput(@"Inputs\Potter.LowQuality.tiff"))
            {
                Input.Deskew(); // removes rotation and perspective
                var Result = Ocr.Read(Input);
                return Result;
            }
        }
    }
}
