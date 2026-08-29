# How to Work with System.Drawing Objects

> Full guide: [How to Work with System.Drawing Objects](https://ironsoftware.com/csharp/ocr/how-to/input-system-drawing/)


The `.NET Framework` provides the `System.Drawing.Bitmap` class, which is an essential tool for handling bitmap images. It offers features for creating, manipulating, and displaying bitmaps.

For more generalized image handling, `.NET` uses `System.Drawing.Image`. This base class supports all GDI+ image types and serves as the parent class for `System.Drawing.Bitmap`.

The `IronSoftware.Drawing.AnyBitmap` extends the capabilities originally found in `System.Drawing.Common`, allowing cross-platform image processing. It's a core class of the [IronDrawing](https://ironsoftware.com/open-source/csharp/drawing/docs/) library, a project by Iron Software designed to aid C# developers in their graphic handling tasks on Windows, macOS, and Linux.

## Quickstart: Extract Text from a System.Drawing.Bitmap

You can easily extract text from a bitmap image using just a single line of code. Below is how you can utilize `IronTesseract` with `OcrImageInput` to convert image data into text swiftly.

```cs
var result = new IronOcr.IronTesseract().Read(new IronOcr.OcrImageInput(new System.Drawing.Bitmap("image.png")));
```

## Procedure to Read System.Drawing.Bitmap

Initialize an `IronTesseract` object to use for OCR purposes. Start by creating a `System.Drawing.Bitmap` from a file.

In the example provided, the `using` statement is employed to create an `OcrImageInput` object with the bitmap, and thereafter, the `Read` method is called to execute OCR.

```csharp
using IronOcr;
using System.Drawing;

// Instantiate IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Load image into a Bitmap
Bitmap bitmap = new Bitmap("Potter.tiff");

// Create OcrImageInput with the bitmap
using var imageInput = new OcrImageInput(bitmap);
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);
```

## Example of Reading from System.Drawing.Image

The process of reading from a `System.Drawing.Image` mirrors that of a bitmap. Simply create an `OcrImageInput` with the image object and call the `Read` method to perform OCR.

```csharp
using IronOcr;
using Image = System.Drawing.Image;

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Load image as Image type
Image image = Image.FromFile("Potter.tiff");

// Create OcrImageInput with the image
using var imageInput = new OcrImageInput(image);
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);
```

## Working with IronSoftware.Drawing.AnyBitmap

Using an `AnyBitmap` object from Iron Software, you can similarly convert images to text. Below is how it can be utilized within `OcrImageInput` for OCR tasks.

```csharp
using IronOcr;
using IronSoftware.Drawing;

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Load AnyBitmap from file
AnyBitmap anyBitmap = AnyBitmap.FromFile("Potter.tiff");

// Create OcrImageInput with AnyBitmap
using var imageInput = new OcrImageInput(anyBitmap);
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);
```

## Define Scanning Area

It's possible to enhance OCR accuracy and performance by specifying a particular area of the image for scanning. Here, the example focuses on extracting text from a specified chapter number and title.

```csharp
using IronOcr;
using IronSoftware.Drawing;
using System;

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Define the area of the image to scan
Rectangle scanRegion = new Rectangle(800, 200, 900, 400);

// Add image with defined content area
using var imageInput = new OcrImageInput("Potter.tiff", ContentArea: scanRegion);
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Display result
Console.WriteLine(ocrResult.Text);
```

### OCR Result

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-images/read-specific-region.webp" alt="Read specific region" class="img-responsive add-shadow">
    </div>
</div>