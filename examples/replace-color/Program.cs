using IronOcr;
using IronSoftware.Drawing;
using System;

var ocrTesseract = new IronTesseract();

using var ocrInput = new OcrInput();
ocrInput.LoadImage("blue_and_pink.png");

ocrInput.WithTitle("Recolored");

ocrInput.ReplaceColor(Color.Pink, Color.White, 10);
// Pink detection has 10% tolerance

ocrInput.ReplaceColor(Color.Blue, Color.Black, 5);
// Blue detection has 5% tolerance

// Export the modified image so you can manually inspect it.
foreach (var page in ocrInput.GetPages())
{
    page.SaveAsImage($"black_and_white_page_{page.Index}.bmp");
}

var ocrResult = ocrTesseract.Read(ocrInput);
Console.WriteLine(ocrResult.Text);
