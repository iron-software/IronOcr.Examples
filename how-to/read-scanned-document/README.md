# Working with IronOCR to Process Scanned Documents

***Based on <https://ironsoftware.com/how-to/read-scanned-document/>***


Extracting text from PDFs that contain image-based and non-searchable content can be quite challenging. IronOCR offers a robust solution to convert such text into searchable content, significantly enhancing ease of access and searching capabilities. This is particularly beneficial for individuals with visual impairments and those dealing with large volumes of documentation.

Automated extraction through IronOCR not only avoids the inaccuracies of manual copying but also significantly improves efficiency in dealing with critical data. Such capabilities are crucial for sectors requiring precise documentation, including legal and research fields, and for businesses looking to streamline data integration into their systems.

Additionally, the technology proves invaluable for designers and marketers who need to repurpose images contained within these documents.

In this guide, let's dive into how the `OcrPdfInput` methods provided by IronOCR can be leveraged to streamline text and image extraction from PDFs across various professional settings.



In order to begin utilizing these capabilities, be sure to include the [IronOcr.Extension.AdvancedScan](https://www.nuget.org/packages/IronOcr.Extensions.AdvancedScan) package in your project.

## Example of Reading Scanned Documents

For extracting text from images within a document, the `ReadDocument` method is employed. Once executed, this method delivers an object that carries the extracted text, accessible via the Text property. The following example demonstrates extracting text from a [sample TIFF](https://ironsoftware.com/static-assets/ocr/how-to/read-scanned-document/Potter.tiff) image file.

- Note: Current language support includes English, Chinese, Japanese, Korean, and Latin Alphabet.
- Reminder: Utilizing advanced scan functionalities requires running the project on an x64 architecture within the .NET Framework.

### Sample Input

![Sample Input Image](https://ironsoftware.com/static-assets/ocr/how-to/read-scanned-document/input.webp)

### Implementation Code

```cs
using IronOcr;
using System;

// Initialize the OCR engine
var ocr = new IronTesseract();

// Set up the OCR input
using var input = new OcrInput();
input.LoadImage("potter.tiff");

// Execute OCR
OcrResult result = ocr.ReadDocument(input);

// Output the result
Console.WriteLine(result.Text);
```

### Expected Output

![Processed Output](https://ironsoftware.com/static-assets/ocr/how-to/read-scanned-document/output.webp)

For instances where you need to extract text from PDF documents, simply substitute the `LoadImage` method with `LoadPdf` in the above code. This adjustment will enable IronOCR to effectively handle and extract textual content from scanned PDFs, similar to its processing of image files.