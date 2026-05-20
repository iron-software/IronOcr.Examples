using IronOcr;
using System;

var ocrTesseract = new IronTesseract();

using var ocrInput = new OcrInput();

// OCR entire document
ocrInput.LoadPdf("example.pdf", Password: "password");

int[] pages = { 1, 2, 3, 4, 5 };

// Alternatively OCR selected page numbers
ocrInput.LoadPdfPages("example.pdf", pages, Password: "password");

var ocrResult = ocrTesseract.Read(ocrInput);
Console.WriteLine(ocrResult.Text);
