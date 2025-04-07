# How to Extract Text from Screenshots with IronOCR

***Based on <https://ironsoftware.com/how-to/read-screenshot/>***


Extracting text from screenshots often presents challenges due to varying image dimensions and background noise. This typically hinders the efficiency of OCR technologies in decoding these images competently. Nonetheless, IronOCR addresses these difficulties by offering tailored methods like `ReadScreenShot`, which is specifically designed to handle screenshots and extract textual content with enhanced accuracy.

In this tutorial, we'll explore the process of using IronOCR to recognize text from screenshots, detailing the steps involved and the characteristics of the result object derived from the process.

Firstly, ensure that you have installed the [IronOcr.Extension.AdvancedScan](https://www.nuget.org/packages/IronOcr.Extensions.AdvancedScan) package.

## How to Utilize IronOCR to Read Screenshots

The `ReadScreenShot` method embraces an `OcrInput` object for input and fine-tunes the OCR process for screenshots – an upgrade from the general `Read` method. Here’s how to implement it:

- The method supports multiple languages including English, Chinese, Japanese, Korean, and the Latin alphabet.
- The advanced scanning feature requires that the .NET Framework project is set to the x64 architecture for optimal performance.

### Example Input

The following image showcases various text fonts and sizes, serving as our input for this demonstration.

![Input Image](https://ironsoftware.com/static-assets/ocr/how-to/read-screenshot/input.webp)

### Implementation Code

```cs
using IronOcr;
using System;
using System.Linq;

// Create OCR engine instance
var ocr = new IronTesseract();

using var inputScreenshot = new OcrInput("screenshotOCR.png"); // Load the screenshot image

// Execute OCR on the screenshot
OcrPhotoResult result = ocr.ReadScreenShot(inputScreenshot);

// Display extracted information from the screenshot
Console.WriteLine(result.Text);
Console.WriteLine(result.TextRegions.First().Region.X); // X coordinate of the first text region
Console.WriteLine(result.TextRegions.Last().Region.Width); // Width of the last text region
Console.WriteLine(result.Confidence); // Confidence level of text recognition
```

### Example Output

As delineated below, the console output effectively extracts and displays text from the provided screenshot.

![Output Image](https://ironsoftware.com/static-assets/ocr/how-to/read-screenshot/output.webp)

Further examination of the `OcrPhotoResult` properties:

**Text**: This property contains the text extracted from the OCR input.

**Confidence**: This `double` type property indicates the OCR accuracy on a scale where 1 is most accurate and 0 least accurate.

**TextRegion**: This array consists of `TextRegion` objects, each representing a detectable text area in the image. These regions are based on the `Rectangle` class from IronOCR, specifying the coordinates, height, and width of each textual block.