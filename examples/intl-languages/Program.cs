using IronOcr;
using System;

var ocrTesseract = new IronTesseract();

ocrTesseract.Language = OcrLanguage.Arabic;

using (var ocrInput = new OcrInput())
{
    ocrInput.LoadImage(@"images\arabic.gif");
    var ocrResult = ocrTesseract.Read(ocrInput);
    Console.WriteLine(ocrResult.Text);
}

// Example with a Custom Trained Font Being used:

var ocrTesseractCustomerLang = new IronTesseract();
ocrTesseractCustomerLang.UseCustomTesseractLanguageFile("custom_tesseract_files/custom.traineddata");
ocrTesseractCustomerLang.AddSecondaryLanguage(OcrLanguage.EnglishBest);

using (var ocrInput = new OcrInput())
{
    ocrInput.LoadPdf(@"images\mixed-lang.pdf");
    var ocrResult = ocrTesseractCustomerLang.Read(ocrInput);
    Console.WriteLine(ocrResult.Text);
}
