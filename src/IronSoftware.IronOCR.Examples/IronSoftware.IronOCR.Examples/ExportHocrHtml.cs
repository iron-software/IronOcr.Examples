using IronOcr;
using IronSoftware.IronOcrConsoleDotNetSamples.Infrastructure;

namespace IronSoftware.IronOcrConsoleDotNetSamples
{
    public class ExportHocrHtml : IExecuteApp
    {
        public OcrResult Run()
        {
            var Ocr = new IronTesseract();
            using (var Input = new OcrInput())
            {
                Input.Title = "Html Title";
                // Add more content as required...
                //input.AddImage("image2.jpeg");
                //input.AddPdf("example.pdf","password"); 
                //input.AddMultiFrameTiff("example.tiff")
                var Result = Ocr.Read("Inputs/Potter.tiff");
                Result.SaveAsHocrFile("Outputs/hocr.html");
                return Result;
            }
        }
    }
}
