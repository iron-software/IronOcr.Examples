using IronOcr;
using IronSoftware.IronOcrConsoleDotNetSamples.Infrastructure;


namespace IronSoftware.IronOcrConsoleDotNetSamples
{
    public class CropRegion : IExecuteApp
    {
        public OcrResult Run()
        {
            var Ocr = new IronTesseract();
            using (var Input = new OcrInput())
            {
                // a 41% improvement on speed
                var ContentArea = new System.Drawing.Rectangle() { X = 164, Y = 354, Height =77 , Width = 191 };
                Input.AddImage("Inputs/ComSci.png", ContentArea);
                var Result = Ocr.Read(Input);
                return Result;
            }
        }
    }
}
