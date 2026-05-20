using IronOcr;

int cancel_time = 1000;

// Opens a Large PDF which may need to be cancelled early
IronTesseract ocrTesseract = new IronTesseract() { Language = OcrLanguage.English };
var ocrInput = new OcrInput();
ocrInput.LoadPdf("large-report.pdf");

// Starts a read on the PDF using IronOCR with specified cancel time
OcrReadTask ocrRead = ocrTesseract.ReadAsync(ocrInput, cancel_time);
ocrRead.Wait();
