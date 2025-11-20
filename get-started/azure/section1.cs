using IronOcr;
namespace IronOcr.Examples.GettingStarted.Azure
{
    public static class Section1
    {
        public static void Run()
        {
            var OCR = new IronTesseract();
            using (var input = new OcrInput())
            {
                input.Title = "Divine Comedy - Purgatory"; // Give title to input document 
                // Supply optional password and name of document
                input.AddPdf("..\\Documents\\Purgatorio.pdf", "dante");
                var result = OCR.Read(input); // Read the input file
                            
                result.SaveAsSearchablePdf("SearchablePDFDocument.pdf"); 
            }
        }
    }
}