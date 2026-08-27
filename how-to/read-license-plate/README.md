# How to Perform License Plate Recognition with IronOCR

> Full guide: [How to Perform License Plate Recognition with IronOCR](https://ironsoftware.com/how-to/read-license-plate/)


Automating the extraction of license plate numbers from vehicle images is a critical efficiency boost, especially when dealing with high volumes. IronOCR offers a powerful solution with its `ReadLicensePlate` method, which extracts license plate numbers programmatically. This not only saves time but also enhances data precision.

This tutorial explores how to utilize IronOCR for accurate license plate recognition. Through step-by-step examples and configurable options, you'll learn how to streamline automated license plate detection for uses like parking systems, toll operations, and security monitoring.

Before beginning, ensure you have the [`IronOcr.Extension.AdvancedScan`](https://www.nuget.org/packages/IronOcr.Extensions.AdvancedScan) package installed.

### Quickstart: Instant License Plate Number Extraction

IronOCR’s `ReadLicensePlate` method allows for instant extraction of license plate text from images. Simply load your image, invoke the method, and immediately receive the plate number along with its confidence level.

```cs
// Example: Extracting a License Plate with One Line of Code using IronOCR
OcrLicensePlateResult result = new IronTesseract().ReadLicensePlate(new OcrInput("plate.jpg"));
```

## Working with IronOCR to Read License Plates

Reading a license plate with IronOCR involves the following:

- Employ the `ReadLicensePlate` method, which requires an `OcrInput` object for the image. This method is specifically optimized for license plate recognition.
- Optionally, configure IronOCR to only recognize certain characters on the license plates to enhance processing speed.

Currently, this method supports various scripts including English, Chinese, Japanese, Korean, and the Latin alphabet. Note that using the advanced scan on .NET Framework mandates an x64 architecture setup.

### License Plate Recognition Example

#### License Plate Sample

![License plate sample](https://ironsoftware.com/static-assets/ocr/how-to/read-license-plate/license-plate.webp)

#### Implementation

```csharp
// Initializing IronOcr
using IronOcr;
using System;

var ocr = new IronTesseract();
ocr.Configuration.WhiteListCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";

using var inputLicensePlate = new OcrInput();
inputLicensePlate.LoadImage("plate.jpeg");

// Performing the license plate recognition
OcrLicensePlateResult result = ocr.ReadLicensePlate(inputLicensePlate);

// Output the recognized license plate number and confidence
string output = $"Detected License Plate: {result.Text}\nConfidence Level: {result.Confidence}";

Console.WriteLine(output);
```

#### Recognition Results

![License plate recognition results](https://ironsoftware.com/static-assets/ocr/how-to/read-license-plate/license-plate-result.webp)

The code illustrates how to input an image for OCR processing and utilize the `ReadLicensePlate` method to identify and extract license plate information. The result demonstrates the OCR's accuracy through the recognized license plate text and the accompanying confidence level.

### License Plate Detection on a Car

The license plate reading method is also effective when extracting information from images featuring cars with visible plates, and it can provide the license plate’s location within the image.

#### Car Image

![Car license plate](https://ironsoftware.com/static-assets/ocr/how-to/read-license-plate/car-license.webp)

```csharp
// Implementing License Plate OCR on a Car Image
using IronOcr;
using IronSoftware.Drawing;
using System;

var ocr = new IronTesseract();
using var inputLicensePlate = new OcrInput();
inputLicensePlate.LoadImage("car_license.jpg");

// Execute license plate reading
OcrLicensePlateResult result = ocr.ReadLicensePlate(inputLicensePlate);

// Retrieving license plate details and coordinates
RectangleF rectangle = result.Licenseplate;
string output = $"Detected Plate Number:\n{result.Text}\n\nPlate Coordinates:\n"
              + $"X: {rectangle.X}, Y: {rectangle.Y}, Width: {rectangle.Width}, Height: {rectangle.Height}";

Console.WriteLine(output);
```

#### Results with Coordinates

![Car license plate extraction results](https://ironsoftware.com/static-assets/ocr/how-to/read-license-plate/car-license-with-coordinates.webp)

This demonstration shows effective use of the `ReadLicensePlate` method for locating and identifying license plates on car images. It successfully extracts both text and coordinates, showcasing its efficacy in applications that require precise spatial data.