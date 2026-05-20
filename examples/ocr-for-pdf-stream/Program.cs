using IronOcr;
using IronPdf;
using System;


ChromePdfRenderer renderer = new ChromePdfRenderer();
PdfDocument pdf = renderer.RenderHtmlAsPdf("<h1> Iron Software </h1>");

var ocrTesseract = new IronTesseract();

using var ocrInput = new OcrInput();
ocrInput.LoadPdf(pdf.Stream);

var ocrResult = ocrTesseract.Read(ocrInput);

Console.WriteLine(ocrResult.Text);
