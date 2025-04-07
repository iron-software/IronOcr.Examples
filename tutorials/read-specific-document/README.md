# How to Read Specific Documents

***Based on <https://ironsoftware.com/tutorials/read-specific-document/>***


Successfully extracting text from various document types like text files, license plates, passports, and photographs can be challenging. This difficulty arises from each document type's unique formats, layouts, and content. Factors such as varying image quality, distortion, and specific types of content add to the complexity. Furthermore, maintaining both contextual understanding and a balance between performance and accuracy across different document types adds layers of complication.

IronOCR presents bespoke methods tailored for OCR on specific documents such as text files, license plates, passports, and images to ensure both high accuracy and enhanced performance.

### Begin with IronOCR

---

## Overview of the Package

For specialized tasks like reading license plates, passports, photographs, and screenshots, IronOCR offers specific functions: `ReadLicensePlate`, `ReadPassport`, `ReadPhoto`, and `ReadScreenShot`. These functions are part of the extended capabilities provided by the [IronOcr.Extensions.AdvancedScan](https://www.nuget.org/packages/IronOcr.Extensions.AdvancedScan) package, which is currently supported only on Windows.

These methods benefit from configurable OCR engine settings including character blacklists and whitelists. They support multiple languages like Chinese, Japanese, Korean, and those using the Latin alphabet—with the exception of the `ReadPassport` function. It's important to note that each language setting requires an additional [IronOcr.Languages](https://www.nuget.org/packages?q=ironocr.languages&includeComputedFrameworks=true&prerel=true&sortby=relevance) package.

To use advanced scanning on the .NET Framework, ensure your project is set to run on x64 architecture. Adjust your project configuration by unchecking the "Prefer 32-bit" option. More details can be found in the guide: "[Advanced Scan on .NET Framework](https://ironsoftware.com/csharp/ocr/troubleshooting/advanced-scan-on-net-framework/)."

## Document Reading Example

`ReadDocument` is a comprehensive method for processing scanned documents or images with dense text. Configuring **PageSegmentationMode** is critical for accurately reading texts across various layouts. For instance, **SingleBlock** is ideal for text blocks, while **SparseText** is suited for documents where text is dispersed.

```cs
using IronOcr;
using System;

// Initialize OCR engine
var ocr = new IronTesseract();

// Set OCR configuration for better text block recognition
ocr.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.SingleBlock;

using var input = new OcrInput();

// Load document
input.LoadPdf("Five.pdf");

// Execute OCR
OcrResult result = ocr.ReadDocument(input);

// Display extracted text
Console.WriteLine(result.Text);
```

### Example: Reading License Plates

`ReadLicensePlate` is designed to efficiently extract information from images of vehicle license plates. It provides details about both the license plate's text and its location within the image.

```cs
using IronOcr;
using IronSoftware.Drawing;
using System;

// Set up the OCR engine
var ocr = new IronTesseract();

using var inputLicensePlate = new OcrInput();

// Load image
inputLicensePlate.LoadImage("LicensePlate.jpeg");

// Execute OCR to find license plate
OcrLicensePlateResult result = ocr.ReadLicensePlate(inputLicensePlate);

// Get license plate data
Rectangle rectangle = result.Licenseplate;
string output = result.Text;
```

### Example: Reading Passports

`ReadPassport` excels in extracting vital information from passport images, focusing on the machine-readable zone (MRZ) which includes the bearer's key details.

```cs
using IronOcr;
using System;

// Initialize OCR engine
var ocr = new IronTesseract();

using var inputPassport = new OcrInput();

// Load passport image
inputPassport.LoadImage("Passport.jpg");

// Extract passport information
OcrPassportResult result = ocr.ReadPassport(inputPassport);

// Print passport details
Console.WriteLine(result.PassportInfo.GivenNames);
Console.WriteLine(result.PassportInfo.Country);
Console.WriteLine(result.PassportInfo.PassportNumber);
Console.WriteLine(result.PassportInfo.Surname);
Console.WriteLine(result.PassportInfo.DateOfBirth);
Console.WriteLine(result.PassportInfo.DateOfExpiry);
```

#### Result

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-specific-document/read-passport.webp" alt="Read Passport" class="img-responsive add-shadow">
    </div>
</div>

Ensure that only the passport image is in the document to prevent misreads with any additional text like headers or footers.

### Example: Reading Photographs

The `ReadPhoto` method is optimized for deciphering text from challenging images. It returns details about the text's location and content within the image.

```cs
using IronOcr;
using IronSoftware.Drawing;

// Create an OCR engine instance
var ocr = new IronTesseract();

using var inputPhoto = new OcrInput();
inputPhoto.LoadImageFrame("photo.tif", 2);

// Perform OCR
OcrPhotoResult result = ocr.ReadPhoto(inputPhoto);

// Gather text and region details
int number = result.TextRegions[0].FrameNumber;
string textInRegion = result.TextRegions[0].TextInRegion;
Rectangle region = result.TextRegions[0].Region;
```

### Example: Reading Screenshots

Similar to `ReadPhoto`, `ReadScreenShot` is tailored for extracting text from screenshots. This method also provides the text's specific locations within the image.

```cs
using IronOcr;
using System;
using System.Linq;

// Initialize OCR engine
var ocr = new IronTesseract();

using var inputScreenshot = new OcrInput();
inputScreenshot.LoadImage("screenshot.png");

// Conduct OCR
OcrPhotoResult result = ocr.ReadScreenShot(inputScreenshot);

// Output screenshot text and details
Console.WriteLine(result.Text);
Console.WriteLine(result.TextRegions.First().Region.X);
Console.WriteLine(result.TextRegions.Last().Region.Width);
Console.WriteLine(result.Confidence);
```