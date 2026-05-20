using IronOcr;
using System;

var ocrTesseract = new IronTesseract();
using var ocrInput = new OcrInput();
ocrInput.LoadImage(@"images\image.png");

ocrInput.Deskew();
ocrInput.DeNoise();
ocrInput.Despeckle();
ocrInput.EnhanceResolution(225);
ocrInput.Sharpen();
ocrInput.Erode();
ocrInput.Dilate();
ocrInput.Scale(200);
var ocrResult = ocrTesseract.Read(ocrInput);
Console.WriteLine(ocrResult.Text);
