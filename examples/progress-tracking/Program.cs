using IronOcr;
using System;

var ocrTesseract = new IronTesseract();

ocrTesseract.OcrProgress += (_, ocrProgressEventsArgs) =>
{
    Console.WriteLine(ocrProgressEventsArgs.ProgressPercent + "%   " + ocrProgressEventsArgs.Duration.TotalSeconds + "s");
};

using var input = new OcrInput();
input.LoadPdf("large.pdf");

// Progress events will fire during the read operation even if the main thread is blocked.
var result = ocrTesseract.Read(input);
