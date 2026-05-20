using IronOcr;

var ocrTesseract = new IronTesseract();

using var ocrInput = new OcrInput();
ocrInput.LoadImageFrame("images/multiframe.tiff", 1);

var ocrResult = ocrTesseract.Read(ocrInput);

ocrResult.SaveAsSearchablePdf("searchable.pdf");
