using IronOcr;
namespace IronOcr.Examples.HowTo.ImageQualityCorrection
{
    public static class Section7
    {
        public static void Run()
        {
            var ocr = new IronTesseract();
            var ocrInput = new OcrInput();
            
            // Load a PDF file
            ocrInput.LoadPdf("invoice.pdf");
            
            // Apply gray scale filter
            ocrInput.ToGrayScale();
            OcrResult result = ocr.Read(ocrInput);
            
            // Save the result as a searchable PDF with filters applied
            result.SaveAsSearchablePdf("outputGrayscale.pdf", true);
        }
    }
}