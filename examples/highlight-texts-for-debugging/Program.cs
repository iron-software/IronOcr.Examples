using IronOcr;

IronTesseract ocrTesseract = new IronTesseract();

using var ocrInput = new OcrInput();
ocrInput.LoadPdf("document.pdf");
ocrInput.HighlightTextAndSaveAsImages(ocrTesseract, "highlight_page_", ResultHighlightType.Paragraph);
