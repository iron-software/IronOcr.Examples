using IronOcr;
namespace IronOcr.Examples.HowTo.TesseractResultConfidence
{
    public static class Section3
    {
        public static void Run()
        {
            // Get page confidence level
            double pageConfidence = ocrResult.Pages[0].Confidence;
            
            // Get paragraph confidence level
            double paragraphConfidence = ocrResult.Paragraphs[0].Confidence;
            
            // Get line confidence level
            double lineConfidence = ocrResult.Lines[0].Confidence;
            
            // Get word confidence level
            double wordConfidence = ocrResult.Words[0].Confidence;
            
            // Get character confidence level
            double characterConfidence = ocrResult.Characters[0].Confidence;
            
            // Get block confidence level
            double blockConfidence = ocrResult.Blocks[0].Confidence;
        }
    }
}