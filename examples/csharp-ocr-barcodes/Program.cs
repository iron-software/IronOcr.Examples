using IronOcr;
using System;

var ocrTesseract = new IronTesseract();
ocrTesseract.Configuration.ReadBarCodes = true;
using var ocrInput = new OcrInput();
ocrInput.LoadImage(@"images\imageWithBarcode.png");
var ocrResult = ocrTesseract.Read(ocrInput);
foreach (var barcode in ocrResult.Barcodes)
{
    Console.WriteLine(barcode.Value);
}
