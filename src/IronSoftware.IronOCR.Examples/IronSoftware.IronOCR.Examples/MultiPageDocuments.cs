using IronOcr;
using IronSoftware.IronOcrConsoleDotNetSamples.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronSoftware.IronOcrConsoleDotNetSamples
{
    public class MultiPageDocuments : IExecuteApp
    {
        public OcrResult Run()
        {
            var Ocr = new IronTesseract();
            using (var input = new OcrInput())
            {
                input.AddImage("Inputs/Potter.tiff");
                input.AddPdf("Inputs/test.pdf");
                var Result = Ocr.Read(input);
                return Result;
            }
        }
    }
}