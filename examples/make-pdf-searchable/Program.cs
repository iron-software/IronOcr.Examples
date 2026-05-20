using IronOcr;

var ocrTesseract = new IronTesseract();

using var ocrInput = new OcrInput();
ocrInput.LoadPdf("scan.pdf", Password: "password");

// Clean up twisted pages
ocrInput.Deskew();

var ocrResult = ocrTesseract.Read(ocrInput);
ocrResult.SaveAsSearchablePdf("searchable.pdf");
