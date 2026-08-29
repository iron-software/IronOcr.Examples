# Utilizing Multiple Languages with Tesseract

> Full guide: [Utilizing Multiple Languages with Tesseract](https://ironsoftware.com/csharp/ocr/how-to/ocr-multiple-languages/)


IronOCR runs on the Tesseract Engine and extracts text across a wide range of languages and scripts. This guide covers how it handles text in several languages at once.

## Quickstart: Deploying IronOCR for Multilingual Text Recognition

Configuring IronOCR to recognize several languages takes very little code.

```cs
string extractedText = new IronTesseract { Language = OcrLanguage.Spanish }.AddSecondaryLanguage(OcrLanguage.French).Read("path_to_document_or_image").Text;
```

## Example: Extracting Text from Multi-Language PDFs

Although IronOCR supports the recognition in approximately 125 languages, it installs with only the English language pack by default. Additional language packs can be accessed via NuGet. View all supported [language packs here](https://ironsoftware.com/csharp/ocr/languages).

Below is an example of how to utilize IronOCR for text extraction from a multilingual PDF document:

```csharp
using IronOcr;
using System;

// Create a new IronTesseract instance
IronTesseract ocrEngine = new IronTesseract();

// Set a secondary language to Russian
ocrEngine.AddSecondaryLanguage(OcrLanguage.Russian);

// Load a PDF file
using var pdfFile = new OcrPdfInput("example.pdf");
// Execute OCR on the loaded PDF
OcrResult ocrResult = ocrEngine.Read(pdfFile);

// Print the OCR result
Console.WriteLine(ocrResult.Text);
```

Adding multiple secondary languages is possible with the `AddSecondaryLanguage` method, but be aware that this might impact the OCR performance and speed. The priority of the languages is based on their addition order.

## Example: OCR on a Multi-Language Image

By default, the primary language is set to English. You can adjust the primary language and add multiple secondary languages as needed.

```csharp
using IronOcr;
using System;

// Establish a new IronTesseract instance
IronTesseract ocr = new IronTesseract();

// Define primary and secondary languages
ocr.Language = OcrLanguage.Hindi;
ocr.AddSecondaryLanguage(OcrLanguage.Japanese);

// Load an image for OCR
using var imageToRead = new OcrImageInput("example.png");
// Process OCR on the image
OcrResult textResult = ocr.Read(imageToRead);

// Display the extracted text
Console.WriteLine(textResult.Text);
```

When set up correctly, you can achieve results as displayed below.

![Russian and Japanese Example](https://ironsoftware.com/static-assets/ocr/how-to/multiple-languages/russian_japanese%20.webp)

## Conclusion

Summarizing, IronOCR, powered by the efficacious Tesseract engine, is exceptionally capable at extracting text from documents and images across a diverse range of languages. It provides a flexible and potent tool for developers and those interested in the intricacies of multilingual text processing, simplifying the recognition and extraction of text from varied language sources. Whether your projects involve PDFs or images with texts in different languages, IronOCR facilitates an easier handling of these tasks.