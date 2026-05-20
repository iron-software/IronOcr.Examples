using IronOcr;

var ocrTesseract = new IronTesseract();

using var ocrInput = new OcrInput();

ocrInput.LoadImage(@"images\page1.png");
ocrInput.LoadImage(@"images\page2.bmp");

var page = new int[]{ 2, 3 };
ocrInput.LoadImageFrames(@"images\page3.tiff", page);

ocrInput.Deskew();

var ocrResult = ocrTesseract.Read(ocrInput);

ocrResult.SaveAsSearchablePdf("searchable.pdf");
