# Guide to Reading Scanned Documents with IronOCR

> Full guide: [Guide to Reading Scanned Documents with IronOCR](https://ironsoftware.com/how-to/read-scanned-document/)


IronOCR excels at transforming the non-searchable, image-based text commonly found in many PDFs into fully searchable content. This facilitates easier information retrieval and increases document accessibility, benefiting those with visual impairments significantly.

By automating the extraction of text and images, IronOCR bypasses the need for manual transcription, enhancing both accuracy and productivity. This functionality proves invaluable in fields like research, legal affairs, and content production where repurposing specific segments of PDFs is frequent.

Companies can use IronOCR to pull essential data from PDFs for further analysis or system integration, optimizing their business processes. Similarly, designers and marketers can extract images for modification and incorporation into diverse projects.

Throughout this guide, we illuminate the usage of `OcrPdfInput` methods, detailing the assorted settings and parameters to illustrate how IronOCR simplifies the process of extracting text and images from PDFs across various use cases.

Before beginning, ensure to install the [`IronOcr.Extensions.AdvancedScan`](https://www.nuget.org/packages/IronOcr.Extensions.AdvancedScan) package.

### Quickstart: Text Extraction from a Scanned PDF or Image

Kickstart your project instantly—utilize either IronOCR's `OcrInput.LoadPdf` or `LoadImage` methods to load your scanned PDF or image. Immediately after, extract text using the `ReadDocument` functionality, a must-have for developers seeking swift implementation of OCR.

```cs
// Title: Efficiently OCR Your Scanned Document
var text = new IronOcr.IronTesseract().ReadDocument(new IronOcr.OcrInput().LoadPdf("scanned.pdf")).Text;
```


## Example: Reading Scanned Documents

To retrieve text from all images in a document, apply the `ReadDocument` method. This method processes the document and yields an object with the extracted text, available via the Text property. Below is how to employ this method with a [sample TIFF](https://ironsoftware.com/static-assets/ocr/how-to/read-scanned-document/potter.tiff) image.


- Currently, the method supports languages including English, Chinese, Japanese, Korean, and the Latin Alphabet.
- Running advanced scans on .NET Framework mandates the use of x64 architecture.


### Input

![Input Image](https://ironsoftware.com/static-assets/ocr/how-to/read-scanned-document/input.webp)

### Code

```csharp
using IronOcr;
using System;

// Create OCR engine instance
var ocr = new IronTesseract();

// Set up OCR engine
using var input = new OcrInput();
input.LoadImage("potter.tiff");

// Execute OCR
OcrResult result = ocr.ReadDocument(input);

Console.WriteLine(result.Text);
```

### Output

![Output Image](https://ironsoftware.com/static-assets/ocr/how-to/read-scanned-document/output.webp)

For OCR operations on PDF files, simply substitute `LoadImage` with `LoadPdf`, permitting IronOCR to apply its text extraction capabilities to scanned PDFs equivalently.