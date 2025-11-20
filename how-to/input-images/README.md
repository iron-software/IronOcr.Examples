# How to Read Images

***Based on <https://ironsoftware.com/how-to/input-images/>***


Optical Character Recognition, or OCR, is a technology that is used to recognize text within images. This technology is particularly beneficial for converting printed documents into a digital format, allowing for the extraction and manipulation of text from scanned documents, photographs, or other image types.

IronOCR supports various image formats, including JPG, PNG, GIF, TIFF, and BMP. Additionally, image filters are available to improve the accuracy of text recognition.

## Quickstart: Read an Image File with IronOCR

You can begin extracting text from an image with a single line of code by using the `Read` method on the `IronTesseract` class. Below, we demonstrate a simple example that illustrates how to quickly load an image and read its text using IronOCR.

```cs
:title=Effortless Text Extraction with IronOCR
var result = new IronTesseract().Read(new OcrImageInput("Potter.png"));
```

## Read Images Example

Start by creating an instance of the `IronTesseract` class to activate OCR capabilities. Use the `using` statement to instantiate an `OcrImageInput` object with the specified image file path, ensuring that resources are managed correctly. IronOCR accepts input images in formats such as JPG, PNG, GIF, TIFF, and BMP. Use the `Read` method to initiate OCR.

From version 2025.6 onwards:
- TIFF image loading processes have significantly improved in speed.
- Depending on the system's GPU, TIFF image reading can now be up to twice as fast compared to older versions.

```csharp
using IronOcr;

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Load image
using var imageInput = new OcrImageInput("Potter.png");

// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);
```

<div class="content-img-align-center">
  <div class="center-image-wrapper">
       <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-images/read-png.webp" alt="Read PNG image" class="img-responsive add-shadow">
  </div>
</div>

Explore further by reading the [How to Read Multi-Frame/Page GIFs and TIFFs](https://ironsoftware.com/csharp/ocr/how-to/input-tiff-gif/) article.

## Import Images as Bytes

In addition to file paths, the `OcrImageInput` class also accepts images as byte arrays, `AnyBitmap`, `Stream`, or `Image`. The `AnyBitmap` is a representation of a bitmap image from [IronSoftware.Drawing.AnyBitmap](https://ironsoftware.com/open-source/csharp/drawing/examples/bitmap-to-stream/).

```csharp
using IronOcr;
using System.IO;

// Create IronTesseract instance
IronTesseract ocrTesseract = new IronTesseract();

// Load image bytes from a file
byte[] data = File.ReadAllBytes("Potter.tiff");

// Create OcrImageInput with bytes
using var imageInput = new OcrImageInput(data);
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);
```

## Specify Scan Region

You can also specify a particular region of an image for OCR by using a `CropRectangle`. This can greatly enhance the efficiency of the reading process depending on your document's layout. Below is a code example where only a specific section of the image is subjected to OCR.

```csharp
using IronOcr;
using IronSoftware.Drawing;
using System;

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Define the scan region
Rectangle scanRegion = new Rectangle(800, 200, 900, 400);

// Load image and apply crop region
using var imageInput = new OcrImageInput("Potter.tiff", ContentArea: scanRegion);
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Display the OCR results
Console.WriteLine(ocrResult.Text);
```

### OCR Result

<div class="content-img-align-center">
  <div class="center-image-wrapper">
       <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-images/read-specific-region.webp" alt="Read specific region" class="img-responsive add-shadow">
  </div>
</div>