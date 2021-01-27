using IronOcr;
using IronSoftware.IronOcrConsoleDotNetSamples.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronSoftware.IronOcrConsoleDotNetSamples
{
    public class MultipleLanguages : IExecuteApp
    {
        public OcrResult Run()
        {
            var Ocr = new IronTesseract();
            Ocr.Language = OcrLanguage.Arabic;
            Ocr.AddSecondaryLanguage(OcrLanguage.English);
            // We can add any number of languages.
            // Optionally add custom tesseract .traineddata files by specifying a file path
            using (var input = new OcrInput())
            {
                input.AddImage("Inputs/MultiLanguage.png");
                var Result = Ocr.Read(input);
                return Result;
            }
        }
    }

}
