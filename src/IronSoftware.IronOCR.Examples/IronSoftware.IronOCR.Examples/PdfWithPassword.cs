using IronOcr;
using IronSoftware.IronOcrConsoleDotNetSamples.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronSoftware.IronOcrConsoleDotNetSamples
{
    public class PdfWithPassword : IExecuteApp
    {
        public OcrResult Run()
        {
            var Ocr = new IronTesseract();
            using (var input = new OcrInput())
            {
                input.AddPdf("Inputs/test.pdf", "123");
                // We can also select specific PDF page numbers to OCR
                var Result = Ocr.Read(input);
                return Result;
            }
        }
    }
}
