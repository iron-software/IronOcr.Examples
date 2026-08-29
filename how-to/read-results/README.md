# How to Extract Read Results

> Full guide: [How to Extract Read Results](https://ironsoftware.com/csharp/ocr/how-to/read-results/?utm_source=github)


The OCR or read results contain detailed information about the recognized paragraphs, lines, words, and individual characters from the scanned document. Each of these components includes detailed specifics.

For each element, details such as the text content, exact X and Y coordinates, dimensions (width and height), text direction (Left to Right or Top to Bottom), and a location inside a [CropRectangle](https://ironsoftware.com/open-source/csharp/drawing/examples/convert-measurement-unit-of-croprectangle/?utm_source=github) object are provided.

### Quick Start: Extracting the First Detected Word’s Text

Begin quickly by using IronTesseract’s `Read` method to perform OCR on an image, then extract the text of the first detected word via the Words collection – ideal for rapid deployments and simple extraction needs.

```cs
// Title: Instant OCR Text Retrieval
string firstWordText = new IronTesseract().Read("example.jpg").Words[0].Text;
```

## Data in OcrResult

The result from OCR not only presents the extracted text but also includes detailed data about pages, paragraphs, lines, words, characters, and barcodes found in your PDF or image files. This can be accessed through the `OcrResult` instance returned by the `Read` method.

```csharp
using IronOcr;
using System;

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Load image for OCR
using var imageInput = new OcrImageInput("example-image.jpg");
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Fetch the detected paragraphs
Paragraph[] paragraphs = ocrResult.Paragraphs;

// Display extracted information
Console.WriteLine($"Text: {paragraphs[0].Text}");
Console.WriteLine($"X position: {paragraphs[0].X}");
Console.WriteLine($"Y position: {paragraphs[0].Y}");
Console.WriteLine($"Width: {paragraphs[0].Width}");
Console.WriteLine($"Height: {paragraphs[0].Height}");
Console.WriteLine($"Direction of text: {paragraphs[0].TextDirection}");
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/result.webp" alt="Data in OcrResult" class="img-responsive add-shadow">
    </div>
</div>

Each text component, such as paragraphs, lines, words, and individual characters, includes details on:

- Text Content
- X: Horizontal position from the left edge in pixels
- Y: Vertical position from the top edge in pixels
- Width in pixels
- Height in pixels
- Text Reading Direction
- Location: The rectangular area where the text is displayed on the page

## Comparison of Text Components

Here's how different text components look when detected and processed:

<table class="table" style="text-align: center; background-color: #f1f9fb;">
    <tr>
        <td style="width: 50%;">
        <div class="content-img-align-center">
            <div class="center-image-wrapper">
                <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/paragraph.webp" alt="Highlight paragraph" class="img-responsive add-shadow" >
                <p class="competitors__download-link" style="color: #181818; font-style: italic;">Paragraph</p>
            </div>
        </div>
        </td>
        <td style="width: 50%;">
        <div class="content-img-align-center">
            <div class="center-image-wrapper">
                <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/line.webp" alt="Highlight line" class="img-responsive add-shadow" >
                <p class="competitors__download-link" style="color: #181818; font-style: italic;">Line</p>
            </div>
        </div>
        </td>
    </tr>
    <tr>
        <td>
        <div class="content-img-align-center">
            <div class="center-image-wrapper">
                <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/word.webp" alt="Highlight word" class="img-responsive add-shadow" >
                <p class="competitors__download-link" style="color: #181818; font-style: italic;">Word</p>
            </div>
        </div>
        </td>
        <td>
        <div class="content-img-align-center">
            <div class="center-image-wrapper">
                <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/character.webp" alt="Highlight character" class="img-responsive add-shadow" >
                <p class="competitors__download-link" style="color: #181818; font-style: italic;">Character</p>
            </div>
        </div>
        </td>
    </tr>
</table>

## Barcode and QR Code Recognition

Indeed, IronOcr is capable of recognizing barcodes and QR codes. While this feature might not be as exhaustive as IronBarcode, it supports common barcode formats effectively. Enable barcode detection by setting the `Configuration.ReadBarCodes` property to true.

Furthermore, you can extract crucial details from every detected barcode, including its type, value, coordinates, dimensions, and location defined by the **Rectangle** class from [IronDrawing](https://ironsoftware.com/open-source/csharp/drawing/docs/?utm_source=github).

```csharp
using IronOcr;
using System;

// Prepare IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Activate barcode detection
ocrTesseract.Configuration.ReadBarCodes = true;

// Load PDF for OCR processing
using OcrInput ocrInput = new OcrInput();
ocrInput.LoadPdf("example-document.pdf");

// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(ocrInput);

// Show barcode data
foreach(var barcode in ocrResult.Barcodes)
{
    Console.WriteLine("Barcode Format = " + barcode.Format);
    Console.WriteLine("Barcode Value = " + barcode.Value);
    Console.WriteLine("X-coordinate = " + barcode.X);
    Console.WriteLine("Y-coordinate = " + barcode.Y);
}
Console.WriteLine(ocrResult.Text);
```

### Visualization of Barcode Detection
<div class="content-img-align-center">
    <div class="center-image-wrapper">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/barcodes.webp" alt="Detect barcodes" class="img-responsive add-shadow" >
    </div>
</div>