# IronOcr.Examples

Runnable C# examples for [IronOCR](https://ironsoftware.com/csharp/ocr/), a .NET OCR library built on a tuned Tesseract 5 engine. Extracts text from images, scanned PDFs, and multi-page documents in 125 languages.

## Install

```bash
dotnet add package IronOcr
```

## Quickstart

```csharp
using IronOcr;

var ocr = new IronTesseract();
using var input = new OcrInput();
input.LoadImage("scan.png");

var result = ocr.Read(input);
Console.WriteLine(result.Text);
```

`OcrInput` also accepts PDFs via `input.LoadPdf("doc.pdf")` and multi-page TIFFs via `input.LoadImageFrames("multipage.tiff", pages)`. For real-world documents, apply `input.Deskew()` and `input.DeNoise()` before reading to improve accuracy on skewed or noisy scans.

For production use, set a license key via `License.LicenseKey = "YOUR-KEY"`. Without one, results are watermarked.

## What's in this repo

Each folder contains a self-contained .NET project you can open and run:

- `examples/` — focused snippets demonstrating individual features
- `get-started/` — minimal first projects covering installation and basic OCR
- `how-to/` — task-oriented guides for specific OCR operations
- `quickstart/` — end-to-end project scaffolds
- `tutorials/` — longer walkthroughs combining multiple features

## Common tasks covered

- Image-to-text and PDF-to-text extraction
- Multi-language and multi-script OCR (125 languages supported)
- Reading barcodes and QR codes from documents
- Exporting searchable PDFs and hOCR HTML
- Confidence scores, bounding boxes, and structured paragraph/line/word output
- Preprocessing filters: deskew, denoise, contrast, resolution enhancement
- Region cropping and page selection

## Platform support

.NET 8, 7, 6, 5, .NET Core, .NET Standard 2, and .NET Framework 4.6.2+. Windows, macOS, Linux, Docker, Azure, and AWS. 64-bit architecture is required. See the [installation docs](https://ironsoftware.com/csharp/ocr/docs/) for environment-specific notes.

## Documentation and support

- Full documentation: [ironsoftware.com/csharp/ocr/docs](https://ironsoftware.com/csharp/ocr/docs/)
- API reference: [ironsoftware.com/csharp/ocr/object-reference/api](https://ironsoftware.com/csharp/ocr/object-reference/api/)
- Issues with these examples: file directly on this repository
- Product support: [support@ironsoftware.com](mailto:support@ironsoftware.com)

## About

This repository is maintained by [Iron Software](https://ironsoftware.com/). IronOCR is a commercial library — see [licensing](https://ironsoftware.com/csharp/ocr/licensing/) for terms and trial details.
