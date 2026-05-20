# Understanding OCR Read Confidence

***Based on <https://ironsoftware.com/how-to/tesseract-result-confidence/>***


OCR (Optical Character Recognition) read confidence pertains to the degree of certainty that an OCR system has regarding the precision of the text it has deciphered from an image or document. Essentially, it gauges how assured the OCR technology is about the correctness of the interpreted text.

A higher confidence score signals a strong conviction that the detected text is accurate, whereas a lower score may indicate potential unreliability in the text recognition process.

## Quickstart: Instantly Determine OCR Read Confidence

To quickly ascertain the OCR confidence level using IronTesseract, simply use the `Read` method with the path of an image file. Afterward, you can inspect the `Confidence` property on the resultant `OcrResult` to gauge IronOCR's certainty regarding its text recognition accuracy.

```cs
:title=Instant OCR Confidence Check
double confidence = new IronOcr.IronTesseract().Read("your-image.png").Confidence;
```

## Detailed Example of Retrieving OCR Read Confidence

To extract the confidence level of the text after implementing OCR on an input image, you should access the `Confidence` property from the `OcrResult`. Employ the `using` directive to ensure proper disposal of resources. Input files such as images or PDFs can be handled with `OcrImageInput` and `OcrPdfInput` classes respectively. The `Read` function provides an `OcrResult` through which the `Confidence` property can be accessed.

```csharp
using IronOcr;

// Create a new IronTesseract instance
IronTesseract ocrTesseract = new IronTesseract();

// Load the image
using var imageInput = new OcrImageInput("example-image.tiff");
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Obtain the confidence level
double confidence = ocrResult.Confidence;
```

## Accessing Various Levels of Read Confidence

It's possible not only to determine the confidence for the entire document but also for each hierarchical level within the document such as pages, paragraphs, lines, words, characters, and text blocks, each potentially offering different confidence levels.

```csharp
// Access page confidence
double pageConfidence = ocrResult.Pages[0].Confidence;

// Access paragraph confidence
double paragraphConfidence = ocrResult.Paragraphs[0].Confidence;

// Access line confidence
double lineConfidence = ocrResult.Lines[0].Confidence;

// Access word confidence
double wordConfidence = ocrResult.Words[0].Confidence;

// Access character confidence
double characterConfidence = ocrResult.Characters[0].Confidence;

// Access block confidence
double blockConfidence = ocrResult.Blocks[0].Confidence;
```

## Exploring Character Choices

Beyond confidence levels, IronOCR provides a `Choices` property that offers alternative interpretations of the words read, along with their statistical probabilities. This feature could be extremely helpful for further accuracy validation or insights into potential OCR misreads.

```csharp
using IronOcr;
using static IronOcr.OcrResult;

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Load the image
using var imageInput = new OcrImageInput("sample-image.tiff");
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Retrieve character choices
Choice[] choices = ocrResult.Characters[0].Choices;
```

### Visual Representation

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/tesseract-result-confidence/choices.webp" alt="Character Choices" class="img-responsive add-shadow">
    </div>
</div>