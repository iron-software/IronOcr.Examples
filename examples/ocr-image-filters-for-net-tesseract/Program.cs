using IronOcr;
using System;

var ocrTesseract = new IronTesseract();
using var ocrInput = new OcrInput();
// First load all image(s)
ocrInput.LoadImage(@"images\image.png");

// Note: You don't need all of them; most users only need Deskew() and occasionally DeNoise()
ocrInput.WithTitle("My Document");
ocrInput.Binarize();
ocrInput.Contrast();
ocrInput.Deskew();
ocrInput.DeNoise();
ocrInput.Despeckle();
ocrInput.Dilate();
ocrInput.EnhanceResolution(300);
ocrInput.Invert();
ocrInput.Rotate(90);
ocrInput.Scale(150);
ocrInput.Sharpen();
ocrInput.ToGrayScale();
ocrInput.Erode();

// WIZARD - If you are unsure use the debug-wizard to test all combinations:
string codeToRun = OcrInputFilterWizard.Run(@"images\image.png", out double confidence, ocrTesseract);
Console.WriteLine(codeToRun);

// Optional: Export modified images so you can view them.
foreach (var page in ocrInput.GetPages())
{
    page.SaveAsImage($"filtered_{page.Index}.bmp");
}

var ocrResult = ocrTesseract.Read(ocrInput);
Console.WriteLine(ocrResult.Text);
