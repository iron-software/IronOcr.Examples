using IronOcr;
using IronSoftware.IronOcrConsoleDotNetSamples.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronSoftware.IronOcrConsoleDotNetSamples
{
    public class ReadingBarcodes : IExecuteApp
    {
        public OcrResult Run()
        {
            var Ocr = new IronTesseract();
            Ocr.Configuration.ReadBarCodes = true;
            using (var input = new OcrInput())
            {
                input.AddImage("Inputs/barcode.png");
                var Result = Ocr.Read(input);
                return Result;
            }
        }
    }
}
