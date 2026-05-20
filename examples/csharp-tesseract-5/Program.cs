using IronOcr;
using System;

var ocrTesseract = new IronTesseract();

// This is done by default and can be omitted:
// ocrTesseract.Configuration.TesseractVersion = TesseractVersion.Tesseract5;

using var ocrInput = new OcrInput();
ocrInput.LoadImage(@"images\image.png");
var ocrResult = ocrTesseract.Read(ocrInput);
Console.WriteLine(ocrResult.Text);
