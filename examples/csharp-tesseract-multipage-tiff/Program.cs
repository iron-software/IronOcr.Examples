using IronOcr;
using System;

var ocrTesseract = new IronTesseract();

using var ocrInput = new OcrInput();

var pages = new int[] { 1, 2 };
ocrInput.LoadImageFrames("images/multiframe.tiff", pages);

var ocrResult = ocrTesseract.Read(ocrInput);
Console.WriteLine(ocrResult.Text);
