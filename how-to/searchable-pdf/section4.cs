using IronOcr;
namespace IronOcr.Examples.HowTo.SearchablePdf
{
    public static class Section4
    {
        public static void Run()
        {
            // Export searchable PDF byte
            byte[] pdfByte = ocrResult.SaveAsSearchablePdfBytes();
            
            // Export searchable PDF stream
            Stream pdfStream = ocrResult.SaveAsSearchablePdfStream();
        }
    }
}