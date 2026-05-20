using IronOcr;
using IronSoftware.Drawing;
using System;

var ocrTesseract = new IronTesseract();

using var ocrInput = new OcrInput();
// A 41% improvement on speed by specifiying a pixel region
var ContentArea = new Rectangle(x: 215, y: 1250, width: 1335, height: 280);
ocrInput.LoadImage("img/example.png", ContentArea);

var ocrResult = ocrTesseract.Read(ocrInput);
Console.WriteLine(ocrResult.Text);
