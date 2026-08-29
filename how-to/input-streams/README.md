# How to Read from Streams

> Full guide: [How to Read from Streams](https://ironsoftware.com/csharp/ocr/how-to/input-streams/?utm_source=github)


In programming, stream data represents an ongoing flow of binary data that can be incrementally read or written. This technique is vital for handling large datasets that cannot be stored entirely in memory, allowing parts of the data to be processed individually.

IronOCR supports importing image data directly from streams. To utilize this functionality, simply feed the stream into one of the available import methods, and it will take care of converting the image stream for OCR processing.

## Quickstart: Stream-Based OCR Input

Here's a quick guide on initializing OCR processing by directly using a `System.IO.Stream` with IronOCR. This approach bypasses the need for file paths, enabling direct access to recognized text efficiently.

```cs
using var input = new IronOcr.OcrInput(stream);
var result = new IronOcr.IronTesseract().Read(input);
```

## Stream Reading Example

Initially, create an instance of the **IronTesseract** class to start the OCR process. To load the image file, utilize the `FromFile` method from AnyBitmap, which converts the image to a stream. Use a `using` statement to initialize an `OcrImageInput` object by supplying the image stream obtained via the `GetStream` method from your AnyBitmap instance. To execute the OCR, simply call the `Read` method.

```csharp
using IronOcr;
using IronSoftware.Drawing;

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Load image file into AnyBitmap
AnyBitmap anyBitmap = AnyBitmap.FromFile("Potter.tiff");

// Stream the image data
using var imageInput = new OcrImageInput(anyBitmap.GetStream());
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);
```

## Define Scan Area

For enhanced performance on extensive images or to focus on specific details within an image, the `CropRectangle` structure is useful. When constructing an `OcrImageInput`, you can pass a `CropRectangle` instance as an argument to delineate the portion of the image to analyze. The example below demonstrates cropping to read only the chapter number and title from an image.

```csharp
using IronOcr;
using IronSoftware.Drawing;
using System;

// Create IronTesseract instance
IronTesseract ocrTesseract = new IronTesseract();

// Load image file into AnyBitmap
AnyBitmap anyBitmap = AnyBitmap.FromFile("Potter.tiff");

// Define scanning region
Rectangle scanRegion = new Rectangle(800, 200, 900, 400);

// Prepare the image with specified region
using var imageInput = new OcrImageInput(anyBitmap.GetStream(), ContentArea: scanRegion);
// Conduct OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Display OCR result
Console.WriteLine(ocrResult.Text);
```

### OCR Output Visualization

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-images/read-specific-region.webp" alt="OCR of specified image region" class="img-responsive add-shadow">
    </div>
</div>