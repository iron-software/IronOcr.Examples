# How to Output OCR Data as hOCR into HTML Format

***Based on <https://ironsoftware.com/how-to/html-hocr-export/>***


hOCR, which stands for "HTML-based OCR," characterizes a file format designed to document the outcomes of Optical Character Recognition (OCR). This format is embedded into HTML (Hypertext Markup Language) and effectively stores the recognized text, spatial arrangement, and precise coordinates of each detected character from images or documents.

## Quick Guide: Generating an hOCR HTML File with IronOCR

For a swift initiation with IronOCR, here's how to convert OCR results into hOCR format and save them into an HTML file using a straightforward configuration and method call. This approach allows developers to quickly visualize OCR output as structured HTML content.

```cs
:title=IronOCR Quick Configuration for hOCR Output
var hocr = new IronTesseract {
    Configuration = { RenderHocr = true }
}.Read(new OcrInput("image.png")).SaveAsHocrString();
```

## Detailed Example: Saving OCR Results as hOCR HTML

To save OCR results as an hOCR, you must enable the `Configuration.RenderHocr` property by setting it to true. Begin by extracting the OCR outcome using the `Read` method. Then employ the `SaveAsHocrFile` method to commit the result as an HTML file. This produced HTML file will encapsulate the text extracted from the input documents. The following code demonstrates this using a [sample TIFF file](https://ironsoftware.com/static-assets/ocr/how-to/html-export/Potter.tiff).

```csharp
using IronOcr;

// Create IronTesseract instance
IronTesseract ocrTesseract = new IronTesseract();

// Set hOCR rendering enabled
ocrTesseract.Configuration.RenderHocr = true;

// Load image
using var imageInput = new OcrImageInput("Potter.tiff");
imageInput.Title = "Html Title";

// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Save as HTML file
ocrResult.SaveAsHocrFile("result.html");
```

## Outputting OCR Result as HTML String

With IronOCR, exporting the OCR data to an HTML string is straightforward. The method `SaveAsHocrString` facilitates this, directly returning an HTML string generated from OCR data. Here's how you can accomplish this using the same sample TIFF image.

```csharp
// Generate HTML string from OCR results
string hocr = ocrResult.SaveAsHocrString();
```