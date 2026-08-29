# Guide to Using IronOCR Filters

> Full guide: [Guide to Using IronOCR Filters](https://ironsoftware.com/csharp/ocr/tutorials/c-sharp-ocr-image-filters/)


IronOCR equips developers with an array of image preprocessing tools to tweak and prepare images for Optical Character Recognition (OCR). These tools include a variety of filters specifically designed to refine images for better OCR results.

## Getting Started: Applying Filters to Enhance OCR Image Quality

With just a few lines of code, you can utilize filters like DeNoise, Binarize, and Deskew to immediately enhance the clarity of scanned documents before OCR processing. The following code snippet illustrates the simplicity of using IronOCR’s filters to optimize image quality:

```cs
using var input = new IronOcr.OcrInput("scan.jpg"); 
input.DeNoise(true).Binarize().Deskew(45); 
var result = new IronOcr.IronTesseract().Read(input);
```

## Comprehensive List of OCR Image Filters

Enhance your OCR performance with these effective image filters:

### Image Orientation Adjustment Filters
- `Rotate`: Rotate images by specific degrees clockwise. For counterclockwise rotation, input negative values.
- `Deskew`: Correct the alignment of images to ensure they are properly oriented, which is crucial as even a slight skew can compromise OCR accuracy.
- `Scale`: Proportionally adjusts the size of the input pages for OCR processing.

### Image Color Manipulation Filters
- `Binarize`: Converts images to pure black and white, enhancing contrast and readability in OCR.
- `ToGrayScale`: Converts images to grayscale, which can speed up processing without sacrificing accuracy.
- `Invert`: Reverses the colors in images—turning white to black, and vice versa.
- `ReplaceColor`: Substitutes a specified color within a set range with another, useful for correcting color anomalies in images.

### Contrast and Clarity Enhancement Filters
- `Contrast`: Automatically boosts the contrast in images, often enhancing both the speed and accuracy of OCR.
- `Dilate`: Expands the edges of characters in an image, which can make them more discernible to OCR software.
- `Erode`: Reduces the pixel count around character edges, potentially cleaning up noisy images.

### Noise Reduction Filters
- `Sharpen`: Increases the definition of images, particularly useful for blurred text documents.
- `DeNoise`: Targets and eliminates digital noise, beneficial in noisy image conditions.
- `DeepCleanBackgroundNoise`: Intensively clears out background noise; ideal for severely noisy documents but can decrease accuracy on cleaner images.
- `EnhanceResolution`: Heightens image resolution; useful for images below the optimal DPI threshold for OCR.

## Demonstrating Filter Application in Code

Below is an example demonstrating how to integrate these filters into your development work:

```csharp
using IronOcr;
using System;

var ocr = new IronTesseract();
using var input = new OcrInput("my_image.png");
input.Deskew();
var result = ocr.Read(input);
Console.WriteLine(result.Text);
```

### Debugging Image Filters

When encountering issues with image readability or barcode detection, you can visualize the outcome of applied filters:

```csharp
using IronOcr;
using System;

var file = "skewed_image.tiff";
var ocr = new IronTesseract();
using var input = new OcrInput();
int[] pageIndices = { 1, 2 };
input.LoadImageFrames(file, pageIndices);
input.Deskew();
input.SaveAsImages("my_deskewed_images");
var result = ocr.Read(input);
Console.WriteLine(result.Text);
```

## Practical Uses for Image Filters

### Rotate Filter Example

[API Reference](https://ironsoftware.com/csharp/ocr/object-reference/api/IronOcr.OcrInput.html#IronOcr_OcrInput_Rotate_System_Double_)

Rotating images properly ensures they are in the best position for OCR recognition. Here’s how you can correct a completely inverted image:

```csharp
using IronOcr;
using System;

var image = "screenshot.png";
var ocr = new IronTesseract();
using var input = new OcrInput();
input.LoadImage(image);
input.Rotate(180);
var result = ocr.Read(input);
Console.WriteLine(result.Text);
```

|`Before` | `After`|
|--|--|
| ![Before Rotate](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronOCR-Tutorial/screenshot.png) | ![After Rotate](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronOCR-Tutorial/screenshot_rotated.png) |

### Binarize Filter Example

[API Reference](https://ironsoftware.com/csharp/ocr/object-reference/api/IronOcr.OcrInput.html#IronOcr_OcrInput_Binarize)

Enhance text clarity by eliminating background colors and aligning text colors:

```csharp
using IronOcr;
using System;

var image = @"no-binarize.jpg";
var ocr = new IronTesseract();
using var input = new OcrInput();
input.LoadImage(image);
input.Binarize();
var result = ocr.Read(input);
Console.WriteLine(result.Text);
```

|`Before` | `After`|
|--|--|
| ![Before Binarize](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronOCR-Tutorial/no-binarize.jpg) | ![After Binarize](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronOCR-Tutorial/after-binarize.png) |

### Invert Filter Example

[API Reference](https://ironsoftware.com/csharp/ocr/object-reference/api/IronOcr.OcrInput.html#IronOcr_OcrInput_Invert_System_Boolean_)

Switch from white text on a black background to its inverse, maximizing OCR accuracy:

```csharp
using IronOcr;
using System;

var image = @"before-invert.png";
var ocr = new IronTesseract();
using var input = new OcrInput();
input.LoadImage(image);
input.Invert(true);
var result = ocr.Read(input);
Console.WriteLine(result.Text);
```

|`Before` | `After`|
|--|--|
| ![Before Invert](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronOCR-Tutorial/before-invert.png) | ![After Invert](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronOCR-Tutorial/after-invert.png) |

By integrating these filters, you can significantly enhance the quality and accuracy of OCR results, ensuring your applications run efficiently and your data capture is as accurate as possible.