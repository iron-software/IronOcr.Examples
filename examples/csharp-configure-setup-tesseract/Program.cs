using IronOcr;
using System;

var ocrTesseract = new IronTesseract()
{
    Language = OcrLanguage.EnglishBest,
    Configuration = new TesseractConfiguration()
    {
        ReadBarCodes = false,
        RenderHocr = true,
        BlackListCharacters = "`ë|^",
        PageSegmentationMode = TesseractPageSegmentationMode.AutoOsd,
    }
};

using var ocrInput = new OcrInput();
ocrInput.LoadImage(@"images\image.png");
var ocrResult = ocrTesseract.Read(ocrInput);
Console.WriteLine(ocrResult.Text);
