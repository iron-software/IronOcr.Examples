using IronOcr;
using IronSoftware.Drawing;

var ocrTesseract = new IronTesseract();
using var ocrInput = new OcrInput();
ocrInput.LoadImage(@"images\image.png");

var ocrResult = ocrTesseract.Read(ocrInput);
foreach (var page in ocrResult.Pages)
{
    foreach (var word in page.Words)
    {
        word.ToBitmap(ocrInput).SaveAs($"page{page.PageNumber}_word{word.WordNumber}.png", AnyBitmap.ImageFormat.Png);
    }
}
