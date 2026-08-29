using IronOcr;
using IronOcr;
using IronOcr.Extension.AdvancedScan;
using System.Linq;

// Instantiate OCR engine
var ocr = new IronTesseract();

using var input = new OcrInput();
input.LoadPdf("table.pdf");

// Perform OCR
var result = ocr.ReadDocumentAdvanced(input);

var cellList = result.Tables.First().CellInfos;
