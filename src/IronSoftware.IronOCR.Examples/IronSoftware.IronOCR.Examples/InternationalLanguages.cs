using IronOcr;
using IronSoftware.IronOcrConsoleDotNetSamples.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronSoftware.IronOcrConsoleDotNetSamples
{
    public class InternationalLanguages : IExecuteApp
    {
        public OcrResult Run()
        {
            var Ocr = new IronTesseract();
            Ocr.Language = OcrLanguage.Arabic;
            using (var input = new OcrInput())
            {
                input.AddImage("Inputs/arabic.gif");
                // add image filters if needed 
                // In this case, even thought input is very low quality
                // IronTesseract can read what conventional Tesseract cannot.
                var Result = Ocr.Read(input);
                return Result;
               // you can save it in text file
                //Result.SaveAsTextFile("arabic.txt");
            }
        }
    }
}
