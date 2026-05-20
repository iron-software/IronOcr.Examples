using IronOcr;

var ocrTesseract = new IronTesseract();

using var ocrInput = new OcrInput();
ocrInput.LoadPdf("scan.pdf");

// Image processing is automatically multi-threaded
ocrInput.Deskew();

// OCR reading is automatically multi-threaded too
var ocrResult = ocrTesseract.Read(ocrInput);
