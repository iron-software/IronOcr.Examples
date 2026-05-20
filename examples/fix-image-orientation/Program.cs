using IronOcr;
using System;

var ocrTesseract = new IronTesseract();
using var ocrInput = new OcrInput();
ocrInput.LoadImage("/path/file.png");

ocrInput.Rotate(90);
ocrInput.Deskew();
ocrInput.Scale(150);

var ocrResult = ocrTesseract.Read(ocrInput);
Console.WriteLine(ocrResult.Text);
