# Utilizing Computer Vision to Identify Text with IronOCR

> Full guide: [Utilizing Computer Vision to Identify Text with IronOCR](https://ironsoftware.com/how-to/computer-vision/)


IronOCR integrates OpenCV to use Computer Vision, which is instrumental in locating text within images. This is particularly beneficial for images with substantial background noise, multiple text locations, or distorted text. IronOCR uses this technology to pinpoint text regions, which are then processed by Tesseract for text extraction.

## Quickstart: Detect and Extract Text from Key Areas

Getting started is straightforward: simply load your image and use IronOCR’s Computer Vision to automatically identify the primary text area with `FindTextRegion()`, followed by `Read(...)` to extract the text. Here’s how you do it in one easy step:

```cs
using var result = new IronTesseract().Read(new OcrInput().LoadImage("image.png").FindTextRegion());
```

- [Tutorial: OCR for License Plates in C#](https://ironsoftware.com/csharp/ocr/blog/using-ironocr/license-plate-ocr-csharp-tutorial/)
- [Extracting Text from Invoices in C# Tutorial](https://ironsoftware.com/csharp/ocr/blog/using-ironocr/invoice-ocr-csharp-tutorial/)
- [Retrieving Text from Screenshots in C#](https://ironsoftware.com/csharp/ocr/blog/using-ironocr/get-text-ocr-screenshot-csharp-tutorial/)
- [Subtitle OCR in C#: A Tutorial](https://ironsoftware.com/csharp/ocr/blog/using-ironocr/subtitle-ocr-csharp-tutorial/)


## Installation of IronOCR.ComputerVision via NuGet Package

The Computer Vision functionalities within IronOCR are part of the standard IronOCR NuGet package.

To access these features, you must install the `IronOcr.ComputerVision` package into your project. Here are the platform-specific packages:

- Windows: `IronOcr.ComputerVision.Windows`
- Linux: `IronOcr.ComputerVision.Linux`
- macOS: `IronOcr.ComputerVision.MacOS`
- macOS ARM: `IronOcr.ComputerVision.MacOS.ARM`

You can install these using the NuGet Package Manager or by entering the following command in the Package Manager Console:

```shell
:InstallCmd Install-Package IronOcr.ComputerVision.Windows
```

This command will install the necessary assemblies required for using the IronOCR Computer Vision capabilities.

## Overview of Functionalities and API

Here's a summary of the available methods:

<table class="table table__configuration-variables">
    <tr>
        <th scope="col">Method</th>
        <th scope="col">Description</th>
    </tr>
    <tr>
        <td><a href="#anchor-findtextregion">FindTextRegion</a></td>
        <td>Detects text regions within an image, allowing Tesseract to focus on these areas during text extraction.</td>
    </tr>
    <tr>
        <td><a href="#anchor-findmultipletextregions">FindMultipleTextRegions</a></td>
        <td>Identifies multiple text areas and segments the image accordingly for targeted OCR processing.</td>
    </tr>
    <tr>
        <td><a href="#anchor-gettextregions">GetTextRegions</a></td>
        <td>Returns a list of detected text regions as `List<CropRectangle>` from the scanned image.</td>
    </tr>
</table>

### Using FindTextRegion for Efficient Text Detection

`FindTextRegion` employs computer vision to identify text-containing regions across all pages of an `OcrInput` object.

```csharp
using IronOcr;

var ocr = new IronTesseract();
using var input = new OcrInput();
input.LoadImage("https://ironsoftware.com/static-assets/ocr/how-to/computer-vision/iron-2022.webp");

input.FindTextRegion();
OcrResult result = ocr.Read(input);
string resultText = result.Text;
// Example image: Iron Software logo with text
```

While this method is deprecated in `IronOcr 2025.6.x` and no longer accepts custom parameters, it is still widely used for its efficacy in simple scenarios.

### Advanced Text Detection with FindMultipleTextRegions

The `FindMultipleTextRegions` method processes an `OcrInput` object to detect text areas and segment the source into separate images for detailed OCR analysis:

```csharp
using IronOcr;

var ocr = new IronTesseract();
using var input = new OcrInput();
input.LoadImage("https://ironsoftware.com/static-assets/ocr/how-to/computer-vision/text_area_0.PNG");

input.FindMultipleTextRegions();
OcrResult result = ocr.Read(input);
string resultText = result.Text;
```

### Extracting Text Regions with GetTextRegions

`GetTextRegions` method scans an image and catalogs the crop areas where text has been detected, facilitating focused text extraction efforts:

```csharp
using IronOcr;
using IronSoftware.Drawing;
using System.Collections.Generic;
using System.Linq;

int pageIndex = 0;
using var input = new OcrInput();
input.LoadImage("https://ironsoftware.com/static-assets/ocr/how-to/computer-vision/iron-2022.webp");

var selectedPage = input.GetPages().ElementAt(pageIndex);
List<Rectangle> regions = selectedPage.GetTextRegions();
```

### Practical Guides for Specific Use Cases

IronOCR's capabilities extend far beyond simple text extraction, making it an invaluable tool for applications that require nuanced and accurate text recognition akin to human-level reading.