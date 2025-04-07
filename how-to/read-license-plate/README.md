# Utilizing IronOCR for Automated License Plate Recognition

***Based on <https://ironsoftware.com/how-to/read-license-plate/>***


Automated license plate recognition with IronOCR streamlines the tedious task of manually analyzing numerous vehicle images. This technology notably enhances efficiency and accuracy. IronOCR's `ReadLicensePlate` method allows for programmatically extracting numbers from license plates, thus optimizing time and improving data reliability.

This tutorial outlines how to employ IronOCR for the automation of reading license plates, including step-by-step examples and adjustable settings that simplify the process. By capitalizing on these techniques, developers facilitate various operations such as parking management, toll collection, and security monitoring through automated license plate recognition.

Before initiating, ensure the installation of the [IronOcr.Extension.AdvancedScan](https://www.nuget.org/packages/IronOcr.Extensions.AdvancedScan) package.

## Implementing License Plate Recognition with IronOCR

To perform license plate recognition using IronOCR, follow these outlined steps:
- Invoke the `ReadLicensePlate` method, designed specifically for license plate recognition and receiving an `OcrInput` parameter.
- Optionally, configure IronOCR to only recognize certain characters typical in license plates, enhancing processing speed.

- This method supports several languages, including English, Chinese, Japanese, Korean, and the Latin alphabet.
- Note: Utilizing this functionality on .NET Framework requires the application to be run on a 64-bit architecture.

### License Plate Example

![License plate](https://ironsoftware.com/static-assets/ocr/how-to/read-license-plate/license-plate.webp)

### Sample Code

```cs
using IronOcr;
using System;

// Initialize IronTesseract
var ocr = new IronTesseract();
// Specify characters expected in a license plate
ocr.Configuration.WhiteListCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";

// Prepare the image
using var inputLicensePlate = new OcrInput("plate.jpeg");

// Extract license plate data
var result = ocr.ReadLicensePlate(inputLicensePlate);

// Display the result and confidence level
string output = $"{result.Text}\nResult Confidence: {result.Confidence}";
Console.WriteLine(output);
```

### Result

![License plate result](https://ironsoftware.com/static-assets/ocr/how-to/read-license-plate/license-plate-result.webp)

The initial step is importing the image into an `OcrInput` to correctly utilize the `ReadLicensePlate` method. The output, as demonstrated, accurately reflects the text and state from the license plate shown in the input image.

**Text**: Extracted text from the OCR input.

**Confidence**: A double representing the statistical confidence accuracy per character, with a range between 0 (lowest) and 1 (highest).

<hr>

## Recognizing a License Plate Directly from a Vehicle Image

This functionality is also effective when applied to individual images featuring cars with visible license plates. The following code is identical to the previous example, differing only by the image input. This method also allows for the extraction of the exact coordinates of the license plate on the image.

### Example Input

![Car license plate](https://ironsoftware.com/static-assets/ocr/how-to/read-license-plate/car-license.webp)

```cs
using IronOcr;
using System;

// Initialize IronTesseract
var ocr = new IronTesseract();
using var inputLicensePlate = new OcrInput("car_license.jpg");

// Process the license plate image
var result = ocr.ReadLicensePlate(inputLicensePlate);

// Extract coordinates of the license plate
var rectangle = result.Licenseplate;

// Format output to show license plate number and its coordinates
string output = $"License Plate Number:\n{result.Text}\n\n"
              + $"License Plate Area:\n"
              + $"Starting X: {rectangle.X}\n"
              + $"Starting Y: {rectangle.Y}\n"
              + $"Width: {rectangle.Width}\n"
              + $"Height: {rectangle.Height}";

Console.WriteLine(output);
```

### Result

![Car license plate result](https://ironsoftware.com/static-assets/ocr/how-to/read-license-plate/car-license-with-coordinates.webp)

As illustrated, the output displays the license plate along with exact coordinates of the license plate within the image. This method is tuned specifically to identify individual license plates, ensuring precision in various scenarios like stock images.