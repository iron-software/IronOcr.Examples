using IronOcr;
using System.Threading;

// Opens a Large PDF which may need to be cancelled early
IronTesseract ocrTesseract = new IronTesseract() { Language = OcrLanguage.English };

using var ocrInput = new OcrInput();
ocrInput.LoadPdf("large-report.pdf");

// Starts a read on the PDF using IronOCR
OcrReadTask ocrRead = ocrTesseract.ReadAsync(ocrInput);

Thread.Sleep(1000); // Time passes...

// Cancellation Example:
ocrRead.Cancel();
ocrRead.Wait();
