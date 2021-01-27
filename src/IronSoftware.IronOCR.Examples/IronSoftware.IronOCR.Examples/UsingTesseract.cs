using IronOcr;
using IronSoftware.IronOcrConsoleDotNetSamples.Infrastructure;


namespace IronSoftware.IronOcrConsoleDotNetSamples
{
    public class UsingTesseract:IExecuteApp
    {
        
        public OcrResult Run()
        {
            var Ocr = new IronTesseract();
            using (var Input = new OcrInput(@"Inputs\Potter.tiff"))
            {
                var Result = Ocr.Read(Input);
                return Result;
            }
            
        }
    }
}
