//PM> Install-Package IronOcr.Languages.Arabic
//PM> Install-Package IronOcr.Languages.Chinese
using IronOcr;
using System;

var Ocr = new IronTesseract();

// Add a primary language (Default is English)
Ocr.Language = OcrLanguage.English;

// Add as many secondary languages as you like
Ocr.AddSecondaryLanguage(OcrLanguage.Arabic);
Ocr.AddSecondaryLanguage(OcrLanguage.ChineseSimplified);

using var ocrInput = new OcrInput();
ocrInput.LoadImage(@"images\image.png");

var Result = Ocr.Read(ocrInput);
Console.WriteLine(Result.Text);
