using IronOcr;
using IronSoftware.Drawing;

// We can delve deep into OCR results as an object model of
// Pages, Barcodes, Paragraphs, Lines, Words and Characters
// This allows us to explore, export and draw OCR content using other APIs/
var ocrTesseract = new IronTesseract();

ocrTesseract.Configuration.ReadBarCodes = true;

using var ocrInput = new OcrInput();
var pages = new int[] { 1, 2 };
ocrInput.LoadImageFrames("example.tiff", pages);

OcrResult ocrResult = ocrTesseract.Read(ocrInput);
foreach (var page in ocrResult.Pages)
{
    // Page object
    int PageNumber = page.PageNumber;
    string PageText = page.Text;
    int PageWordCount = page.WordCount;
    // null if we dont set Ocr.Configuration.ReadBarCodes = true;
    OcrResult.Barcode[] Barcodes = page.Barcodes;
    AnyBitmap PageImage = page.ToBitmap(ocrInput);
    double PageWidth = page.Width;
    double PageHeight = page.Height;
    double PageRotation = page.Rotation; // angular correction in degrees from OcrInput.Deskew()

    foreach (var paragraph in page.Paragraphs)
    {
        // Pages -> Paragraphs
        int ParagraphNumber = paragraph.ParagraphNumber;
        string ParagraphText = paragraph.Text;
        AnyBitmap ParagraphImage = paragraph.ToBitmap(ocrInput);
        int ParagraphX_location = paragraph.X;
        int ParagraphY_location = paragraph.Y;
        int ParagraphWidth = paragraph.Width;
        int ParagraphHeight = paragraph.Height;
        double ParagraphOcrAccuracy = paragraph.Confidence;
        OcrResult.TextFlow paragrapthText_direction = paragraph.TextDirection;
        foreach (var line in paragraph.Lines)
        {
            // Pages -> Paragraphs -> Lines
            int LineNumber = line.LineNumber;
            string LineText = line.Text;
            AnyBitmap LineImage = line.ToBitmap(ocrInput);
            int LineX_location = line.X;
            int LineY_location = line.Y;
            int LineWidth = line.Width;
            int LineHeight = line.Height;
            double LineOcrAccuracy = line.Confidence;
            double LineSkew = line.BaselineAngle;
            double LineOffset = line.BaselineOffset;
            foreach (var word in line.Words)
            {
                // Pages -> Paragraphs -> Lines -> Words
                int WordNumber = word.WordNumber;
                string WordText = word.Text;
                AnyBitmap WordImage = word.ToBitmap(ocrInput);
                int WordX_location = word.X;
                int WordY_location = word.Y;
                int WordWidth = word.Width;
                int WordHeight = word.Height;
                double WordOcrAccuracy = word.Confidence;
                foreach (var character in word.Characters)
                {
                    // Pages -> Paragraphs -> Lines -> Words -> Characters
                    int CharacterNumber = character.CharacterNumber;
                    string CharacterText = character.Text;
                    AnyBitmap CharacterImage = character.ToBitmap(ocrInput);
                    int CharacterX_location = character.X;
                    int CharacterY_location = character.Y;
                    int CharacterWidth = character.Width;
                    int CharacterHeight = character.Height;
                    double CharacterOcrAccuracy = character.Confidence;
                    // Output alternative symbols choices and their probability.
                    // Very useful for spellchecking
                    OcrResult.Choice[] Choices = character.Choices;
                }
            }
        }
    }
}
