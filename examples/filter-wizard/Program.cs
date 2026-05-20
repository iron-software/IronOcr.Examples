using IronOcr;
using System;

var ocrTesseract = new IronTesseract();

// WIZARD - If you are unsure which filters to use,
// use the debug-wizard to test all combinations:

string codeToRun = OcrInputFilterWizard.Run(@"images\image.png", out double confidence, ocrTesseract);
Console.WriteLine($"Confidence: {confidence}");
Console.WriteLine(codeToRun);
