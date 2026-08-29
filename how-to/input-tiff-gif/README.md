# Reading Multi-Frame/Page GIFs and TIFFs

> Full guide: [Reading Multi-Frame/Page GIFs and TIFFs](https://ironsoftware.com/csharp/ocr/how-to/input-tiff-gif/?utm_source=github)


TIFF (Tagged Image File Format) is an ideal format for storing high-quality images. It uses lossless compression to preserve the pristine condition of images, which is crucial for scanned documents or high-resolution photography.

GIF (Graphics Interchange Format) is typically used for simpler web graphics and animations. This format is flexible in that it supports both lossless and lossy compression methods and is widely used for its ability to display animated images in a single file, commonly in web contexts and digital communication.

## Quickstart: OCR with Multi-Frame TIFF or GIF Files

Discover the simplicity of extracting text from multi-page TIFFs or animated GIFs using IronOCR. Only a few steps are necessary, starting with an `OcrImageInput` and a `Read` function.

```cs
using IronOcr;
var result = new IronTesseract().Read(new OcrImageInput("Potter.tiff"));
```

## OCR on a Single/Multi-Frame TIFF Example

Begin by creating an instance of the IronTesseract class. Use a `using` statement to initiate the `OcrImageInput` object, which accepts both single and multi-frame TIFF files. Then, execute the `Read` method to perform OCR on your chosen TIFF image.

```csharp
using IronOcr;

// Initialize the IronTesseract engine
IronTesseract ocrTesseract = new IronTesseract();

// Load the TIFF/TIF image
using var imageInput = new OcrImageInput("Potter.tiff");
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-tiff-gif/read-tiff.webp" alt="Reading TIFF image" class="img-responsive add-shadow">
    </div>
</div>

## OCR on GIFs

For GIFs, the procedure is straightforward: define the GIF file path while initializing the `OcrImageInput` object, which will manage all necessary preparations for the image.

```csharp
using IronOcr;

// Set up IronTesseract OCR engine
IronTesseract ocrTesseract = new IronTesseract();

// Load the GIF image
using var imageInput = new OcrImageInput("Potter.gif");
// Conduct OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);
```

## Specifying a Scanning Region

Enhance OCR accuracy by using the `CropRectangle` object in the `OcrImageInput` class initialization. This allows you to specify a particular region in the image for OCR, improving performance on larger or detailed documents.

```csharp
using IronOcr;
using IronSoftware.Drawing;
using System;

// Initialize IronTesseract OCR engine
IronTesseract ocrTesseract = new IronTesseract();

// Define the OCR scan region
Rectangle scanRegion = new Rectangle(800, 200, 900, 400);

// Prepare the image with defined region
using var imageInput = new OcrImageInput("Potter.tiff", ContentArea: scanRegion);
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Display the OCR results
Console.WriteLine(ocrResult.Text);
```

### OCR Result Display

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-images/read-specific-region.webp" alt="OCR reading specific region" class="img-responsive add-shadow">
    </div>
</div>