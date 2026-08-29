# How to Read PDFs

> Full guide: [How to Read PDFs](https://ironsoftware.com/how-to/input-pdfs/)


PDF, an acronym for "Portable Document Format," was devised by Adobe as a method to maintain the originality of documents, making them look consistent irrespective of the tools employed to develop them. PDFs are commonly utilized for the distribution and viewing of documents, maintaining the same visual format across different platforms and devices. IronOcr is proficient at managing various types of PDF documents.

## Quickstart: OCR a PDF File in Seconds

Get started with IronOCR by creating an `OcrPdfInput` pointing towards your PDF file and invoking the `Read` method. Here’s a straightforward example that demonstrates how simple it is to extract text from a PDF file with IronOCR.

```cs
using var result = new IronOcr.IronTesseract().Read(new IronOcr.OcrPdfInput("your-document.pdf", PdfContents.TextAndImages));
```

## Example: Reading a PDF

To perform OCR on a PDF file, first, create an instance of the `IronTesseract` class. Utilize a 'using' statement to define an `OcrPdfInput`, specify the path to the PDF file, and then engage the `Read` method to carry out OCR.

```csharp
using IronOcr;

// Create an instance of IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Specify PDF path
using var pdfInput = new OcrPdfInput("example.pdf");
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(pdfInput);
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-pdfs/read-pdf.webp" alt="Read PDF file" class="img-responsive add-shadow">
    </div>
</div>

Typically, setting the DPI is not necessary, but specifying a higher DPI during the `OcrPdfInput` setup can improve the OCR accuracy.

## Reading Specific PDF Pages Example

To process specific pages within a PDF, you can designate which pages to read by passing their index numbers to the `PageIndices` parameter when you construct an `OcrPdfInput`. Remember, these indices start from zero.

```csharp
using IronOcr;
using System.Collections.Generic;

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Define page indices
List<int> pageIndices = new List<int>() { 0, 2 };

// Load PDF with specified pages
using var pdfInput = new OcrPdfInput("example.pdf", PageIndices: pageIndices);
// Extract text via OCR
OcrResult ocrResult = ocrTesseract.Read(pdfInput);
```

## Setting an OCR Scan Region

Focusing on a specific section can increase the effectiveness of the OCR. You can define a precise area of the PDF to be processed. Below is how you set IronOcr to only extract information such as a chapter number and title.

```csharp
using IronOcr;
using IronSoftware.Drawing;
using System;

// Create an instance of IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Define OCR scan region
Rectangle[] scanRegions = { new Rectangle(550, 100, 600, 300) };

// Configure OCR input
using (var pdfInput = new OcrPdfInput("example.pdf", ContentAreas: scanRegions))
{
    // Execute OCR
    OcrResult ocrResult = ocrTesseract.Read(pdfInput);

    // Display OCR results
    Console.WriteLine(ocrResult.Text);
}
```

### OCR Result

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-pdfs/read-specific-region.webp" alt="Read specific region" class="img-responsive add-shadow">
    </div>
</div>