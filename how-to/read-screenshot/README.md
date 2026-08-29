# Utilizing IronOCR to Extract Text from Screenshots

> Full guide: [Utilizing IronOCR to Extract Text from Screenshots](https://ironsoftware.com/csharp/ocr/how-to/read-screenshot/)


Screenshots represent a convenient method for quickly sharing and capturing essential information, which you can distribute among colleagues and peers. However, extracting text from screenshots can be challenging due to the inherent noise and dimensions of these images. This often reduces the effectiveness of OCR technology when applied to screenshots.

Nonetheless, IronOCR has addressed these limitations by introducing the `ReadScreenshot` method. This method is specifically tailored for screenshot OCR tasks and supports various common file formats.

To employ this functionality, ensure to install the [IronOcr.Extension.AdvancedScan](https://www.nuget.org/packages/IronOcr.Extensions.AdvancedScan) package.

## Quick Guide: Extract Text from a Screenshot Using IronOCR

Jump right into using IronOCR's `ReadScreenshot`. Simply load your screenshot into an `OcrInput`, invoke `ReadScreenShot`, and you'll immediately gain access to the extracted text, confidence score, and detailed text regions.

```cs
// Creating an instance of IronTesseract
IronTesseract ocr = new IronTesseract();

// Load the screenshot image into the OcrInput
OcrInput screenshotInput = new OcrInput();
screenshotInput.LoadImage("screenshot.png");

// Extract text from the loaded screenshot
OcrPhotoResult extractedText = ocr.ReadScreenShot(screenshotInput);
```

This guide aims to provide a clear and concise overview of using IronOCR for screenshot text extraction, exploring various examples and exploring the properties of the result object itself.

## Reading Screenshots with IronOCR

Below, the steps involved in reading a screenshot using IronOCR are mapped out. The `ReadScreenshot` method has been optimized specifically for screenshots and requires an `OcrInput` object for the file input.

This method supports multiple languages such as English, Chinese, Japanese, Korean, and other Latin-based alphabets. Note that using the advanced scan feature on .NET Framework mandates running your project on x64 architecture.

### Sample Input

Here's our example input for demonstrating the adaptability of the `ReadScreenshot` method across different text fonts and sizes.

![Input](https://ironsoftware.com/static-assets/ocr/how-to/read-screenshot/input.webp)

### Example Code

```csharp
using IronOcr;
using System;
using System.Linq;

// Initialize the IronOCR engine
var ocr = new IronTesseract();

// Setup the OCR input with the image path
using var inputScreenshot = new OcrInput("screenshotOCR.png");

// Perform the OCR process
OcrPhotoResult result = ocr.ReadScreenShot(inputScreenshot);

// Print out details of the extracted text
Console.WriteLine("Extracted Text: " + result.Text);
Console.WriteLine("First Text Region X Coordinate: " + result.TextRegions.First().Region.X);
Console.WriteLine("Width of Last Text Region: " + result.TextRegions.Last().Region.Width);
Console.WriteLine("OCR Confidence Level: " + result.Confidence);
```

### Output Example

![Output](https://ironsoftware.com/static-assets/ocr/how-to/read-screenshot/output.webp)

The console output clearly displays the extracted text. Here's a closer look at the properties of `OcrPhotoResult`:

- **`Text`**: The actual text retrieved from the OCR operation.
- **`Confidence`**: A measurement of how accurate the OCR results are, represented as a double. A confidence level of 1 indicates the highest accuracy.
- **`TextRegion`**: This is an array containing `TextRegion` objects that define the text regions within the screenshot. Each `TextRegion` is essentially a `Rectangle` as per the IronOCR model, detailing the x and y coordinates, alongside the height and width of each textual area.