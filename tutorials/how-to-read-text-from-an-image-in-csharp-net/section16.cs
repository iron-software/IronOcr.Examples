using IronSoftware.Drawing;
using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section16
    {
        public static void Run()
        {
            // Configure with barcode support
            IronTesseract ocr = new IronTesseract
            {
                Configuration = { ReadBarCodes = true }
            };
            
            using OcrInput input = new OcrInput();
            
            // Process multi-page document
            int[] pageIndices = { 1, 2 };
            input.LoadImageFrames(@"img\Potter.tiff", pageIndices);
            
            OcrResult result = ocr.Read(input);
            
            // Navigate the complete results hierarchy
            foreach (var page in result.Pages)
            {
                // Page-level data
                int pageNumber = page.PageNumber;
                string pageText = page.Text;
                int pageWordCount = page.WordCount;
            
                // Extract page elements
                OcrResult.Barcode[] barcodes = page.Barcodes;
                AnyBitmap pageImage = page.ToBitmap();
                double pageWidth = page.Width;
                double pageHeight = page.Height;
            
                foreach (var paragraph in page.Paragraphs)
                {
                    // Paragraph properties
                    int paragraphNumber = paragraph.ParagraphNumber;
                    string paragraphText = paragraph.Text;
                    double paragraphConfidence = paragraph.Confidence;
                    var textDirection = paragraph.TextDirection;
            
                    foreach (var line in paragraph.Lines)
                    {
                        // Line details including baseline information
                        string lineText = line.Text;
                        double lineConfidence = line.Confidence;
                        double baselineAngle = line.BaselineAngle;
                        double baselineOffset = line.BaselineOffset;
            
                        foreach (var word in line.Words)
                        {
                            // Word-level data
                            string wordText = word.Text;
                            double wordConfidence = word.Confidence;
            
                            // Font information (when available)
                            if (word.Font != null)
                            {
                                string fontName = word.Font.FontName;
                                double fontSize = word.Font.FontSize;
                                bool isBold = word.Font.IsBold;
                                bool isItalic = word.Font.IsItalic;
                            }
            
                            foreach (var character in word.Characters)
                            {
                                // Character-level analysis
                                string charText = character.Text;
                                double charConfidence = character.Confidence;
            
                                // Alternative character choices for spell-checking
                                OcrResult.Choice[] alternatives = character.Choices;
                            }
                        }
                    }
                }
            }
        }
    }
}