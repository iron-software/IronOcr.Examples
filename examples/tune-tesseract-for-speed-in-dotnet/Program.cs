using IronOcr;
using System;

var ocrTesseract = new IronTesseract();

// Fast Dictionary
ocrTesseract.Language = OcrLanguage.EnglishFast;

// Turn off unneeded options
ocrTesseract.Configuration.ReadBarCodes = false;

// Assume text is laid out neatly in an orthogonal document
ocrTesseract.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.Auto;

using var ocrInput = new OcrInput();
ocrInput.LoadImage(@"images\image.png");

var ocrResult = ocrTesseract.Read(ocrInput);
Console.WriteLine(ocrResult.Text);
