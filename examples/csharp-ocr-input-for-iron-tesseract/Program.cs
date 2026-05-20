using IronOcr;
using System;

var ocrTesseract = new IronTesseract();

using var ocrInput = new OcrInput();
ocrInput.LoadImage(@"images\image.png");
var ocrResult = ocrTesseract.Read(ocrInput);
Console.WriteLine(ocrResult.Text);
